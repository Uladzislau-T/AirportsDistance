using System;
using System.Threading.Tasks;
using AirportsDistance.API.Connections.Http.Clients;
using AirportsDistance.Domain.Dto;
using AirportsDistance.Domain.Enums;
using AirportsDistance.Infrasturcture.Contracts;

namespace AirportsDistance.API.Services
{
  class DistanceService : IDistanceService
  {
    private readonly PlacesDevCteleportHttpClient _PDCteleportClient;
    private readonly IAirportRepository _repository;

    public DistanceService(PlacesDevCteleportHttpClient PDCteleportClient, IAirportRepository repository)
    {
      _PDCteleportClient = PDCteleportClient;
      _repository = repository;
    }
    public async Task<DistanceResponseDto> GetDistanceAsync(DistanceRequestDto dto)
    {      
      var airportFirst = await _repository.GetAirportAsync(dto.Iata1.ToUpper());

      if(airportFirst == null)
      {
        airportFirst = await _PDCteleportClient.GetAirportByIataAsync(dto.Iata1.ToUpper());
        await _repository.UpdateAirportAsync(airportFirst);
      }

      var airportSecond = await _repository.GetAirportAsync(dto.Iata2.ToUpper());

      if(airportSecond == null)
      {
        airportSecond = await _PDCteleportClient.GetAirportByIataAsync(dto.Iata2.ToUpper());  
        await _repository.UpdateAirportAsync(airportSecond);
      }

      var distanceRaw = CalculateDistance(
        airportFirst.Location.Lat, 
        airportFirst.Location.Lon, 
        airportSecond.Location.Lat, 
        airportSecond.Location.Lon
      );    

      var distance = dto.Units switch
      {        
        DistanceUnitsEnum.Miles => Math.Round(distanceRaw * 0.00062137),
        DistanceUnitsEnum.Kilometres => Math.Round(distanceRaw / 1000),        
        _ => Math.Round(distanceRaw)
      };      

      var result = new DistanceResponseDto() {
        AirportFirst = airportFirst.Name,
        AirportSecond = airportSecond.Name,
        Distance = (int)distance,
        Units = dto.Units.ToString()
      };

      return result;
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