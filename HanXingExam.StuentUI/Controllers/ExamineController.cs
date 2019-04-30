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
    /// ** 描述：前台考试控制器
    /// ** 创始时间：2018年11月6日18点27分
    /// ** 修改时间：-
    /// ** 作者：mqc
    /// </summary>
    public class ExamineController : Controller
    {
        private IExamQuestion_BLL examquestion_BLL;
        private IScores_BLL iScores_BLL;
        private IHistoricalPapers_BLL iHistoricalPapers_BLL;

        public ExamineController(IExamQuestion_BLL _examquestion_BLL, IScores_BLL _iScores_BLL, IHistoricalPapers_BLL _iHistoricalPapers_BLL)
        {
            examquestion_BLL = _examquestion_BLL;
            iScores_BLL = _iScores_BLL;
            iHistoricalPapers_BLL = _iHistoricalPapers_BLL;
        }

        /// <summary>
        /// 开始考试获取试卷题目的方法
        /// </summary>
        /// <param name="ExamQuestionId">试卷Id</param>
        /// <param name="typeId">类型ID 0为在线考试 1为历史试卷</param>
        /// <returns>string 所有的试卷json字符串</returns>
        [HttpPost]
        public string QueryByEQId(string ExamQuestionId, int typeId = 0)
        {
            try
            {
                var list = examquestion_BLL.QueryByEQId(ExamQuestionId);
                List<Questions> result = list;
                if (typeId == 0)
                {
                    List<TestPage> test = new List<TestPage>();
                    for (int i = 0; i < result.Count(); i++)
                    {
                        TestPage m = new TestPage
                        {
                            QuestionNum = result[i].QuestionNum,
                            Answer = result[i].Answer
                        };
                        test.Add(m);
                        result[i].Answer = CookiesHelper.GetCookie(result[i].QuestionNum);
                    }
                    //写入Cookie
                    CookiesHelper.SetCookie(ExamQuestionId, JsonConvert.SerializeObject(test), DateTime.Now.AddDays(1));
                    result = RandomQuestions(list, list.Count());
                }
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }
            
        }

        /// <summary>
        /// 将随机的试卷下标添加到一个新的集合
        /// </summary>
        /// <param name="list">查询到的试卷集合</param>
        /// <param name="Count">试卷集合的数量</param>
        /// <returns>string 所有的试卷json字符串</returns>
        public List<Questions> RandomQuestions(List<Questions> list, int Count)
        {
            try
            {
                Random random = new Random();
                List<Questions> ids = new List<Questions>();
                for (int i = 0; i < Count; i++)
                {
                    var index = random.Next(list.Count - 1);
                    ids.Add(list[index]);
                    list.RemoveAt(index);
                }
                return ids;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }

        }


        /// <summary>
        /// 交卷并判分
        /// </summary>
        /// <param name="answer">答案的集合</param>
        /// <param name="ExamQuestionId">试卷Id</param>
        /// <param name="StudentId">学生Id</param>
        /// <param name="ename">试卷名称</param>
        /// <returns>int 受影响行数</returns>
        [HttpPost]
        public int AddTest(string answer, string ExamQuestionId, int StudentId, string ename, string StudentNum, DateTime ExamEndDate, string StudentName)
        {
            try
            {
                List<Score_His> socreList = new List<Score_His>();
                var redisList = RedisHelper.Get<List<Score_His>>("Score_His" + StudentId);
                if (redisList != null)
                    socreList = redisList;
                //分数
                var sore = 0;
                //单选题分数
                var oneNum = 0;
                //多选题分数
                var twoNum = 0;
                //判断题分数
                var threeNum = 0;
                //根据试题ID获取cookie中的答案
                var json = CookiesHelper.GetCookie(ExamQuestionId);
                //答案集合
                var answerList = JsonConvert.DeserializeObject<List<TestPage>>(json);
                //我的答案
                var myAnswer = JsonConvert.DeserializeObject<List<TestPage>>(answer);
                if (myAnswer.Count != 0)
                {
                    //20个题的分数
                    if (myAnswer.Count == 20)
                    {
                        oneNum = 5;
                        twoNum = 5;
                        threeNum = 5;
                    }
                    //40个题的分数
                    if (myAnswer.Count == 40)
                    {
                        oneNum = 3;
                        twoNum = 2;
                        threeNum = 2;
                    }
                    //60个题的分数
                    if (myAnswer.Count == 60)
                    {
                        oneNum = 2;
                        twoNum = 2;
                        threeNum = 1;
                    }
                    //100个题的分数
                    if (myAnswer.Count == 100)
                    {
                        oneNum = 1;
                        twoNum = 1;
                        threeNum = 1;
                    }
                    //我的答案
                    var myAnswerStr = "";
                    for (int i = 0; i < answerList.Count; i++)
                    {
                        for (int j = 0; j < myAnswer.Count; j++)
                        {
                            if (answerList[i].QuestionNum == myAnswer[j].QuestionNum)
                            {
                                myAnswerStr += myAnswer[j].Answer + ",";
                                if (answerList[i].Answer == myAnswer[j].Answer)
                                {
                                    if (myAnswer[j].TypeId == 1)
                                    {
                                        sore += oneNum;
                                    }
                                    if (myAnswer[j].TypeId == 2)
                                    {
                                        sore += twoNum;
                                    }
                                    if (myAnswer[j].TypeId == 3)
                                    {
                                        sore += threeNum;
                                    }
                                }

                            }
                        }
                    }
                    if (myAnswerStr.Length == 0)
                    {
                        myAnswerStr = "";
                    }
                    else
                        myAnswerStr = myAnswerStr.Substring(0, myAnswerStr.Length - 1);

                    Score_His sh = new Score_His();
                    sh.StudentId = StudentId;
                    sh.ScoreNum = sore;
                    sh.ExamQuestionId = ExamQuestionId;
                    sh.MyAnswerStr = myAnswerStr;
                    sh.CreateDate = DateTime.Now;
                    sh.ExamName = ename;
                    sh.ExamEndDate = ExamEndDate;
                    sh.StudentNum = StudentNum;
                    sh.StudentName = StudentName;
                    socreList.Add(sh);


                    //写入缓存
                    var result = RedisHelper.Set<List<Score_His>>("Score_His" + StudentId, socreList);

                    ////添加成绩
                    //var result = iScores_BLL.Add(StudentId, sore, ExamQuestionId, myAnswerStr, DateTime.Now);
                }
                else
                {
                    sore = 0;
                }
                return sore;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return 0;
            }

        }

        /// <summary>
        /// 写入cookie
        /// </summary>
        /// <param name="qid"></param>
        /// <param name="answer"></param>
        /// <param name="answer"></param>
        [HttpPost]
        public void SetAnswers(string qid, string answer, DateTime time, int tid)
        {
            try
            {
                if (tid == 0)
                    CookiesHelper.SetCookie(qid, answer, time.AddSeconds(10));
                else
                    CookiesHelper.SetCookie(qid, "", time.AddSeconds(10));
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
            }
        }
    }
}