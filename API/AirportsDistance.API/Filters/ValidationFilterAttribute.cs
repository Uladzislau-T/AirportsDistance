using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AirportsDistance.API.Filters
{
  public class ValidationFilterAttribute : IActionFilter
  {
    public void OnActionExecuting(ActionExecutingContext context)
    {
      if (!context.ModelState.IsValid)
      {
        // context.Result = new UnprocessableEntityObjectResult(context.ModelState);
        string messages = string.Join("; ",context.ModelState.Values
                     .SelectMany(x => x.Errors)
                     .Select(x => !string.IsNullOrWhiteSpace(x.ErrorMessage) ? x.ErrorMessage : x.Exception.Message.ToString()));
        
        var responseObj = new
        {
            Message = "Bad Request",
            Errors = messages                    
        };

        context.Result = new JsonResult(responseObj)
        {
            StatusCode = 400
        };
      }
    }
    public void OnActionExecuted(ActionExecutedContext context) {}
  }
}