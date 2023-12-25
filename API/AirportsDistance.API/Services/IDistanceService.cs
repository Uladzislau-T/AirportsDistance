using System.Threading.Tasks;
using AirportsDistance.Domain.Dto;

namespace AirportsDistance.API.Services
{
  public interface IDistanceService
  {
    Task<DistanceResponseDto> GetDistanceAsync(DistanceRequestDto dto);    
  }
}