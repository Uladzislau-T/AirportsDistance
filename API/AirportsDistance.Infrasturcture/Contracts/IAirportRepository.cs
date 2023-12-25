using System.Threading.Tasks;
using AirportsDistance.Domain.Models;

namespace AirportsDistance.Infrasturcture.Contracts
{
  public interface IAirportRepository
  {
    Task<Airport> GetAirportAsync(string iata);
    Task<Airport> UpdateAirportAsync(Airport airport);
  }
}