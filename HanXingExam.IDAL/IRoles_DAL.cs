using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.IDAL
{
    using Entity;
    using Common;
    /// <summary>
    /// ** 描述：角色DAL接口
    /// ** 创始时间：2018-11-02
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public interface IRoles_DAL:IDALBase<Roles>
    {
        /// <summary>
        /// 查询角色信息
        /// </summary>
        /// <returns>返回角色信息</returns>
        List<Roles> Query();

        /// <summary>
        /// 根据PID获取权限信息
        /// </summary>
        /// <param name="PId">父级Id 可选参数</param>
        /// <returns>List<Permissions> 返回权限信息 </returns>
        List<Permissions> GetPermissions(int PId=0);
    }
}
