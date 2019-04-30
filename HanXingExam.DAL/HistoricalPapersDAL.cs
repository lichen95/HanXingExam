using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.DAL
{
    using HanXingExam.IDAL;
    using HanXingExam.Entity;
    using SqlSugar;
    using HanXingExam.Common;

    /// <summary>
    /// ** 描述：历史试卷数据访问层
    /// ** 创始时间：2018年11月6日
    /// ** 修改时间：-
    /// ** 作者：zhq
    /// </summary>
    public class HistoricalPapersDAL : IHistoricalPapers_DAL
    {
        private SqlSugarClient db = null;

        public HistoricalPapersDAL()
        {
            if (db == null)
                db = SqlSugarClientHelper.SqlDBConnection;
        }

        /// <summary>
        /// 添加历史试卷
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns></returns>
        public bool Add(HistoricalPapers t)
        {
            try
            {
                var result = db.Insertable<HistoricalPapers>(t).ExecuteCommand();
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return false;
            }

        }

        public bool Delete(string Ids)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 获取历史试卷
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="pageIndex">首页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns>返回page</returns>
        public PageBox GetHistoricalPapers(int StudentId, DateTime? startDate, DateTime? endDate, int pageIndex = 1, int pageSize = 10)
        {
            try
            {
                //总页数
                var pageCount = 0;
                //五表联查
                var list = db.Queryable<HistoricalPapers, ExamQuestions, Scores, Students>((hp, eq, sc, st) => new object[] { JoinType.Inner, hp.ExamQuestionId == eq.ExamQuestionId, JoinType.Inner, hp.ScoreId == sc.ScoreId, JoinType.Inner, sc.StudentId == st.StudentId }).Select((hp, eq, sc, st) => new {
                    sc.ScoreNum,
                    st.StudentNum,
                    st.StudentName,
                    eq.ExamName,
                    hp.CreateDate,
                    hp.ExamQuestionId,
                    st.StudentId,
                    eq.ExamEndDate
                }).OrderBy(hp => hp.CreateDate, OrderByType.Desc).ToList();

                PageBox page = new PageBox
                {
                    PageIndex = pageIndex,
                    PageCount = pageCount,
                    Data = list
                };
                return page;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }

        }

        public HistoricalPapers QueryById(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(HistoricalPapers t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据学生ID查询历史试卷是否有记录
        /// </summary>
        /// <param name="StudentId"></param>
        /// <returns></returns>
        public HistoricalPapers IsShowTestInfos(int StudentId,string ExamQuestionId)
        {
            try
            {
                var sql = "select * from HistoricalPapers where ScoreId in (select ScoreId from Scores where StudentId=@StudentId) and ExamQuestionId=@ExamQuestionId";
                SugarParameter[] parms = {
                new SugarParameter("@StudentId",StudentId),
                 new SugarParameter("@ExamQuestionId",ExamQuestionId)
            };
                var result = db.Ado.SqlQuery<HistoricalPapers>(sql, parms).FirstOrDefault();
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
