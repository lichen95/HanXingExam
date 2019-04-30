using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.IBLL
{
    using HanXingExam.Entity;
    using HanXingExam.Common;

    /// <summary>
    /// ** 描述：历史试卷业务逻辑接口
    /// ** 创始时间：2018年11月6日
    /// ** 修改时间：-
    /// ** 作者：zhq
    /// </summary>
    public interface IHistoricalPapers_BLL
    {
        /// <summary>
        /// ** 描述：历史试卷的查询方法
        /// ** 创始时间：2018年11月6日
        /// ** 修改时间：-
        /// ** 作者：zhq
        /// </summary>

        PageBox GetHistoricalPapers(int StudentId, DateTime? startDate, DateTime? endDate, int pageIndex = 1, int pageSize = 10);

        /// <summary>
        /// 添加历史试卷
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Add(HistoricalPapers t);

        /// <summary>
        /// 根据学生ID查询历史试卷是否有记录
        /// </summary>
        /// <param name="StudentId"></param>
        /// <param name="ExamQuestionId"></param>
        /// <returns></returns>
        HistoricalPapers IsShowTestInfos(int StudentId, string ExamQuestionId);
    }
}
