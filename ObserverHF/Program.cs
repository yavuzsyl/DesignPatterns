// See https://aka.ms/new-console-template for more information
using ObserverHF;
using ObserverHF.Concrete.Observers;

Console.WriteLine("Hello, World!");

//subject - publisher - objenin state'i değiştiği zaman onu dinleyen observer objelerine bildirim gönderir 
//The Observer Pattern defines a one-to-many relationship between a set of objects. When the state of one object changes, all of its dependents are notified


WeatherData weatherData = new WeatherData();

var currentConditionsDisplay = new CurrentConditionsDisplay(weatherData);
var statisticsDisplay = new StatisticsDisplay(weatherData);
var forecastDisplay = new ForecastDisplay(weatherData);


//mock
weatherData.SetMeasurements(80, 65, 30.4f);
weatherData.SetMeasurements(82, 70, 29.2f);
weatherData.SetMeasurements(78, 90, 29.2f);


Console.WriteLine();