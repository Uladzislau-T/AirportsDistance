using System;
using System.Net;
using System.Threading.Tasks;
using AirportsDistance.API.Exceptions;
using AirportsDistance.Domain.ErrorModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AirportsDistance.API.Middlewares
{
  public class ExceptionMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
      _logger = logger;
      _next = next;
    }
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
          await _next(httpContext);
        }
        catch(HttpResponseException ex)
        {
          _logger.LogError($"Error: {ex.Message}");
          await HandleExceptionAsync(httpContext, ex, ex.StatusCode);
        }
        catch (Exception ex)
        {
          _logger.LogError($"Error: {ex.Message}");
          await HandleExceptionAsync(httpContext, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
    {
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)statusCode;

      // var message = exception switch
      // {
      //   AccessViolationException => "",
      //   _ => ""
      // };
      
      await context.Response.WriteAsync(new ErrorDetails()
      {
        StatusCode = (int)statusCode,
        Message = exception.Message
      }.ToString());
    }
  }
}