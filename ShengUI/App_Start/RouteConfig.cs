using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShengUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var guidRegx = @"^\w{2}$";

            //routes.MapRoute(
            //    "Admin", // 路由名称
            //    "Admin", // 带有参数的 URL
            //    new { controller = "Home", action = "Admin" } // 参数默认值
            //);

            //routes.MapRoute(
            //    "LogOn", // 路由名称
            //    "LogOn", // 带有参数的 URL
            //    new { controller = "Home", action = "LogOn" } // 参数默认值
            //);
            //            routes.Add(new Route(
            //   "{lang}/{controller}/{action}/{id}",
            //   new RouteValueDictionary(new
            //   {
            //       lang = "en-US",
            //       controller = "Home",
            //       action = "Index",
            //       id = UrlParameter.Optional
            //   }),
            //   new SampleUI.MvcApplication.MultiLangRouteHandler()
            //));
            //routes.Add(new Route(
            //                "{lang}/{controller}/{action}/{id}",
            //                new RouteValueDictionary(new {
            //                    lang = "en-US",//默认为E文
            //                    controller = "home",
            //                    action = "center",
            //                    id = UrlParameter.Optional
            //                }),
            //                new MultiLangRouteHandler()//这个类主要是通过GetHttpHandler来取得当前Lang的值
            //            ));
            routes.MapRoute(
                   "BIMI",
                   "BIMI/{action}.aspx/{id}",
                   new { controller = "BIMI", action = "userMain", id = 0, pageindex = 1 },
                // new { id = @"[\d]{0,11}" },//new { id = @"[\d]*" }//*表示任意长度
                   new string[1] { "ShengUI.Logic" }
               );
            // routes.MapRoute(
            //    "news_detail",
            //    "news/{action}_{id}.htm",
            //    new { controller = "News", action = "news", id = UrlParameter.Optional},
            //     // new { id = @"[\d]{0,11}" },//new { id = @"[\d]*" }//*表示任意长度
            //    new string[1] { "SampleUI.Logic" }
            //);
            routes.MapRoute(
                "news-detail",
                "news/{action}-{id}.html",
                new { controller = "News", action = "NewsDetail", id = UrlParameter.Optional },
                 new { id = @"[\d]{0,11}" },//new { id = @"[\d]*" }//*表示任意长度
                new string[1] { "ShengUI.Logic" }
            );
            routes.MapRoute(
                 "news",
                 "news/{action}.html",
                 new { controller = "News", action = "List", id = UrlParameter.Optional, pageindex = 1 },
                // new { id = @"[\d]{0,11}" },//new { id = @"[\d]*" }//*表示任意长度
                 new string[1] { "ShengUI.Logic" }
             );

            // routes.MapRoute(
            //     "Accounts",
            //     "Accounts/{action}/{id}",
            //     new { controller = "Accounts", action = "Accounts_Info", id = UrlParameter.Optional },
            //     // new { id = @"[\d]{0,11}" },//new { id = @"[\d]*" }//*表示任意长度
            //     new string[1] { "SampleUI.Logic" }
            // );
            routes.MapRoute(
                 "projrct",
                 "projrct/{action}_{categoryid}.htm/{pageindex}",
                 new { controller = "projrct", action = "List", categoryid = UrlParameter.Optional, pageindex = UrlParameter.Optional },
                // new { id = @"[\d]{0,11}" },//new { id = @"[\d]*" }//*表示任意长度
                 new string[1] { "ShengUI.Logic" }
             );
            routes.MapRoute(
                "projrct_detail",
                "projrct/{action}_{categoryid}.htm",
                new { controller = "projrct", action = "List", pageindex = 1 },
                // new { id = @"[\d]{0,11}" },//new { id = @"[\d]*" }//*表示任意长度
                new string[1] { "ShengUI.Logic" }
            );


            routes.MapRoute(
                    "product",
                    "Product/{action}_{categoryid}.htm",
                    new { controller = "Product", action = "List", id = UrlParameter.Optional, pageindex = 1 },
                // new { id = @"[\d]{0,11}" },//new { id = @"[\d]*" }//*表示任意长度
                    new string[1] { "ShengUI.Logic" }
                );

            routes.MapRoute(
                       "product-details",
                       "Product/{action}-{id}.htm",
                       new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                       new { id = @"[\d]{0,11}" },//new { id = @"[\d]*" }//*表示任意长度
                       new string[1] { "ShengUI.Logic" }
                   );
            routes.MapRoute(
                  name: "DefaultHtm",
                  url: "{controller}/{action}.htm/{id}",
                  defaults: new { controller = "product", action = "list", id = UrlParameter.Optional },
                  namespaces: new string[1] { "ShengUI.Logic" }
              );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "BIMI", action = "userMain", id = UrlParameter.Optional },
                namespaces: new string[1] { "ShengUI.Logic" }
            );
        
         
        }
    }
}