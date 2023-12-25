
using System.Collections.Generic;
using System.Text.Json;

namespace AirportsDistance.Domain.ErrorModel
{
    public class ErrorDetails
    {
        public string StatusCode { get; set; }
        public ICollection<string> Errors { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
        
    }
}
