using System.Threading.Tasks;
using AirportsDistance.API.Filters;
using AirportsDistance.API.Services;
using AirportsDistance.Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AirportsDistance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistanceController : ControllerBase
    {
        private readonly IDistanceService _distanceService;

        public DistanceController(IDistanceService distanceService)
        {
            _distanceService = distanceService;
        }


        // GET api/distance
        [HttpGet]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> GetDistance([FromQuery] DistanceRequestDto dto)
        {
            var result = await _distanceService.GetDistanceAsync(dto);

            return Ok(result);
        }

        // // POST api/distance
        // [HttpPost]
        // public async Task<IActionResult> Create([FromBody] DistanceRequestDto dto)
        // {

        //     return Created(result);
        // }

        // // PUT api/values/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
