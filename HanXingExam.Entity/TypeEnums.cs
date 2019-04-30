using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.Entity
{
    /// <summary>
    /// ** 描述：试题类型Id
    /// ** 创始时间：2018年11月4日
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public enum TypeEnums
    {
        单选题 = 1,
        多选题 = 2,
        判断题 = 3
    }
    /// <summary>
    /// ** 描述：成绩分析创建时间
    /// ** 创始时间：2018年11月8日
    /// ** 修改时间：-
    /// ** 作者：whd
    /// </summary>
    public enum DateNum
    {
        当天 = 0,
        一周 = 7,
        一个月 = 30,
        一季度 = 90,
        一年 = 365
    }
}
