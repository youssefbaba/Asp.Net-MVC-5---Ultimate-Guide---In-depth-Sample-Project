using ModelExample.Models;
using System.Web.Mvc;

namespace ModelExample.Controllers
{
    public class StudentsController : Controller
    {

        [HttpGet]
        // GET: /Students/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        // POST
        public ActionResult Create([ModelBinder(typeof(CustomBinder))] Student student)
        {
            return View("Details", student);
        }

        [HttpGet]
        // GET: /Students/Details
        public ActionResult Details()
        {
            return View();
        }

    }
}