// See https://aka.ms/new-console-template for more information
using ObserverHF;
using ObserverHF.Concrete.Observers;

Console.WriteLine("Hello, World!");


WeatherData weatherData = new WeatherData();

CurrentConditionsDisplay currentConditionsDisplay = new CurrentConditionsDisplay(weatherData);
StatisticsDisplay statisticsDisplay = new StatisticsDisplay(weatherData);
ForecastDisplay forecastDisplay = new ForecastDisplay(weatherData);

weatherData.SetMeasurements(80, 65, 30.4f);
weatherData.SetMeasurements(82, 70, 29.2f);
weatherData.SetMeasurements(78, 90, 29.2f);


Console.WriteLine();