using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class MyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
