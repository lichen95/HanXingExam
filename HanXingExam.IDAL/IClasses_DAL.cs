using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.IDAL
{
    using Entity;
    using HanXingExam.Common;

    /// <summary>
    /// ** 描述：班级数据访问接口
    /// ** 创始时间：2018-11-04
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public interface IClasses_DAL:IDALBase<Classes>
    {
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
        PageBox Query(DateTime? startDate, DateTime? endDate, string className, int collegeId, int mjorId, int stageId, int pageIndex = 1, int pageSize = 3);
    }
}
