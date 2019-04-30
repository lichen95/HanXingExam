using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.DAL
{
    using HanXingExam.Common;
    using HanXingExam.IDAL;
    using HanXingExam.Entity;
    using SqlSugar;

    /// <summary>
    /// ** 描述：用户接口
    /// ** 创始时间：2018-11-02
    /// ** 修改时间：2018-11-04
    /// ** 作者：whd
    /// </summary>
    public class UsersDAL :IUsers_DAL
    {
        private SqlSugarClient db = null;
        public UsersDAL()
        {
            if (db == null)
            {
                db = SqlSugarClientHelper.SqlDBConnection;
            }
        }
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>int 受影响行数</returns>
        public bool Add(Users t)
        {
            SugarParameter[] parm = {
                new SugarParameter("@UserName",t.UserName),
                new SugarParameter("@UserPwd",t.UserPwd),
                new SugarParameter("@RoleIds",t.RoleIds),
                new SugarParameter("@RoleNames",t.RoleNames),
                new SugarParameter("@CollegeId",t.CollegeId),
                new SugarParameter("@MajorId",t.MajorId),
                new SugarParameter("@StageId",t.StageId),
                new SugarParameter("@IsUse",t.IsUse),
                new SugarParameter("@CreateDate",t.CreateDate),
                new SugarParameter("@rowCount",null,true)
            };
            var result = db.Ado.ExecuteCommand("exec  p_AddUsers @UserName,@UserPwd,@RoleIds,@RoleNames,@CollegeId,@MajorId,@StageId,@IsUse,@CreateDate,0", parm);
            return result > 0;
            
        }
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="Ids">用户ID</param>
        /// <returns>int 受影响行数</returns>
        public bool Delete(string Ids)
        {
            SugarParameter[] parm = {
                new SugarParameter("@UserId",Ids)
            };
            var result = db.Ado.ExecuteCommand("exec p_DeleteUsers @UserId", parm);
            return result > 0;
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
        public PageBox Query(DateTime? startDate, DateTime? endDate, string userName, int collegeId=0, int mjorId=0, int stageId=0, int pageIndex = 1, int pageSize = 3)
        {
            //总页数
            var pageCount = 0;
            //四表联查
            var list = db.Queryable<Users, Colleges, Stages, Majors>((us, co, st, ma) => new object[] { JoinType.Inner, us.CollegeId == co.CollegeId, JoinType.Inner, us.StageId == st.StageId, JoinType.Inner, us.MajorId == ma.MajorId }).Select((us, co, st, ma) => new { us.UserId,us.UserName,us.UserPwd,us.StageId,us.RoleNames,us.RoleIds,us.MajorId,us.IsUse,us.CreateDate,us.CollegeId, co.CollegeName, st.StageName,ma.MajorName });

            //查询开始时间
            if (!string.IsNullOrWhiteSpace(startDate.ToString()))
                list = list.Where(us => us.CreateDate >= startDate);
            //查询结束时间
            if (!string.IsNullOrWhiteSpace(endDate.ToString()))
                list = list.Where(us => us.CreateDate <= endDate);
            //用户查询
            if (!string.IsNullOrWhiteSpace(userName))
                list = list.Where(us => us.UserName.Contains(userName));
            //学院查询
            if (collegeId != 0)
                list = list.Where(us => us.CollegeId.Equals(collegeId));
            //专业查询
            if (mjorId != 0)
                list = list.Where(us => us.MajorId.Equals(mjorId));
            //阶段查询
            if (stageId != 0)
                list = list.Where(us => us.StageId.Equals(stageId));
            var listUser = list.ToPageList(pageIndex, pageSize, ref pageCount);
            PageBox page = new PageBox();
            page.PageIndex = pageIndex;
            page.PageCount = pageCount;
            page.Data = listUser;
            return page;
        }
        /// <summary>
        /// 根据ID获取用户信息
        /// </summary>
        /// <param name="Id">用户Id</param>
        /// <returns></returns>
        public Users QueryById(int Id)
        {
            var result = db.Queryable<Users>().InSingle(Id);
            return result;
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>int 受影响行数</returns>
        public bool Update(Users t)
        {
            SugarParameter[] parm = {
                new SugarParameter("@UserId",t.UserId),
                new SugarParameter("@UserName",t.UserName),
                new SugarParameter("@UserPwd",t.UserPwd),
                new SugarParameter("@RoleIds",t.RoleIds),
                new SugarParameter("@RoleNames",t.RoleNames),
                new SugarParameter("@CollegeId",t.CollegeId),
                new SugarParameter("@MajorId",t.MajorId),
                new SugarParameter("@StageId",t.StageId),
                new SugarParameter("@IsUse",t.IsUse),
                new SugarParameter("@CreateDate",t.CreateDate),
                new SugarParameter("@rowCount",null,true)
            };
            var result = db.Ado.ExecuteCommand("exec  p_UpdateUsers @UserId,@UserName,@UserPwd,@RoleIds,@RoleNames,@CollegeId,@MajorId,@StageId,@IsUse,@CreateDate,0", parm);
            return result > 0;
        }

        /// <summary>
        /// 获取学院
        /// </summary>
        /// <returns>返回学院信息</returns>
        public List<Colleges> GetColleges()
        {
            var result = db.Queryable<Colleges>().ToList();
            return result;
        }
        /// <summary>
        /// 根据学院ID获取专业
        /// </summary>
        /// <returns>返回专业信息</returns>
        public List<Majors> GetMajorsByCollegeId(int CollegeId)
        {
            var result = db.Queryable<Majors>().Where(m=>m.CollegeId.Equals(CollegeId)).ToList();
            return result;
        }
        /// <summary>
        /// 获取阶段
        /// </summary>
        /// <returns>返回阶段信息</returns>
        public List<Stages> GetStages(int MajorId)
        {
            var result = db.Queryable<Stages>().Where(m=>m.MajorId.Equals(MajorId)).ToList();
            return result;
        }

        /// <summary>
        /// 返回用户信息
        /// </summary>
        /// <returns></returns>
        public List<Users> GetUsers()
        {
            var result = db.Queryable<Users>().ToList();
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
            var getByWhere = db.Queryable<Users>().Where(it => it.UserName == UserName && it.UserPwd == UserPwd).ToList().FirstOrDefault();
            if (getByWhere != null)
            {
               return getByWhere;
            }
            return null;
        }

    }
}
