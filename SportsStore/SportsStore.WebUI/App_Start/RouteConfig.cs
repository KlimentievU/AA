﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            null,
            "",
            new{
                controller = "Product", action ="List",
                category = (string)null, page = 1
            });
                

            routes.MapRoute(
            name: null,
            url:"Page{page}", 
            defaults: new {controller = "Product", action = "List", category =(string)null},
            constraints: new {page = @"\d+"}//page должен быть числовым значением
            );

            routes.MapRoute(null, "{category}",
                new {controller = "Product", action = "List", category = (string)null, page = 1});


            routes.MapRoute(null,
                "{category}/Page{page}", // kak /football/page1
                new {controller = "Product", action = "List"}, //по умолчанию
                new {page = @"\d+"}
                );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
