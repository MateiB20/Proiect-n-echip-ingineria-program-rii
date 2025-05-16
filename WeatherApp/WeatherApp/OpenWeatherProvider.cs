//-----------------------------------------------------------------------------
// Nume proiect: Weather App
// Fisier: OpenWeatherProvider.cs
// Descriere: TODO
// Autor: Tonix
//
//-----------------------------------------------------------------------------

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class OpenWeatherProvider : IWeatherProvider
    {
        private readonly string _apiKey;
        public OpenWeatherProvider(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<WeatherInfo.root> GetCurrentAsync(string location)
        {
            using var webClient = new WebClient { Encoding = Encoding.UTF8 };
            string url = string.Format(
                "https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric&lang={2}",
                WebUtility.UrlEncode(location),
                _apiKey,
                CultureInfo.CurrentUICulture.TwoLetterISOLanguageName
            );

            var json = await webClient.DownloadStringTaskAsync(url);
            return JsonConvert.DeserializeObject<WeatherInfo.root>(json);
        }
        public async Task<WeatherForecast.ForecastInfo> GetForecastAsync(double latitude, double longitude)
        {
            using var webClient = new WebClient { Encoding = Encoding.UTF8 };
            string url = string.Format(
                "https://api.openweathermap.org/data/2.5/forecast?lat={0}&lon={1}&appid={2}&units=metric&lang={3}",
                latitude,
                longitude,
                _apiKey,
                CultureInfo.CurrentUICulture.TwoLetterISOLanguageName
            );

            var json = await webClient.DownloadStringTaskAsync(url);
            return JsonConvert.DeserializeObject<WeatherForecast.ForecastInfo>(json);
        }
    }
}
