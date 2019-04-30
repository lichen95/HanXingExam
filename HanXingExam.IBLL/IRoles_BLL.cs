using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.IBLL
{
    using Entity;
    using Common;
    /// <summary>
    /// ** 描述：角色BLL接口
    /// ** 创始时间：2018-11-02
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public interface IRoles_BLL
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        bool Add(Roles t);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        bool Update(Roles t);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids">Id集合</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        bool Delete(string Ids);
        /// <summary>
        /// 根据ID获取信息
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        Roles QueryById(int Id);

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns>返回角色信息</returns>
        List<Roles> Query();

        /// <summary>
        /// 根据PID获取权限信息
        /// </summary>
        /// <param name="PId">父级Id 可选参数</param>
        /// <returns>List<Permissions>返回权限信息 </returns>
        List<Permissions> GetPermissions(int PId = 0);
    }
}
