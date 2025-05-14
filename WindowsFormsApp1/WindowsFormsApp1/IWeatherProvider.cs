//-----------------------------------------------------------------------------
// Nume proiect: Weather App
// Fisier: IWeatherProvider.cs
// Descriere: Interfata pentru api-uri de weather provider.
// Autor: Tonix
//
//-----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApp1
{
    /// <summary>
    /// Interfata pentru api-uri de weather provider.
    /// </summary>
    public interface IWeatherProvider
    {
        Task<WeatherInfo.root> GetCurrentAsync(string location);

        Task<WeatherForecast.ForecastInfo> GetForecastAsync(double latitude, double longitude);
    }

}
