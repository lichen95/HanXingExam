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
    /// ** 描述：专业表数据访问类
    /// ** 创始时间：2018-11-04
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class MajorsDAL : IMajors_DAL
    {
        private SqlSugarClient db = null;
        public MajorsDAL()
        {
            if (db == null)
                db = SqlSugarClientHelper.SqlDBConnection;
        }
        /// <summary>
        /// 新增专业
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Add(Majors t)
        {
            try
            {
                var result = db.Insertable<Majors>(t).ExecuteCommand();
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return false;
            }
        }

        /// <summary>
        /// 删除专业
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public bool Delete(string Ids)
        {
            try
            {
                var arr = Ids.Split(',');
                //string[] input = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                int[] output = Array.ConvertAll<string, int>(arr, delegate (string s) { return int.Parse(s); });
                var result = db.Deleteable<Majors>().In(arr).ExecuteCommand();
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return false;
            }

        }

        /// <summary>
        /// 查询专业表
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="majorName">专业名称</param>
        /// <param name="collegeId">学院Id</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页几条</param>
        /// <returns>返回分页类</returns>
        public PageBox Query(DateTime? startDate, DateTime? endDate, string majorName, int collegeId, int pageIndex = 1, int pageSize = 3)
        {
            try
            {
                //总页数
                var pageCount = 0;
                //四表联查
                var list = db.Queryable<Majors, Colleges>((ma, co) => new object[] { JoinType.Inner, ma.CollegeId == co.CollegeId }).Select((ma, co) => new { ma.MajorId, ma.MajorName, ma.CollegeId, ma.CreateDate, co.CollegeName });

                //查询开始时间
                if (!string.IsNullOrWhiteSpace(startDate.ToString()))
                    list = list.Where(ma => ma.CreateDate >= startDate);
                //查询结束时间
                if (!string.IsNullOrWhiteSpace(endDate.ToString()))
                    list = list.Where(ma => ma.CreateDate <= endDate);
                //专业查询
                if (!string.IsNullOrWhiteSpace(majorName))
                    list = list.Where(ma => ma.MajorName.Contains(majorName));
                //学院查询
                if (collegeId != 0)
                    list = list.Where(ma => ma.CollegeId.Equals(collegeId));
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
        /// 根据Id查询专业信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Majors QueryById(int Id)
        {
            try
            {
                var result = db.Queryable<Majors>().InSingle(Id);
                return result;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 修改专业
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Update(Majors t)
        {
            try
            {
                var result = db.Updateable<Majors>(t).ExecuteCommand();
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
