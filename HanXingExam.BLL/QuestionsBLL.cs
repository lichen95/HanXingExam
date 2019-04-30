using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.BLL
{
    using Entity;
    using HanXingExam.Common;
    using IBLL;
    using IDAL;
    /// <summary>
    /// ** 描述：试题业务逻辑层
    /// ** 创始时间：2018-11-05
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class QuestionsBLL:IQuestions_BLL
    {
        private IQuestions_DAL iQuestions_DAL;
        public QuestionsBLL(IQuestions_DAL _iQuestions_DAL)
        {
            iQuestions_DAL = _iQuestions_DAL;
        }
        /// <summary>
        /// 批量插入试题信息
        /// </summary>
        /// <param name="t">试题集合</param>
        /// <returns>返回bool 成功返回true 失败返回false</returns>
        public bool Add(List<Questions> t)
        {
            var result = iQuestions_DAL.Add(t);
            return result;
        }

        /// <summary>
        /// 删除试题
        /// </summary>
        /// <param name="Ids">试题Id</param>
        /// <returns>返回bool 成功返回true 失败返回false</returns>
        public bool Delete(string Ids)
        {
            var result = iQuestions_DAL.Delete(Ids);
            return result;
        }

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
        public PageBox Query(DateTime? startDate, DateTime? endDate, int pageIndex = 1, int pageSize = 2, string questionsName = "", int collegeId = 0, int mjorId = 0, int stageId = 0)
        {
            var result = iQuestions_DAL.Query(startDate, endDate, pageIndex, pageSize, questionsName, collegeId, mjorId, stageId);
            return result;
        }

        /// <summary>
        /// 根据Id查询试题信息
        /// </summary>
        /// <param name="Id">试题Id</param>
        /// <returns>返回试题</returns>
        public Questions QueryById(int Id)
        {
            var result = iQuestions_DAL.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 修改试题
        /// </summary>
        /// <param name="t">试题实体</param>
        /// <returns>返回bool 成功返回true 失败返回false</returns>
        public bool Update(Questions t)
        {
            var result = iQuestions_DAL.Update(t);
            return result;
        }
    }
}
