using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.BLL
{
    using HanXingExam.IBLL;
    using HanXingExam.Entity;
    using HanXingExam.IDAL;
    using HanXingExam.Common;

    /// <summary>
    /// ** 描述：学院业务逻辑层
    /// ** 创始时间：2018年11月2日10点30分
    /// ** 修改时间：-
    /// ** 作者：mqc
    /// </summary>
    public class CollegeBLL : ICollege_BLL
    {
        private ICollege_DAL college_DAL;

        public CollegeBLL(ICollege_DAL _college_DAL)
        {
            college_DAL = _college_DAL;
        }

        /// <summary>
        /// 学院信息添加方法
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 是否添加成功true成功，false失败</returns>
        public bool Add(Colleges m)
        {
            return college_DAL.Add(m);
        }

        /// <summary>
        /// 学院信息删除方法
        /// </summary>
        /// <param name="Ids">要删除的学院Id</param>
        /// <returns>bool 是否删除成功true成功，false失败</returns>
        public bool Delete(string Ids)
        {
            return college_DAL.Delete(Ids);
        }

        /// <summary>
        /// 学院信息查询方法
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>PageBox 所有信息的实体</returns>
        public PageBox Query(DateTime? startDate, DateTime? endDate, int pageIndex = 1, int pageSize = 2, string CollegeName = "")
        {
            return college_DAL.Query(startDate, endDate, pageIndex, pageSize, CollegeName);
        }

        /// <summary>
        /// 学院信息编辑反填方法
        /// </summary>
        /// <param name="Id">要编辑的学院Id</param>
        /// <returns>Colleges 要编辑的学院信息</returns>
        public Colleges QueryById(int Id)
        {
            return college_DAL.QueryById(Id);
        }

        /// <summary>
        /// 学院信息修改方法
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 是否修改成功true成功，false失败</returns>
        public bool Update(Colleges m)
        {
            return college_DAL.Update(m);
        }
    }
}
