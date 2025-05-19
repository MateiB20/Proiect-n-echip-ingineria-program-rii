//-----------------------------------------------------------------------------
// Nume proiect: Weather App
// Fisier: WttrProvider.cs
// Descriere: TODO
// Autor: Tonix
//
//-----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherModule;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Weather provider = Wttr: wttr.io
    /// </summary>
    class WttrProvider : IWeatherProvider
    {
        public async Task<WeatherInfo.CurrentWeatherResponse> GetCurrentAsync(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                throw new ArgumentException(nameof(location));
            }

            try
            {             
                using var httpClient = new HttpClient();
                string url = $"https://wttr.in/{WebUtility.UrlEncode(location)}?format=j1";
                var json = await httpClient.GetStringAsync(url);
                using var doc = JsonDocument.Parse(json);

                var currentEl = doc.RootElement.GetProperty("current_condition")[0];
                var nearestAreaEl = doc.RootElement.GetProperty("nearest_area")[0];

                double lat = double.Parse(nearestAreaEl.GetProperty("latitude").GetString()!, CultureInfo.InvariantCulture);
                double lon = double.Parse(nearestAreaEl.GetProperty("longitude").GetString()!, CultureInfo.InvariantCulture);

                var response = new WeatherInfo.CurrentWeatherResponse
                {
                    Coordinates = new WeatherInfo.Coordinates { Latitude = lat, Longitude = lon },
                    WeatherConditions = new List<WeatherInfo.WeatherConditions>
                {
                    new WeatherInfo.WeatherConditions
                    {
                        Condition = currentEl.GetProperty("weatherDesc")[0].GetProperty("value").GetString() ?? string.Empty,
                        Description = currentEl.GetProperty("weatherDesc")[0].GetProperty("value").GetString() ?? string.Empty,
                        Icon = currentEl.GetProperty("weatherIconUrl")[0].GetProperty("value").GetString() ?? string.Empty
                    }
                },
                    WeatherMetrics = new WeatherInfo.WeatherMetrics
                    {
                        Temperature = double.Parse(currentEl.GetProperty("temp_C").GetString()!, CultureInfo.InvariantCulture),
                        Pressure = double.Parse(currentEl.GetProperty("pressure").GetString()!, CultureInfo.InvariantCulture),
                        Humidity = double.Parse(currentEl.GetProperty("humidity").GetString()!, CultureInfo.InvariantCulture)
                    },
                    Wind = new WeatherInfo.Wind
                    {
                        Speed = double.Parse(currentEl.GetProperty("windspeedKmph").GetString()!, CultureInfo.InvariantCulture)
                    },
                    SystemInfo = new WeatherInfo.SystemInfo()
                };
                return response;

            }
            catch (HttpRequestException ex)
            {
                throw new InvalidOperationException("Network error in wttr.in.", ex);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("Json parsing error in wttr.in.", ex);
            }
        }

        public async Task<WeatherForecast.ForecastInfo> GetForecastAsync(double latitude, double longitude)
        {
            try
            {
                using var httpClient = new HttpClient();

                string url = $"https://wttr.in/{latitude.ToString(CultureInfo.InvariantCulture)},{longitude.ToString(CultureInfo.InvariantCulture)}?format=j1";
                var json = await httpClient.GetStringAsync(url);
                using var doc = JsonDocument.Parse(json);

                var weatherArray = doc.RootElement.GetProperty("weather");

                var forecastInfo = new WeatherForecast.ForecastInfo
                {
                    ForecastEntries = new List<WeatherForecast.ForecastEntry>()
                };

                foreach (var dayEl in weatherArray.EnumerateArray())
                {
                    var date = DateTime.ParseExact(dayEl.GetProperty("date").GetString()!, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    var hourly = dayEl.GetProperty("hourly")[4]; 

                    string description = hourly.GetProperty("weatherDesc")[0].GetProperty("value").GetString() ?? string.Empty;
                    string icon = hourly.GetProperty("weatherIconUrl")[0].GetProperty("value").GetString() ?? string.Empty;

                    forecastInfo.ForecastEntries!.Add(new WeatherForecast.ForecastEntry
                    {
                        Timestamp = new DateTimeOffset(date.AddHours(12)).ToUnixTimeSeconds(),
                        TemperatureInfo = new WeatherForecast.TemperatureInfo
                        {
                            MinimumTemperature = double.Parse(dayEl.GetProperty("mintempC").GetString()!, CultureInfo.InvariantCulture),
                            MaximumTemperature = double.Parse(dayEl.GetProperty("maxtempC").GetString()!, CultureInfo.InvariantCulture)
                        },
                        WeatherDescriptions = new List<WeatherForecast.WeatherDescription>
                    {
                        new WeatherForecast.WeatherDescription
                        {
                            Condition = description,
                            DetailedDescription = description,
                            Icon = icon
                        }
                    }
                    });
                }

                return forecastInfo;
            }
            catch (HttpRequestException ex)
            {
                throw new InvalidOperationException("Network error in wttr.in.", ex);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("Json parsing error in wttr.in.", ex);
            }
        }
    }
}
