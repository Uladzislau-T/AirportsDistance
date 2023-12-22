namespace AirportsDistance.Domain.Models
{
  public class Airport
  {
    public string Iata { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string CityIata { get; set; }
    public string Country { get; set; }
    public string CountryIata { get; set; }
    public Location Location { get; set; }
    public double Rating { get; set; }
    public int Hubs { get; set; }
    public string TimezoneRegionName { get; set; }
    public string Type { get; set; }
  }
}