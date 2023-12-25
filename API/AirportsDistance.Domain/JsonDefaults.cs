using System.Text.Json;

namespace AirportsDistance.Domain
{
  public static class JsonDefaults
  {
    public static readonly JsonSerializerOptions CaseInsensitiveOptions = new JsonSerializerOptions()
    {
      PropertyNameCaseInsensitive = true
    };
  }
}