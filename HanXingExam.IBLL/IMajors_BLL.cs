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
    /// ** 描述：专业业务逻辑接口
    /// ** 创始时间：2018-11-04
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public interface IMajors_BLL
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        bool Add(Majors t);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        bool Update(Majors t);
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
        /// <returns>返回实体</returns>
        Majors QueryById(int Id);
        /// <summary>
        /// 专业表
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="majorName">专业名称</param>
        /// <param name="collegeId">学院Id</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页几条</param>
        /// <returns>返回分页类</returns>
        PageBox Query(DateTime? startDate, DateTime? endDate, string majorName, int collegeId, int pageIndex = 1, int pageSize = 3);
    }
}
