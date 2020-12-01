using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WSR.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Главная страница
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Title = "Главная страница";

            return View();
        }
    }
}
