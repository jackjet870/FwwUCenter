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
            ViewBag.imgsrc = @"User/UserQualification/"+userid; 
            return View();
        }

        public ActionResult UserQualification(string userid)
        {
            ViewBag.Message = userid;
            ViewBag.imgsrc = @"http://www.86fuwuwang.com/Upload/imageB/121224044756487.jpg"; 
            return View();
        }
        
    }
}