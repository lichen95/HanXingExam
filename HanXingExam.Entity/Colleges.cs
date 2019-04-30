using System;
using System.Linq;
using System.Text;

namespace HanXingExam.Entity
{
    /// <summary>
    /// ** 描述：学院表
    /// ** 创始时间：2018年11月2日10点17分
    /// ** 修改时间：-
    /// ** 作者：mqc
    /// </summary>
    public partial class Colleges
    {
        public Colleges()
        {


        }
        /// <summary>
        /// Desc:学院Id
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int CollegeId { get; set; }

        /// <summary>
        /// Desc:学院名称
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string CollegeName { get; set; }

        /// <summary>
        /// Desc:学院负责人
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string CollegeDean { get; set; }

        /// <summary>
        /// Desc:联系方式
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string CollegePhone { get; set; }

        /// <summary>
        /// Desc:创建日期
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime CollegeCreateDate { get; set; }

        /// <summary>
        /// Desc:学院简介
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string CollegeDesc { get; set; }

        /// <summary>
        /// Desc:备注
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string CollegeRemark { get; set; }

    }
}
