using AirportsDistance.Domain.Enums;

namespace AirportsDistance.Domain.Dto
{
  public class DistanceRequestDto
  {
    public string Iata1 { get; set; }
    public string Iata2 { get; set; }
    public DistanceUnitsEnum Units { get; set; }    
  }
}