using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanXingExam.UI.Controllers
{
    using HanXingExam.BLL;
    using HanXingExam.Entity;
    using HanXingExam.IBLL;
    using Newtonsoft.Json;
    using System.Collections;
    using HanXingExam.Common;

    /// <summary>
    /// ** 描述：试卷控制器
    /// ** 创始时间：2018年11月6日14点31分
    /// ** 修改时间：-
    /// ** 作者：mqc
    /// </summary>
    public class ExamQuestionController : Controller
    {
        private IExamQuestion_BLL examquestion_BLL;
        private IAnalysisInfo_BLL analysisInfo_BLL;
        public ExamQuestionController(IExamQuestion_BLL _examquestion_BLL, IAnalysisInfo_BLL _analysisInfo_BLL)
        {
            examquestion_BLL = _examquestion_BLL;
            analysisInfo_BLL = _analysisInfo_BLL;
        }

        /// <summary>
        /// 生成试卷的方法
        /// </summary>
        /// <param name="ExamName">试卷名称</param>
        /// <param name="Num">生成试卷的数量</param>
        /// <param name="ExamStartDate">考试开始时间</param>
        /// <param name="ExamEndDate">考试结束时间</param>
        /// <param name="CollegeId">学院Id</param>
        /// <param name="MajorId">专业Id</param>
        /// <param name="StageId">阶段Id</param>
        /// <returns>bool 是否生成成功true成功，false失败</returns>
        [HttpPost]
        public bool Add(string ExamName, string Num, DateTime ExamStartDate, DateTime ExamEndDate, int CollegeId, int MajorId, int StageId)
        {
            try
            {
                var list = examquestion_BLL.QueryByIds(CollegeId, MajorId, StageId);
                Random random = new Random();
                ArrayList ids = new ArrayList();
                var singleNums = 0;
                var moreNums = 0;
                var judgeNums = 0;
                switch (Num)
                {
                    case "20":
                        singleNums = 10; moreNums = 5; judgeNums = 5;
                        break;
                    case "40":
                        singleNums = 20; moreNums = 10; judgeNums = 10;
                        break;
                    case "60":
                        singleNums = 20; moreNums = 20; judgeNums = 20;
                        break;
                    case "100":
                        singleNums = 40; moreNums = 30; judgeNums = 30;
                        break;
                }
                for (int i = 0; i < singleNums; i++)
                {
                    var index = random.Next(list.Single.Count - 1);
                    ids.Add(list.Single[index].QuestionId);
                    list.Single.RemoveAt(index);
                }
                for (int i = 0; i < moreNums; i++)
                {
                    var index = random.Next(list.More.Count - 1);
                    ids.Add(list.More[index].QuestionId);
                    list.More.RemoveAt(index);
                }
                for (int i = 0; i < judgeNums; i++)
                {
                    var index = random.Next(list.Judge.Count - 1);
                    ids.Add(list.Judge[index].QuestionId);
                    list.Judge.RemoveAt(index);
                }
                string str = "";
                for (int i = 0; i < ids.Count; i++)
                {
                    if (i == ids.Count - 1)
                    {
                        str = str + ids[i].ToString();
                    }
                    else
                    {
                        str = str + ids[i].ToString() + ",";
                    }
                }
                //添加试卷到试卷表
                ExamQuestions model = new ExamQuestions
                {
                    ExamName = ExamName,
                    ExamQuestionId = DateTime.Now.Ticks.ToString(),
                    QuestionIds = str,
                    ExamStartDate = ExamStartDate,
                    ExamEndDate = ExamEndDate,
                    CreateDate = DateTime.Now,
                    CollegeId = CollegeId,
                    MajorId = MajorId,
                    StageId = StageId,
                    State = 1
                };
                var result = examquestion_BLL.Add(model);
                //写入redis缓存
                var examQuestionsList = examquestion_BLL.GetExamQuestions();
                var redis = RedisHelper.Set<List<ExamQuestions>>("Exam", examQuestionsList);
                return result;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return false;
            }

        }

        /// <summary>
        /// 试卷查询方法
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="CollegeName"></param>
        /// <returns>string 查询到的试卷信息的json字符串</returns>
        [HttpPost]
        public string Query(DateTime? strartDate,DateTime? endDate,int collegeId = 0, int majorId = 0, int stageId = 0, int pageIndex = 1, int pageSize = 3)
        {
            var list = examquestion_BLL.GetExamQuestions(strartDate, endDate, collegeId, majorId, stageId, pageIndex, pageSize);
            return JsonConvert.SerializeObject(list);
        }

        /// <summary>
        /// 根据Id获取试卷详情
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        public string GetExamQuestions(string ids)
        {
            var examQuestionsList = examquestion_BLL.GetExamQuestionsByExamQuestionId(ids);
            return JsonConvert.SerializeObject(examQuestionsList);
        }

        /// <summary>
        /// 删除试卷
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool Delete(string ids)
        {
            var arr = ids.Split(',');
            var result = false;
            for (int i = 0; i < arr.Length; i++)
            {
                result = examquestion_BLL.Delete(arr[i]);
            }
            return result;
        }

        /// <summary>
        /// 班级成绩分析
        /// </summary>
        /// <param name="CollegeId"></param>
        /// <param name="MajorId"></param>
        /// <param name="StageId"></param>
        /// <param name="calassId"></param>
        /// <returns></returns>
        [HttpPost]
        public string ClassAnalysis(int CollegeId, int MajorId, int StageId, int calassId, int DateNum)
        {
            var list = analysisInfo_BLL.classAnalysis(CollegeId, MajorId, StageId, calassId, DateNum);
            return JsonConvert.SerializeObject(list);
        }

        /// <summary>
        /// 成绩统计
        /// </summary>
        /// <param name="CollegeId"></param>
        /// <param name="MajorId"></param>
        /// <param name="StageId"></param>
        /// <returns></returns>
        [HttpPost]
        public string GetAnalysis(DateTime? startDate, int CollegeId, int MajorId, int StageId)
        {
            if (string.IsNullOrWhiteSpace(startDate.ToString()))
                startDate = DateTime.Now.Date.AddDays(-1);

            var list = analysisInfo_BLL.GetAnalysis(startDate, CollegeId, MajorId, StageId);
            
            return JsonConvert.SerializeObject(list);
        }


        /// <summary>
        /// 考试结束 自动为旷考学生填充0分 并统计成绩
        /// </summary>
        public void GetScores_Analysis()
        {
            analysisInfo_BLL.GetScores_Analysis();
        }
    }
}