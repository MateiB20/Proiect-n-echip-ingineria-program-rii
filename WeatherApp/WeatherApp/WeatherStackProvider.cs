//-----------------------------------------------------------------------------
// Nume proiect: Weather App
// Fisier: WeatherStackProvider.cs
// Descriere: TODO
// Autor: Tonix
//
//-----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherModule;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Weather provider = WeatherStack: https://weatherstack.com/
    /// </summary>
    class WeatherStackProvider : IWeatherProvider
    {
        private readonly string _apiKey;

        public WeatherStackProvider(string apiKey)
        {
            _apiKey = apiKey;
        }
        public Task<WeatherInfo.CurrentWeatherResponse> GetCurrentAsync(string location)
        {
            throw new NotImplementedException();
        }

        public Task<WeatherForecast.ForecastInfo> GetForecastAsync(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }
    }
}
