//-----------------------------------------------------------------------------
// Nume proiect: Weather App
// Fisier: WeatherProviderFactory.cs
// Descriere: TODO
// Autor: Tonix
//
//-----------------------------------------------------------------------------
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Fabrica de weather provider.
    /// </summary>
    public class WeatherProviderFactory : IWeatherProviderFactory
    {
        private readonly ApiKeys _keys;

        public WeatherProviderFactory(ApiKeys keys)
        {
            _keys = keys ?? throw new ArgumentNullException(nameof(keys));
        }
        public IWeatherProvider Create(string providerName)
        {
            if (string.IsNullOrWhiteSpace(providerName))
                throw new ArgumentException("Provider name must be provided.", nameof(providerName));

            return providerName.Trim().ToLowerInvariant() switch
            {
                "openweather" => new OpenWeatherProvider(_keys.OpenWeather),
                "weatherbit" => new WeatherBitProvider(_keys.WeatherBit),
                "wttr" => new WttrProvider(), // doesn't need api
                _ => throw new NotSupportedException($"Weather provider '{providerName}' not supported.")
            };
        }
    }
}
