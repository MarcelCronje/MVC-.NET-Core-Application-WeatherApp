# MVC-.NET-Core-Application-WeatherApp
<h2>Weather App</h2>
<h3>Overview</h3>

<p>The Weather App is a .NET Core MVC application that allows users to search for and view the weather forecast for any city. The app fetches weather data from a weather API and displays current weather conditions, including temperature, humidity, pressure, wind speed, and a weather description. Users can switch between Celsius and Fahrenheit temperature units, and a loader animation provides feedback during data fetching.<p/>
<be>

<p align="center">
<img src="https://i.ibb.co/smZM6n5/Mobile-Preview-Assesment.png" alt="Mobile-Preview-Assessment" width="320" height="670.8">
<p/>

<img src="https://i.ibb.co/Y0zYF68/Desktop-Preview-Assesment.png" alt="Desktop-Preview-Assessment" width="auto" height="auto">

<h3>Features</h3>

- Search by City: Users can search for weather information by entering the name of a city.
- Current Weather Display: Displays current weather conditions such as temperature, humidity, pressure, wind speed, and a descriptive weather icon.
- Temperature Unit Conversion: Users can switch between Celsius and Fahrenheit.
- Loading Indicator: A loader animation displays while data is being fetched.
- Error Handling: Provides feedback if the city does not exist or if weather data is unavailable.
<br>

<h3>Technologies Used</h3>

- .NET Core MVC
- HTML/CSS/JavaScript
- Bootstrap CSS Library
- Weather API (e.g., WeatherAPI.com)
- AJAX for asynchronous operations
<br>

<h3>Setup Instructions</h3>

1. Clone the Repository

- Use git clone to clone the repository and navigate into the directory.
<br>

2. Install Dependencies

- Ensure you have the .NET Core SDK installed and run dotnet restore to restore the project dependencies.
<br>

3. API Key Configuration

- Obtain an API key from a weather data provider and add this key to your appsettings.json file.
<br>

4. Run the Application

- Use dotnet run to start the application.
<br>

<h3>Project Structure</h3>

<h4>Controllers</h4>

- Handles the logic for weather search, temperature conversion, and error handling.
<br>

<h4>Models</h4>

- Data models for city search, weather details, and API responses.
<br>

<h4>Views</h4>

- Views for searching weather by city and displaying weather details.
<br>

<h4>wwwroot/css/site.css</h4>

- Contains the CSS for styling the application and loader animation.
<br>

<h4>Scripts</h4>

- JavaScript for handling form submission, showing the loader, and client-side validation.
<br>


<h3>Key Implementations</h3>

<h4>Controller Actions</h4>

SearchByCity (GET)
- Initializes and returns the search by city view.

SearchByCity (POST)
- Validates the input, fetches weather data, and handles the case where the city does not exist.

City (GET)
- Fetches and displays weather details for a specified city, or shows an error message if data is not found.

ConvertTemperatureUnit (GET)
- Converts the temperature between Celsius and Fahrenheit and updates the view accordingly.
<br>

<h4>View Enhancements</h4>

Loader Animation and Overlay
- Adds a loader animation and overlay that displays while data is being fetched.

Form Validation and Error Display
- Provides client-side validation and displays error messages if the city does not exist.
<br>

<h4>Styling</h4>

Loader CSS
- Styles for the loader animation to indicate data fetching.
<br>


<h3>Contributing</h3>

<p>Contributions are welcome! Please open an issue or submit a pull request for any improvements or bug fixes.</p>
<br>


<h3>License</h3>

<p>This project is licensed under the MIT License.</p>
