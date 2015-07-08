using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FwwUCenter.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult Account()
        {
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "";
            Session["loginuserid"] = "Ricky";

            return View();
        }

        public ActionResult Logout()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult UserInfo()
        {
            ViewBag.Message = "";

            return View();
        }
        public ActionResult UserFinInfo()
        {
            ViewBag.Message = "";

            return View();
        }
        public ActionResult UserCard()
        {
            ViewBag.Message = "";

            return View();
        }
        public ActionResult MyCompany()
        {
            ViewBag.Message = "";

            return View();
        }
        public ActionResult MyQualification()
        {
            ViewBag.Message = "";

            return View();
        }
        public ActionResult MyPwd()
        {
            ViewBag.Message = "";

            return View();


        }
        public ActionResult MyPayPwd()
        {
            ViewBag.Message = "";

            return View();
        }
        public ActionResult MyAppealPayPwd()
        {
            ViewBag.Message = "";

            return View();
        }
        public ActionResult MyMembers()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}