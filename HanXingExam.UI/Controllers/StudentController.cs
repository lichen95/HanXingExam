using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanXingExam.UI.Controllers
{
    using HanXingExam.Common;
    using HanXingExam.Entity;
    using HanXingExam.IBLL;
    using Newtonsoft.Json;
    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;
    using System.Data;
    using System.Configuration;

    /// <summary>
    /// ** 描述：学生控制器
    /// ** 创始时间：2018年11月4日10点35分
    /// ** 修改时间：-
    /// ** 作者：mqc
    /// </summary>
    public class StudentController : Controller
    {
        private IStudent_BLL student_BLL;

        public StudentController(IStudent_BLL _student_BLL)
        {
            student_BLL = _student_BLL;
        }

        /// <summary>
        /// 学生信息添加方法
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 是否添加成功true成功，false失败</returns>
        [HttpPost]
        public bool Add(Students model)
        {
            model.StudentNum = DateTime.Now.Ticks.ToString();
            model.StudentPwd = Md5Helper.MD5Encoding("123456", 123);
            model.CreateDate = DateTime.Now;
            model.CreateUserId = 1;
            List<Students> list = new List<Students>();
            list.Add(model);
            var result = student_BLL.AddList(list);
            return result;
        }

        /// <summary>
        /// 学生信息查询方法
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>PageBox 所有信息的实体</returns>
        [HttpPost]
        public string Query(DateTime? startDate, DateTime? endDate, int pageIndex = 1, int pageSize = 2, string StudentName = "", int collegeId = 0, int mjorId = 0, int stageId = 0, int classId = 0)
        {
            return JsonConvert.SerializeObject(student_BLL.Query(startDate, endDate, pageIndex, pageSize, StudentName, collegeId, mjorId, stageId, classId));
        }

        /// <summary>
        /// 学生信息删除方法
        /// </summary>
        /// <param name="Ids">要删除的学院Id</param>
        /// <returns>bool 是否删除成功true成功，false失败</returns>
        [HttpPost]
        public bool Delete(string Ids)
        {
            return student_BLL.Delete(Ids);
        }

        /// <summary>
        /// 学生信息编辑反填方法
        /// </summary>
        /// <param name="Id">要编辑的学院Id</param>
        /// <returns>Colleges 要编辑的学院信息</returns>
        [HttpPost]
        public string QuertById(int Id)
        {
            return JsonConvert.SerializeObject(student_BLL.QueryById(Id));
        }

        /// <summary>
        /// 学生信息修改方法
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>bool 是否修改成功true成功，false失败</returns>
        [HttpPost]
        public bool Update(Students m)
        {
            m.StudentPwd = Md5Helper.MD5Encoding("123456", 123);
            m.CreateDate = DateTime.Now;
            m.CreateUserId = 1;
            return student_BLL.Update(m);
        }

        /// <summary>
        /// 班级信息查询方法
        /// </summary>
        /// <param name="Id">阶段Id</param>
        /// <returns>string 班级信息json字符串</returns>
        [HttpPost]
        public string QueryBySid(int Id)
        {
            
            var result = student_BLL.QueryBySid().Where(m => m.StageId.Equals(Id)).ToList();
            return JsonConvert.SerializeObject(result);
        }

        
        /// <summary>
        /// 导入学生信息
        /// </summary>
        /// <param name="UsersId"></param>
        /// <returns></returns>
        [HttpPost]
        public int InputStudent(int UsersId = 1)
        {
            try
            {
                List<Students> list = new List<Students>();
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
                                    //LastRowNum 是当前表的总行数-1
                    for (int k = 1; k <= sheet.LastRowNum; k++)
                    {
                        row = sheet.GetRow(k);//读取当前行数据
                        Students model = new Students();
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
                                model.StudentNum = BaseRandom.GenerateIntID().ToString();
                                model.StudentPwd = Md5Helper.MD5Encoding("123456", 123);
                                model.StudentName = row.GetCell(3).ToString();
                                model.StudentIdCard = row.GetCell(4).ToString();
                                model.CreateDate = DateTime.Now;
                                model.CreateUserId = UsersId;
                                var collegeName = row.GetCell(7).ToString();
                                var strColleges = HttpUtility.UrlDecode(CookiesHelper.GetCookie("Colleges"));
                                var listColleges = JsonConvert.DeserializeObject<List<Colleges>>(strColleges);
                                var collegeId = listColleges.Where(m => m.CollegeName.Equals(collegeName)).FirstOrDefault().CollegeId;
                                model.CollegeId = collegeId;

                                var majorName = row.GetCell(8).ToString();
                                var strMajors = HttpUtility.UrlDecode(CookiesHelper.GetCookie("Majors"));
                                var listMajors = JsonConvert.DeserializeObject<List<Majors>>(strMajors);
                                var majorId = listMajors.Where(m => m.MajorName.Equals(majorName)).FirstOrDefault().MajorId;
                                model.MajorId = majorId;

                                var stageName = row.GetCell(9).ToString();
                                var strStages = HttpUtility.UrlDecode(CookiesHelper.GetCookie("Stages"));
                                var listStages = JsonConvert.DeserializeObject<List<Stages>>(strStages);
                                var stageId = listStages.Where(m => m.StageName.Equals(stageName)).FirstOrDefault().StageId;
                                model.StageId = stageId;

                                var className = row.GetCell(10).ToString();
                                var strClasses = HttpUtility.UrlDecode(CookiesHelper.GetCookie("Classes"));
                                var listClasses = JsonConvert.DeserializeObject<List<Classes>>(strClasses);
                                var classId = listClasses.Where(m => m.ClassName.Equals(className)).FirstOrDefault().ClassId;
                                model.ClassId = classId;
                            }
                            list.Add(model);
                        }
                        
                    }
                    if (student_BLL.AddList(list))
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

        /// <summary>
        /// 导出学生信息
        /// </summary>
        /// <param name="UsersId"></param>
        /// <returns></returns>
        [HttpPost]
        public bool OutStudent()
        {
            try
            {
                var url = ConfigurationManager.AppSettings["StudentsOutURL"];
                DataTable dt = student_BLL.GetStudents();
                var result = ExcelHelper.DataTableToExcel(dt, "sheet1", true, @"" + url + "" + DateTime.Now.Ticks + "学生信息表.xls");
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