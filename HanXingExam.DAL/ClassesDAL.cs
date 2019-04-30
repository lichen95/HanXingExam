using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.DAL
{
    using SqlSugar;
    using Entity;
    using IDAL;
    using HanXingExam.Common;

    /// <summary>
    /// ** 描述：班级数据访问层
    /// ** 创始时间：2018-11-04
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class ClassesDAL:IClasses_DAL
    {
        private SqlSugarClient db = null;
        public ClassesDAL()
        {
            if (db == null)
                db = SqlSugarClientHelper.SqlDBConnection;
        }

        /// <summary>
        /// 新增班级
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>返回bool 成功返回true 失败返回flase</returns>
        public bool Add(Classes t)
        {
            try
            {
                var result = db.Insertable<Classes>(t).ExecuteCommand();
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return false;
            }
           
        }

        /// <summary>
        /// 删除班级
        /// </summary>
        /// <param name="Ids">班级Id</param>
        /// <returns>返回bool 成功返回true 失败返回flase</returns>
        public bool Delete(string Ids)
        {
            try
            {
                var arr = Ids.Split(',');
                int[] output = Array.ConvertAll<string, int>(arr, delegate (string s) { return int.Parse(s); });
                var result = db.Deleteable<Classes>().In(arr).ExecuteCommand();
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return false;
            }
            
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="className">班级名称</param>
        /// <param name="collegeId">学院</param>
        /// <param name="mjorId">专业</param>
        /// <param name="stageId">阶段</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页几条</param>
        /// <returns>返回班级信息</returns>
        public PageBox Query(DateTime? startDate, DateTime? endDate, string className, int collegeId, int mjorId, int stageId, int pageIndex = 1, int pageSize = 3)
        {
            try
            {
                //总页数
                var pageCount = 0;
                //四表联查
                var list = db.Queryable<Classes, Colleges, Stages, Majors>((us, co, st, ma) => new object[] { JoinType.Inner, us.CollegeId == co.CollegeId, JoinType.Inner, us.StageId == st.StageId, JoinType.Inner, us.MajorId == ma.MajorId }).Select((us, co, st, ma) => new { us.ClassId, us.ClassName, us.StageId, us.MajorId, us.CreateDate, us.CollegeId, co.CollegeName, st.StageName, ma.MajorName });

                //查询开始时间
                if (!string.IsNullOrWhiteSpace(startDate.ToString()))
                    list = list.Where(us => us.CreateDate >= startDate);
                //查询结束时间
                if (!string.IsNullOrWhiteSpace(endDate.ToString()))
                    list = list.Where(us => us.CreateDate <= endDate);
                //用户查询
                if (!string.IsNullOrWhiteSpace(className))
                    list = list.Where(us => us.ClassName.Contains(className));
                //学院查询
                if (collegeId != 0)
                    list = list.Where(us => us.CollegeId.Equals(collegeId));
                //专业查询
                if (mjorId != 0)
                    list = list.Where(us => us.MajorId.Equals(mjorId));
                //阶段查询
                if (stageId != 0)
                    list = list.Where(us => us.StageId.Equals(stageId));
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
        /// 根据ID获取信息
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>返回实体</returns>
        public Classes QueryById(int Id)
        {
            try
            {
                var result = db.Queryable<Classes>().InSingle(Id);
                return result;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }

        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        public bool Update(Classes t)
        {
            try
            {
                var result = db.Updateable<Classes>(t).ExecuteCommand();
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
