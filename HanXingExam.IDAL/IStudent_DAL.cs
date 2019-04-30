using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.IDAL
{
    using HanXingExam.Common;
    using HanXingExam.Entity;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// ** 描述：学生数据访问接口
    /// ** 创始时间：2018年11月4日10点17分
    /// ** 修改时间：-
    /// ** 作者：mqc
    /// </summary>
    public interface IStudent_DAL : IDALBase<Students>
    {
        /// <summary>
        /// ** 描述：学生的查询方法
        /// ** 创始时间：2018年11月4日10点17分
        /// ** 修改时间：-
        /// ** 作者：mqc
        /// </summary>
        PageBox Query(DateTime? startDate, DateTime? endDate, int pageIndex = 1, int pageSize = 2, string StudentName = "", int collegeId = 0, int mjorId = 0, int stageId = 0, int classId = 0);

        /// <summary>
        /// ** 描述：班级的查询方法
        /// ** 创始时间：2018年11月4日14点07分
        /// ** 修改时间：-
        /// ** 作者：mqc
        /// </summary>
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
        Students StudentLogin(string Name,string pwd);
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
