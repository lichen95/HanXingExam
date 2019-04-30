using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.IBLL
{
    using HanXingExam.Common;
    using HanXingExam.Entity;

    /// <summary>
    /// ** 描述：学院业务逻辑接口
    /// ** 创始时间：2018年11月2日10点30分
    /// ** 修改时间：-
    /// ** 作者：mqc
    /// </summary>
    public interface ICollege_BLL
    {
        /// <summary>
        /// 学院新增
        /// </summary>
        /// <param name="m">实体</param>
        /// <returns>bool true成功 false失败</returns>
        bool Add(Colleges m);
        /// <summary>
        /// 学院修改
        /// </summary>
        /// <param name="m">实体</param>
        /// <returns>bool true成功 false失败</returns>
        bool Update(Colleges m);
        /// <summary>
        /// 学院删除
        /// </summary>
        /// <param name="Id">学院Id</param>
        /// <returns>bool true成功 false失败</returns>
        bool Delete(string Ids);
        /// <summary>
        /// 学院反填
        /// </summary>
        /// <param name="Id">学院Id</param>
        /// <returns>Colleges 根据学院Id查找到的学院信息</returns>
        Colleges QueryById(int Id);
        /// <summary>
        /// 学院信息查询
        /// </summary>
        /// <param name="Id">学院Id</param>
        /// <returns>List<Colleges> 所有的学院信息</returns>
        PageBox Query(DateTime? startDate, DateTime? endDate, int pageIndex = 1, int pageSize = 2, string CollegeName = "");
    }
}
