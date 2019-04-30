using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.IDAL
{
    using HanXingExam.Entity;
    using Common;

    /// <summary>
    /// ** 描述：历史试卷数据访问接口
    /// ** 创始时间：2018年11月6日
    /// ** 修改时间：-
    /// ** 作者：zhq
    /// </summary>
    public interface IHistoricalPapers_DAL:IDALBase<HistoricalPapers>
    {
        /// <summary>
        /// 获取历史试卷
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="pageIndex">首页</param>
        /// <param name="pageSize">每页显示页数</param>
        /// <returns>返回PageBox</returns>
        PageBox GetHistoricalPapers(int StudentId,DateTime? startDate, DateTime? endDate, int pageIndex = 1, int pageSize = 10);


        /// <summary>
        /// 根据学生ID查询历史试卷是否有记录
        /// </summary>
        /// <param name="StudentId"></param>
        /// <param name="ExamQuestionId"></param>
        /// <returns></returns>
        HistoricalPapers IsShowTestInfos(int StudentId, string ExamQuestionId);
    }
}
