using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.DAL
{
    using Entity;
    using HanXingExam.Common;
    using IDAL;
    using SqlSugar;
    /// <summary>
    /// ** 描述：阶段表数据操作类
    /// ** 创始时间：2018-11-02
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class StagesDAL : IStages_DAL
    {
        private SqlSugarClient db = null;
        public StagesDAL()
        {
            if (db == null)
                db = SqlSugarClientHelper.SqlDBConnection;
        }

        /// <summary>
        /// 新增阶段信息
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        public bool Add(Stages t)
        {
            try
            {
                var result = db.Insertable<Stages>(t).ExecuteCommand();
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return false;
            }

        }

        /// <summary>
        /// 根据ID删除阶段信息
        /// </summary>
        /// <param name="Ids">ID</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        public bool Delete(string Ids)
        {
            try
            {
                var arr = Ids.Split(',');
                //string[] input = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                int[] output = Array.ConvertAll<string, int>(arr, delegate (string s) { return int.Parse(s); });
                var result = db.Deleteable<Stages>().In(arr).ExecuteCommand();
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return false;
            }
        }

        /// <summary>
        /// 查询阶段信息
        /// </summary>
        /// <returns>返回阶段信息</returns>
        public PageBox Query(DateTime? startDate, DateTime? endDate, string stageName, int collegeId, int mjorId, int pageIndex = 1, int pageSize = 3)
        {
            try
            {
                //总页数
                var pageCount = 0;
                //四表联查
                var list = db.Queryable<Stages, Colleges, Majors>((st, co, ma) => new object[] { JoinType.Inner, st.CollegeId == co.CollegeId, JoinType.Inner, st.MajorId == ma.MajorId }).Select((st, co, ma) => new { st.CollegeId, st.CreateDate, st.MajorId, st.StageId, st.StageName, co.CollegeName, ma.MajorName });

                //查询开始时间
                if (!string.IsNullOrWhiteSpace(startDate.ToString()))
                    list = list.Where(st => st.CreateDate >= startDate);
                //查询结束时间
                if (!string.IsNullOrWhiteSpace(endDate.ToString()))
                    list = list.Where(st => st.CreateDate <= endDate);
                //用户查询
                if (!string.IsNullOrWhiteSpace(stageName))
                    list = list.Where(st => st.StageName.Contains(stageName));
                //学院查询
                if (collegeId != 0)
                    list = list.Where(st => st.CollegeId.Equals(collegeId));
                //专业查询
                if (mjorId != 0)
                    list = list.Where(st => st.MajorId.Equals(mjorId));
                var listUser = list.ToPageList(pageIndex, pageSize, ref pageCount);
                PageBox page = new PageBox();
                page.PageIndex = pageIndex;
                page.PageCount = pageCount;
                page.Data = listUser;
                return page;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 根据Id查询阶段信息
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>返回实体</returns>
        public Stages QueryById(int Id)
        {
            try
            {
                var result = db.Queryable<Stages>().InSingle(Id);
                return result;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 更新阶段信息
        /// </summary>
        /// <param name="obj">实体</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        public bool Update(Stages obj)
        {
            try
            {
                var result = db.Updateable<Stages>(obj).ExecuteCommand();
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return false;
            }
        }
    }
}
