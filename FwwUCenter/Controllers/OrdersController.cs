using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FwwUCenter.Controllers
{
    public class OrdersController : BaseController
    {
        public ActionResult MyOrders()
        {
            //我的钱包 包含 电子钱包余额\车票等等信息
            return View();
        }

        public ActionResult NewOrder()
        {
            //我的钱包 包含 电子钱包余额\车票等等信息
            return View();
        }
    }
}