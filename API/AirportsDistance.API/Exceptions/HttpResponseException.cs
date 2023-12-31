using System;
using System.Net;

namespace AirportsDistance.API.Exceptions
{
  public class HttpResponseException : Exception
  {
    public HttpStatusCode StatusCode { get; private set; }

    public HttpResponseException(HttpStatusCode statusCode, string message) : base(message)
    {
      StatusCode = statusCode;
    }
  }
}