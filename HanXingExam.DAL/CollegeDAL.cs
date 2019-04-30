using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.DAL
{
    using HanXingExam.Common;
    using HanXingExam.Entity;
    using HanXingExam.IDAL;
    using SqlSugar;

    /// <summary>
    /// ** 描述：学院数据访问层
    /// ** 创始时间：2018年11月2日10点30分
    /// ** 修改时间：-
    /// ** 作者：mqc
    /// </summary>
    public class CollegeDAL : ICollege_DAL
    {
        private SqlSugarClient sugar;

        public CollegeDAL()
        {
            if (sugar == null)
            {
                sugar = SqlSugarClientHelper.SqlDBConnection;
            }
        }

        /// <summary>
        /// 学院信息添加方法
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 是否添加成功true成功，false失败</returns>
        public bool Add(Colleges t)
        {
            try
            {
                return sugar.Insertable<Colleges>(t).ExecuteCommand() > 0;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return false;
            }
           
        }

        /// <summary>
        /// 学院信息删除方法
        /// </summary>
        /// <param name="Ids">要删除的学院Id</param>
        /// <returns>bool 是否删除成功true成功，false失败</returns>
        public bool Delete(string Ids)
        {
            try
            {
                var id = Ids.Split(',');
                int[] output = Array.ConvertAll<string, int>(id, delegate (string s) { return int.Parse(s); });
                return sugar.Deleteable<Colleges>().In(id).ExecuteCommand() > 0;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return false;
            }

        }

        /// <summary>
        /// 学院信息查询方法
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>PageBox 所有信息的实体</returns>
        public PageBox Query(DateTime? startDate, DateTime? endDate, int pageIndex = 1, int pageSize = 2, string CollegeName = "")
        {
            try
            {
                var pageCount = 0;
                var list = sugar.Queryable<Colleges>();
                if (!string.IsNullOrWhiteSpace(startDate.ToString()))
                {
                    list = list.Where(m => m.CollegeCreateDate >= startDate);
                }
                if (!string.IsNullOrWhiteSpace(endDate.ToString()))
                {
                    list = list.Where(m => m.CollegeCreateDate <= endDate);
                }
                if (!string.IsNullOrWhiteSpace(CollegeName))
                {
                    list = list.Where(m => m.CollegeName.Contains(CollegeName));
                }
                var listResult = list.ToPageList(pageIndex, pageSize, ref pageCount);
                PageBox page = new PageBox();
                page.PageIndex = pageIndex;
                page.PageCount = pageCount;
                page.Data = listResult;
                return page;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }

        }

        /// <summary>
        /// 学院信息编辑反填方法
        /// </summary>
        /// <param name="Id">要编辑的学院Id</param>
        /// <returns>Colleges 要编辑的学院信息</returns>
        public Colleges QueryById(int Id)
        {
            try
            {
                return sugar.Queryable<Colleges>().InSingle(Id);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 学院信息修改方法
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 是否修改成功true成功，false失败</returns>
        public bool Update(Colleges t)
        {
            try
            {
                return sugar.Updateable<Colleges>(t).ExecuteCommand() > 0;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return false;
            }

        }
    }
}
