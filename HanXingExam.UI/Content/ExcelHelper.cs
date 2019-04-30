using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HanXingExam.UI
{
    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;
    using HanXingExam.Entity;
    using HanXingExam.IBLL;
    using System.IO;
    using HanXingExam.Common;
    using Newtonsoft.Json;
    /// <summary>
    /// Copyright (C) 2015-2018 LiChen
    /// 导入导出Excel类
    /// QQ 594281739
    /// Email 594281739@qq.com
    /// </summary>
    public class ExcelHelper
    {
        private static IStudent_BLL student_BLL;

        public ExcelHelper(IStudent_BLL _student_BLL)
        {
            student_BLL = _student_BLL;
        }
        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="file">文件</param>
        /// <param name="TableName">表名</param>
        public static bool ExcelAdd(HttpPostedFileBase file,string TableName,int UsersId)
        {
            var result = false;
            if (null != file)
            {
                IWorkbook wk = null;
                //.xlsx 应该XSSFWorkbook workbook = new XSSFWorkbook(file); 而xls应该用 HSSFWorkbook workbook = new HSSFWorkbook(file);
                var f = file.FileName.Substring(file.FileName.LastIndexOf('.'));
				  //var PicLst = new List<string>();
                if (f.Equals(".xls"))
                {
                    //把xls文件中的数据写入wk中
                    wk = new HSSFWorkbook(file.InputStream);
                    //PicLst = wk.HSSFSaveAllPicture();
                }
                else
                {
                    //把xlsx文件中的数据写入wk中
                    wk = new XSSFWorkbook(file.InputStream);
                    //PicLst = wk.XSSFSaveAllPicture();
                }
                ISheet sheet = wk.GetSheetAt(0);
                IRow row = null;//读取当前行数据
                                //LastRowNum 是当前表的总行数-1
                for (int k = 1; k <= sheet.LastRowNum; k++)
                {
                    row = sheet.GetRow(k);//读取当前行数据
                    //var sql = "insert into "+TableName+" values(";
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
                            //if (j == 1)
                            //{
                            //  var name= row.GetCell(1).ToString();
                            //  num=  new StudentsBLL().Query().Where(m => m.Name.Equals(name)).ToList().Count;
                            //}
                            //读取该行的第j列数据


                            model.StudentNum = DateTime.Now.Ticks.ToString();
                            model.StudentPwd = Md5Helper.MD5Encoding("1",123);
                            model.StudentName = row.GetCell(3).ToString();
                            model.StudentIdCard = row.GetCell(4).ToString();
                            model.CreateDate = DateTime.Now;
                            model.CreateUserId = UsersId;
                            var collegeName = row.GetCell(7).ToString();
                            var strColleges = CookiesHelper.GetCookie("Colleges");
                            var listColleges = JsonConvert.DeserializeObject<List<Colleges>>(strColleges);
                            var collegeId = listColleges.Where(m => m.CollegeName.Equals(collegeName)).FirstOrDefault().CollegeId;
                            model.CollegeId = collegeId;

                            var majorName = row.GetCell(8).ToString();
                            var strMajors = CookiesHelper.GetCookie("Majors");
                            var listMajors = JsonConvert.DeserializeObject<List<Majors>>(strMajors);
                            var majorId = listMajors.Where(m => m.MajorName.Equals(majorName)).FirstOrDefault().MajorId;
                            model.MajorId = majorId;

                            var stageName = row.GetCell(9).ToString();
                            var strStages = CookiesHelper.GetCookie("Stages");
                            var listStages = JsonConvert.DeserializeObject<List<Stages>>(strStages);
                            var stageId = listStages.Where(m => m.StageName.Equals(stageName)).FirstOrDefault().StageId;
                            model.StageId = stageId;

                            var className = row.GetCell(10).ToString();
                            var strClasses = CookiesHelper.GetCookie("Classes");
                            var listClasses = JsonConvert.DeserializeObject<List<Classes>>(strClasses);
                            var classId = listClasses.Where(m => m.ClassName.Equals(className)).FirstOrDefault().ClassId;
                            model.ClassId = classId;
                            //var value = row.GetCell(j).ToString();
                            //sql += "'" + value + "',";
                            result= student_BLL.Add(model);
                        }
                        //sql = sql.TrimEnd(',') + ")";
                        
                        
                       // result += new StudentsBLL().Add(sql);
                    }
                }
            }
            return result;
        }

        /// 将DataTable数据导入到excel中
        /// </summary>
        /// <param name="data">要导入的数据</param>
        /// <param name="sheetName">要导入的excel的sheet的名称</param>
        /// <param name="isColumnWritten">DataTable的列名是否要导入</param>
        /// <param name="fileName">文件夹路径</param>
        /// <returns>导入数据行数(包含列名那一行)</returns>
        public static int DataTableToExcel(DataTable data, string sheetName, bool isColumnWritten, string fileName)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            if (string.IsNullOrEmpty(sheetName))
            {
                throw new ArgumentNullException(sheetName);
            }
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(fileName);
            }
            IWorkbook workbook = null;
            if (fileName.IndexOf(".xlsx", StringComparison.Ordinal) > 0)
            {
                workbook = new XSSFWorkbook();
            }
            else if (fileName.IndexOf(".xls", StringComparison.Ordinal) > 0)
            {
                workbook = new HSSFWorkbook();
            }
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                ISheet sheet;
                if (workbook != null)
                {
                    sheet = workbook.CreateSheet(sheetName);
                }
                else
                {
                    return -1;
                }
                int j;
                int count;

                data.Columns["StudentId"].ColumnName = "ID";
                data.Columns["StudentNum"].ColumnName = "学号";
                data.Columns["StudentPwd"].ColumnName = "密码";
                data.Columns["StudentName"].ColumnName = "姓名";
                data.Columns["StudentIdCard"].ColumnName = "身份证";
                data.Columns["CreateDate"].ColumnName = "创建时间";
                data.Columns["CreateUserId"].ColumnName = "创建人";
                data.Columns["CollegeId"].ColumnName = "学院";
                data.Columns["MajorId"].ColumnName = "专业";
                data.Columns["StageId"].ColumnName = "阶段";
                data.Columns["ClassId"].ColumnName = "班级";

                if (isColumnWritten)
                {
                    var row = sheet.CreateRow(0);
                   
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                    }
                    count = 1;
                }
                else
                {
                    count = 0;
                }
                //遍历循环datatable具体数据项
                int i;
                for (i = 0; i < data.Rows.Count; ++i)
                {
                    var row = sheet.CreateRow(count);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                    }
                    ++count;
                }
                //将文件流写入到excel
                workbook.Write(fs);
                return count;
            }
            catch (IOException ioex)
            {
                throw new IOException(ioex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

    }
}