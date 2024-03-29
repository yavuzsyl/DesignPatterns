﻿namespace ObserverHF;

public class WeatherData : ISubject
{
    private List<IObserver> observers;

    private float temperature;
    private float humidity;
    private float pressure;
    private float heatIndex => temperature * humidity;

    public WeatherData()
    {
        observers = new List<IObserver>();
    }

    public float GetTemperature() => temperature;
    public float GetHumidity() => humidity;
    public float GetPressure() => pressure;

    public void NotifyObservers()
    {
        observers.ForEach(o => o.Update());
        Console.WriteLine($"Heat Index: {heatIndex}");
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void MeasurementsChanged()
    {
        NotifyObservers();
    }

    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        this.pressure = pressure;
        MeasurementsChanged();
    }

}



