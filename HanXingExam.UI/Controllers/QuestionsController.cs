using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanXingExam.UI.Controllers
{

    using IBLL;
    using Entity;
    using Newtonsoft.Json;
    using NPOI.SS.UserModel;
    using NPOI.HSSF.UserModel;
    using NPOI.XSSF.UserModel;
    using System.Data;
    using HanXingExam.Common;

    /// <summary>
    /// ** 描述：试题控制器
    /// ** 创始时间：2018-11-05
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class QuestionsController : Controller
    {
        private IQuestions_BLL iQuestions_BLL;
        public QuestionsController(IQuestions_BLL _iQuestions_BLL)
        {
            iQuestions_BLL = _iQuestions_BLL;
        }
        /// <summary>
        /// 批量插入试题信息
        /// </summary>
        /// <param name="t">试题集合</param>
        /// <returns>返回bool 成功返回true 失败返回false</returns>
        [HttpPost]
        public bool Add(Questions q)
        {
            q.Answer = q.Answer.ToUpper();
            q.QuestionNum = DateTime.Now.Ticks.ToString();
            q.CreateDate = DateTime.Now;
            List<Questions> t = new List<Questions>();
            t.Add(q);
            var result = iQuestions_BLL.Add(t);
            return result;
        }

        /// <summary>
        /// 删除试题
        /// </summary>
        /// <param name="Ids">试题Id</param>
        /// <returns>返回bool 成功返回true 失败返回false</returns>
        [HttpPost]
        public bool Delete(string Ids)
        {
            var result = iQuestions_BLL.Delete(Ids);
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
        [HttpPost]
        public string Query(DateTime? startDate, DateTime? endDate, int pageIndex = 1, int pageSize = 3, string questionsName = "", int collegeId = 0, int mjorId = 0, int stageId = 0)
        {
            var result = iQuestions_BLL.Query(startDate, endDate, pageIndex, pageSize, questionsName, collegeId, mjorId, stageId);
            return JsonConvert.SerializeObject(result);
        }



        /// <summary>
        /// 根据Id查询试题信息
        /// </summary>
        /// <param name="Id">试题Id</param>
        /// <returns>返回试题</returns>
        [HttpPost]
        public string QueryById(int Id)
        {
            var result = iQuestions_BLL.QueryById(Id);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 修改试题
        /// </summary>
        /// <param name="t">试题实体</param>
        /// <returns>返回bool 成功返回true 失败返回false</returns>
        [HttpPost]
        public bool Update(Questions t)
        {
            var result = iQuestions_BLL.Update(t);
            return result;
        }

        /// <summary>
        /// 导入试题信息
        /// </summary>
        /// <param name="UsersId"></param>
        /// <returns></returns>
        [HttpPost]
        public int InputQuestions(int UsersId = 1)
        {
            try
            {
                var result = 0;
                HttpPostedFileBase file = Request.Files[0];
                if (null != file)
                {
                    IWorkbook wk = null;
                    //.xlsx 应该XSSFWorkbook workbook = new XSSFWorkbook(file); 而xls应该用 HSSFWorkbook workbook = new HSSFWorkbook(file);
                    var f = file.FileName.Substring(file.FileName.LastIndexOf('.'));
                    if (f.Equals(".xls"))
                    {
                        //把xls文件中的数据写入wk中
                        wk = new HSSFWorkbook(file.InputStream);
                    }
                    else
                    {
                        //把xlsx文件中的数据写入wk中
                        wk = new XSSFWorkbook(file.InputStream);
                    }
                    ISheet sheet = wk.GetSheetAt(0);
                    IRow row = null;//读取当前行数据
                    List<Questions> list = new List<Questions>();
                    //LastRowNum 是当前表的总行数-1
                    for (int k = 1; k <= sheet.LastRowNum; k++)
                    {
                        row = sheet.GetRow(k);//读取当前行数据
                        Questions model = new Questions();
                        if (row != null)
                        {
                            //LastRowNum 是当前表的总行数-1
                            for (int j = 0; j < row.LastCellNum; j++)
                            {
                                if (j == 0)
                                {
                                    continue;
                                }
                                //读取该行的第j列数据
                                model.QuestionNum = BaseRandom.GenerateIntID().ToString();

                                var collegeName = row.GetCell(2).ToString();
                                var strColleges = HttpUtility.UrlDecode(CookiesHelper.GetCookie("Colleges"));
                                var listColleges = JsonConvert.DeserializeObject<List<Colleges>>(strColleges);
                                var collegeId = listColleges.Where(m => m.CollegeName.Equals(collegeName)).FirstOrDefault().CollegeId;
                                model.CollegeId = collegeId;

                                var majorName = row.GetCell(3).ToString();
                                var strMajors = HttpUtility.UrlDecode(CookiesHelper.GetCookie("Majors"));
                                var listMajors = JsonConvert.DeserializeObject<List<Majors>>(strMajors);
                                var majorId = listMajors.Where(m => m.MajorName.Equals(majorName)).FirstOrDefault().MajorId;
                                model.MajorId = majorId;

                                var stageName = row.GetCell(4).ToString();
                                var strStages = HttpUtility.UrlDecode(CookiesHelper.GetCookie("Stages"));
                                var listStages = JsonConvert.DeserializeObject<List<Stages>>(strStages);
                                var stageId = listStages.Where(m => m.StageName.Equals(stageName)).FirstOrDefault().StageId;
                                model.StageId = stageId;

                                var typeName = row.GetCell(5).ToString();
                                if (typeName == "单选题")
                                    model.TypeId = Convert.ToInt32(TypeEnums.单选题);
                                if (typeName == "多选题")
                                    model.TypeId = Convert.ToInt32(TypeEnums.多选题);
                                if (typeName == "判断题")
                                    model.TypeId = Convert.ToInt32(TypeEnums.判断题);

                                model.QuestionTitle = row.GetCell(6).ToString();
                                if (row.LastCellNum != 12)
                                {
                                    model.OptionA = " ";
                                    model.OptionB = " ";
                                    model.OptionC = " ";
                                    model.OptionD = " ";
                                    model.Answer = row.GetCell(7).ToString();
                                }
                                else
                                {
                                    model.OptionA = row.GetCell(7).ToString();
                                    model.OptionB = row.GetCell(8).ToString();
                                    model.OptionC = row.GetCell(9).ToString();
                                    model.OptionD = row.GetCell(10).ToString();
                                    model.Answer = row.GetCell(11).ToString();
                                }

                                model.CreateDate = DateTime.Now;

                            }
                            list.Add(model);
                        }

                    }
                    if (iQuestions_BLL.Add(list))
                        result = 1;
                }

                return result;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return 0;
            }
        }
    }
}