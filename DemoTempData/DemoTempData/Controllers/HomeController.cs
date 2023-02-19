using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoTempData.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            TempData["Message"] = "Hello World";
            TempData["y"] = 200;
            TempData["z"] = 300;
            return RedirectToAction("Index1");
        }
        public ActionResult Index1()
        {
            return RedirectToAction("Index2");
        }
        public ActionResult Index2()
        {
            // Default behavior
            string message = Convert.ToString(TempData["Message"]);
            ViewBag.Message = message;


            // Remove the mark for deletion
            string val = Convert.ToString(TempData["y"]);
            TempData.Keep("y");


            // Remove the mark for deletion by using short way
            string val1 = Convert.ToString(TempData.Peek("z")) ;

            return View("Index");
        }

        public ActionResult Demo()
        {
            TempData["x"] = 100;
            return RedirectToAction("Demo1");
        }
        public ActionResult Demo1()
        {
            var value = Convert.ToString(TempData["x"]);
            return RedirectToAction("Demo2");
        }
        public ActionResult Demo2()
        {
            ViewBag.amount = Convert.ToString(TempData["x"]);
            return View("Demo");
        }
        public ActionResult Test()
        {
            string message = Convert.ToString(TempData["Message"]);
            if (string.IsNullOrEmpty(message))
            {
                ViewBag.Message = "No Value For TempData[\"Message\"]";
            }
            ViewBag.Value = Convert.ToString(TempData["y"]);
            ViewBag.Test = Convert.ToString(TempData["z"]);
            return View("Test");
        }
    }
}