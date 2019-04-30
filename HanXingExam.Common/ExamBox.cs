using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.Common
{
    using Entity;
    /// <summary>
    /// ** 描述：试题类型类
    /// ** 创始时间：2018年11月5日17点48分
    /// ** 修改时间：-
    /// ** 作者：mqc
    /// </summary>
    public class ExamBox
    {
        /// <summary>
        /// 单选
        /// </summary>
        public List<Questions> Single { get; set; }

        /// <summary>
        /// 多选
        /// </summary>
        public List<Questions> More { get; set; }

        /// <summary>
        /// 判断
        /// </summary>
        public List<Questions> Judge { get; set; }
    }
}
