using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.BLL
{
    using IBLL;
    using IDAL;
    using Common;
    using Entity;
    /// <summary>
    /// ** 描述：角色业务逻辑层
    /// ** 创始时间：2018-11-02
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class RolesBLL:IRoles_BLL
    {
        private IRoles_DAL iRoles_DAL;
        public RolesBLL(IRoles_DAL _iRoles_DAL)
        {
            iRoles_DAL = _iRoles_DAL;
        }
        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        public bool Add(Roles t)
        {
            var result = iRoles_DAL.Add(t);
            return result;
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="Ids">角色ID</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        public bool Delete(string Ids)
        {
            var result = iRoles_DAL.Delete(Ids);
            return result;
        }

        /// <summary>
        /// 根据PID查询权限信息
        /// </summary>
        /// <param name="PId">父级ID</param>
        /// <returns>返回权限信息list集合</returns>
        public List<Permissions> GetPermissions(int PId = 0)
        {
            var result = iRoles_DAL.GetPermissions(PId);
            return result;
        }

        /// <summary>
        /// 查询角色信息
        /// </summary>
        /// <returns>返回角色信息</returns>
        public List<Roles> Query()
        {
            //list 
            var result = iRoles_DAL.Query();
            return result;
        }

        /// <summary>
        /// 根据Id获取角色信息
        /// </summary>
        /// <param name="Id">角色Id</param>
        /// <returns>返回角色实体</returns>
        public Roles QueryById(int Id)
        {
            var result = iRoles_DAL.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        public bool Update(Roles t)
        {
            var result = iRoles_DAL.Update(t);
            return result;
        }
    }
}
