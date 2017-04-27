using System.Web;
using System.Web.Mvc;

namespace ShengUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
          
           filters.Add(new ShengUI.Filters.LoginValidateAttribute()); 
           // filters.Add(new ShengUI.Filters.ErrorHandlerAttribute());
        }
    }
}