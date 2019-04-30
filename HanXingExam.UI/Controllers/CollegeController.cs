using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanXingExam.UI.Controllers
{
    using HanXingExam.Entity;
    using HanXingExam.IBLL;
    using Newtonsoft.Json;

    /// <summary>
    /// ** 描述：学院控制器
    /// ** 创始时间：2018年11月2日10点30分
    /// ** 修改时间：-
    /// ** 作者：mqc
    /// </summary>
    public class CollegeController : Controller
    {
        private ICollege_BLL college_BLL;
        public CollegeController(ICollege_BLL _college_BLL)
        {
            college_BLL = _college_BLL;
        }

        /// <summary>
        /// 学院信息添加方法
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 是否添加成功true成功，false失败</returns>
        [HttpPost]
        public bool Add(Colleges model)
        {
            return college_BLL.Add(model);
        }

        /// <summary>
        /// 学院信息查询方法
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>PageBox 所有信息的实体</returns>
        [HttpPost]
        public string Query(DateTime? startDate, DateTime? endDate, int pageIndex = 1, int pageSize = 2, string CollegeName = "")
        {
            return JsonConvert.SerializeObject(college_BLL.Query(startDate, endDate, pageIndex, pageSize, CollegeName));
        }

        /// <summary>
        /// 学院信息删除方法
        /// </summary>
        /// <param name="Ids">要删除的学院Id</param>
        /// <returns>bool 是否删除成功true成功，false失败</returns>
        [HttpPost]
        public bool Delete(string Ids)
        {
            return college_BLL.Delete(Ids);
        }

        /// <summary>
        /// 学院信息编辑反填方法
        /// </summary>
        /// <param name="Id">要编辑的学院Id</param>
        /// <returns>Colleges 要编辑的学院信息</returns>
        [HttpPost]
        public string QuertById(int Id)
        {
            return JsonConvert.SerializeObject(college_BLL.QueryById(Id));
        }

        /// <summary>
        /// 学院信息修改方法
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 是否修改成功true成功，false失败</returns>
        [HttpPost]
        public bool Update(Colleges m)
        {
            return college_BLL.Update(m);
        }
    }
}