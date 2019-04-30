using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanXingExam.StuentUI.Controllers
{
    using HanXingExam.Common;
    using HanXingExam.Entity;
    using HanXingExam.IBLL;
    using Newtonsoft.Json;

    /// <summary>
    /// ** 描述：历史试卷控制器
    /// ** 创始时间：2018年11月6日
    /// ** 修改时间：-
    /// ** 作者：zhq
    /// </summary>
    public class HistoricalPapersController : Controller
    {
        private IHistoricalPapers_BLL IHistoricalPapers_bll;

        public HistoricalPapersController(IHistoricalPapers_BLL _IHistoricalPapers_bll)
        {
            IHistoricalPapers_bll = _IHistoricalPapers_bll;
        }

        /// <summary>
        /// 历史试卷
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        [HttpPost]
        public string QueryHis(int StudentId, DateTime? startDate, DateTime? endDate, int pageIndex = 1, int pageSize = 10)
        {
            try
            {
                var list = RedisHelper.Get<List<Score_His>>("Score_His" + StudentId);
                if (list != null)
                    list = list.Where(m => m.StudentId.Equals(StudentId)).ToList();
                PageBox page = new PageBox();
                page = IHistoricalPapers_bll.GetHistoricalPapers(StudentId, startDate, endDate, pageIndex, pageSize);
                var json = JsonConvert.SerializeObject(page.Data);
                var listdb = JsonConvert.DeserializeObject<List<Score_His>>(json).Where(st => st.StudentId.Equals(StudentId)).ToList();
                for (int i = 0; i < listdb.Count; i++)
                {
                    list.Add(listdb[i]);
                }

                list = list.OrderByDescending(m => m.CreateDate).ToList();
                //查询开始时间
                if (!string.IsNullOrWhiteSpace(startDate.ToString()))
                    list = list.Where(m => m.CreateDate >= startDate).ToList();
                //查询结束时间
                if (!string.IsNullOrWhiteSpace(endDate.ToString()))
                    list = list.Where(m => m.CreateDate <= endDate).ToList();
                page.PageIndex = pageIndex;
                page.PageCount = list.Count / pageSize + (list.Count % pageSize > 0 ? 1 : 0);
                page.Data = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);

                return JsonConvert.SerializeObject(page);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <param name="id">变量ID</param>
        /// <returns>string 历史试卷json字符串</returns>
        public string GetHisByID(string Id, int StudentId)
        {
            try
            {
                var result = IHistoricalPapers_bll.IsShowTestInfos(StudentId, Id);
                var arr = result.MyAnswer.Split(',');
                List<string> list = new List<string>();
                for (int i = 0; i < arr.Length; i++)
                {
                    list.Add(arr[i]);
                }
                return JsonConvert.SerializeObject(arr);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }
        }
    }
}