using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverHF.Concrete.Observers
{
    public class ForecastDisplay : IObserver, IDisplayElement
    {
        private WeatherData weatherData;
        private float currentPressure = 29.92f;
        private float lastPressure;

        public ForecastDisplay(WeatherData weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }

        public void Display()
        {
            Console.WriteLine("Forecast: current pressure" + currentPressure + " last pressure" + lastPressure);
        }
        public void Update()
        {
            lastPressure = currentPressure;
            currentPressure = weatherData.GetPressure();
            Display();
        }
    }
}
