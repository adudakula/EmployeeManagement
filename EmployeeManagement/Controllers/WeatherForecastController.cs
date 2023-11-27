using Microsoft.AspNetCore.Mvc;
namespace EmployeeManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            int length = Summaries.Length;
            return Enumerable.Range(1, length).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("{summary}")]
        public IActionResult GetStudent(string summary)
        {
            try
            {
                var entity = Summaries.FirstOrDefault((s) => s == summary);
                if (entity == null)
                {
                    return NotFound("Summary Not Found");
                }
                var message = new WeatherForecast()
                {
                    Date = DateTime.Now.AddDays(3),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = entity
                };


                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong in server. see details" + ex.Message);
            }
        }

        [HttpPost("{summary}")]
        public IActionResult POSTStudent(string summary)
        {
            try
            {
                if (Summaries.Contains(summary))
                {
                    return Conflict("Item already present");
                }
                Summaries = Summaries.ToArray().Append(summary).ToArray();
                var message = new WeatherForecast()
                {
                    Date = DateTime.Now.AddDays(3),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summary
                };
                return StatusCode(201, message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong in server. see details" + ex.Message);
            }

        }

        [HttpDelete("{summary}")]
        public IActionResult DeleteStudent(string summary)
        {

            try
            {
                var entity = Summaries.ToArray().FirstOrDefault((s) => s == summary);
                if (entity == null)
                {
                    return NotFound("The Summary is not present to delete");
                }
                else
                {
                    Summaries = Summaries.ToArray().Where(s => s != summary).ToArray();
                    return StatusCode(204, "Deleted Successfully");

                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong in server. see details" + ex.Message);
            }

        }

        [HttpPut("{summary}/{newSummary}")]
        public IActionResult PutStudent(string summary, string newSummary)
        {
            try
            {
                int index = Array.IndexOf(Summaries, summary);
                if (index == -1)
                {
                    return NotFound();
                }
                else
                {
                    Summaries[index] = newSummary;
                    var message = new WeatherForecast()
                    {
                        Date = DateTime.Now.AddDays(3),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = newSummary
                    };
                    return Ok(message);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong in server. see details" + ex.Message);
            }

        }
        //public HttpResponseMessage GetStudent([FromUri] string summary)
        //{
        //    try
        //    {

        //        var entity = Summaries.FirstOrDefault((s) => s == summary);
        //        if (entity == null)
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Summary found for Summary Name = " + summary);
        //        }
        //        var message = new
        //        {
        //            Date = DateTime.Now.AddDays(3),
        //            TemperatureC = Random.Shared.Next(-20, 55),
        //            Summary = entity
        //        };
        //        return Request.CreateResponse(HttpStatusCode.OK, message);

        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
        //    }

        //}




        //public HttpResponseMessage POSTStudent([System.Web.Http.FromBody] string summary)
        //{
        //    try
        //    {

        //        Summaries = Summaries.ToArray().Append(summary).ToArray();
        //        var response = Request.CreateResponse(HttpStatusCode.Created, summary);
        //        response.Headers.Location = new Uri(Request.RequestUri + summary);
        //        return response;


        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
        //    }

        //}



        //public HttpResponseMessage DeleteStudent([FromUri] string summary)
        //{
        //    try
        //    {

        //        var entity = Summaries.ToArray().FirstOrDefault((s) => s == summary);
        //        if (entity == null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.NotFound, "Forecast with summary = " + summary + " Not found to delete");
        //        }
        //        else
        //        {
        //            Summaries = Summaries.ToArray().Where(s => s != summary).ToArray();
        //            return Request.CreateErrorResponse(HttpStatusCode.OK, "Forecast with summary = " + summary + " Deleted Successfully");
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
        //    }

        //}




        //public HttpResponseMessage PutStudent([FromUri] string summary, [System.Web.Http.FromBody] string newSummary)
        //{
        //    try
        //    {

        //        int index = Array.IndexOf(Summaries, summary);
        //        if (index == -1)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.NotFound, "Forecast with summary = " + newSummary + " Not Found to Edit");
        //        }
        //        else
        //        {
        //            Summaries[index] = newSummary;
        //            var message = new
        //            {
        //                Date = DateTime.Now.AddDays(3),
        //                TemperatureC = Random.Shared.Next(-20, 55),
        //                Summary = newSummary
        //            };
        //            var response = Request.CreateResponse(HttpStatusCode.OK, message);
        //            return response;
        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
        //    }

        //}




        //return new ContentResult
        //{
        //    StatusCode = 204,
        //    Content = "Deleted Successfully",
        //    ContentType = "text/plain" // Optional content type
        //};
    }

}