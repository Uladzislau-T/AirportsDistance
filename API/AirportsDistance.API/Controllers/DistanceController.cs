using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportsDistance.Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AirportsDistance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistanceController : ControllerBase
    {
        // // GET api/values
        // [HttpGet]
        // public ActionResult<IEnumerable<string>> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }

        // POST api/distance
        [HttpPost]
        public async Task<IActionResult> GetDistance([FromBody] DistanceRequestDto dto)
        {

            return Ok(dto);
        }

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
