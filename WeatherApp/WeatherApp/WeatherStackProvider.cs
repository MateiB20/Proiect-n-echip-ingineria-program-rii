//-----------------------------------------------------------------------------
// Nume proiect: Weather App
// Fisier: WeatherStackProvider.cs
// Descriere: TODO
// Autor: Tonix
//
//-----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherModule;
using Microsoft.VisualBasic.Logging;

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
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        }
        public async Task<WeatherInfo.CurrentWeatherResponse> GetCurrentAsync(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentException(nameof(location));

            try
            {
                using var httpClient = new HttpClient();

                string url = $"https://api.weatherbit.io/v2.0/current?city={WebUtility.UrlEncode(location)}&key={_apiKey}&units=M";
                var json = await httpClient.GetStringAsync(url);
                using var doc = JsonDocument.Parse(json);
               

                var data = doc.RootElement.GetProperty("data")[0];


                return new WeatherInfo.CurrentWeatherResponse
                {
                    Coordinates = new WeatherInfo.Coordinates
                    {
                        Latitude = double.Parse(data.GetProperty("lat").GetRawText(), CultureInfo.InvariantCulture),
                        Longitude = double.Parse(data.GetProperty("lon").GetRawText(), CultureInfo.InvariantCulture)
                    },
                    WeatherConditions = new List<WeatherInfo.WeatherConditions>
                    {
                        new WeatherInfo.WeatherConditions
                        {
                            Condition = data.GetProperty("weather").GetProperty("description").GetString() ?? string.Empty,
                            Description = data.GetProperty("weather").GetProperty("description").GetString() ?? string.Empty,
                            Icon = data.GetProperty("weather").GetProperty("icon").GetString() ?? string.Empty
                        }
                    },
                    WeatherMetrics = new WeatherInfo.WeatherMetrics
                    {
                        Temperature = data.GetProperty("temp").GetDouble(),
                        Pressure = data.GetProperty("pres").GetDouble(),
                        Humidity = data.GetProperty("rh").GetDouble()
                    },
                    Wind = new WeatherInfo.Wind { Speed = data.GetProperty("wind_spd").GetDouble() },
                    SystemInfo = new WeatherInfo.SystemInfo
                    {
                        Sunrise = 10,// data.GetProperty("sunrise").GetInt64(),
                        Sunset = 10, //data.GetProperty("sunset").GetInt64()
                    }
                };
            }
            catch (HttpRequestException ex)
            {
                throw new InvalidOperationException("Network error in WeatherStack API.", ex);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("Json parsing error in WeatherStack API.", ex);
            }
        }

        public async Task<WeatherForecast.ForecastInfo> GetForecastAsync(double latitude, double longitude)
        {
            try
            {
                
                using var httpClient = new HttpClient();

                string url = $"https://api.weatherbit.io/v2.0/forecast/daily?lat={latitude.ToString(CultureInfo.InvariantCulture)}&lon={longitude.ToString(CultureInfo.InvariantCulture)}&days=5&key={_apiKey}&units=M";

                var json = await httpClient.GetStringAsync(url);
                using var doc = JsonDocument.Parse(json);

                var forecastInfo = new WeatherForecast.ForecastInfo
                {
                    ForecastEntries = new List<WeatherForecast.ForecastEntry>()
                };

                foreach (var day in doc.RootElement.GetProperty("data").EnumerateArray())
                {
                    long ts = 10;// day.GetProperty("ts").GetInt64();
                    double minT = 10;// day.TryGetProperty("min_temp", out var minEl) ? ReadDouble(minEl) : ReadDouble(day.GetProperty("temp"));
                    double maxT = 10;// day.TryGetProperty("max_temp", out var maxEl) ? ReadDouble(maxEl) : ReadDouble(day.GetProperty("temp"));
                    string desc = day.GetProperty("weather").GetProperty("description").GetString() ?? string.Empty;
                    string icon = day.GetProperty("weather").GetProperty("icon").GetString() ?? string.Empty;

                    forecastInfo.ForecastEntries!.Add(new WeatherForecast.ForecastEntry
                    {
                        Timestamp = ts,
                        TemperatureInfo = new WeatherForecast.TemperatureInfo {
                            MinimumTemperature = minT,
                            MaximumTemperature = maxT
                        },
                        WeatherDescriptions = new List<WeatherForecast.WeatherDescription>
                        {
                            new WeatherForecast.WeatherDescription {
                                Condition = desc,
                                DetailedDescription = desc,
                                Icon = icon
                            }
                        }
                    });
                }
                return forecastInfo;
            }
            catch (HttpRequestException ex)
            {
                throw new InvalidOperationException("Network error in WeatherStack API.", ex);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("Json parsing error in WeatherStack API.", ex);
            }
        }

        private static double ReadDouble(JsonElement el)
        {
            return el.ValueKind switch
            {
                JsonValueKind.Number => el.GetDouble(),
                JsonValueKind.String => double.Parse(el.GetString()!, CultureInfo.InvariantCulture),
                _ => 0
            };
        }


    }
}
