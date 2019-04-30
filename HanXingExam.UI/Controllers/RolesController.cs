using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanXingExam.UI.Controllers
{
    using IBLL;
    using Entity;
    using Newtonsoft.Json;
    /// <summary>
    /// ** 描述：角色控制器
    /// ** 创始时间：2018-11-02
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class RolesController : Controller
    {
        private IRoles_BLL iRoles_BLL;
        public RolesController(IRoles_BLL _iRoles_BLL)
        {
            iRoles_BLL = _iRoles_BLL;
        }

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        [HttpPost]
        public bool Add(string PermissionIds,string PermissionNames,string RoleName)
        {
            Roles t = new Roles();
            t.RoleName = RoleName;
            t.PermissionIds = PermissionIds;
            t.PermissionNames = PermissionNames;
            t.IsUse = 1;
            t.CreateDate = DateTime.Now;
            var result = iRoles_BLL.Add(t);
            return result;
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="Ids">角色ID</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        [HttpPost]
        public bool Delete(string Ids)
        {
            var result = false;
            var arr = Ids.Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                result = iRoles_BLL.Delete(arr[i]);
            }
            return result;
        }

        /// <summary>
        /// 根据PID查询权限信息
        /// </summary>
        /// <param name="PId">父级ID</param>
        /// <returns>返回权限信息list集合</returns>
        [HttpPost]
        public string GetPermissions(int PId = 0)
        {
            var result = iRoles_BLL.GetPermissions(PId);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 查询角色信息
        /// </summary>
        /// <returns>返回角色信息</returns>
        [HttpPost]
        public string Query()
        {
            //list 
            var result = iRoles_BLL.Query();
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 根据Id获取角色信息
        /// </summary>
        /// <param name="Id">角色Id</param>
        /// <returns>返回角色实体</returns>
        [HttpPost]
        public string QueryById(int Id)
        {
            var result = iRoles_BLL.QueryById(Id);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        [HttpPost]
        public bool Update(int Id,string PermissionIds, string PermissionNames, string RoleName,DateTime CreateDate)
        {
            Roles t = new Roles();
            t.RoleId = Id;
            t.RoleName = RoleName;
            t.PermissionIds = PermissionIds;
            t.PermissionNames = PermissionNames;
            t.IsUse = 1;
            t.CreateDate = CreateDate;
            var result = iRoles_BLL.Update(t);
            return result;
        }
    }
}