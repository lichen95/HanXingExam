using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.IBLL
{
    using HanXingExam.Entity;
    using HanXingExam.Common;
    using System.Data;

    /// <summary>
    /// ** 描述：学生业务逻辑接口
    /// ** 创始时间：2018年11月4日10点20分
    /// ** 修改时间：-
    /// ** 作者：mqc
    /// </summary>
    public interface IStudent_BLL
    {
        /// <summary>
        /// 学生新增
        /// </summary>
        /// <param name="m">实体</param>
        /// <returns>bool true成功 false失败</returns>
        bool Add(Students m);

        /// <summary>
        /// 学生修改
        /// </summary>
        /// <param name="m">实体</param>
        /// <returns>bool true成功 false失败</returns>
        bool Update(Students m);

        /// <summary>
        /// 学生删除
        /// </summary>
        /// <param name="Id">学院Id</param>
        /// <returns>bool true成功 false失败</returns>
        bool Delete(string Ids);

        /// <summary>
        /// 学生反填
        /// </summary>
        /// <param name="Id">学院Id</param>
        /// <returns>Colleges 根据学院Id查找到的学院信息</returns>
        Students QueryById(int Id);

        /// <summary>
        /// 学生信息查询
        /// </summary>
        /// <param name="Id">学院Id</param>
        /// <returns>List<Colleges> 所有的学院信息</returns>
        PageBox Query(DateTime? startDate, DateTime? endDate, int pageIndex = 1, int pageSize = 2, string StudentName = "", int collegeId = 0, int mjorId = 0, int stageId = 0, int classId = 0);

        // <summary>
        /// 班级信息查询
        /// </summary>
        /// <param name="Id">阶段Id</param>
        /// <returns>List<Colleges> 所有的班级信息</returns>
        List<Classes> QueryBySid();
        /// <summary>
        /// 获取专业
        /// </summary>
        /// <returns>返回专业信息</returns>
        List<Majors> GetMajors();
        /// <summary>
        /// ** 描述：学生登陆
        /// ** 创始时间：2018年11月6日
        /// ** 修改时间：-
        /// ** 作者：王宏丹
        /// </summary>
        /// <summary>
        /// 根据用户名和密码查询ID
        /// </summary>
        /// <param name="UserName">定义的用户名变量</param>
        /// <param name="UserPwd">定义的密码变量</param>
        /// <returns>返回</returns>
        Students StudentLogin(string name, string pwd);
        /// <summary>
        /// 获取学生信息
        /// </summary>
        /// <returns></returns>
        DataTable GetStudents();
        /// <summary>
        /// 获取阶段
        /// </summary>
        /// <returns>返回阶段信息</returns>
        List<Stages> GetStages();

        /// <summary>
        /// 批量插入学生信息
        /// </summary>
        /// <param name="t">学生集合</param>
        /// <returns>返回bool 成功返回true 失败返回false</returns>
        bool AddList(List<Students> t);
    }

}
