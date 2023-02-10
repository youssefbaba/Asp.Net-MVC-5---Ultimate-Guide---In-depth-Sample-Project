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
            return View();
        }

        public ActionResult GetEmployeeName(int employeeId)
        {
            var employees = new[]
            {
                new { EmployeeId = 1 , EmployeeName = "Timoteo Blanco" , Salary = 1200},
                new { EmployeeId = 2 , EmployeeName = "Abel Blesa" , Salary = 1000},
                new { EmployeeId = 3 , EmployeeName = "Enrique Hidalgo" , Salary = 1500},
                new { EmployeeId = 4 , EmployeeName = "Pascual Márquez" , Salary = 1180},
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
    }
}