using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApiEF.Filters
{

    public class LowercaseFilter : Attribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {

        }

        public void OnResultExecuting(ResultExecutingContext context)
        {

            if (context.Result is ObjectResult objectResult)

            {



                var temp = objectResult.Value;

                if (temp is IEnumerable<WeatherForecast>)

                {

                    IEnumerable<WeatherForecast> weatherEnumerable = temp as IEnumerable<WeatherForecast>;

                    foreach (var w in weatherEnumerable)

                    {

                        w.Summary = w.Summary.ToLower();

                    }

                    objectResult.Value = weatherEnumerable;

                }

                else if (temp is WeatherForecast)

                {

                    var weather = temp as WeatherForecast;

                    weather.Summary = weather.Summary.ToUpper();

                    objectResult.Value = weather;

                }

            }



        }


    }
}