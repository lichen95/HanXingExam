using System;
using System.Linq;
using System.Text;

namespace HanXingExam.Entity
{
    /// <summary>
    /// ** 描述：角色表
    /// ** 创始时间：2018-11-02
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public partial class Roles
    {
           public Roles(){


           }
           /// <summary>
           /// Desc:角色Id
           /// Default:主键自增
           /// Nullable:False
           /// </summary>           
           public int RoleId {get;set;}

           /// <summary>
           /// Desc:角色名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string RoleName {get;set;}

           /// <summary>
           /// Desc:权限id集合
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string PermissionIds {get;set;}

           /// <summary>
           /// Desc:权限名集合
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string PermissionNames {get;set;}

           /// <summary>
           /// Desc:是否启用
           /// Default:0禁用  1启用
           /// Nullable:False
           /// </summary>           
           public int IsUse {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime CreateDate {get;set;}

    }
}
