using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.IBLL
{
    using Entity;
    using HanXingExam.Common;
    /// <summary>
    /// ** 描述：班级业务逻辑接口
    /// ** 创始时间：2018-11-07
    /// ** 修改时间：-
    /// ** 作者：whd
    /// </summary>
    public interface IAnalysisInfo_BLL
    {

        /// <summary>
        /// 班级成绩分析
        /// </summary>
        /// <param name="CollegeId"></param>
        /// <param name="MajorId"></param>
        /// <param name="StageId"></param>
        /// <param name="calassId"></param>
        /// <returns></returns>
        List<AnalysisInfo> classAnalysis(int CollegeId, int MajorId, int StageId, int calassId, int DateNum);

        /// <summary>
        /// 综合成绩的分析
        /// </summary>
        /// <param name="CreateDtae"></param>
        /// <param name="CollegeId"></param>
        /// <param name="MajorId"></param>
        /// <param name="StageId"></param>
        /// <returns></returns>
        List<AnalysisInfo> GetAnalysis(DateTime? CreateDtae, int CollegeId, int MajorId, int StageId);
        /// <summary>
        /// 考试结束 自动为旷考学生填充0分 并统计成绩
        /// </summary>
        void GetScores_Analysis();
    }
}
