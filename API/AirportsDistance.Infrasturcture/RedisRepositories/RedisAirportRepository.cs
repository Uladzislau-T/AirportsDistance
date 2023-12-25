using System;
using System.Text.Json;
using System.Threading.Tasks;
using AirportsDistance.Domain;
using AirportsDistance.Domain.Models;
using AirportsDistance.Infrasturcture.Contracts;
using StackExchange.Redis;

namespace AirportsDistance.Infrasturcture.RedisRepositories
{
  public class RedisAirportRepository : IAirportRepository
  {
    private readonly ConnectionMultiplexer _redis;
    private readonly IDatabase _database;

    public RedisAirportRepository(ConnectionMultiplexer redis)
    {
      _redis = redis;
      _database = redis.GetDatabase();
    }

    public async Task<Airport> GetAirportAsync(string iata)
    {
      var redisAirport = await _database.StringGetAsync($"Iata:{iata}");
      
      if(!redisAirport.IsNullOrEmpty)
      {
        var response = JsonSerializer.Deserialize<Airport>(redisAirport, JsonDefaults.CaseInsensitiveOptions);

        Console.WriteLine("Responsed with cached airport");

        return response;
      }

      return null;
    }

    public async Task<Airport> UpdateAirportAsync(Airport airport)
    {
      var stringToCache = JsonSerializer.Serialize<Airport>(airport, JsonDefaults.CaseInsensitiveOptions);

      var created = await _database.StringSetAsync($"Iata:{airport.Iata}", stringToCache, TimeSpan.FromMinutes(10));

      if (!created)
      {
        Console.WriteLine("Problem occur persisting the item.");
        return null;
      }

      Console.WriteLine("Airport response persisted successfully.");
      return airport;
    }
  }
}