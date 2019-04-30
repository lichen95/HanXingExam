using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.Entity
{
    /// <summary>
    /// ** 描述：用于实现单用户登录
    /// ** 创始时间：2018-11-14
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public static class IsLogin
    {
        public static StudentLogin _studentLogin { get; set; } = new StudentLogin();
       
    }
    public class StudentLogin
    {
        /// <summary>
        /// 登录的guid
        /// </summary>
        public string GuId { get; set; }
    }

}
