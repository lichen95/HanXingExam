using System;
using System.Linq;
using System.Text;

namespace HanXingExam.Entity
{

    /// <summary>
    /// ** 描述：班级表
    /// ** 创始时间：2018-11-02
    /// ** 修改时间：2018-11-04
    /// ** 作者：lc
    /// </summary>
    public partial class Classes
    {
           public Classes(){


           }
           /// <summary>
           /// Desc:班级Id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ClassId {get;set;}

           /// <summary>
           /// Desc:班级名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string ClassName {get;set;}

           /// <summary>
           /// Desc:学院Id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int CollegeId {get;set;}

           /// <summary>
           /// Desc:专业ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int MajorId {get;set;}

           /// <summary>
           /// Desc:阶段Id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int StageId {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime CreateDate {get;set;}

    }
}
