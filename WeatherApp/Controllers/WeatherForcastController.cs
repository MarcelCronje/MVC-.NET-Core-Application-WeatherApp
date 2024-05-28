using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;
using WeatherApp.Repositories;
using System;

namespace WeatherApp.Controllers
{
    public class WeatherForecastController : Controller
    {
        private readonly IWForecastRepository _WForecastRepository;

        public WeatherForecastController(IWForecastRepository WForecastRepository)
        {
            _WForecastRepository = WForecastRepository;
        }

        [HttpGet]
        public IActionResult SearchByCity()
        {
            var viewModel = new SearchByCity();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SearchByCity(SearchByCity model)
        {
            if (ModelState.IsValid)
            {
                // Check if the city exists
                var weatherResponse = _WForecastRepository.GetForecast(model.CityName);
                if (weatherResponse == null)
                {
                    ModelState.AddModelError(string.Empty, "Place does not exist.");
                    return View(model);
                }

                return RedirectToAction("City", new { city = model.CityName });
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult City(string city, int? temperature, string temperatureUnit)
        {
            WeatherResponse weatherResponse = _WForecastRepository.GetForecast(city);
            if (weatherResponse != null)
            {
                int tempC = temperature ?? (int)Math.Round((double)weatherResponse.Current.Temp_c);
                string tempUnit = temperatureUnit ?? "Celsius";
                var viewModel = new City
                {
                    Name = weatherResponse.Location.Name,
                    Temperature = tempC,
                    Humidity = weatherResponse.Current.Humidity,
                    Pressure = (int)weatherResponse.Current.Pressure_mb,
                    Weather = weatherResponse.Current.Condition.Text,
                    Wind = weatherResponse.Current.Wind_kph,
                    WeatherConditionText = weatherResponse.Current.Condition.Text,
                    WeatherConditionIcon = weatherResponse.Current.Condition.Icon,
                    TemperatureUnit = tempUnit
                };
                return View(viewModel);
            }
            else
            {
                ViewBag.ErrorMessage = "Weather data not found for the specified city.";
                return View();
            }
        }

        [HttpGet]
        public IActionResult ConvertTemperatureUnit(string city, int currentTemperature, string currentUnit)
        {
            int newTemperature;
            string newUnit;

            if (currentUnit == "Celsius")
            {
                newTemperature = (int)Math.Round((double)(currentTemperature * 9 / 5) + 32);
                newUnit = "Fahrenheit";
            }
            else
            {
                newTemperature = (int)Math.Round((double)(currentTemperature - 32) * 5 / 9);
                newUnit = "Celsius";
            }

            return RedirectToAction("City", new { city = city, temperature = newTemperature, temperatureUnit = newUnit });
        }
    }
}