using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.DAL
{
    using HanXingExam.Entity;
    using HanXingExam.IDAL;
    using HanXingExam.Common;
    using SqlSugar;
    using System.Data;

    /// <summary>
    /// ** 描述：学生数据访问层
    /// ** 创始时间：2018年11月4日10点26分
    /// ** 修改时间：-
    /// ** 作者：mqc
    /// </summary>
    public class StudentDAL : IStudent_DAL
    {
        private SqlSugarClient sugar;

        public StudentDAL()
        {
            if (sugar == null)
            {
                sugar = SqlSugarClientHelper.SqlDBConnection;
            }
        }

        /// <summary>
        /// 学生信息添加方法
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 是否添加成功true成功，false失败</returns>
        public bool Add(Students t)
        {
            try
            {
                return sugar.Insertable<Students>(t).ExecuteCommand() > 0;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return false;
            }

        }
        /// <summary>
        /// 批量插入学生信息
        /// </summary>
        /// <param name="t">学生集合</param>
        /// <returns>返回bool 成功返回true 失败返回false</returns>
        public bool AddList(List<Students> t)
        {
            try
            {
                var result = sugar.Insertable(t.ToArray()).ExecuteCommand();
                //var result = db.Insertable<Questions>(t).ExecuteCommand();
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return false;
            }
        }

        /// <summary>
        /// 学生信息删除方法
        /// </summary>
        /// <param name="Ids">要删除的学院Id</param>
        /// <returns>bool 是否删除成功true成功，false失败</returns>
        public bool Delete(string Ids)
        {
            try
            {
                var id = Ids.Split(',');
                int[] output = Array.ConvertAll<string, int>(id, delegate (string s) { return int.Parse(s); });
                return sugar.Deleteable<Students>().In(id).ExecuteCommand() > 0;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return false;
            }
        }

        /// <summary>
        /// 获取专业信息
        /// </summary>
        /// <returns>返回专业信息</returns>
        public List<Majors> GetMajors()
        {
            try
            {
                var result = sugar.Queryable<Majors>().ToList();
                return result;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }
        }


        /// <summary>
        /// 学生信息查询方法
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>PageBox 所有信息的实体</returns>
        public PageBox Query(DateTime? startDate, DateTime? endDate, int pageIndex = 1, int pageSize = 2, string StudentName = "", int collegeId = 0, int mjorId = 0, int stageId = 0,int classId=0)
        {
            try
            {
                var pageCount = 0;
                //五表联查
                var list = sugar.Queryable<Students, Classes, Colleges, Stages, Majors>((s, cl, co, st, ma) => new object[] { JoinType.Inner, s.ClassId == cl.ClassId, JoinType.Inner, s.CollegeId == co.CollegeId, JoinType.Inner, s.StageId == st.StageId, JoinType.Inner, s.MajorId == ma.MajorId }).Select((s, cl, co, st, ma) => new { s.StudentId, s.StudentNum, s.StudentName, s.StudentIdCard, s.CreateDate, s.CreateUserId, s.StudentPwd, cl.ClassName, co.CollegeName, st.StageName, ma.MajorName, s.CollegeId, s.MajorId, s.StageId, s.ClassId });
                if (!string.IsNullOrWhiteSpace(startDate.ToString()))
                {
                    list = list.Where(s => s.CreateDate >= startDate);
                }
                if (!string.IsNullOrWhiteSpace(endDate.ToString()))
                {
                    list = list.Where(s => s.CreateDate <= endDate);
                }
                if (!string.IsNullOrWhiteSpace(StudentName))
                {
                    list = list.Where(s => s.StudentName.Contains(StudentName));
                }
                //学院查询
                if (collegeId != 0)
                    list = list.Where(s => s.CollegeId.Equals(collegeId));
                //专业查询
                if (mjorId != 0)
                    list = list.Where(s => s.MajorId.Equals(mjorId));
                //阶段查询
                if (stageId != 0)
                    list = list.Where(s => s.StageId.Equals(stageId));
                //班级查询
                if (classId != 0)
                    list = list.Where(s => s.ClassId.Equals(classId));
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
        /// 学生信息编辑反填方法
        /// </summary>
        /// <param name="Id">要编辑的学院Id</param>
        /// <returns>Colleges 要编辑的学院信息</returns>
        public Students QueryById(int Id)
        {
            try
            {
                return sugar.Queryable<Students>().InSingle(Id);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 班级信息查询方法
        /// </summary>
        /// <param name="Id">阶段Id</param>
        /// <returns>Classes 班级信息</returns>
        public List<Classes> QueryBySid()
        {
            try
            {
                var result = sugar.Queryable<Classes>().ToList();
                return result;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 学生信息修改方法
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 是否修改成功true成功，false失败</returns>
        public bool Update(Students t)
        {
            try
            {
                return sugar.Updateable<Students>(t).ExecuteCommand() > 0;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return false;
            }

        }
        /// <summary>
        /// ** 描述：学生登陆
        /// ** 创始时间：2018年11月6日
        /// ** 修改时间：-
        /// ** 作者：王宏丹
        /// </summary>
        public Students StudentLogin(string name, string pwd)
        {
            try
            {
                var studentLogin = sugar.Queryable<Students>().Where(it => it.StudentNum == name && it.StudentPwd == pwd).ToList().FirstOrDefault();
                if (studentLogin != null)
                {
                    return studentLogin;
                }
                return null;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 获取学生信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetStudents()
        {
            try
            {
                var result = sugar.Ado.GetDataTable("select * from Students");
                return result;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }

        }

        /// <summary>
        /// 获取阶段
        /// </summary>
        /// <returns>返回阶段信息</returns>
        public List<Stages> GetStages()
        {
            try
            {
                var result = sugar.Queryable<Stages>().ToList();
                return result;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }

        }
    }
}
