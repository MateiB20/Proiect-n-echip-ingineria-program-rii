//-----------------------------------------------------------------------------
// Nume proiect: Weather App
// Fisier: OpenWeatherProvider.cs
// Descriere: TODO
// Autor: Tonix
//
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using WeatherModule;

namespace WindowsFormsApp1
{
    public class OpenWeatherProvider : IWeatherProvider
    {
        private readonly string _apiKey;
        public OpenWeatherProvider(string apiKey)
        {
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        }

        public async Task<WeatherInfo.CurrentWeatherResponse> GetCurrentAsync(string location)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(location))
                {
                    throw new ArgumentException(nameof(location));
                }

                using var httpClient = new HttpClient();
                string url = $"https://api.openweathermap.org/data/2.5/weather?q={WebUtility.UrlEncode(location)}&appid={_apiKey}&units=metric&lang={CultureInfo.CurrentUICulture.TwoLetterISOLanguageName}";

                var json = await httpClient.GetStringAsync(url);
                return JsonSerializer.Deserialize<WeatherInfo.CurrentWeatherResponse>(json)
                    ?? throw new Exception("Failed to deserialize weather data.");
            }
            catch (HttpRequestException httpEx)
            {
                throw new Exception("HTTP request failed.", httpEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error in GetCurrentAsync.", ex);
            }
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

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement
            };

            return JsonSerializer.Deserialize<WeatherForecast.ForecastInfo>(json, options)!;

        }
    }
}
