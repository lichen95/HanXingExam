using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanXingExam.StuentUI.Controllers
{
    using HanXingExam.Common;
    using HanXingExam.IBLL;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Web.Security;
    
    /// <summary>
    /// ** 描述：前台学生控制器
    /// ** 创始时间：2018年11月6日
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class StudentsController : Controller
    {
        private IStudent_BLL student_BLL;
        private IAnalysisInfo_BLL AnalysisInfo_BLL;

        public StudentsController(IStudent_BLL _student_BLL, IAnalysisInfo_BLL _AnalysisInfo_BLL)
        {
            student_BLL = _student_BLL;
            AnalysisInfo_BLL = _AnalysisInfo_BLL;
        }

        /// <summary>
        /// ** 描述：学生登陆
        /// ** 创始时间：2018年11月6日
        /// ** 修改时间：-
        /// ** 作者：whd
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns>ActionResult 试图</returns>
        [HttpPost]
        public ActionResult StudentLogin(string name, string pwd)
        {
            try
            {
                var Pwd = Md5Helper.MD5Encoding(pwd, 123);
                var result = student_BLL.StudentLogin(name, Pwd);
                if (result != null)
                {
                    FormsAuthentication.SetAuthCookie(name, true);

                    GetOnline(name);

                    CookiesHelper.SetCookie("SId", HttpUtility.UrlEncode(JsonConvert.SerializeObject(result)), DateTime.Now.AddDays(7));
                    return Redirect("~/Exam/Index");
                }
                return Redirect("/Exam/Login");
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns>ActionResult 试图</returns>
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Exam");
        }

        /// <summary>
        /// 该方法实现记录用户ID以及SessionID
        /// </summary>
        /// <param name="Name">学号</param>
        private void GetOnline(string Name)
        {
            Hashtable SingleOnline = (Hashtable)System.Web.HttpContext.Current.Application["Online"];
            if (SingleOnline == null)
                SingleOnline = new Hashtable();

            Session["mySession"] = "Test";
            //SessionID
            if (SingleOnline.ContainsKey(Name))
            {
                SingleOnline[Name] = Session.SessionID;
            }
            else
                SingleOnline.Add(Name, Session.SessionID);

            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["Online"] = SingleOnline;
            System.Web.HttpContext.Current.Application.UnLock();
        }
    }
}