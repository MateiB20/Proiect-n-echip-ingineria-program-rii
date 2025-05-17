using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WeatherModule
{
    /// <summary>
    /// Reprezintă modelul pentru prognoza meteo pe mai multe intervale.
    /// </summary>
    public class WeatherForecast
    {
        #region Temperature Data
        /// <summary>
        /// Informații despre temperaturile minime și maxime estimate.
        /// </summary>
        public class TemperatureInfo
        {
            /// <summary>
            /// Temperatura minimă estimată pentru intervalul de timp.
            /// </summary>
            [JsonPropertyName("temp_min")]
            public double MinimumTemperature { get; set; }

            /// <summary>
            /// Temperatura maximă estimată pentru intervalul de timp.
            /// </summary>
            [JsonPropertyName("temp_max")]
            public double MaximumTemperature { get; set; }
        }
        #endregion

        #region Weather Condition Description
        /// <summary>
        /// Descrierea condițiilor meteo pentru o anumită perioadă.
        /// </summary>
        public class WeatherDescription
        {
            /// <summary>
            /// Condiția meteo principală (ex. Clear, Rain, Snow).
            /// </summary>
            [JsonPropertyName("main")]
            public string? Condition { get; set; }

            /// <summary>
            /// Descriere detaliată a condiției meteo.
            /// </summary>
            [JsonPropertyName("description")]
            public string? DetailedDescription { get; set; }

            /// <summary>
            /// Codul pictogramei meteo.
            /// </summary>
            [JsonPropertyName("icon")]
            public string? Icon { get; set; }
        }
        #endregion

        #region Forecast Entry
        /// <summary>
        /// Reprezintă o singură intrare din prognoza meteo.
        /// </summary>
        public class ForecastEntry
        {
            /// <summary>
            /// Timpul prognozei (timestamp Unix).
            /// </summary>
            [JsonPropertyName("dt")]
            public long Timestamp { get; set; }

            /// <summary>
            /// Informații despre temperaturile maxime/minime.
            /// </summary>
            [JsonPropertyName("main")]
            public TemperatureInfo? TemperatureInfo { get; set; }

            /// <summary>
            /// Lista condițiilor meteo asociate acestui interval.
            /// </summary>
            [JsonPropertyName("weather")]
            public List<WeatherDescription>? WeatherDescriptions { get; set; }
        }
        #endregion

        #region Forecast Collection
        /// <summary>
        /// Obiectul principal care conține lista de prognoze.
        /// </summary>
        public class ForecastInfo
        {
            /// <summary>
            /// Lista de intrări de prognoză.
            /// </summary>
            [JsonPropertyName("list")]
            public List<ForecastEntry>? ForecastEntries { get; set; }
        }
        #endregion
    }
}
