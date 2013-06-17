using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StaticReflection.MvcDemo.Models;

namespace StaticReflection.MvcDemo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(new IndexModel());
        }


        public ActionResult Detail(int id, DateTime date)
        {
            var model = new HomeDetail()
                {
                    Id = id,
                    Age = (DateTime.Now - date).Days/365
                };
            return View(model);
        }

        public ActionResult DoSomething()
        {
            return View("_SomePartial");
        }

    }
}
