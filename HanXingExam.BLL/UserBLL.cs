using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.BLL
{
    using HanXingExam.IBLL;
    using HanXingExam.IDAL;
    using HanXingExam.Entity;
    using HanXingExam.Common;
    /// <summary>
    /// ** 描述：用户接口
    /// ** 创始时间：2018-11-02
    /// ** 修改时间：2018-11-04
    /// ** 作者：whd
    /// </summary>
    public class UserBLL : IUser_BLL
    {
        private IUsers_DAL users_DAL;
        public UserBLL(IUsers_DAL _users_DAL)
        {
            users_DAL = _users_DAL;
        }
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool成功返回true  失败返回false</returns>
        public bool Add(Users t)
        {
            var result = users_DAL.Add(t);
            return result;
        }
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="Ids">用户ID</param>
        /// <returns>bool成功返回true  失败返回false</returns>
        public bool Delete(string Ids)
        {
            var result = users_DAL.Delete(Ids);
            return result;
        }
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
        public PageBox Query(DateTime? startDate, DateTime? endDate, string userName, int collegeId = 0, int mjorId = 0, int stageId = 0, int pageIndex = 1, int pageSize = 3)
        {
            var result = users_DAL.Query(startDate,endDate,userName,collegeId ,mjorId,stageId,pageIndex,pageSize);
            return result;
        }
        /// <summary>
        /// 根据ID获取用户信息
        /// </summary>
        /// <param name="Id">用户Id</param>
        /// <returns></returns>
        public Users QueryById(int Id)
        {
            var result = users_DAL.QueryById(Id);
            return result;
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool成功返回true  失败返回false</returns>
        public bool Update(Users t)
        {
            var result = users_DAL.Update(t);
            return result;
        }
        /// <summary>
        /// 获取学院
        /// </summary>
        /// <returns>返回学院信息</returns>
        public List<Colleges> GetColleges()
        {
            var result = users_DAL.GetColleges();
            return result;
        }
        /// <summary>
        /// 根据学院ID获取专业
        /// </summary>
        /// <returns>返回专业信息</returns>
        public List<Majors> GetMajorsByCollegeId(int CollegeId)
        {
            var result = users_DAL.GetMajorsByCollegeId(CollegeId);
            return result;
        }
        /// <summary>
        /// 获取阶段
        /// </summary>
        /// <returns>返回阶段信息</returns>
        public List<Stages> GetStages(int MajorId)
        {
            var result = users_DAL.GetStages(MajorId);
            return result;
        }

        /// <summary>
        /// 返回用户信息
        /// </summary>
        /// <returns></returns>
        public List<Users> GetUsers()
        {
            var result = users_DAL.GetUsers();
            return result;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="UserPwd">密码</param>
        /// <returns></returns>
        public Users GetUserID(string UserName, string UserPwd)
        {
            var result = users_DAL.GetUserID(UserName, UserPwd);
            return result;
        }
    }
}
