using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanXingExam.StuentUI.Content
{
    /// <summary>
    /// 该过滤器用于判断是否存在重复登录的情况
    /// </summary>
    public class LoginActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Hashtable singleOnline = (Hashtable)filterContext.HttpContext.Application["Online"];
            // 判断当前SessionID是否存在
            if (singleOnline != null && singleOnline.ContainsKey(filterContext.HttpContext.User.Identity.Name))
            {
                if (!singleOnline[filterContext.HttpContext.User.Identity.Name].Equals(filterContext.HttpContext.Session.SessionID))
                {
                    filterContext.Result = new ContentResult() { Content = "<script>if(confirm('你的账号已在别处登陆，是否返回登陆页面重新登陆？')){window.location.href='/Exam/Login';}else{window.close();}</script>" };
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}