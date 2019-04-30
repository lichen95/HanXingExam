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
    /// ** 描述：试卷数据访问接口
    /// ** 创始时间：2018年11月5日14点50分
    /// ** 修改时间：-
    /// ** 作者：mqc
    /// </summary>
    public interface IExamQuestion_DAL : IDALBase<ExamQuestions>
    {
         /// <summary>
        /// 根据学院Id 专业Id 阶段Id 将题库题目分类
        /// </summary>
        /// <param name="CollegeId">学院Id</param>
        /// <param name="MajorId">专业Id</param>
        /// <param name="StageId">阶段Id</param>
        /// <returns></returns>
        ExamBox QueryByIds(int CollegeId, int MajorId, int StageId);

        /// <summary>
        /// ** 描述：根据试卷唯一ID查询试卷信息
        /// ** 创始时间：2018年11月6日13点52分
        /// ** 修改时间：-
        /// ** 作者：mqc
        /// </summary>
        ExamQuestions QueryByEQId(string ExamQuestionId);
        /// <summary>
        /// ** 描述：查看待考信息
        /// ** 创始时间：2018年11月6日
        /// ** 修改时间：-
        /// ** 作者：whd
        /// </summary>
        PageBox GetExamQuestions(DateTime? strartDate, DateTime? endDate,int collegeId = 0, int majorId = 0, int stageId = 0, int pageIndex = 1, int pageSize = 3);

        /// <summary>
        /// 根据Id查询试卷
        /// </summary>
        /// <param name="collegeId"></param>
        /// <param name="majorId"></param>
        /// <param name="stageId"></param>
        /// <returns></returns>
        List<ExamQuestions> ExamQuestions(int collegeId = 0, int majorId = 0, int stageId = 0);

        /// <summary>
        /// 获取试卷信息
        /// </summary>
        /// <returns></returns>
        List<ExamQuestions> GetExamQuestions();
    }
}
