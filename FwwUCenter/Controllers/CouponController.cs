using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FwwUCenter.Controllers
{
    [Authorize]
    public class CouponController : BaseController
    {
        public ActionResult MyCoupon()
        {
            //我的券包含 多少张 已经排队  未排队
            //券获取时间 排队时间等
            //队列查看明细
            return View();
        }

        public ActionResult AllCoupon()
        {
            ViewBag.Message = "Your page.";

            return View();
        }

        public ActionResult LineupCoupon()
        {
            ViewBag.Message = "Your page.";

            return View();
        }

        public ActionResult TransferCoupon()
        {
            ViewBag.Message = "Your page.";

            return View();
        }

        public ActionResult BuyCoupon()
        {
            ViewBag.Message = "Your page.";

            return View();
        }
    }
}