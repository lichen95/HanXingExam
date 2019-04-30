using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.DAL
{
    using Entity;
    using IDAL;
    using Common;
    using SqlSugar;
    /// <summary>
    /// ** 描述：角色数据操作类
    /// ** 创始时间：2018-11-02
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class RolesDAL :IRoles_DAL
    {
        private SqlSugarClient db=null;
        public RolesDAL()
        {
            if (db == null)
                db = SqlSugarClientHelper.SqlDBConnection;
        }
        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        public bool Add(Roles t)
        {
            try
            {
                SugarParameter[] parms = {
                new SugarParameter("@RoleName",t.RoleName),
                new SugarParameter("@PermissionIds",t.PermissionIds),
                new SugarParameter("@PermissionNames",t.PermissionNames),
                new SugarParameter("@IsUse",t.IsUse),
                new SugarParameter("@CreateDate",t.CreateDate),
                new SugarParameter("@rowCount",null,true)
            };
                var result = db.Ado.ExecuteCommand("exec p_AddRoles @RoleName,@PermissionIds,@PermissionNames,@IsUse,@CreateDate,0", parms);
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return false;
            }
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="Ids">角色ID</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        public bool Delete(string Ids)
        {
            try
            {
                SugarParameter[] parms = {
                new SugarParameter("@id",Ids)
            };
                var result = db.Ado.ExecuteCommand(" exec p_DeleteRoles @id", parms);
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return false;
            }
        }

        /// <summary>
        /// 根据PID查询权限信息
        /// </summary>
        /// <param name="PId">父级ID</param>
        /// <returns>返回权限信息list集合</returns>
        public List<Permissions> GetPermissions(int PId = 0)
        {
            try
            {
                var result = db.Queryable<Permissions>().Where(m => m.PId.Equals(PId)).ToList();
                return result;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 查询角色信息
        /// </summary>
        /// <returns>返回角色信息</returns>
       public List<Roles> Query()
        {
            try
            {
                //list 
                var result = db.Queryable<Roles>().ToList();
                return result;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }

        }

        /// <summary>
        /// 根据Id获取角色信息
        /// </summary>
        /// <param name="Id">角色Id</param>
        /// <returns>返回角色实体</returns>
        public Roles QueryById(int Id)
        {
            try
            {
                var result = db.Queryable<Roles>().InSingle(Id);
                return result;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        public bool Update(Roles t)
        {
            try
            {
                SugarParameter[] parms = {
                 new SugarParameter("@RoleId",t.RoleId),
                new SugarParameter("@RoleName",t.RoleName),
                new SugarParameter("@PermissionIds",t.PermissionIds),
                new SugarParameter("@PermissionNames",t.PermissionNames),
                new SugarParameter("@IsUse",t.IsUse),
                new SugarParameter("@CreateDate",t.CreateDate),
                new SugarParameter("@rowCount",null,true)
            };
                var result = db.Ado.ExecuteCommand("exec p_UpdateRoles  @RoleId,@RoleName,@PermissionIds,@PermissionNames,@IsUse,@CreateDate,0", parms);
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return false;
            }

        }
    }
}
