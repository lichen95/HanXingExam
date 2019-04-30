using System;
using System.Linq;
using System.Text;

namespace HanXingExam.Entity
{
    /// <summary>
    /// ** 描述：历史试卷表
    /// ** 创始时间：2018-11-06
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public partial class HistoricalPapers
    {
           public HistoricalPapers(){


           }


        /// <summary>
        /// Desc:历史试卷Id
        /// Default:主键自增
        /// Nullable:False
        /// </summary>           
        public int HistoricalPaperId { get; set; }


        /// <summary>
        /// Desc:试卷Id
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string ExamQuestionId {get;set;}

           /// <summary>
           /// Desc:我的答案
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string MyAnswer {get;set;}

           /// <summary>
           /// Desc:成绩Id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ScoreId {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime CreateDate {get;set;}

    }
}
