using System;
using System.Linq;
using System.Text;

namespace HanXingExam.Entity
{
    /// <summary>
    /// ** 描述：阶段表
    /// ** 创始时间：2018-11-02
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public partial class Stages
    {
           public Stages(){


           }
           /// <summary>
           /// Desc:阶段Id
           /// Default:主键自增
           /// Nullable:False
           /// </summary>           
           public int StageId {get;set;}

           /// <summary>
           /// Desc:阶段名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string StageName {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime CreateDate {get;set;}

        /// <summary>
        /// Desc:学院Id
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int CollegeId { get; set; }

        /// <summary>
        /// Desc:专业ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int MajorId { get; set; }
    }
}
