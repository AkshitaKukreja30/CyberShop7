using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cyber_shop7.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
       public ActionResult Mobiles()
        {
            return File("~/Views/Mobiles.html", "text/html");
        }
        public ActionResult Foods()
        {
            return File("~/Views/Foods.html", "text/html");

        }
      /*  public ActionResult Clothings()
        {
            return File("~/Views/Clothings.html", "text/html");
        }
        public ActionResult Books()
        {
            return File("~/Views/Books.html", "text/html");

        }
        public ActionResult Categories()
        {
            return File("~/Views/Categories.html", "text/html");
        }*/
    }
}
