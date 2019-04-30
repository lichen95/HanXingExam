using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.IDAL
{
    using Entity;
    using Common;
    /// <summary>
    /// ** 描述：专业表接口
    /// ** 创始时间：2018-11-04
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public interface IMajors_DAL:IDALBase<Majors>
    {
        /// <summary>
        /// 专业表
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="majorName">专业名称</param>
        /// <param name="collegeId">学院Id</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页几条</param>
        /// <returns>返回分页类</returns>
        PageBox Query(DateTime? startDate, DateTime? endDate, string majorName, int collegeId, int pageIndex = 1, int pageSize = 3);
    }
}
