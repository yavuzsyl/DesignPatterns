using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverHF.Concrete.Observers;
public class CurrentConditionsDisplay : IObserver, IDisplayElement
{
    private float temperature;
    private float humidity;
    private ISubject weatherData;

    public CurrentConditionsDisplay(ISubject weatherData)
    {
        this.weatherData = weatherData;
        weatherData.RegisterObserver(this);
    }
    public void Display()
    {
        Console.WriteLine("Current conditions: " + temperature + "F degrees and " + humidity + "% humidity");
    }

    public void Update()
    {
        this.temperature = weatherData.GetTemperature();
        this.humidity = weatherData.GetHumidity();
        Display();
    }
}
