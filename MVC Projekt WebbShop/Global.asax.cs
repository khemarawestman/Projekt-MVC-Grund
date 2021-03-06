﻿using MVC_Projekt_WebbShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVC_Projekt_WebbShop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
        protected void Session_Start(object sender, EventArgs e)
        {

           Session["ProductList"] = Product.Catalogue;
            Session["AnvändarLista"] = new List<UserModel>() {
                                            new UserModel(),
                                            new UserModel("JohnDoe", "unknown@ymail.com","Hej123",false),
                                            new UserModel("admin","admin@gmail.com","qwerty123",true)};
            Session["User"] = null;
            Session["LoginStatus"] = false;
        }
    }
}
