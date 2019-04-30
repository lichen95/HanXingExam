using System;
using System.Linq;
using System.Text;

namespace HanXingExam.Entity
{
    /// <summary>
    /// ** 描述：试题表
    /// ** 创始时间：2018-11-02
    /// ** 修改时间：2018-11-04
    /// ** 作者：lc
    /// </summary>
    public partial class Questions
    {
           public Questions(){


           }
           /// <summary>
           /// Desc:试题Id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int QuestionId {get;set;}

           /// <summary>
           /// Desc:题号唯一
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string QuestionNum {get;set;}

           /// <summary>
           /// Desc:题干
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string QuestionTitle {get;set;}

           /// <summary>
           /// Desc:选项A
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string OptionA {get;set;}

           /// <summary>
           /// Desc:选项B
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string OptionB {get;set;}

           /// <summary>
           /// Desc:选项C
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OptionC {get;set;}

           /// <summary>
           /// Desc:选项D
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OptionD {get;set;}

           /// <summary>
           /// Desc:正确答案
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Answer {get;set;}

           /// <summary>
           /// Desc:学院Id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int CollegeId {get;set;}

           /// <summary>
           /// Desc:专业Id
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
           /// Desc:试题类型Id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int TypeId {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime CreateDate {get;set;}

    }
}
