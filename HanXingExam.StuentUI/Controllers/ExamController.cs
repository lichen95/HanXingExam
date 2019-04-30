using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanXingExam.StuentUI.Controllers
{
    using Entity;
    using HanXingExam.Common;
    using HanXingExam.StuentUI.Content;
    using Newtonsoft.Json;

    /// <summary>
    /// ** 描述：学生页面控制器
    /// ** 创始时间：2018年11月6日11点05分
    /// ** 修改时间：-
    /// ** 作者：mqc
    /// </summary>
    [Authorize]
  
    public class ExamController : Controller
    {
        /// <summary>
        /// ** 描述：读取缓存中学生数据
        /// ** 创始时间：2018-11-06
        /// ** 修改时间：-
        /// ** 作者：lc
        /// </summary>
        public Students GetStu()
        {
            //获取当前登录学生的信息
            string sid = HttpUtility.UrlDecode(CookiesHelper.GetCookie("SId"));
            Students stu = JsonConvert.DeserializeObject<Students>(sid);
            if (stu != null)
            {
                return stu;
            }
            return null;
        }

        /// <summary>
        /// ** 描述：学生登陆
        /// ** 创始时间：2018-11-06
        /// ** 修改时间：-
        /// ** 作者：whd
        /// </summary>
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// ** 描述：学生考试页面
        /// ** 创始时间：2018年11月6日11点05分
        /// ** 修改时间：-
        /// ** 作者：mqc
        /// </summary>
        [LoginActionFilter]
        public ActionResult Exam_Index()
        {
            ViewBag.Student = GetStu() ;
            return View();     
        }

        /// <summary>
        /// ** 描述：学生待考信息界面
        /// ** 创始时间：2018-11-06
        /// ** 修改时间：-
        /// ** 作者：whd
        /// </summary>
        [LoginActionFilter]
        public ActionResult WaitTest()
        {
            ViewBag.Student = GetStu();
            return View();
        }

        /// <summary>
        /// ** 描述：学生考试主界面
        /// ** 创始时间：2018-11-06
        /// ** 修改时间：-
        /// ** 作者：whd
        /// </summary>
        [LoginActionFilter]
        public ActionResult Index()
        {
            ViewBag.Student = GetStu();
            return View();
        }

        /// <summary>
        /// ** 描述：在线考试界面
        /// ** 创始时间：2018-11-06
        /// ** 修改时间：-
        /// ** 作者：whd
        /// </summary>
        [LoginActionFilter]
        public ActionResult Online()
        {
            ViewBag.Student = GetStu();
            ViewBag.Times = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return View();
        }

        /// <summary>
        /// ** 描述：历史试卷信息
        /// ** 创始时间：2018-11-06
        /// ** 修改时间：-
        /// ** 作者：zhq
        /// </summary>
        [LoginActionFilter]
        public ActionResult History()
        {
            ViewBag.Student = GetStu();
            return View();
        }

        /// <summary>
        /// ** 描述：查看历史试卷
        /// ** 创始时间：2018-11-06
        /// ** 修改时间：-
        /// ** 作者：zhq
        /// </summary>
        [LoginActionFilter]
        public ActionResult HisXiang()
        {
            ViewBag.Student = GetStu();
            return View();
        }
    }
}