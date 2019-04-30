using System;
using System.Linq;
using System.Text;

namespace HanXingExam.Entity
{
    /// <summary>
    /// ** 描述：成绩表
    /// ** 创始时间：2018-11-02
    /// ** 修改时间：2018-11-07
    /// ** 作者：lc
    /// </summary>
    public partial class Scores
    {
           public Scores(){


           }
           /// <summary>
           /// Desc:成绩Id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ScoreId {get;set;}

           /// <summary>
           /// Desc:学生Id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int StudentId {get;set;}

        /// <summary>
        /// Desc:分数
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int ScoreNum {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime CreateDate {get;set;}

    }
}
