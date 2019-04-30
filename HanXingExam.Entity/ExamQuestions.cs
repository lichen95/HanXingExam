using System;
using System.Linq;
using System.Text;

namespace HanXingExam.Entity
{
    /// <summary>
    /// ** 描述：试卷表
    /// ** 创始时间：2018-11-06
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public partial class ExamQuestions
    {
        public ExamQuestions()
        {


        }

        /// <summary>
        /// Desc:试卷的唯一标识符
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string ExamQuestionId { get; set; }

        /// <summary>
        /// Desc:题目的Id集合
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string QuestionIds { get; set; }

        /// <summary>
        /// Desc:试卷名称
        /// Default:
        /// Nullable:False
        /// </summary>  
        public string ExamName { get; set; }

        /// <summary>
        /// Desc:开始时间
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime ExamStartDate { get; set; }

        /// <summary>
        /// Desc:结束时间
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime ExamEndDate { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Desc:学院Id
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int CollegeId { get; set; }

        /// <summary>
        /// Desc:专业Id
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int MajorId { get; set; }

        /// <summary>
        /// Desc:阶段Id
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int StageId { get; set; }

        /// <summary>
        /// Desc:试卷状态 0:已经考过了 1:还没考
        /// Default:
        /// Nullable:False
        /// </summary>  
        public int State { get; set; }
    }
}
