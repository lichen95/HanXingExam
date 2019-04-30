using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanXingExam.UI.Controllers
{
    using IBLL;
    using Entity;
    using Newtonsoft.Json;
    /// <summary>
    /// ** 描述：阶段表控制器类
    /// ** 创始时间：2018-11-02
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class StagesController : Controller
    {
        private IStages_BLL iStages_BLL;
        public StagesController(IStages_BLL _iStages_BLL)
        {
            iStages_BLL = _iStages_BLL;
        }

        /// <summary>
        /// 新增阶段信息
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        [HttpPost]
        public bool Add(Stages t)
        {
            t.CreateDate = DateTime.Now;
            var result = iStages_BLL.Add(t);
            return result;
        }

        /// <summary>
        /// 根据ID删除阶段信息
        /// </summary>
        /// <param name="Ids">ID</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        [HttpPost]
        public bool Delete(string Ids)
        {
            var result = iStages_BLL.Delete(Ids);
            return result;
        }

        /// <summary>
        /// 查询阶段信息
        /// </summary>
        /// <returns>返回阶段信息</returns>
        [HttpPost]
        public string Query(DateTime? startDate, DateTime? endDate, string stageName, int collegeId, int mjorId, int pageIndex = 1, int pageSize = 3)
        {
            var result = iStages_BLL.Query(startDate, endDate, stageName, collegeId, mjorId, pageIndex, pageSize);
            return JsonConvert.SerializeObject(result);
        }
        /// <summary>
        /// 根据Id查询阶段信息
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>返回实体</returns>
        [HttpPost]
        public string QueryById(int Id)
        {
            var result = iStages_BLL.QueryById(Id);
            return JsonConvert.SerializeObject(result);
        }
        /// <summary>
        /// 更新阶段信息
        /// </summary>
        /// <param name="obj">实体</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        [HttpPost]
        public bool Update(Stages obj)
        {
            var result = iStages_BLL.Update(obj);
            return result;
        }
    }
}