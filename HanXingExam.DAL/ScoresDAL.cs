using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.DAL
{
    using HanXingExam.Common;
    using HanXingExam.IDAL;
    using HanXingExam.Entity;
    using SqlSugar;
    /// <summary>
    /// ** 描述：学生成绩
    /// ** 创始时间：2018-11-07
    /// ** 修改时间：-
    /// ** 作者：whd
    /// </summary>
    public class ScoresDAL : IScores_DAL
    {
        private SqlSugarClient db = null;
        public ScoresDAL()
        {
            if (db==null)
            {
                db = SqlSugarClientHelper.SqlDBConnection;
            }
        }

        /// <summary>
        /// 批量添加成绩
        /// </summary>
        /// <param name="scores"></param>
        /// <returns></returns>
        public int Add(int studentId,int scoreNum,string examQuestionId,string myAnswer,DateTime cateDate)
        {
            try
            {
                SugarParameter[] parms = {
                new SugarParameter("@StudentId",studentId),
                new SugarParameter("@ScoreNum",scoreNum),
                new SugarParameter("@ExamQuestionId",examQuestionId),
                new SugarParameter("@MyAnswer",myAnswer),
                new SugarParameter("@CreateDate",cateDate)
            };
                var result = db.Ado.ExecuteCommand("exec p_AddSocre_HistoricalPapers @StudentId,@ScoreNum,@ExamQuestionId,@MyAnswer,@CreateDate", parms);
                return result;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return 0;
            }

        }
    }
}
