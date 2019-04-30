using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.BLL
{
    using HanXingExam.Common;
    using HanXingExam.IBLL;
    using HanXingExam.Entity;
    using HanXingExam.IDAL;

    /// <summary>
    /// ** 描述：历史试卷业务逻辑类
    /// ** 创始时间：2018-11-06
    /// ** 修改时间：-
    /// ** 作者：zhq
    /// </summary>
    public class HistoricalPapersBLL:IHistoricalPapers_BLL
    {
        private IHistoricalPapers_DAL IHistoricalPapers_dal;

        public HistoricalPapersBLL(IHistoricalPapers_DAL _IHistoricalPapers_dal)
        {
            IHistoricalPapers_dal = _IHistoricalPapers_dal;
        }
        /// <summary>
        /// 添加历史试卷
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns></returns>
        public bool Add(HistoricalPapers t)
        {
            var result = IHistoricalPapers_dal.Add(t);
            return result;
        }


        /// <summary>
        ///  历史试卷查询
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="ScoreId">成绩id</param>
        /// <param name="StudentId">学生id</param>
        /// <param name="pageIndex">显示第几页</param>
        /// <param name="pageSize">每页几条</param>
        /// <returns></returns>
        public PageBox GetHistoricalPapers(int StudentId, DateTime? startDate, DateTime? endDate, int pageIndex = 1, int pageSize = 10)
        {
            var result = IHistoricalPapers_dal.GetHistoricalPapers(StudentId,startDate, endDate, pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// 根据学生ID查询历史试卷是否有记录
        /// </summary>
        /// <param name="StudentId"></param>
        /// <returns></returns>
        public HistoricalPapers IsShowTestInfos(int StudentId, string ExamQuestionId)
        {
            var result = IHistoricalPapers_dal.IsShowTestInfos(StudentId, ExamQuestionId);
            return result;
        }

    }
}
