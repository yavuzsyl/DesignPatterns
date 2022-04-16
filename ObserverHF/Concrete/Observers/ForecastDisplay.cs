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

        public ForecastDisplay(WeatherData weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }

        public void Display()
        {
            //
            Console.WriteLine("Forecast: " );
        }
        public void Update(float temp, float humidity, float pressure)
        {
            //  
            Display();
        }
    }
}
