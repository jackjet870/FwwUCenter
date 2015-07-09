using System;
using System.Web.Mvc;

namespace FwwUCenter.Controllers
{
    public class BaseController : Controller
    {
  
    }
    //public class MemberAuthorizeAttribute : ActionFilterAttribute
    //{
    //    /// <summary>
    //    /// 拦截会员是否登录验证
    //    /// </summary>
    //    /// <param name="filterContext"></param>
    //    public override void OnActionExecuting(ActionExecutingContext filterContext)
    //    {
    //        var session = filterContext.RequestContext.HttpContext.Session;
    //        var response = filterContext.RequestContext.HttpContext.Response;
    //        var request = filterContext.RequestContext.HttpContext.Request;
    //        // 验证微是否已经登录
    //        if (session["loginuserid"] == null)
    //        {
    //            // 跳转到登陆页
    //            response.Redirect("/Login/Login?RedUrl=" + request.Url.AbsoluteUri + "&t=" + DateTime.Now.ToString("yyyyMMddHHmmss"));
    //        }
    //        else
    //        {

    //            // 当前用户已登录，继续访问页面
    //            base.OnActionExecuting(filterContext);
    //        }
           
    //    }
          
    //}
}