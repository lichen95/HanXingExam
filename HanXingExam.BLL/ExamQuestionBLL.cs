using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.BLL
{
    using HanXingExam.IBLL;
    using HanXingExam.Entity;
    using HanXingExam.IDAL;
    using HanXingExam.Common;
    using System.Collections;

    /// <summary>
    /// ** 描述：试卷业务逻辑层
    /// ** 创始时间：2018年11月6日14点36分
    /// ** 修改时间：-
    /// ** 作者：mqc
    /// </summary>
    public class ExamQuestionBLL : IExamQuestion_BLL
    {
        private IExamQuestion_DAL examquestion_DAL;
        private IQuestions_DAL questions_DAL;

        public ExamQuestionBLL(IExamQuestion_DAL _examquestion_DAL, IQuestions_DAL _questions_DAL)
        {
            examquestion_DAL = _examquestion_DAL;
            questions_DAL = _questions_DAL;
        }

        public bool Add(ExamQuestions m)
        {
            return examquestion_DAL.Add(m);
        }

        /// <summary>
        /// 删除试卷
        /// </summary>
        /// <param name="Ids">试卷Id</param>
        /// <returns></returns>
        public bool Delete(string Ids)
        {
            var result = examquestion_DAL.Delete(Ids);
            return result;
        }

        /// <summary>
        /// 查看待考信息
        /// </summary>
        /// <param name="collegeId"></param>
        /// <param name="majorId"></param>
        /// <param name="stageId"></param>
        /// <returns></returns>
        public PageBox GetExamQuestions(DateTime? strartDate, DateTime? endDate,int collegeId = 0, int majorId = 0, int stageId = 0, int pageIndex = 1, int pageSize = 3)
        {
            return examquestion_DAL.GetExamQuestions(strartDate, endDate,collegeId, majorId, stageId, pageIndex, pageSize);
        }


        /// <summary>
        /// 根据试卷ID查询
        /// </summary>
        /// <param name="ExamQuestionId"></param>
        /// <returns></returns>
        public List<Questions> QueryByEQId(string ExamQuestionId)
        {
            ExamQuestions m = examquestion_DAL.QueryByEQId(ExamQuestionId);
            string[] id = m.QuestionIds.Split(',');
            List<Questions> li = new List<Questions>();
            foreach (var item in id)
            {
                var list = questions_DAL.QueryById(int.Parse(item));
                li.Add(list);
            }
            return li;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="CollegeId"></param>
        /// <param name="MajorId"></param>
        /// <param name="StageId"></param>
        /// <returns></returns>
        public ExamBox QueryByIds(int CollegeId, int MajorId, int StageId)
        {
            return examquestion_DAL.QueryByIds(CollegeId, MajorId, StageId);
        }

        /// <summary>
        /// 根据Id查询试卷
        /// </summary>
        /// <param name="collegeId"></param>
        /// <param name="majorId"></param>
        /// <param name="stageId"></param>
        /// <returns></returns>
        public List<ExamQuestions> ExamQuestions(int collegeId = 0, int majorId = 0, int stageId = 0)
        {
            var result = examquestion_DAL.ExamQuestions(collegeId, majorId, stageId);
            return result;
        }
        /// <summary>
        /// 获取试卷信息
        /// </summary>
        /// <returns></returns>
        public List<ExamQuestions> GetExamQuestions()
        {
            var result = examquestion_DAL.GetExamQuestions();
            return result;
        }

        /// <summary>
        /// 根据Id查询试卷详情
        /// </summary>
        /// <param name="ExamQuestionId"></param>
        /// <returns></returns>
        public ExamQuestions GetExamQuestionsByExamQuestionId(string ExamQuestionId)
        {
            var result = examquestion_DAL.QueryByEQId(ExamQuestionId);
            return result;
        }
    }
}
