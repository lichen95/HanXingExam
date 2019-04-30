using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.Entity
{
    /// <summary>
    /// ** 描述：成绩分析记录表
    /// ** 创始时间：2018-11-09
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class Analysis
    {
        public Analysis()
        {


        }
        /// <summary>
        /// Desc:主键Id
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int Id { get; set; }

        /// <summary>
        /// Desc:学院Id
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int CollegeId { get; set; }

        /// <summary>
        /// Desc:专业Id
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int MajorId { get; set; }

        /// <summary>
        /// Desc:阶段Id
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int StageId { get; set; }

        /// <summary>
        /// Desc:班级Id
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int ClassId { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime CreteDate { get; set; }

        /// <summary>
        /// Desc:平均分
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal AvgNum { get; set; }

        /// <summary>
        /// Desc:成才数
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int PassNum { get; set; }

        /// <summary>
        /// Desc:成绩数
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int StudentNum { get; set; }

        /// <summary>
        /// Desc:成材率
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal Yield { get; set; }
    }
}
