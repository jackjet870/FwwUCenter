using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WorkflowEngine;

namespace FwwUCenter.Controllers
{
    [Authorize]
    public class TicketController : BaseController
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

        public ActionResult MyTicket()
        {
            ViewBag.Message = "Your page.";

            return View();
        }

        [HttpPost]
        public ActionResult NewCompanyTicket(string wfCode)
        {
            //UserName.ToUpper() == "ZCZCZY" && Password.ToUpper() == "ZCZCZY2015"
            if (!String.IsNullOrEmpty(User.Identity.Name))
            {
                WFService wfService = new WFService();
                int temp = wfService.NewTicket(User.Identity.Name,"A");
                if (temp == 0)
                {
                    ViewBag.Message = "提交成功";
                }
                else
                {
                    ViewBag.Message = "提交失败";
                }
            }
            return Redirect("/Ticket/NewCompany");
        }



    }
}