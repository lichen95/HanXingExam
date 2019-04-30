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
    /// ** 描述：权限业务逻辑类
    /// ** 创始时间：2018-11-02
    /// ** 修改时间：-
    /// ** 作者：zhq
    /// </summary>
    public class PermissionsBLL : IPermissions_BLL
    {
        private IPermissions_DAL ipermissions_dal;

        public PermissionsBLL(IPermissions_DAL _ipermissions_dal)
        {
            ipermissions_dal = _ipermissions_dal;
        }
        /// <summary>
        /// 权限添加
        /// </summary>
        /// <param name="t">权限实体</param>
        /// <returns></returns>

        public bool Add(Permissions t)
        {
            var result = ipermissions_dal.Add(t);
            return result;
        }
        /// <summary>
        /// 权限删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete(string Id)
        {
            var result = ipermissions_dal.Delete(Id);
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
        public List<Permissions> GetPermissionsById(int Id)
        {
            var result = ipermissions_dal.GetPermissionsById(Id);
            return result;
        }
        /// <summary>
        /// 动态加载权限菜单
        /// </summary>
        /// <returns>返回用户信息</returns>
        public List<Permissions> GetPermissions(int Id)
        {
            var getPermissions = ipermissions_dal.GetPermissions(Id);
            return getPermissions;
        }

        /// <summary>
        /// 获取权限信息
        /// </summary>
        /// <param name="permissionName">权限名称</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页几条</param>
        /// <returns>返回分页类</returns>
        public PageBox Query(string permissionName, int pageIndex = 1, int pageSize = 3)
        {
            var result=ipermissions_dal.Query(permissionName, pageIndex, pageSize);
            return result;
        }
        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Permissions QueryById(int Id)
        {
            var result = ipermissions_dal.QueryById(Id);
            return result;
        }
        /// <summary>
        /// 权限查询
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Update(Permissions t)
        {
            var result = ipermissions_dal.Update(t);
            return result;
        }
    }
}
