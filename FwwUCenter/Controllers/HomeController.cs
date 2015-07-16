using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FwwUCenter.Controllers
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
            //UserName.ToUpper() == "ZCZCZY" && Password.ToUpper() == "ZCZCZY2015"
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

        public ActionResult ForgetPWD()
        {
            return View();
        }

        public ActionResult NewUser()
        {
            return View();
        }
        

    }
}