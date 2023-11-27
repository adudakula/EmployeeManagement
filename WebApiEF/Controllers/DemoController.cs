using Microsoft.AspNetCore.Mvc;
using WebApiEF.Filters;

namespace WebApiEF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [CustomExceptionFilter("DemoController")]
    public class DemoController : ControllerBase
    {

        // GET: DemoController
        [HttpGet]
        [CustomExceptionFilterAttribute("Action(Index)")]
        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                // Your action logic here
                // If an exception occurs within this action, the CustomExceptionFilterAttribute will handle it
                throw new NullReferenceException("Id is null");






            }
            return Content("No id value");
        }

    }
}
