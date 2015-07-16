using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FwwWorkCenter.Controllers
{
    public class UserController : Controller
    {
        // GET: Member
        public ActionResult Index(string userid)
        {
            ViewBag.Message = userid;
            return View();
        }
    }
}