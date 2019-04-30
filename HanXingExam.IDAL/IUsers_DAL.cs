using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.IDAL
{
    using HanXingExam.Entity;
    using HanXingExam.Common;
    /// <summary>
    /// ** 描述：用户接口
    /// ** 创始时间：2018-11-02
    /// ** 修改时间：-
    /// ** 作者：whd
    /// </summary>
    public interface IUsers_DAL : IDALBase<Users> 
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns>返回用户信息</returns>
        List<Users> GetUsers();
        /// <summary>
        /// 分页显示
        /// </summary>
        /// <param name="pageIndex">当前页 可选参数</param>
        /// <param name="pageSize">每页显示几条 可选参数</param>
        /// <returns>int 受影响行数</returns>
        PageBox Query(DateTime? startDate,DateTime? endDate, string userName, int collegeId,int mjorId,int stageId, int pageIndex = 1, int pageSize = 3);

        /// <summary>
        /// 获取学院
        /// </summary>
        /// <returns>返回学院信息</returns>
        List<Colleges> GetColleges();
        /// <summary>
        /// 根据学院ID获取专业
        /// </summary>
        /// <returns>返回专业信息</returns>
        List<Majors> GetMajorsByCollegeId(int CollegeId);
        /// <summary>
        /// 获取阶段
        /// </summary>
        /// <returns>返回阶段信息</returns>
        List<Stages> GetStages(int MajorId);
        /// <summary>
        /// 根据用户名和密码查询ID
        /// </summary>
        /// <param name="UserName">定义的用户名变量</param>
        /// <param name="UserPwd">定义的密码变量</param>
        /// <returns>返回</returns>
        Users GetUserID(string UserName, string UserPwd);
    }
}
