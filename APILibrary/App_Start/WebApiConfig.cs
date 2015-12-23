using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http;

namespace APILibrary
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            /*config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );*/

            config.Routes.MapHttpRoute(
                name: "service", 
                routeTemplate: "service/{id}/{type}",
                constraints: null, 
                handler:
                HttpClientFactory.CreatePipeline
                (
                    innerHandler: new HttpClientHandler(), // will never get here if proxy is doing its job
                    handlers: new DelegatingHandler[] { new ApiProxy() }
                ),
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "test",
                routeTemplate: "test/{id}/{type}",
                constraints: null,
                handler:
                HttpClientFactory.CreatePipeline
                (
                    innerHandler: new HttpClientHandler(), // will never get here if proxy is doing its job
                    handlers: new DelegatingHandler[] { new ApiProxy() }
                ),
                defaults: new { type = RouteParameter.Optional }
            );

        }
    }

}
