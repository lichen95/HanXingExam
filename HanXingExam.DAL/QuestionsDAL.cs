using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.DAL
{
    using IDAL;
    using Entity;
    using HanXingExam.Common;
    using SqlSugar;
    /// <summary>
    /// ** 描述：试题数据访问层
    /// ** 创始时间：2018-11-05
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class QuestionsDAL : IQuestions_DAL
    {
        private SqlSugarClient db = null;
        public QuestionsDAL()
        {
            if (db == null)
                db = SqlSugarClientHelper.SqlDBConnection;
        }
        public bool Add(Questions t)
        {
            return false;
        }
        /// <summary>
        /// 批量插入试题信息
        /// </summary>
        /// <param name="t">试题集合</param>
        /// <returns>返回bool 成功返回true 失败返回false</returns>
        public bool Add(List<Questions> t)
        {
            try
            {
                var result = db.Insertable(t.ToArray()).ExecuteCommand();
                //var result = db.Insertable<Questions>(t).ExecuteCommand();
                return result > 0;
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
        /// <param name="Ids">试题Id</param>
        /// <returns>返回bool 成功返回true 失败返回false</returns>
        public bool Delete(string Ids)
        {
            try
            {
                var arr = Ids.Split(',');
                int[] output = Array.ConvertAll<string, int>(arr, delegate (string s) { return int.Parse(s); });
                var result = db.Deleteable<Questions>().In(arr).ExecuteCommand();
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return false;
            }

        }

        /// <summary>
        /// 查询试题
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示几条</param>
        /// <param name="questionsName">题干</param>
        /// <param name="collegeId">学院</param>
        /// <param name="mjorId">专业</param>
        /// <param name="stageId">阶段</param>
        /// <returns>返回分页类</returns>
        public PageBox Query(DateTime? startDate, DateTime? endDate, int pageIndex = 1, int pageSize = 2, string questionsName = "", int collegeId = 0, int mjorId = 0, int stageId = 0)
        {
            try
            {
                //总页数
                var pageCount = 0;
                //四表联查
                var list = db.Queryable<Questions, Colleges, Stages, Majors>((qu, co, st, ma) => new object[] { JoinType.Inner, qu.CollegeId == co.CollegeId, JoinType.Inner, qu.StageId == st.StageId, JoinType.Inner, qu.MajorId == ma.MajorId }).Select((qu, co, st, ma) => new { qu.QuestionId, qu.QuestionNum, qu.QuestionTitle, qu.OptionA, qu.OptionB, qu.OptionC, qu.OptionD, qu.Answer, qu.CollegeId, qu.CreateDate, qu.MajorId, qu.StageId, qu.TypeId, co.CollegeName, st.StageName, ma.MajorName });

                //查询开始时间
                if (!string.IsNullOrWhiteSpace(startDate.ToString()))
                    list = list.Where(qu => qu.CreateDate >= startDate);
                //查询结束时间
                if (!string.IsNullOrWhiteSpace(endDate.ToString()))
                    list = list.Where(qu => qu.CreateDate <= endDate);
                //用户查询
                if (!string.IsNullOrWhiteSpace(questionsName))
                    list = list.Where(qu => qu.QuestionTitle.Contains(questionsName));
                //学院查询
                if (collegeId != 0)
                    list = list.Where(qu => qu.CollegeId.Equals(collegeId));
                //专业查询
                if (mjorId != 0)
                    list = list.Where(qu => qu.MajorId.Equals(mjorId));
                //阶段查询
                if (stageId != 0)
                    list = list.Where(qu => qu.StageId.Equals(stageId));
                var listUser = list.ToPageList(pageIndex, pageSize, ref pageCount);
                PageBox page = new PageBox();
                page.PageIndex = pageIndex;
                page.PageCount = pageCount;
                page.Data = listUser;
                return page;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 根据Id查询试题信息
        /// </summary>
        /// <param name="Id">试题Id</param>
        /// <returns>返回试题</returns>
        public Questions QueryById(int Id)
        {
            try
            {
                var result = db.Queryable<Questions>().InSingle(Id);
                return result;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }

        }

        /// <summary>
        /// 修改试题
        /// </summary>
        /// <param name="t">试题实体</param>
        /// <returns>返回bool 成功返回true 失败返回false</returns>
        public bool Update(Questions t)
        {
            try
            {
                var result = db.Updateable<Questions>(t).ExecuteCommand();
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return false;
            }
        }
    }
}
