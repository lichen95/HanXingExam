using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.DAL
{
    using HanXingExam.Common;
    using HanXingExam.Entity;
    using HanXingExam.IDAL;
    using SqlSugar;

    /// <summary>
    /// ** 描述：试卷数据访问层
    /// ** 创始时间：2018年11月5日14点55分
    /// ** 修改时间：-
    /// ** 作者：mqc
    /// </summary>
    public class ExamQuestionDAL : IExamQuestion_DAL
    {
        private SqlSugarClient sugar;

        public ExamQuestionDAL()
        {
            if (sugar == null)
            {
                sugar = SqlSugarClientHelper.SqlDBConnection;
            }
        }

        /// <summary>
        /// 新增试题
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Add(ExamQuestions t)
        {
            try
            {
                return sugar.Insertable<ExamQuestions>(t).ExecuteCommand() > 0;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return false;
            }

        }

        /// <summary>
        /// 删除试题
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public bool Delete(string Ids)
        {
            try
            {
                var sql = "delete from ExamQuestions where ExamQuestionId=@Id";
                SugarParameter[] parms = {
                new SugarParameter("@Id",Ids)
            };
                var result = sugar.Ado.ExecuteCommand(sql, parms) > 0;
                return result;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return false;
            }

        }

        /// <summary>
        /// 根据学院Id 专业Id 阶段Id 将题库题目分类
        /// </summary>
        /// <param name="CollegeId">学院Id</param>
        /// <param name="MajorId">专业Id</param>
        /// <param name="StageId">阶段Id</param>
        /// <returns></returns>
        public ExamBox QueryByIds(int CollegeId, int MajorId, int StageId)
        {
            try
            {
                var list = sugar.Queryable<Questions>();
                var listResult = list.Where(qu => qu.CollegeId.Equals(CollegeId) && qu.MajorId.Equals(MajorId) && qu.StageId.Equals(StageId)).ToList();
                ExamBox exam = new ExamBox
                {
                    Single = listResult.Where(qu => qu.TypeId.Equals(1)).ToList(),
                    More = listResult.Where(qu => qu.TypeId.Equals(2)).ToList(),
                    Judge = listResult.Where(qu => qu.TypeId.Equals(3)).ToList()
                };
                return exam;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }

        }

        public ExamQuestions QueryById(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ExamQuestions t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据试卷ID查询
        /// </summary>
        /// <param name="ExamQuestionId"></param>
        /// <returns></returns>
        public ExamQuestions QueryByEQId(string ExamQuestionId)
        {
            try
            {
                var list = sugar.Queryable<ExamQuestions>().InSingle(ExamQuestionId);
                return list;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }

        }

        /// <summary>
        /// 查看待考信息
        /// </summary>
        /// <param name="collegeId"></param>
        /// <param name="majorId"></param>
        /// <param name="stageId"></param>
        /// <returns></returns>
        public PageBox GetExamQuestions(DateTime? strartDate, DateTime? endDate,int collegeId=0, int majorId=0, int stageId=0, int pageIndex = 1, int pageSize = 3)
        {
            try
            {
                var pageCount = 0;
                var list = sugar.Queryable<ExamQuestions, Colleges, Stages, Majors>((qu, co, st, ma) => new object[] { JoinType.Inner, qu.CollegeId == co.CollegeId, JoinType.Inner, qu.StageId == st.StageId, JoinType.Inner, qu.MajorId == ma.MajorId }).Select((qu, co, st, ma) => new { qu.CollegeId, qu.CreateDate, qu.ExamEndDate, qu.ExamName, qu.ExamQuestionId, qu.ExamStartDate, qu.MajorId, qu.QuestionIds, qu.StageId, qu.State, co.CollegeName, st.StageName, ma.MajorName }).OrderBy(qu => qu.CreateDate, OrderByType.Desc);
                //var listresult = list.Where(ex => ex.CollegeId.Equals(collegeId) && ex.MajorId.Equals(collegeId) && ex.StageId.Equals(collegeId));
                //查询开始时间
                if (!string.IsNullOrWhiteSpace(strartDate.ToString()))
                    list = list.Where(qu => qu.CreateDate >= strartDate);
                //查询结束时间
                if (!string.IsNullOrWhiteSpace(endDate.ToString()))
                    list = list.Where(qu => qu.CreateDate <= endDate);
                //学院查询
                if (collegeId != 0)
                    list = list.Where(qu => qu.CollegeId.Equals(collegeId));
                //专业查询
                if (majorId != 0)
                    list = list.Where(qu => qu.MajorId.Equals(majorId));
                //阶段查询
                if (stageId != 0)
                    list = list.Where(qu => qu.StageId.Equals(stageId));
                var listExamQuestions = list.ToPageList(pageIndex, pageSize, ref pageCount);
                PageBox page = new PageBox();
                page.PageIndex = pageIndex;
                page.PageCount = pageCount;
                page.Data = listExamQuestions;
                return page;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }

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
            try
            {
                var list = sugar.Queryable<ExamQuestions>();
                var listresult = list.Where(ex => ex.CollegeId.Equals(collegeId) && ex.MajorId.Equals(majorId) && ex.StageId.Equals(stageId)).ToList();
                return listresult;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }

        }
        /// <summary>
        /// 获取试卷信息
        /// </summary>
        /// <returns></returns>
        public List<ExamQuestions> GetExamQuestions()
        {
            try
            {
                var result = sugar.Queryable<ExamQuestions>().ToList();
                return result;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }

        }
    }
}
