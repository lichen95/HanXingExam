using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.IDAL
{
    using HanXingExam.Common;
    using HanXingExam.Entity;

    /// <summary>
    /// ** 描述：权限表接口
    /// ** 创始时间：2018-11-02
    /// ** 修改时间：-
    /// ** 作者：zhq
    /// </summary>
    public interface IPermissions_DAL:IDALBase<Permissions>
    {
        /// <summary>
        /// 获取权限信息
        /// </summary>
        /// <param name="permissionName">权限名称</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页几条</param>
        /// <returns>返回分页类</returns>
        PageBox Query(string permissionName, int pageIndex = 1, int pageSize = 3);

        /// <summary>
        /// 获取用户加载权限
        /// </summary>
        /// <returns>返回用户信息</returns>
        List<Permissions> GetPermissionsById(int Id);
        /// <summary>
        /// 动态加载权限菜单
        /// </summary>
        /// <returns>返回用户信息</returns>
        List<Permissions> GetPermissions(int Id);
    }
}
