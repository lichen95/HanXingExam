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
    /// ** 描述：专业表业务逻辑类
    /// ** 创始时间：2018-11-04
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class MajorsBLL:IMajors_BLL
    {
        private IMajors_DAL IMajors_DAL;
        public MajorsBLL(IMajors_DAL _IMajors_DAL)
        {
            IMajors_DAL = _IMajors_DAL;

        }
        /// <summary>
        /// 新增专业
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Add(Majors t)
        {
            var result = IMajors_DAL.Add(t);
            return result;
        }

        /// <summary>
        /// 删除专业
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public bool Delete(string Ids)
        {
            var result = IMajors_DAL.Delete(Ids);
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
        public PageBox Query(DateTime? startDate, DateTime? endDate, string majorName, int collegeId, int pageIndex = 1, int pageSize = 3)
        {
            var result = IMajors_DAL.Query(startDate, endDate, majorName, collegeId, pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// 根据Id查询专业信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Majors QueryById(int Id)
        {
            var result = IMajors_DAL.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 修改专业
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Update(Majors t)
        {
            var result = IMajors_DAL.Update(t);
            return result;
        }
    }
}
