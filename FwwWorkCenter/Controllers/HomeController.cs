using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FwwWorkCenter.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string UserName, string Password)
        {
            //这个是服务网会员中心 需要用服务网的验证逻辑来验证
            //前台需要加入验证码机制
            if (!String.IsNullOrEmpty(UserName))
            {
                FormsAuthentication.SetAuthCookie(UserName, false);
                return Redirect("/Dashboard/Dashboard");
            }
            return Redirect("/");
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
        
    }
}