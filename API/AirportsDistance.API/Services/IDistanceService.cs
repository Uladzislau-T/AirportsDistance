using System.Threading.Tasks;
using AirportsDistance.Domain.Dto;

namespace AirportsDistance.API.Services
{
  public interface IDistanceService
  {
    Task<int> GetDistanceAsync(DistanceRequestDto dto);    
  }
}