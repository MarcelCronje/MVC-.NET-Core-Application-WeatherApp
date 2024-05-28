using RestSharp;
using WeatherApp.Models;

namespace WeatherApp.Repositories
{
    public class WForecastRepository : IWForecastRepository
    {
        public WeatherResponse GetForecast(string city)
        {
            string API_KEY = "4043ba14d05d4bff865110107242705"; // Your API key from weatherapi.com

            var client = new RestClient("http://api.weatherapi.com/v1/current.json");
            var request = new RestRequest(Method.GET); // Here's the correction
            request.AddParameter("key", API_KEY);
            request.AddParameter("q", city);
            request.AddParameter("aqi", "no"); // You may adjust this parameter based on your requirement

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherResponse>(response.Content);
            }
            else
            {
                // Handle unsuccessful response
                Console.WriteLine("Error: " + response.StatusCode);
                return null;
            }
        }
    }
}