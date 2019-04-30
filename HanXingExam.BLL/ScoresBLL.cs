using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.BLL
{
    using HanXingExam.IBLL;
    using HanXingExam.IDAL;
    using HanXingExam.Entity;
    using HanXingExam.Common;
    /// <summary>
    /// ** 描述：学生成绩
    /// ** 创始时间：2018-11-07
    /// ** 修改时间：-
    /// ** 作者：whd
    /// </summary>
    public class ScoresBLL : IScores_BLL
    {
        private IScores_DAL scores_DAL;
        public ScoresBLL(IScores_DAL _scores_DAL)
        {
            scores_DAL = _scores_DAL;
        }
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="scores"></param>
        /// <returns></returns>
        public int Add(int studentId, int scoreNum, string examQuestionId, string myAnswer, DateTime cateDate)
        {
            var result = scores_DAL.Add(studentId, scoreNum, examQuestionId, myAnswer, cateDate);
            return result;
        }
    }
}
