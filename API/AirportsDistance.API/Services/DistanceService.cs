using System;
using System.Threading.Tasks;
using AirportsDistance.Domain.Dto;

namespace AirportsDistance.API.DistanceService
{
  class DistanceService
  {


    public DistanceService()
    {
      
    }
    public async Task GetDistance(DistanceRequestDto dto)
    {
      try
      {
        
      }
      catch (System.Exception)
      {
        
        throw;
      }
    }


    private double CalculateDistance()
    {
      var latitude = 52.526073;
      var longitude = 31.017895;
      var otherLatitude = 53.889725;
      var otherLongitude = 28.032442;
      
      var d1 = latitude * (Math.PI / 180.0);
      var num1 = longitude * (Math.PI / 180.0);
      var d2 = otherLatitude * (Math.PI / 180.0);
      var num2 = otherLongitude * (Math.PI / 180.0) - num1;
      var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

      
      
      return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
    } 
  }
}