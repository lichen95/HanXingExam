using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanXingExam.UI.Controllers
{
    using Newtonsoft.Json;
    using Entity;
    using IBLL;
    /// <summary>
    /// ** 描述：专业控制器
    /// ** 创始时间：2018-11-04
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class MajorsController : Controller
    {
        private IMajors_BLL IMajors_BLL;
        
        public MajorsController(IMajors_BLL _IMajors_BLL)
        {
            IMajors_BLL = _IMajors_BLL;
        }
        /// <summary>
        /// 新增专业
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Add(Majors t)
        {
            t.CreateDate = DateTime.Now;
            var result = IMajors_BLL.Add(t);
            return result;
        }

        /// <summary>
        /// 删除专业
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Delete(string Ids)
        {
            var result = IMajors_BLL.Delete(Ids);
            return result;
        }

        /// <summary>
        /// 查询专业表
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="majorName">专业名称</param>
        /// <param name="collegeId">学院Id</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页几条</param>
        /// <returns>返回分页类</returns>
        [HttpPost]
        public string Query(DateTime? startDate, DateTime? endDate, string majorName, int collegeId, int pageIndex = 1, int pageSize = 3)
        {
            var result = IMajors_BLL.Query(startDate, endDate, majorName, collegeId, pageIndex, pageSize);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 根据Id查询专业信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public string QueryById(int Id)
        {
            var result = IMajors_BLL.QueryById(Id);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 修改专业
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Update(Majors t)
        {
            var result = IMajors_BLL.Update(t);
            return result;
        }
    }
}