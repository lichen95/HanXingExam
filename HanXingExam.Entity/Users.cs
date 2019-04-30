using System;
using System.Linq;
using System.Text;

namespace HanXingExam.Entity
{
    /// <summary>
    /// ** 描述：用户表
    /// ** 创始时间：2018-11-02
    /// ** 修改时间：-
    /// ** 作者：whd
    /// </summary>
    public partial class Users
    {
        public Users()
        {


        }
        /// <summary>
        /// Desc:用户ID
        /// Default:主键自增
        /// Nullable:False
        /// </summary>           
        public int UserId { get; set; }

        /// <summary>
        /// Desc:用户名
        /// Default:唯一
        /// Nullable:False
        /// </summary>           
        public string UserName { get; set; }

        /// <summary>
        /// Desc:密码
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string UserPwd { get; set; }
        /// <summary>
        /// Desc:用户角色ID
        /// Default:
        /// Nullable:False
        /// </summary>   
        public string RoleIds { get; set; }
        /// <summary>
        /// Desc:角色名称
        /// Default:
        /// Nullable:False
        /// </summary>   
        public string RoleNames { get; set; }

        /// <summary>
        /// Desc:学院ID
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

        /// <summary>
        /// Desc:阶段ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int StageId { get; set; }

        /// <summary>
        /// Desc:是否启用
        /// Default:0禁用，1启用
        /// Nullable:False
        /// </summary>           
        public int IsUse { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime CreateDate { get; set; }

    }
}
