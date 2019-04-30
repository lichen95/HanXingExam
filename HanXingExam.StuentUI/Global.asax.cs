using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HanXingExam.StuentUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
       
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //注册 Global
            UnityIOC.Initialise();
        }

        protected void Session_End()
        {
            Hashtable SingleOnline = (Hashtable)System.Web.HttpContext.Current.Application["Online"];
            if (SingleOnline != null && SingleOnline[User.Identity.Name] != null)
            {
                SingleOnline.Remove(Session.SessionID);
                System.Web.HttpContext.Current.Application.Lock();
                System.Web.HttpContext.Current.Application["Online"] = SingleOnline;
                System.Web.HttpContext.Current.Application.UnLock();
            }
            Session.Abandon();
        }
    }
}
