# MVC-.NET-Core-Application-WeatherApp
Weather App
Overview
The Weather App is a .NET Core MVC application that allows users to search for and view the weather forecast for any city. The app fetches weather data from a weather API and displays current weather conditions, including temperature, humidity, pressure, wind speed, and a weather description. Users can switch between Celsius and Fahrenheit temperature units, and a loader animation provides feedback during data fetching.

Features
Search by City: Users can search for weather information by entering the name of a city.
Current Weather Display: Displays current weather conditions such as temperature, humidity, pressure, wind speed, and a descriptive weather icon.
Temperature Unit Conversion: Users can switch between Celsius and Fahrenheit.
Loading Indicator: A loader animation displays while data is being fetched.
Error Handling: Provides feedback if the city does not exist or if weather data is unavailable.
Technologies Used
.NET Core MVC
HTML/CSS/JavaScript
Weather API (e.g., WeatherAPI.com)
AJAX for asynchronous operations
Setup Instructions
Clone the Repository


git clone https://github.com/your-username/your-repo-name.git
cd your-repo-name
Install Dependencies
Make sure you have .NET Core SDK installed. Restore the project dependencies.


dotnet restore
API Key Configuration
Obtain an API key from a weather data provider (e.g., WeatherAPI.com). Add this key to your configuration.

Open appsettings.json.
Add your API key:

{
  "WeatherApiKey": "your_api_key_here"
}
Run the Application


dotnet run
Project Structure
Controllers

WeatherForecastController.cs: Manages the weather search, temperature conversion, and error handling logic.
Models

SearchByCity.cs: Represents the data model for city search.
City.cs: Represents the data model for the weather details of a city.
WeatherResponse.cs: Represents the structure of the weather data received from the API.
Views

SearchByCity.cshtml: View for searching weather by city.
City.cshtml: View for displaying weather details of a city.
wwwroot/css/site.css

Contains the CSS for styling the application and loader animation.
Scripts

JavaScript for handling form submission, showing the loader, and client-side validation.
Key Implementations
Controller Actions
SearchByCity (GET)


[HttpGet]
public IActionResult SearchByCity()
{
    var viewModel = new SearchByCity();
    return View(viewModel);
}
SearchByCity (POST)


[HttpPost]
public IActionResult SearchByCity(SearchByCity model)
{
    if (ModelState.IsValid)
    {
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
City (GET)


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
ConvertTemperatureUnit (GET)


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
View Enhancements
Loader Animation and Overlay


<div class="overlay"></div>
<div class="loader"></div>

<script>
    function showLoader() {
        document.querySelector('.loader').style.display = 'block';
        document.querySelector('.overlay').style.display = 'block';
    }
</script>
Form Validation and Error Display


<span asp-validation-for="CityName" class="text-danger"></span>
@if (ViewData.ModelState[""] != null && ViewData.ModelState[""].Errors.Count > 0)
{
    <div class="text-danger">
        @ViewData.ModelState[""].Errors[0].ErrorMessage
    </div>
}
Styling
Loader CSS

.loader {
    border: 16px solid #f3f3f3;
    border-radius: 50%;
    border-top: 16px solid #3498db;
    width: 120px;
    height: 120px;
    animation: spin 2s linear infinite;
    position: fixed;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    display: none; /* Hidden by default */
    z-index: 9999; /* Ensure loader is above other elements */
}

@keyframes spin {
    0% { transform: rotate(0deg); }
    100% { transform: rotate(360deg); }
}

.overlay {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: rgba(0, 0, 0, 0.5);
    z-index: 9998;
    display: none; /* Hidden by default */
}
Contributing
Contributions are welcome! Please open an issue or submit a pull request for any improvements or bug fixes.

License
This project is licensed under the MIT License.
