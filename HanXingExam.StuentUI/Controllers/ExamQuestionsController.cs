using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanXingExam.StuentUI.Controllers
{
    using HanXingExam.Entity;
    using HanXingExam.IBLL;
    using Newtonsoft.Json;
    using HanXingExam.Common;

    /// <summary>
    /// ** 描述：试卷控制器
    /// ** 创始时间：2018-11-06
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class ExamQuestionsController : Controller
    {
        private IExamQuestion_BLL examquestion_BLL;
        private IHistoricalPapers_BLL iHistoricalPapers_BLL;
        public ExamQuestionsController(IExamQuestion_BLL _examquestion_BLL, IHistoricalPapers_BLL _iHistoricalPapers_BLL)
        {
            examquestion_BLL = _examquestion_BLL;
            iHistoricalPapers_BLL = _iHistoricalPapers_BLL;
        }

        /// <summary>
        /// 查看待考信息
        /// </summary>
        /// <param name="CollegeId">学院Id</param>
        /// <param name="MajorId">专业Id</param>
        /// <param name="StageId">阶段Id</param>
        /// <param name="typeId">请求类型Id  0为查看待考信息 1为在线考试列表</param>
        /// <returns>string 所有待考信息的json字符串</returns>
        public string GetExamQuestion(int StudentId,int CollegeId, int MajorId, int StageId, int typeId = 0)
        {
            try
            {
                var list = RedisHelper.Get<List<ExamQuestions>>("Exam");
                if (list == null)
                {
                    var examQuestionsList = examquestion_BLL.GetExamQuestions();
                    list = examQuestionsList.Where(m => m.CollegeId.Equals(CollegeId) && m.MajorId.Equals(MajorId) && m.StageId.Equals(StageId)).ToList();
                    var redis = RedisHelper.Set<List<ExamQuestions>>("Exam", examQuestionsList);
                }
                list = list.Where(m => m.CollegeId.Equals(CollegeId) && m.MajorId.Equals(MajorId) && m.StageId.Equals(StageId)).ToList();
                List<ExamQuestions> resultList = new List<ExamQuestions>();
                for (int i = 0; i < list.Count; i++)
                {
                    //判断类型
                    if (typeId != 0)
                    {
                        if (list[i].ExamStartDate <= DateTime.Now && list[i].ExamEndDate > DateTime.Now)
                        {
                            var historyRedis = RedisHelper.Get<List<Score_His>>("Score_His" + StudentId);
                            if (historyRedis != null)
                                historyRedis = historyRedis.Where(m => m.StudentId.Equals(StudentId) && m.ExamQuestionId.Equals(list[i].ExamQuestionId)).ToList();
                            var history = iHistoricalPapers_BLL.IsShowTestInfos(StudentId, list[i].ExamQuestionId);
                            if (history == null && historyRedis == null || historyRedis.Count == 0)
                                resultList.Add(list[i]);
                        }
                    }
                    else
                    {
                        if (list[i].ExamStartDate > DateTime.Now)
                        {
                            resultList.Add(list[i]);
                        }
                    }
                }
                return JsonConvert.SerializeObject(resultList);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }
        }
    }
}