using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace WebApiEF.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Assembly, AllowMultiple = false)]
    public class CustomExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        public string _scope { get; set; }
        public int _level { get; set; }
        public CustomExceptionFilterAttribute(string scope, int level = 0)
        {
            _scope = scope;
            _level = level;
        }

        public void OnException(ExceptionContext context)
        {
            Console.WriteLine($"Inside CustomExceptionFilterAttribute Scope:{_scope} Level:{_scope}");
            // Resolve the SampleExceptionHandling class through service provider
            var serviceProvider = context.HttpContext.RequestServices;
            var sampleExceptionHandling = serviceProvider.GetRequiredService<SampleExceptionHandling>();

            // Log or handle the exception using SampleExceptionHandling instance
            sampleExceptionHandling.HandleException(context.Exception);
            context.Result = new ObjectResult("An error occurred.")
            {
                StatusCode = 500,
            };

            // Mark the exception as handled
            context.ExceptionHandled = true;



        }
    }
    public class SampleExceptionHandling
    {
        private readonly ILogger<SampleExceptionHandling> _logger;

        public SampleExceptionHandling(ILogger<SampleExceptionHandling> logger)
        {
            _logger = logger;
        }
        public void HandleException(Exception exception)
        {
            Console.WriteLine("Exception : " + exception.Message);

        }

    }
}
