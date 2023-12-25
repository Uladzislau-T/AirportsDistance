using System.ComponentModel.DataAnnotations;
using AirportsDistance.Domain.Enums;

namespace AirportsDistance.Domain.Dto
{
  public class DistanceRequestDto
  {
    [Required(ErrorMessage = "Iata1 for the first Airport is required")]
    [StringLength(3, MinimumLength = 3, ErrorMessage = "Iata must have 3 characters")]
    public string Iata1 { get; set; }

    [Required(ErrorMessage = "Iata2 for the second Airport is required")]
    [StringLength(3, MinimumLength = 3, ErrorMessage = "Iata must have 3 characters")]
    public string Iata2 { get; set; }
    
    [Required(ErrorMessage = "Units type for distance calculation is required")]
    public DistanceUnitsEnum? Units { get; set; } = DistanceUnitsEnum.Miles;   
  }
}