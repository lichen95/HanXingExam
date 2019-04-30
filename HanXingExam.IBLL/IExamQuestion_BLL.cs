using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.IBLL
{
    using HanXingExam.Common;
    using HanXingExam.Entity;

    /// <summary>
    /// ** 描述：试卷业务逻辑接口
    /// ** 创始时间：2018年11月5日15点32分
    /// ** 修改时间：-
    /// ** 作者：mqc
    /// </summary>
    public interface IExamQuestion_BLL
    {
        /// <summary>
        /// 试卷生成
        /// </summary>
        /// <param name="m">实体</param>
        /// <returns>bool true成功 false失败</returns>
        bool Add(ExamQuestions m);

        /// <summary>
        /// 试卷删除
        /// </summary>
        /// <param name="Id">学院Id</param>
        /// <returns>bool true成功 false失败</returns>
        bool Delete(string Ids);

        /// <summary>
        /// 根据学院Id 专业Id 阶段Id 将题库题目分类
        /// </summary>
        /// <param name="CollegeId">学院Id</param>
        /// <param name="MajorId">专业Id</param>
        /// <param name="StageId">阶段Id</param>
        /// <returns></returns>
        ExamBox QueryByIds(int CollegeId, int MajorId, int StageId);

        /// <summary>
        /// 根据试题Id 查找具体题目
        /// </summary>
        /// <param name="ExamQuestionId">试题Id</param>
        /// <returns></returns>
        List<Questions> QueryByEQId(string ExamQuestionId);
        /// <summary>
        /// 查看待考信息
        /// </summary>
        /// <param name="collegeId">学院Id</param>
        /// <param name="majorId">专业Id</param>
        /// <param name="stageId">阶段Id</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页几条</param>
        /// <returns></returns>
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
        /// <summary>
        /// 根据试卷ID查询
        /// </summary>
        /// <param name="ExamQuestionId"></param>
        /// <returns></returns>
        ExamQuestions GetExamQuestionsByExamQuestionId(string ExamQuestionId);
    }
}
