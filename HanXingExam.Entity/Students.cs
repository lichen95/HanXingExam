using System;
using System.Linq;
using System.Text;

namespace HanXingExam.Entity
{
    /// <summary>
    /// ** 描述：学生表
    /// ** 创始时间：2018年11月2日10点20分
    /// ** 修改时间：-
    /// ** 作者：mqc
    /// </summary>
    public partial class Students
    {
        public Students()
        {


        }
        /// <summary>
        /// Desc:学生Id
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int StudentId { get; set; }

        /// <summary>
        /// Desc:学号
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string StudentNum { get; set; }

        /// <summary>
        /// Desc:密码
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string StudentPwd { get; set; }

        /// <summary>
        /// Desc:学生姓名
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string StudentName { get; set; }

        /// <summary>
        /// Desc:身份证号
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string StudentIdCard { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Desc:创建人
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int CreateUserId { get; set; }
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
        /// Desc:班级Id
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int ClassId { get; set; }

    }
}
