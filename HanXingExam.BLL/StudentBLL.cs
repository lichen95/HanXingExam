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
    using System.Data;

    /// <summary>
    /// ** 描述：学生业务逻辑层
    /// ** 创始时间：2018年11月4日10点30分
    /// ** 修改时间：-
    /// ** 作者：mqc
    /// </summary>
    public class StudentBLL : IStudent_BLL
    {
        private IStudent_DAL student_DAL;

        public StudentBLL(IStudent_DAL _student_DAL)
        {
            student_DAL = _student_DAL;
        }

        /// <summary>
        /// 学生信息添加方法
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 是否添加成功true成功，false失败</returns>
        public bool Add(Students m)
        {
            return student_DAL.Add(m);
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
                var result = student_DAL.AddList(t);
                //var result = db.Insertable<Questions>(t).ExecuteCommand();
                return result;
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
            return student_DAL.Delete(Ids);
        }

        /// <summary>
        /// 学生信息查询方法
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>PageBox 所有信息的实体</returns>
        public PageBox Query(DateTime? startDate, DateTime? endDate, int pageIndex = 1, int pageSize = 2, string StudentName = "", int collegeId = 0, int mjorId = 0, int stageId = 0, int classId = 0)
        {
            return student_DAL.Query(startDate, endDate, pageIndex, pageSize, StudentName, collegeId, mjorId, stageId, classId);
        }

        /// <summary>
        /// 学生信息编辑反填方法
        /// </summary>
        /// <param name="Id">要编辑的学院Id</param>
        /// <returns>Colleges 要编辑的学院信息</returns>
        public Students QueryById(int Id)
        {
            return student_DAL.QueryById(Id);
        }

        /// <summary>
        /// 班级信息查询方法
        /// </summary>
        /// <param name="Id">阶段Id</param>
        /// <returns>Classes 班级信息</returns>
        public List<Classes> QueryBySid()
        {
            return student_DAL.QueryBySid();
        }

        /// <summary>
        /// 学生信息修改方法
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 是否修改成功true成功，false失败</returns>
        public bool Update(Students m)
        {
            return student_DAL.Update(m);
        }
        /// <summary>
        /// 获取专业信息
        /// </summary>
        /// <returns>返回专业信息</returns>
        public List<Majors> GetMajors()
        {
            var result = student_DAL.GetMajors();
            return result;
        }
        /// <summary>
        /// ** 描述：学生登陆
        /// ** 创始时间：2018年11月6日
        /// ** 修改时间：-
        /// ** 作者：王宏丹
        /// </summary>
        public Students StudentLogin(string name, string pwd)
        {
            var result = student_DAL.StudentLogin(name, pwd);
            return result;
        }
        /// <summary>
        /// 获取学生信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetStudents()
        {
            var result = student_DAL.GetStudents();
            return result;
        }
        /// <summary>
        /// 获取阶段
        /// </summary>
        /// <returns>返回阶段信息</returns>
        public List<Stages> GetStages()
        {
            var result = student_DAL.GetStages();
            return result;
        }
    }
}
