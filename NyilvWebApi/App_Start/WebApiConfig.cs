﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Diagnostics;

namespace Nyilv
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            Trace.Listeners.Add(new TextWriterTraceListener(@"C:\Users\TG\BME-Cubby\DotnetHF\DotnetHF\NyilvWebApi\Trace_WebApi.log", "WebApiListener"));            
        }
    }
}
