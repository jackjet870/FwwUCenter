using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FwwUCenter.Controllers
{
    [Authorize]
    public class IncidentController : BaseController
    {
        public ActionResult NewCompany()
        {
            //我的钱包 包含 电子钱包余额\车票等等信息
            return View();
        }

        public ActionResult NewAgent()
        {
            ViewBag.Message = "Your page.";

            return View();
        }

        public ActionResult NewOperationCenter()
        {
            ViewBag.Message = "Your page.";

            return View();
        }

        public ActionResult MyIncident()
        {
            ViewBag.Message = "Your page.";

            return View();
        }


    }
}