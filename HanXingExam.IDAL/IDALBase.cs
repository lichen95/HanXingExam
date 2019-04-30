using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.IDAL
{
    /// <summary>
    /// ** 描述：公共接口
    /// ** 创始时间：2018-11-01
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public interface IDALBase<T> where T:class,new()
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        bool Add(T t);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        bool Update(T t);
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
        T QueryById(int Id);
    }
}
