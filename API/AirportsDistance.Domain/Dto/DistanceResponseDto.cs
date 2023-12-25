using System.Text.Json.Serialization;
using AirportsDistance.Domain.Enums;

namespace AirportsDistance.Domain.Dto
{
  public class DistanceResponseDto
  {
    public string AirportFirst { get; set; }
    public string AirportSecond { get; set; }
    public int Distance { get; set; }
    public string Units { get; set; }    
  }
}