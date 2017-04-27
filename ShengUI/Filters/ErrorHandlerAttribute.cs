using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace ShengUI.Filters
{
    public class ErrorHandlerAttribute:System.Web.Mvc.HandleErrorAttribute
    {
        public override void OnException(System.Web.Mvc.ExceptionContext filterContext)
        {
            if (filterContext.IsChildAction)
            {
                return;
            }
            // If custom errors are disabled, we need to let the normal ASP.NET exception handler  
            // execute so that the user can see useful debugging information.  
            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }
            Exception exception = filterContext.Exception;
            var httpException = exception as HttpException;
            if (httpException != null && httpException.GetHttpCode() != 500)
            {
                return;
            }

            //if (!ExceptionType.IsInstanceOfType(exception))
            //{
            //    return;
            //}

            //filterContext.Controller.ViewData["ExceptionMessage"] = exception.Message;
            //BaseAppContext.Logger.Info(exception);
            //var section = System.Configuration.ConfigurationManager.GetSection("system.web/customErrors") as CustomErrorsSection;
            //filterContext.Result = new RedirectResult(section.DefaultRedirect);
            //filterContext.ExceptionHandled = true;

            base.OnException(filterContext);
        }
    }
}
