using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.Entity
{
    /// <summary>
    /// ** 描述：试卷答案
    /// ** 创始时间：2018年11月8日09点36分
    /// ** 修改时间：-
    /// ** 作者：mqc
    /// </summary>
    public class TestPage
    {
        /// <summary>
        /// Desc:学院Id
        /// Default:
        /// Nullable:False
        /// </summary>   
        public string QuestionNum { get; set; }

        /// <summary>
        /// Desc:学院Id
        /// Default:
        /// Nullable:False
        /// </summary>   
        public string Answer { get; set; }
        /// <summary>
        /// Desc:类型Id
        /// Default:
        /// Nullable:False
        /// </summary>   
        public int TypeId { get; set; }
    }
}
