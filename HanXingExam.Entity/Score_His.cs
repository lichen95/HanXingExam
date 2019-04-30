using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.Entity
{
    /// <summary>
    /// ** 描述：记录成绩与历史试卷信息
    /// ** 创始时间：2018-11-09
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class Score_His
    {
        /// <summary>
        /// 学生Id
        /// </summary>
        public int StudentId { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        public string StudentNum { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// 试卷名称
        /// </summary>
        public string ExamName { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime ExamEndDate { get; set; }
        /// <summary>
        /// 分数
        /// </summary>
        public int ScoreNum { get; set; }
        /// <summary>
        /// 试卷ID
        /// </summary>
        public string ExamQuestionId { get; set; }
        /// <summary>
        /// 我的答案
        /// </summary>
        public string MyAnswerStr { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
