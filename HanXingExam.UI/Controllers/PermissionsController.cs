using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanXingExam.UI.Controllers
{
    using HanXingExam.Entity;
    using HanXingExam.IBLL;
    using Newtonsoft.Json;
    /// <summary>
    /// ** 描述：权限控制器
    /// ** 创始时间：2018-11-02
    /// ** 修改时间：-
    /// ** 作者：zhq
    /// </summary>
    public class PermissionsController : Controller
    {
        private IPermissions_BLL ipermissions_bll;

        public PermissionsController(IPermissions_BLL _ipermissions_bll)
        {
            ipermissions_bll = _ipermissions_bll;
        }


        /// <summary>
        /// 获取权限信息
        /// </summary>
        /// <param name="permissionName">权限名称</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页几条</param>
        /// <returns>返回分页类</returns>
        public string Query(string permissionName, int pageIndex = 1, int pageSize = 3)
        {
            var result = ipermissions_bll.Query(permissionName, pageIndex, pageSize);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        public bool AddPermissions(Permissions p)
        {
            p.IsUse = 1;
            p.CreateDate = DateTime.Now;
            var result = ipermissions_bll.Add(p);
            return result;

        }
        /// <summary>
        /// 删除权限
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public bool DeletePermissions(string Ids)
        {
            var result = ipermissions_bll.Delete(Ids);
            return result;
        }


        /// <summary>
        /// 根据Id查询信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string QueryById(int Id)
        {
            var result = ipermissions_bll.QueryById(Id);
            return JsonConvert.SerializeObject(result);
        }
        /// <summary>
        /// 更新权限
        /// </summary>
        /// <returns></returns>
        public bool UpdatePermissions(Permissions p)
        {
            var result = ipermissions_bll.Update(p);
            return result;
        }

        /// <summary>
        /// ** 描述：用户接口
        /// ** 创始时间：2018-11-05
        /// ** 修改时间：-
        /// ** 作者：whd
        /// </summary>

        /// <summary>
        /// 获取用户加载权限
        /// </summary>
        /// <returns>返回用户信息</returns>
        public string GetPermissionsById(int Id)
        {
            var result = ipermissions_bll.GetPermissionsById(Id);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 动态加载权限菜单
        /// </summary>
        /// <returns>返回用户信息</returns>
        public string GetPermissions(int Id)
        {
            var result = ipermissions_bll.GetPermissions(Id);
            return JsonConvert.SerializeObject(result);
        }
    }

}