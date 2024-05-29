# MVC-.NET-Core-Application-WeatherApp
Weather App
Overview
The Weather App is a .NET Core MVC application that allows users to search for and view the weather forecast for any city. The app fetches weather data from a weather API and displays current weather conditions, including temperature, humidity, pressure, wind speed, and a weather description. Users can switch between Celsius and Fahrenheit temperature units, and a loader animation provides feedback during data fetching.

Features

- Search by City: Users can search for weather information by entering the name of a city.
- Current Weather Display: Displays current weather conditions such as temperature, humidity, pressure, wind speed, and a descriptive weather icon.
- Temperature Unit Conversion: Users can switch between Celsius and Fahrenheit.
- Loading Indicator: A loader animation displays while data is being fetched.
- Error Handling: Provides feedback if the city does not exist or if weather data is unavailable.
Technologies Used
.NET Core MVC
HTML/CSS/JavaScript
Weather API (e.g., WeatherAPI.com)
AJAX for asynchronous operations
Setup Instructions
Clone the Repository

Use git clone to clone the repository and navigate into the directory.
Install Dependencies

Ensure you have the .NET Core SDK installed and run dotnet restore to restore the project dependencies.
API Key Configuration

Obtain an API key from a weather data provider and add this key to your appsettings.json file.
Run the Application

Use dotnet run to start the application.
Project Structure
Controllers

Handles the logic for weather search, temperature conversion, and error handling.
Models

Data models for city search, weather details, and API responses.
Views

Views for searching weather by city and displaying weather details.
wwwroot/css/site.css

Contains the CSS for styling the application and loader animation.
Scripts

JavaScript for handling form submission, showing the loader, and client-side validation.
Key Implementations
Controller Actions
SearchByCity (GET)

Initializes and returns the search by city view.
SearchByCity (POST)

Validates the input, fetches weather data, and handles the case where the city does not exist.
City (GET)

Fetches and displays weather details for a specified city, or shows an error message if data is not found.
ConvertTemperatureUnit (GET)

Converts the temperature between Celsius and Fahrenheit and updates the view accordingly.
View Enhancements
Loader Animation and Overlay

Adds a loader animation and overlay that displays while data is being fetched.
Form Validation and Error Display

Provides client-side validation and displays error messages if the city does not exist.
Styling
Loader CSS
Styles for the loader animation to indicate data fetching.
Contributing
Contributions are welcome! Please open an issue or submit a pull request for any improvements or bug fixes.

License
This project is licensed under the MIT License.
