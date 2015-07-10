using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkflowEngine;

namespace WorkflowAdmin.Controllers
{
     [Authorize]
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            WFService wf = new WFService();
            ViewBag.Message = wf.TestFunc();
            return View();
        }


    }
}