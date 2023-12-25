using System.Collections.Generic;
using System.Linq;
using AirportsDistance.Domain.ErrorModel;
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
        var messages = new List<string>();

        messages.AddRange(context.ModelState.Values
                     .SelectMany(x => x.Errors)
                     .Select(x => !string.IsNullOrWhiteSpace(x.ErrorMessage) ? x.ErrorMessage : x.Exception.Message)); 
        
        var responseObj = new ErrorDetails()
        {
            StatusCode = "Bad Request",
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