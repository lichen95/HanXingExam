using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.BLL
{
    using Entity;
    using IDAL;
    using IBLL;
    using HanXingExam.Common;

    /// <summary>
    /// ** 描述：阶段表业务逻辑类
    /// ** 创始时间：2018-11-02
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class StagesBLL : IStages_BLL
    {
        private IStages_DAL iStages_DAL;
        public StagesBLL(IStages_DAL _iStages_DAL)
        {
            iStages_DAL = _iStages_DAL;
        }
        /// <summary>
        /// 新增阶段信息
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        public bool Add(Stages t)
        {
            var result = iStages_DAL.Add(t);
            return result;
        }

        /// <summary>
        /// 根据ID删除阶段信息
        /// </summary>
        /// <param name="Ids">ID</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        public bool Delete(string Ids)
        {
            var result = iStages_DAL.Delete(Ids);
            return result;
        }

        /// <summary>
        /// 查询阶段信息
        /// </summary>
        /// <returns>返回阶段信息</returns>
        public PageBox Query(DateTime? startDate, DateTime? endDate, string stageName, int collegeId, int mjorId, int pageIndex = 1, int pageSize = 3)
        {
            var result = iStages_DAL.Query(startDate, endDate, stageName, collegeId, mjorId, pageIndex, pageSize);
            return result;
        }
        /// <summary>
        /// 根据Id查询阶段信息
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>返回实体</returns>
        public Stages QueryById(int Id)
        {
            var result = iStages_DAL.QueryById(Id);
            return result;
        }
        /// <summary>
        /// 更新阶段信息
        /// </summary>
        /// <param name="obj">实体</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        public bool Update(Stages obj)
        {
            var result = iStages_DAL.Update(obj);
            return result;
        }
    }
}
