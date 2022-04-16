using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverHF.Concrete.Observers
{
    public class StatisticsDisplay : IObserver, IDisplayElement
    {
        private WeatherData weatherData;

        public StatisticsDisplay(WeatherData weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }

        public void Display()
        {
            Console.WriteLine("StatisticsDisplay: ");
        }

        public void Update(float temp, float humidity, float pressure)
        {
            //
            Display();
        }
    }
}
