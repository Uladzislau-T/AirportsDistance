using System.Text.Json.Serialization;

namespace AirportsDistance.Domain.Enums
{
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum DistanceUnitsEnum
  {
    Metres,
    Kilometres,
    Miles
  }
}