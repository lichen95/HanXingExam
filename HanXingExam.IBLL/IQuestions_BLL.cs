using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.IBLL
{
    using Common;
    using Entity;
    /// <summary>
    /// ** 描述：试题业务逻辑接口
    /// ** 创始时间：2018-11-05
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public interface IQuestions_BLL
    {
        /// <summary>
        /// 查询试题
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示几条</param>
        /// <param name="questionsName">题干</param>
        /// <param name="collegeId">学院</param>
        /// <param name="mjorId">专业</param>
        /// <param name="stageId">阶段</param>
        /// <returns>返回分页类</returns>
        PageBox Query(DateTime? startDate, DateTime? endDate, int pageIndex = 1, int pageSize = 2, string questionsName = "", int collegeId = 0, int mjorId = 0, int stageId = 0);
        /// <summary>
        /// 批量添加试题
        /// </summary>
        /// <param name="t">试题实体集合</param>
        /// <returns>返回bool 成功返回true 失败返回false</returns>
        bool Add(List<Questions> t);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 成功返回true 失败返回false</returns>
        bool Update(Questions t);
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
        Questions QueryById(int Id);
    }
}
