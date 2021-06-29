using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;

namespace FinderApi.App_Start
{
    public class DefaultConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            IHttpRoute defaultRoute =
                config.Routes.CreateRoute("api/{controller}", new { id = RouteParameter.Optional }, null);

            config.Routes.Add("DefaultApi", defaultRoute);
        }
    }
}