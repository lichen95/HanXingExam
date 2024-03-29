﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.IBLL
{
    using HanXingExam.Entity;
    using HanXingExam.Common;
    /// <summary>
    /// ** 描述：学生成绩
    /// ** 创始时间：2018-11-07
    /// ** 修改时间：-
    /// ** 作者：whd
    /// </summary>
    public interface IScores_BLL
    {
        /// <summary>
        /// 批量添加成绩
        /// </summary>
        /// <param name="scores"></param>
        /// <returns></returns>
        int Add(int studentId, int scoreNum, string examQuestionId, string myAnswer, DateTime cateDate);
    }
}
