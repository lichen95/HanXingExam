using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanXingExam.UI.Controllers
{
    using IBLL;
    using Entity;
    using HanXingExam.Common;
    using Newtonsoft.Json;
    using System.Web.Security;

    /// <summary>
    /// ** 描述：用户控制器
    /// ** 创始时间：2018-11-02
    /// ** 修改时间：2018-11-04
    /// ** 作者：whd
    /// </summary>
    public class UsersController : Controller
    {
        private IUser_BLL user_BLL;

        public UsersController(IUser_BLL _user_BLL)
        {
            user_BLL = _user_BLL;
        }

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool成功返回true  失败返回false</returns>
        [HttpPost]
        public bool Add(string UserName, string UserPwd, string RoleIds, string RoleNames, int collegeId, int majorId, int stageId)
        {
            //Md5加盐加密
            var password = Md5Helper.MD5Encoding(UserPwd, 123);
            Users u = new Users();
            u.UserName = UserName;
            u.UserPwd = password;
            u.RoleIds = RoleIds;
            u.RoleNames = RoleNames;
            u.CollegeId = collegeId;
            u.MajorId = majorId;
            u.StageId = stageId;
            u.IsUse = 1;
            u.CreateDate = DateTime.Now;
            var result = user_BLL.Add(u);
            return result;
        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="Ids">用户ID</param>
        /// <returns>bool成功返回true  失败返回false</returns>
        [HttpPost]
        public bool Delete(string Ids)
        {
            var result = false;
            var arr = Ids.Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                result = user_BLL.Delete(arr[i]);
            }
            return result;
        }

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="userName">用户名</param>
        /// <param name="collegeId">学院ID</param>
        /// <param name="mjorId">专业ID</param>
        /// <param name="stageId">阶段ID</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页几条</param>
        /// <returns>int 受影响行数</returns>
        [HttpPost]
        public string Query(DateTime? startDate, DateTime? endDate, string userName, int collegeId = 0, int mjorId = 0, int stageId = 0, int pageIndex = 1, int pageSize = 3)
        {
            var result = user_BLL.Query(startDate, endDate, userName, collegeId, mjorId, stageId, pageIndex, pageSize);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 根据ID获取用户信息
        /// </summary>
        /// <param name="Id">用户Id</param>
        /// <returns></returns>
        [HttpPost]
        public string QueryById(int Id)
        {
            var result = user_BLL.QueryById(Id);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool成功返回true  失败返回false</returns>
        [HttpPost]
        public bool Update(int UserId, string UserName, string UserPwd, string RoleIds, string RoleNames, int CollegeId, int MajorId, int StageId, DateTime CreateDate)
        {
            var users = user_BLL.QueryById(UserId);
            //Md5加盐加密
            var password = Md5Helper.MD5Encoding(UserPwd, 123);
            Users u = new Users();
            u.UserId = UserId;
            u.UserName = UserName;
            u.UserPwd = password;
            u.RoleIds = RoleIds;
            u.RoleNames = RoleNames;
            u.CollegeId = CollegeId;
            u.MajorId = MajorId;
            u.StageId = StageId;
            u.IsUse = 1;
            u.CreateDate = CreateDate;
            var result = user_BLL.Update(u);
            return result;
        }

        /// <summary>
        /// 获取学院
        /// </summary>
        /// <returns>返回学院信息</returns>
        [HttpPost]
        public string GetColleges()
        {
            var result = user_BLL.GetColleges();
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 根据学院ID获取专业
        /// </summary>
        /// <returns>返回专业信息</returns>
        [HttpPost]
        public string GetMajorsByCollegeId(int CollegeId)
        {
            var result = user_BLL.GetMajorsByCollegeId(CollegeId);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 获取阶段
        /// </summary>
        /// <returns>返回阶段信息</returns>
        [HttpPost]
        public string GetStages(int MajorId)
        {
            var result = user_BLL.GetStages(MajorId);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 返回用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public int GetUsers(string UserName)
        {
            var list = user_BLL.GetUsers();
            if (!string.IsNullOrWhiteSpace(UserName))
                list = list.Where(m => m.UserName.Equals(UserName)).ToList();
            return list.Count;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPwd"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(string UserName, string UserPwd)
        {
            var pwd = Md5Helper.MD5Encoding(UserPwd, 123);
            var result = user_BLL.GetUserID(UserName, pwd);
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(UserName, false);
                //写入缓存
                CookiesHelper.SetCookie("UID", HttpUtility.UrlEncode(JsonConvert.SerializeObject(result)), DateTime.Now.AddDays(7));
                return Redirect("~/Home/Index");
            }
            return Redirect("~/Home/Login");
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }


    }
}