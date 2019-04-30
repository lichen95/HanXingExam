using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.BLL
{
    using Entity;
    using HanXingExam.Common;
    using IBLL;
    using IDAL;
    /// <summary>
    /// ** 描述：班级业务逻辑类
    /// ** 创始时间：2018-11-04
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class ClassesBLL:IClasses_BLL
    {
        private IClasses_DAL iClasses_DAL;
        public ClassesBLL(IClasses_DAL _iClasses_DAL)
        {
            iClasses_DAL = _iClasses_DAL;
        }

        /// <summary>
        /// 新增班级
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>返回bool 成功返回true 失败返回flase</returns>
        public bool Add(Classes t)
        {
            var result = iClasses_DAL.Add(t);
            return result;
        }

        /// <summary>
        /// 删除班级
        /// </summary>
        /// <param name="Ids">班级Id</param>
        /// <returns>返回bool 成功返回true 失败返回flase</returns>
        public bool Delete(string Ids)
        {
            var result = iClasses_DAL.Delete(Ids);
            return result;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="className">班级名称</param>
        /// <param name="collegeId">学院</param>
        /// <param name="mjorId">专业</param>
        /// <param name="stageId">阶段</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页几条</param>
        /// <returns>返回班级信息</returns>
        public PageBox Query(DateTime? startDate, DateTime? endDate, string className, int collegeId, int mjorId, int stageId, int pageIndex = 1, int pageSize = 3)
        {
            var result = iClasses_DAL.Query(startDate, endDate, className, collegeId, mjorId, stageId, pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// 根据ID获取信息
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>返回实体</returns>
        public Classes QueryById(int Id)
        {
            var result = iClasses_DAL.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        public bool Update(Classes t)
        {
            var result = iClasses_DAL.Update(t);
            return result;
        }
    }
}
