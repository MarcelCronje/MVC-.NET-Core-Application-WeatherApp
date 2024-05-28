namespace WeatherApp.Models
{
    public class WeatherResponse
    {
        public Location Location { get; set; }
        public CurrentWeather Current { get; set; }
    }
}