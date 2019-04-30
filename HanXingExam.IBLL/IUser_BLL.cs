using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.IBLL
{
    using HanXingExam.Entity;
    using HanXingExam.Common;
    /// <summary>
    /// ** 描述：用户接口
    /// ** 创始时间：2018-11-02
    /// ** 修改时间：-
    /// ** 作者：whd
    /// </summary>
    public interface IUser_BLL
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns>返回用户信息</returns>
        List<Users> GetUsers();
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool成功返回true  失败返回false</returns>
        bool Add(Users t);
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="Ids">用户ID</param>
        /// <returns>bool成功返回true  失败返回false</returns>
        bool Delete(string Ids);
        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="userName">用户名</param>
        /// <param name="collegeId">学院ID</param>
        /// <param name="mjorId">专业ID</param>
        /// <param name="stageId">阶段ID</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页几条</param>
        /// <returns>int 受影响行数</returns>
        PageBox Query(DateTime? startDate, DateTime? endDate, string userName, int collegeId = 0, int mjorId = 0, int stageId = 0, int pageIndex = 1, int pageSize = 3);

        /// <summary>
        /// 根据ID获取用户信息
        /// </summary>
        /// <param name="Id">用户Id</param>
        /// <returns></returns>
        Users QueryById(int Id);
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>int 受影响行数</returns>
        bool Update(Users t);
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
        /// 登录
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="UserPwd">密码</param>
        /// <returns></returns>
        Users GetUserID(string UserName, string UserPwd);

    }
}
