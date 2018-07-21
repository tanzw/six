using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Well.Wen.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Well.Data.OrderImpl service = new Data.OrderImpl();
            ViewBag.TMList = service.GetTJ(0, "", "",0).Body;

            return View();
        }
    }
}
