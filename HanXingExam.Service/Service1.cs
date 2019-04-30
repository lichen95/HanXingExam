using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using SqlSugar;

namespace HanXingExam.Service
{
    using HanXingExam.Common;
    using HanXingExam.Entity;

    public partial class Service1 : ServiceBase
    {

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Timer timer = new Timer();
            timer.Interval = 5000;
            timer.Elapsed += Timer_Elapsed;
            //timer.Enabled = true;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            List<Students> studentNum = null;
            using (SqlSugarClient db = SqlSugarClientHelper.SqlDBConnection)
            {
                studentNum = db.Queryable<Students>().ToList();
            }
            var num = 0;
            List<Score_His> list = null;
            for (int j = 0; j < studentNum.Count; j++)
            {
                list = RedisHelper.Get<List<Score_His>>("Score_His" + studentNum[j].StudentId);
                if (list != null && list.Count != 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        var result = Add(list[i].StudentId, list[i].ScoreNum, list[i].ExamQuestionId, list[i].MyAnswerStr, list[i].CreateDate);
                        if (result > 0)
                        {
                            list.Remove(list[i]);
                            RedisHelper.Set<List<Score_His>>("Score_His" + studentNum[j].StudentId, list);
                            num++;
                        }
                    }
                    WriteRunLog("成功添加" + num + "条数据");
                }
            }
        }

        protected override void OnStop()
        {
            WriteRunLog("服务停止");
        }

        /// <summary>
        /// 批量添加成绩
        /// </summary>
        /// <param name="scores"></param>
        /// <returns></returns>
        public int Add(int studentId, int scoreNum, string examQuestionId, string myAnswer, DateTime cateDate)
        {
            using (SqlSugarClient db = SqlSugarClientHelper.SqlDBConnection)
            {
                SugarParameter[] parms = {
                new SugarParameter("@StudentId",studentId),
                new SugarParameter("@ScoreNum",scoreNum),
                new SugarParameter("@ExamQuestionId",examQuestionId),
                new SugarParameter("@MyAnswer",myAnswer),
                new SugarParameter("@CreateDate",cateDate)
                };
                var result = db.Ado.ExecuteCommand("exec p_AddSocre_HistoricalPapers @StudentId,@ScoreNum,@ExamQuestionId,@MyAnswer,@CreateDate", parms);
                return result;
            }
        }

        /// <summary>
        /// 记录运行日志
        /// </summary>
        /// <param name="writeMsg"></param>
        public void WriteRunLog(string writeMsg)
        {
            FIle_Common file = new FIle_Common();
            file.CreateDire(@"C:\ServiceLog\");
            using (FileStream fs = new FileStream(@"C:\ServiceLog\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                StreamWriter m_streamWriter = new StreamWriter(fs);
                m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                m_streamWriter.WriteLine("mcWindowsService:" + writeMsg + "  Time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\n");
                m_streamWriter.Flush();
                m_streamWriter.Close();
                fs.Close();
            }
        }
    }
}
