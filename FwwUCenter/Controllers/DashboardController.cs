using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FwwUCenter.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {

        public ActionResult Dashboard()
        {
            return View();
        }

        
        public ActionResult Noti()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        public ActionResult Resourcecenter()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}