//-----------------------------------------------------------------------------
// Nume proiect: Weather App
// Fisier: WeatherBitProvider.cs
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
//using Microsoft.VisualBasic.Logging;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Weather provider = WeatherBitProvider: https://weatherbit.com/
    /// </summary>
    public class WeatherBitProvider : IWeatherProvider
    {
        private readonly string _apiKey;

        public WeatherBitProvider(string apiKey)
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


                double lat = data.GetProperty("lat").GetDouble();
                double lon = data.GetProperty("lon").GetDouble();
                string desc = data.GetProperty("weather").GetProperty("description").GetString()!;
                string iconKey = data.GetProperty("weather").GetProperty("icon").GetString()!;
                string iconUrl = iconKey != "" ? iconKey : "00d";

                double temp = data.GetProperty("temp").GetDouble();
                double pressure = data.GetProperty("pres").GetDouble();
                double humidity = data.GetProperty("rh").GetDouble();
                double windSpd = data.GetProperty("wind_spd").GetDouble();   

                long sunrise = ParseUtcTime(data.GetProperty("sunrise").GetString()!);
                long sunset = ParseUtcTime(data.GetProperty("sunset").GetString()!);

                return new WeatherInfo.CurrentWeatherResponse
                {
                    Coordinates = new WeatherInfo.Coordinates { Latitude = lat, Longitude = lon },

                    WeatherConditions = new List<WeatherInfo.WeatherConditions>
                    {
                        new WeatherInfo.WeatherConditions
                        {
                            Condition = desc.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0],
                            Description = desc,
                            Icon = iconUrl
                        }
                    },

                    WeatherMetrics = new WeatherInfo.WeatherMetrics
                    {
                        Temperature = temp,
                        Pressure = pressure,
                        Humidity = humidity
                    },

                    Wind = new WeatherInfo.Wind { Speed = windSpd },

                    SystemInfo = new WeatherInfo.SystemInfo
                    {
                        Sunrise = sunrise,
                        Sunset = sunset
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

                var forecast = new WeatherForecast.ForecastInfo
                {
                    ForecastEntries = new List<WeatherForecast.ForecastEntry>()
                };

                foreach (var day in doc.RootElement.GetProperty("data").EnumerateArray())
                {
                    long ts = day.GetProperty("ts").GetInt64();                                
                    double minT = day.GetProperty("min_temp").GetDouble();
                    double maxT = day.GetProperty("max_temp").GetDouble();
                    string desc = day.GetProperty("weather").GetProperty("description").GetString()!;
                    string iconKey = day.GetProperty("weather").GetProperty("icon").GetString()!;
                    string icon = iconKey != "" ? iconKey : "00d";

                    forecast.ForecastEntries!.Add(new WeatherForecast.ForecastEntry
                    {
                        Timestamp = ts,
                        TemperatureInfo = new WeatherForecast.TemperatureInfo
                        {
                            MinimumTemperature = minT,
                            MaximumTemperature = maxT
                        },
                        WeatherDescriptions = new List<WeatherForecast.WeatherDescription>
                        {
                            new WeatherForecast.WeatherDescription
                            {
                                Condition = desc,
                                DetailedDescription = desc,
                                Icon = icon
                            }
                        }
                    });
                }

                return forecast;
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

        private static long ParseUtcTime(string hhmmUtc)
        {
            var t = DateTime.ParseExact(hhmmUtc, "HH:mm", CultureInfo.InvariantCulture,
                                        DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
            return new DateTimeOffset(t).ToUnixTimeSeconds();
        }
    }
}
