//-----------------------------------------------------------------------------
// Nume proiect: Weather App
// Fisier: WttrProvider.cs
// Descriere: TODO
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
    /// Weather provider = Wttr: wttr.io
    /// </summary>
    class WttrProvider : IWeatherProvider
    {
        public Task<WeatherInfo.root> GetCurrentAsync(string location)
        {
            throw new NotImplementedException();
        }

        public Task<WeatherForecast.ForecastInfo> GetForecastAsync(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }
    }
}
