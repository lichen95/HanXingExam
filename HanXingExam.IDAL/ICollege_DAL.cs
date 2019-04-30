using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.IDAL
{
    using HanXingExam.Common;
    using HanXingExam.Entity;

    /// <summary>
    /// ** 描述：学院数据访问接口
    /// ** 创始时间：2018年11月2日10点30分
    /// ** 修改时间：-
    /// ** 作者：mqc
    /// </summary>
    public interface ICollege_DAL : IDALBase<Colleges>
    {
        /// <summary>
        /// ** 描述：学院的查询方法
        /// ** 创始时间：2018年11月2日10点30分
        /// ** 修改时间：-
        /// ** 作者：mqc
        /// </summary>
        PageBox Query(DateTime? startDate, DateTime? endDate, int pageIndex = 1, int pageSize = 2, string CollegeName = "");
    }
}
