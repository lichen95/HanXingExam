using System;
using System.Linq;
using System.Text;

namespace HanXingExam.Entity
{
    /// <summary>
    /// ** 描述：权限表
    /// ** 创始时间：2018-11-02
    /// ** 修改时间：2018-11-02
    /// ** 作者：zhq
    /// </summary>
    public partial class Permissions
    {
           public Permissions(){


           }
           /// <summary>
           /// Desc:权限ID
           /// Default: 自增
           /// Nullable:False
           /// </summary>           
           public int PermissionId {get;set;}

           /// <summary>
           /// Desc:权限名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string PermissionName {get;set;}

           /// <summary>
           /// Desc:页面路径
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string URL {get;set;}

           /// <summary>
           /// Desc:是否启用
           /// Default:0：禁用 1：启用
           /// Nullable:False
           /// </summary>           
           public int IsUse {get;set;}

           /// <summary>
           /// Desc:父级Id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int PId {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime CreateDate {get;set;}

    }
}
