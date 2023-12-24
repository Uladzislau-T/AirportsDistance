using System;
using System.Threading.Tasks;
using AirportsDistance.API.Connections.Http.Clients;
using AirportsDistance.Domain.Dto;
using AirportsDistance.Domain.Enums;

namespace AirportsDistance.API.Services
{
  class DistanceService : IDistanceService
  {
    private readonly PlacesDevCteleportHttpClient _PDCteleportClient;

    public DistanceService(PlacesDevCteleportHttpClient PDCteleportClient)
    {
      _PDCteleportClient = PDCteleportClient;
    }
    public async Task<int> GetDistanceAsync(DistanceRequestDto dto)
    {      
      var airportFirst = await _PDCteleportClient.GetAirportByIataAsync(dto.Iata1);

      var airportSecond = await _PDCteleportClient.GetAirportByIataAsync(dto.Iata2);  

      var resultRaw = CalculateDistance(
        airportFirst.Location.Lat, 
        airportFirst.Location.Lon, 
        airportSecond.Location.Lat, 
        airportSecond.Location.Lon
      );    

      // var result = dto.Units switch
      // {        
      //   DistanceUnitsEnum.Miles => Math.Round(resultRaw * 0.00062137),
      //   DistanceUnitsEnum.Kilometres => Math.Round(resultRaw / 1000),        
      //   _ => Math.Round(resultRaw)
      // };

      // return (int)result;
      return 0;
    }


    private double CalculateDistance(double latitudeFirst, double longitudeFirst, double latitudeSecond, double longitudeSecond)
    {
      
      var d1 = latitudeFirst * (Math.PI / 180.0);
      var num1 = longitudeFirst * (Math.PI / 180.0);
      var d2 = latitudeSecond * (Math.PI / 180.0);
      var num2 = longitudeSecond * (Math.PI / 180.0) - num1;
      var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);      
      
      return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
    } 
  }
}