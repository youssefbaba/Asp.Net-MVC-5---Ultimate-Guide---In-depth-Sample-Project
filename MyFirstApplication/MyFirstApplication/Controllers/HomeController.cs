using MyFirstApplication.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MyFirstApplication.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        // GET: /home/index
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        // GET: /home/products
        public ActionResult Products()
        {
            return View("OurCompanyProducts");
        }

        [HttpGet]
        // GET: /home/contact
        public ActionResult Contact()
        {
            ViewBag.Phone = "123-123-123";
            return View();
        }

        [HttpGet]
        // GET: /home/getemployeename?employeeid = 1
        public ActionResult GetEmployeeName(int employeeId)
        {
            var employees = new[]
            {
                new { EmployeeId = 1 , EmployeeName = "Timoteo Blanco" , Salary = 1200},
                new { EmployeeId = 2 , EmployeeName = "Abel Blesa" , Salary = 1000},
                new { EmployeeId = 3 , EmployeeName = "Enrique Hidalgo" , Salary = 1500},
            };
            var employee = employees.SingleOrDefault(e => e.EmployeeId == employeeId);
            if (employee == null)
            {
                return HttpNotFound();
            }
            string matchingEmployeeName = employee.EmployeeName;
            //return new ContentResult() { Content = "Good", ContentType = "text/plain" };
            //return new ContentResult() { Content = "Good", ContentType = "text/html" };
            //return new ContentResult() { Content = "Good" };
            //return Content("Good", "text/plain");
            //return Content(matchingEmployeeName, "text/plain");
            //return Content(matchingEmployeeName, "text/html");
            //return Content(matchingEmployeeName);
            return Content($"Employee Name : {matchingEmployeeName}");
        }

        [HttpGet]
        // GET: /home/getpayslip?employeeid=1 
        public ActionResult GetPaySlip(int employeeId)
        {
            string path = $"~/Content/Files/PaySlip{employeeId}.pdf";
            return File(path, "application/pdf");
        }

        [HttpGet]
        // GET: /home/employeefacebookpage?employeeid=1
        public ActionResult EmployeeFacebookPage(int employeeId)
        {
            var employees = new[]
{
                new { EmployeeId = 1 , EmployeeName = "Timoteo Blanco" , Salary = 1200},
                new { EmployeeId = 2 , EmployeeName = "Abel Blesa" , Salary = 1000},
                new { EmployeeId = 3 , EmployeeName = "Enrique Hidalgo" , Salary = 1500},
            };
            var employee = employees.SingleOrDefault(e => e.EmployeeId == employeeId);
            if (employee == null)
            {
                return HttpNotFound();
            }
            string facebookUrl = $"https://www.facebook.com/{employeeId}";
            return Redirect(facebookUrl);
        }

        [HttpGet]
        // GET: /home/studentdetails
        public ActionResult StudentDetails()
        {
            var student = new StudentViewModel()
            {
                StudentId = 100,
                StudentName = "Pablo Vargas",
                Mark = 80,
                NumberOfSemesters = 6,
                Subjects = new List<string>() { "Mathematics", "English", "Computer Science", "Philosophy" }
            };
            return View(student);
        }

        [HttpGet]
        // GET: /home/requestexample
        public ActionResult RequestExample()
        {
            ViewBag.Url = Request.Url;
            ViewBag.PhysicalApplicationPath = Request.PhysicalApplicationPath;
            ViewBag.Path = Request.Path;
            ViewBag.BrowserType = Request.Browser.Type;
            ViewBag.QueryString = Request.QueryString;
            ViewBag.SpecificQueryString = Request.QueryString["param1"];
            ViewBag.HeadersAccept = Request.Headers["Accept"];
            ViewBag.HttpMethod = Request.HttpMethod;

            return View();
        }

        [HttpGet]
        // GET: /home/responseexample
        public ActionResult ResponseExample()
        {
            Response.Write("Hello");
            Response.Write("World");
            Response.ContentType = "text/plain";
            Response.Headers["server"] = "My Server";
            Response.StatusCode = 500;
            Response.StatusDescription = "Internal Server Error";
            return View();
        }
    }
}