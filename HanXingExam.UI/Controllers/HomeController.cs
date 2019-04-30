using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanXingExam.UI.Controllers
{
    using Newtonsoft.Json;
    using HanXingExam.Entity;
    using HanXingExam.IBLL;

    /// <summary>
    /// ** 描述：视图控制器
    /// ** 创始时间：2018年11月2日08点58分
    /// ** 修改时间：-
    /// ** 作者：mqc
    /// </summary>
    [Authorize]
    public class HomeController : Controller
    {
        private IStudent_BLL student_BLL;
        private IUser_BLL user_BLL;
        private IAnalysisInfo_BLL analysisInfo_BLL;

        public HomeController(IStudent_BLL _student_BLL, IUser_BLL _user_BLL, IAnalysisInfo_BLL _analysisInfo_BLL)
        {
            student_BLL = _student_BLL;
            user_BLL = _user_BLL;
            analysisInfo_BLL = _analysisInfo_BLL;
        }

        /// <summary>
        /// 获取信息 加入缓存
        /// </summary>
        public void GetMajors()
        {
            //写入专业缓存
            CookiesHelper.SetCookie("Majors", HttpUtility.UrlEncode(JsonConvert.SerializeObject(student_BLL.GetMajors())), DateTime.Now.AddDays(7));
            //写入班级缓存
            CookiesHelper.SetCookie("Classes", HttpUtility.UrlEncode(JsonConvert.SerializeObject(student_BLL.QueryBySid())), DateTime.Now.AddDays(7));
            //写入阶段缓存
            CookiesHelper.SetCookie("Stages", HttpUtility.UrlEncode(JsonConvert.SerializeObject(student_BLL.GetStages())), DateTime.Now.AddDays(7));
            //写入学院缓存
            CookiesHelper.SetCookie("Colleges", HttpUtility.UrlEncode(JsonConvert.SerializeObject(user_BLL.GetColleges())), DateTime.Now.AddDays(7));
            //记录数量
            var majorNum = 0;
                majorNum=student_BLL.GetMajors().Count;
            var classNum = 0;
                classNum = student_BLL.QueryBySid().Count;
            var stageNum = 0;
                stageNum = student_BLL.GetStages().Count;
            var collegesNum = 0;
                collegesNum = user_BLL.GetColleges().Count;
            ViewBag.majorNum = majorNum;
            ViewBag.classNum = classNum;
            ViewBag.stageNum = stageNum;
            ViewBag.collegesNum = collegesNum;
        }

        #region 首页
        /// <summary>
        /// ** 描述：首页
        /// ** 创始时间：2018年11月2日08点58分
        /// ** 修改时间：-
        /// ** 作者：mqc
        /// </summary>
        public ActionResult Index()
        {
            GetMajors();
            var result = HttpUtility.UrlDecode(CookiesHelper.GetCookie("UID"));
            Users user = JsonConvert.DeserializeObject<Users>(result);
            ViewBag.User = user;
            return View();
        }

        /// <summary>
        /// ** 描述：登录页面
        /// ** 创始时间：2018年11月2日08点58分
        /// ** 修改时间：-
        /// ** 作者：mqc
        /// </summary>
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// ** 描述：我的桌面页面
        /// ** 创始时间：2018年11月2日09点35分
        /// ** 修改时间：-
        /// ** 作者：mqc
        /// </summary>
        public ActionResult Welcome()
        {
            GetMajors();
            return View();
        }

        /// <summary>
        /// ** 描述：获取用户加载权限
        /// ** 创始时间：2018-11-05
        /// ** 修改时间：-
        /// ** 作者：whd
        /// </summary>
        public ActionResult GetPermissionsById()
        {
            return View();
        }

        /// <summary>
        /// ** 描述：动态加载权限菜单
        /// ** 创始时间：2018-11-05
        /// ** 修改时间：-
        /// ** 作者：whd
        /// </summary>
        public ActionResult GetPermissions()
        {
            return View();
        }

        #endregion

        #region 学院信息
        /// <summary>
        /// ** 描述：学院信息页面
        /// ** 创始时间：2018年11月2日09点35分
        /// ** 修改时间：-
        /// ** 作者：mqc
        /// </summary>
        public ActionResult College_List()
        {
            return View();
        }

        /// <summary>
        /// ** 描述：学院信息添加页面
        /// ** 创始时间：2018年11月2日11点11分
        /// ** 修改时间：-
        /// ** 作者：mqc
        /// </summary>
        public ActionResult College_Add()
        {
            return View();
        }

        /// <summary>
        /// ** 描述：学院信息编辑页面
        /// ** 创始时间：2018年11月3日11点23分
        /// ** 修改时间：-
        /// ** 作者：mqc
        /// </summary>
        public ActionResult College_Edit()
        {
            return View();
        }
        #endregion

        #region 角色
        /// <summary>
        /// ** 描述：角色添加页面
        /// ** 创始时间：2018-11-02
        /// ** 修改时间：-
        /// ** 作者：lc
        /// </summary>
        public ActionResult Roles_Add()
        {
            return View();
        }

        /// <summary>
        /// ** 描述：角色显示页面
        /// ** 创始时间：2018-11-02
        /// ** 修改时间：-
        /// ** 作者：lc
        /// </summary>
        public ActionResult Roles_Index()
        {
            return View();
        }

        /// <summary>
        /// ** 描述：角色更新页面
        /// ** 创始时间：2018-11-02
        /// ** 修改时间：-
        /// ** 作者：lc
        /// </summary>
        public ActionResult Roles_Update()
        {
            return View();
        }
        #endregion

        #region  用户
        /// <summary>
        /// ** 描述：用户添加页面
        /// ** 创始时间：2018-11-02
        /// ** 修改时间：-
        /// ** 作者：whd
        /// </summary>
        public ActionResult Users_Add()
        {
            return View();
        }

        /// <summary>
        /// ** 描述：用户显示页面
        /// ** 创始时间：2018-11-02
        /// ** 修改时间：-
        /// ** 作者：whd
        /// </summary>
        public ActionResult Users_Index()
        {
            return View();
        }

        /// <summary>
        /// ** 描述：用户更新页面
        /// ** 创始时间：2018-11-02
        /// ** 修改时间：-
        /// ** 作者：whd
        /// </summary>
        public ActionResult Users_Update()
        {
            return View();
        }
        #endregion

        #region 阶段
        /// <summary>
        /// ** 描述：阶段更新页面
        /// ** 创始时间：2018-11-02
        /// ** 修改时间：-
        /// ** 作者：lc
        /// </summary>
        public ActionResult Stages_Update()
        {
            return View();
        }

        /// <summary>
        /// ** 描述：阶段新增页面
        /// ** 创始时间：2018-11-02
        /// ** 修改时间：-
        /// ** 作者：lc
        /// </summary>
        public ActionResult Stages_Add()
        {
            return View();
        }

        /// <summary>
        /// ** 描述：阶段列表页面
        /// ** 创始时间：2018-11-02
        /// ** 修改时间：-
        /// ** 作者：lc
        /// </summary>
        public ActionResult Stages_Index()
        {
            return View();
        }
        #endregion

        #region 学生
        /// <summary>
        /// ** 描述：学生信息页面
        /// ** 创始时间：2018年11月4日09点49分
        /// ** 修改时间：-
        /// ** 作者：mqc
        /// </summary>
        public ActionResult Student_List()
        {
            var result = HttpUtility.UrlDecode(CookiesHelper.GetCookie("UID"));
            Users user = JsonConvert.DeserializeObject<Users>(result);
            ViewBag.User = user;
            GetMajors();
            return View();
        }

        /// <summary>
        /// ** 描述：学生信息添加页面
        /// ** 创始时间：2018年11月2日11点11分
        /// ** 修改时间：-
        /// ** 作者：mqc
        /// </summary>
        public ActionResult Student_Add()
        {
            var result = HttpUtility.UrlDecode(CookiesHelper.GetCookie("UID"));
            Users user = JsonConvert.DeserializeObject<Users>(result);
            ViewBag.User = user;
            return View();
        }

        /// <summary>
        /// ** 描述：学生信息编辑页面
        /// ** 创始时间：2018年11月3日11点23分
        /// ** 修改时间：-
        /// ** 作者：mqc
        /// </summary>
        public ActionResult Student_Edit()
        {
            return View();
        }
        #endregion

        #region 班级
        /// <summary>
        /// ** 描述：班级更新页面
        /// ** 创始时间：2018-11-04
        /// ** 修改时间：-
        /// ** 作者：lc
        /// </summary>
        public ActionResult Classes_Update()
        {
            return View();
        }

        /// <summary>
        /// ** 描述：班级新增页面
        /// ** 创始时间：2018-11-04
        /// ** 修改时间：-
        /// ** 作者：lc
        /// </summary>
        public ActionResult Classes_Add()
        {
            return View();
        }

        /// <summary>
        /// ** 描述：班级列表页面
        /// ** 创始时间：2018-11-04
        /// ** 修改时间：-
        /// ** 作者：lc
        /// </summary>
        public ActionResult Classes_Index()
        {
            return View();
        }
        #endregion

        #region 专业
        /// <summary>
        /// ** 描述：专业更新页面
        /// ** 创始时间：2018-11-04
        /// ** 修改时间：-
        /// ** 作者：lc
        /// </summary>
        public ActionResult Majors_Update()
        {
            return View();
        }

        /// <summary>
        /// ** 描述：专业新增页面
        /// ** 创始时间：2018-11-04
        /// ** 修改时间：-
        /// ** 作者：lc
        /// </summary>
        public ActionResult Majors_Add()
        {
            return View();
        }

        /// <summary>
        /// ** 描述：专业列表页面
        /// ** 创始时间：2018-11-04
        /// ** 修改时间：-
        /// ** 作者：lc
        /// </summary>
        public ActionResult Majors_Index()
        {
            return View();
        }
        #endregion

        #region 权限
        /// <summary>
        /// ** 描述：权限更新页面
        /// ** 创始时间：2018-11-04
        /// ** 修改时间：-
        /// ** 作者：lc
        /// </summary>
        public ActionResult Permissions_Update()
        {
            return View();
        }

        /// <summary>
        /// ** 描述：权限新增页面
        /// ** 创始时间：2018-11-04
        /// ** 修改时间：-
        /// ** 作者：lc
        /// </summary>
        public ActionResult Permissions_Add()
        {
            return View();
        }

        /// <summary>
        /// ** 描述：权限列表页面
        /// ** 创始时间：2018-11-04
        /// ** 修改时间：-
        /// ** 作者：lc
        /// </summary>
        public ActionResult Permissions_Index()
        {
            return View();
        }
        #endregion

        #region 试题
        /// <summary>
        /// ** 描述：试题显示页面
        /// ** 创始时间：2018年11月5日
        /// ** 修改时间：-
        /// ** 作者：lc
        /// </summary>
        public ActionResult Question_List()
        {
            GetMajors();
            return View();
        }

        /// <summary>
        /// ** 描述：试题添加页面
        /// ** 创始时间：2018年11月5日
        /// ** 修改时间：-
        /// ** 作者：lc
        /// </summary>
        public ActionResult Question_Add()
        {
            return View();
        }

        /// <summary>
        /// ** 描述：试题修改页面
        /// ** 创始时间：2018年11月5日
        /// ** 修改时间：-
        /// ** 作者：lc
        /// </summary>
        public ActionResult Question_Edit()
        {
            return View();
        }
        #endregion
        
        #region 试卷页面
        /// <summary>
        /// 试题生成
        /// </summary>
        /// <returns></returns>
        public ActionResult ExamQuestion_Add()
        {
            return View();
        }

        /// <summary>
        /// 试卷页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ExamQuestion_List()
        {
            return View();
        }

        /// <summary>
        /// 试卷详情
        /// </summary>
        /// <returns></returns>
        public ActionResult ExamQuestion_Item()
        {
            return View();
        }
        #endregion
    }
}