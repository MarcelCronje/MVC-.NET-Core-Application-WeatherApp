using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Models
{
    public class City
    {
        [Display(Name = "City Name")]
        public string Name { get; set; }

        [Display(Name = "Temperature (°C)")]
        public double Temperature { get; set; }

        [Display(Name = "Humidity (%)")]
        public int Humidity { get; set; }

        [Display(Name = "Pressure (mb)")]
        public double Pressure { get; set; }

        [Display(Name = "Wind Speed (km/h)")]
        public double Wind { get; set; }

        [Display(Name = "Weather Condition")]
        public string Weather { get; set; }

        [Display(Name = "Weather Condition Text")]
        public string WeatherConditionText { get; set; }

        [Display(Name = "Weather Condition Icon")]
        public string WeatherConditionIcon { get; set; }

        public string WeatherIconUrl { get; set; }
        public string TemperatureUnit { get; set; }

    }
}
