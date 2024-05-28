using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Models
{
    public class SearchByCity
    {
        [Required(ErrorMessage = "City name is empty!")]
        [Display(Name = "City Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "City name must be between 2 and 50 characters")]
        public string CityName { get; set; }
    }
}
