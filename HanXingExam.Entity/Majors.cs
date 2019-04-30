using System;
using System.Linq;
using System.Text;

namespace HanXingExam.Entity
{
    /// <summary>
    /// ** 描述：专业表
    /// ** 创始时间：2018-11-02
    /// ** 修改时间：2018-11-04
    /// ** 作者：lc
    /// </summary>
    public partial class Majors
    {
           public Majors(){


           }
           /// <summary>
           /// Desc:专业Id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int MajorId {get;set;}

           /// <summary>
           /// Desc:专业名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string MajorName {get;set;}

           /// <summary>
           /// Desc:学院Id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int CollegeId {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime CreateDate {get;set;}

    }
}
