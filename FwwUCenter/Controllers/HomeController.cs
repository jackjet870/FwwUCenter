using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FwwUCenter.Controllers
{
    public class HomeController : BaseController
    {
         [MemberAuthorize]
        public ActionResult Index()
        {
            return View();
        }

         [MemberAuthorize]
        public ActionResult Noti()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
         [MemberAuthorize]
        public ActionResult Resourcecenter()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}