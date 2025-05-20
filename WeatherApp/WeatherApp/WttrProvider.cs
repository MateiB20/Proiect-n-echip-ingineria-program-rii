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
using System.Windows.Forms;
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

                var current = doc.RootElement.GetProperty("current_condition")[0];
                var area = doc.RootElement.GetProperty("nearest_area")[0];
                var astronomy = doc.RootElement.GetProperty("weather")[0].GetProperty("astronomy")[0];

                double lat = double.Parse(area.GetProperty("latitude").GetString()!, CultureInfo.InvariantCulture);
                double lon = double.Parse(area.GetProperty("longitude").GetString()!, CultureInfo.InvariantCulture);
                string desc = current.GetProperty("weatherDesc")[0].GetProperty("value").GetString()!;
                string iconUrl = "00d";              

                double tempC = double.Parse(current.GetProperty("temp_C").GetString()!, CultureInfo.InvariantCulture);
                double pressure = double.Parse(current.GetProperty("pressure").GetString()!, CultureInfo.InvariantCulture);
                double humidity = double.Parse(current.GetProperty("humidity").GetString()!, CultureInfo.InvariantCulture);
                double windKmph = double.Parse(current.GetProperty("windspeedKmph").GetString()!, CultureInfo.InvariantCulture);

                long sunriseUnix = ParseUtc(DateTime.Today, astronomy.GetProperty("sunrise").GetString()!);
                long sunsetUnix = ParseUtc(DateTime.Today, astronomy.GetProperty("sunset").GetString()!);

                return new WeatherModule.WeatherInfo.CurrentWeatherResponse
                {
                    Coordinates = new WeatherModule.WeatherInfo.Coordinates
                    {
                        Latitude = lat,
                        Longitude = lon
                    },

                    WeatherConditions = new List<WeatherModule.WeatherInfo.WeatherConditions>
                    {
                        new()
                        {
                            Condition   = desc.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0],
                            Description = desc,
                            Icon        = iconUrl
                        }
                    },

                    WeatherMetrics = new WeatherModule.WeatherInfo.WeatherMetrics
                    {
                        Temperature = tempC,
                        Pressure = pressure,
                        Humidity = humidity
                    },

                    Wind = new WeatherModule.WeatherInfo.Wind
                    {
                        Speed = Math.Round(windKmph / 3.6, 1)
                    },

                    SystemInfo = new WeatherModule.WeatherInfo.SystemInfo
                    {
                        Sunrise = sunriseUnix,
                        Sunset = sunsetUnix
                    }
                };

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

        public async Task<WeatherModule.WeatherForecast.ForecastInfo> GetForecastAsync(double lat, double lon)
        {
            using var http = new HttpClient();
            var url = $"https://wttr.in/{lat.ToString(CultureInfo.InvariantCulture)},{lon.ToString(CultureInfo.InvariantCulture)}?format=j1";
            using var doc = JsonDocument.Parse(await http.GetStringAsync(url));

            var days = doc.RootElement.GetProperty("weather");
            var forecast = new WeatherModule.WeatherForecast.ForecastInfo
            {
                ForecastEntries = new List<WeatherModule.WeatherForecast.ForecastEntry>()
            };

            foreach (var day in days.EnumerateArray())
            {
                var date = DateTime.ParseExact(day.GetProperty("date").GetString()!, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                var hourlyArr = day.GetProperty("hourly");

                var noon = hourlyArr.EnumerateArray()
                                    .FirstOrDefault(h => h.GetProperty("time").GetString() == "1200");

                if (noon.ValueKind == JsonValueKind.Undefined)
                {
                    noon = hourlyArr[hourlyArr.GetArrayLength() / 2];
                }

                forecast.ForecastEntries!.Add(new WeatherModule.WeatherForecast.ForecastEntry
                {
                    Timestamp = new DateTimeOffset(date.AddHours(12)).ToUnixTimeSeconds(),
                    TemperatureInfo = new WeatherModule.WeatherForecast.TemperatureInfo
                    {
                        MinimumTemperature = double.Parse(day.GetProperty("mintempC").GetString()!, CultureInfo.InvariantCulture),
                        MaximumTemperature = double.Parse(day.GetProperty("maxtempC").GetString()!, CultureInfo.InvariantCulture)
                    },
                    WeatherDescriptions = new List<WeatherModule.WeatherForecast.WeatherDescription>
                    {
                        new()
                        {
                            Condition           = noon.GetProperty("weatherDesc")[0].GetProperty("value").GetString()!,
                            DetailedDescription = noon.GetProperty("weatherDesc")[0].GetProperty("value").GetString()!,
                            Icon                = "00d"
                        }
                    }
                });
            }

            return forecast;
        }
        private static long ParseUtc(DateTime todayLocal, string hhmm12)
        {
            var tm = DateTime.ParseExact(hhmm12, "hh:mm tt", CultureInfo.InvariantCulture);
            var local = new DateTime(todayLocal.Year, todayLocal.Month, todayLocal.Day,
                                     tm.Hour, tm.Minute, 0, DateTimeKind.Local);
            return new DateTimeOffset(local).ToUnixTimeSeconds();
        }
    }
}
