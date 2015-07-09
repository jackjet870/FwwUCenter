using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FwwUCenter.Controllers
{
    public class WalletController : BaseController
    {
      [Authorize]
        public ActionResult MyWallet()
        {
            //我的钱包 包含 电子钱包余额\车票等等信息
            return View();
        }

        
        public ActionResult MyBill()
        {
            ViewBag.Message = "Your page.";

            return View();
        }

        
        public ActionResult TransferAcount()
        {
            ViewBag.Message = "Your page.";

            return View();
        }

         
        public ActionResult WithdrawCash()
        {
            ViewBag.Message = "Your page.";

            return View();
        }

         
        public ActionResult WalletPurchase()
        {
            ViewBag.Message = "Your page.";

            return View();
        }
    }
}