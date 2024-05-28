namespace WeatherApp.Models
{
    public class Location
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string TimeZoneId { get; set; }
        public long LocalTimeEpoch { get; set; }
        public string LocalTime { get; set; }
    }
}
