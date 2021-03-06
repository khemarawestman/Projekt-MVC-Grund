﻿using MVC_Projekt_WebbShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVC_Projekt_WebbShop.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Result()
        {
            //var find = from x in Product.Catalogue
            //           where x.Name == Request["search"]
            //           select x;
            var search = Request["search"];
            var find = Product.Catalogue.Where(t =>
            t.Name.ToLower().Contains(search.ToLower()) ||
            t.Description.ToLower().Contains(search.ToLower())
            )
        .ToList();
            if (search != "" && search!=null && find.Count!= 0)
            {
        //        var find = Product.Catalogue.Where(t =>
        //    t.Name.ToLower().Contains(search.ToLower()) ||
        //    t.Description.ToLower().Contains(search.ToLower())
        //    )
        //.ToList();
                //return View(find.ToList());
                Session["Search"] = find;
                return RedirectToAction("StoreIndex","Store");
            }
            else
            {
                return RedirectToAction("SearchNotFound");
            }
        }
        public ActionResult SearchNotFound()
        {
            return View();
        }
    }
}