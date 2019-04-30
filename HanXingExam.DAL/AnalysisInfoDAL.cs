using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.DAL
{
    using SqlSugar;
    using Entity;
    using IDAL;
    using HanXingExam.Common;

    /// <summary>
    /// ** 描述：班级数据访问层
    /// ** 创始时间：2018-11-07
    /// ** 修改时间：-
    /// ** 作者：whd
    /// </summary>
    public class AnalysisInfoDAL : IAnalysisInfo_DAL  
    {
        private SqlSugarClient db = null;
        public AnalysisInfoDAL()
        {
            if (db==null)
            {
                db = SqlSugarClientHelper.SqlDBConnection;
            }
        }
        /// <summary>
        /// 综合成绩分析
        /// </summary>
        /// <param name="CreateDtae"></param>
        /// <param name="CollegeId"></param>
        /// <param name="MajorId"></param>
        /// <param name="StageId"></param>
        /// <returns></returns>
        public List<AnalysisInfo> GetAnalysis(DateTime? CreateDtae, int CollegeId, int MajorId, int StageId)
        {
            try
            {
                SugarParameter[] parm = {
                new SugarParameter("@CollegeId",CollegeId),
                new SugarParameter("@MajorId",MajorId),
                new SugarParameter("@StageId",StageId),
                new SugarParameter("@CreateDate",CreateDtae)
            };

                var list = db.Ado.SqlQuery<AnalysisInfo>("exec p_showAnalysis @CollegeId,@MajorId,@StageId,@CreateDate", parm).ToList();
                return list;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }
           
        }


        /// <summary>
        /// 班级成绩分析
        /// </summary>
        /// <param name="CollegeId"></param>
        /// <param name="MajorId"></param>
        /// <param name="StageId"></param>
        /// <param name="calassId"></param>
        /// <returns></returns>
        public List<AnalysisInfo> classAnalysis(int CollegeId, int MajorId, int StageId, int calassId, int DateNum)
        {
            try
            {
                SugarParameter[] parm = {
                new SugarParameter("@CollegeId",CollegeId),
                new SugarParameter("@MajorId",MajorId),
                new SugarParameter("@StageId",StageId),
                new SugarParameter("@ClassId",calassId),
                new SugarParameter("@DataNum",DateNum),
            };
                var result = db.Ado.SqlQuery<AnalysisInfo>("exec ClassAnalysis @CollegeId,@MajorId,@StageId,@ClassId", parm).ToList();
                return result;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }

        }

        /// <summary>
        /// 考试结束 自动为旷考学生填充0分 并统计成绩
        /// </summary>
        public void GetScores_Analysis()
        {
            try
            {
                var result1 = db.Ado.ExecuteCommand("exec p_AddSocres");
                var result2 = db.Ado.ExecuteCommand("exec p_Analysis");

            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
            }
        }
  
    }
}
