using System.Text.Json.Serialization;

namespace WeatherModule
{
    /// <summary>
    /// Reprezintă modelul datelor pentru vremea curentă.
    /// </summary>
    public class WeatherInfo
    {
        #region Coordinate Data
        /// <summary>
        /// Coordonatele geografice ale locației.
        /// </summary>
        public class Coordinates
        {
            /// <summary>
            /// Longitudinea locației.
            /// </summary>
            [JsonPropertyName("lon")]
            public double Longitude { get; set; }

            /// <summary>
            /// Latitudinea locației.
            /// </summary>
            [JsonPropertyName("lat")]
            public double Latitude { get; set; }
        }
        #endregion

        #region Weather Description
        /// <summary>
        /// Descrierea stării vremii (ex. senin, înnorat).
        /// </summary>
        public class WeatherConditions
        {
            /// <summary>
            /// Condiția meteo principală (ex. Clear, Clouds).
            /// </summary>
            [JsonPropertyName("main")]
            public string? Condition { get; set; }

            /// <summary>
            /// Descriere detaliată a condiției meteo.
            /// </summary>
            [JsonPropertyName("description")]
            public string? Description { get; set; }

            /// <summary>
            /// Codul pictogramei meteo.
            /// </summary>
            [JsonPropertyName("icon")]
            public string? Icon { get; set; }
        }
        #endregion

        #region Temperature and Pressure Metrics
        /// <summary>
        /// Informații despre temperatură, presiune și umiditate.
        /// </summary>
        public class WeatherMetrics
        {
            /// <summary>
            /// Temperatura actuală (°C).
            /// </summary>
            [JsonPropertyName("temp")]
            public double Temperature { get; set; }

            /// <summary>
            /// Presiunea atmosferică (hPa).
            /// </summary>
            [JsonPropertyName("pressure")]
            public double Pressure { get; set; }

            /// <summary>
            /// Umiditatea relativă (%).
            /// </summary>
            [JsonPropertyName("humidity")]
            public double Humidity { get; set; }
        }
        #endregion

        #region Wind Info
        /// <summary>
        /// Informații despre vânt.
        /// </summary>
        public class Wind
        {
            /// <summary>
            /// Viteza vântului (m/s).
            /// </summary>
            [JsonPropertyName("speed")]
            public double Speed { get; set; }
        }
        #endregion

        #region System Metadata
        /// <summary>
        /// Informații suplimentare de sistem (răsărit, apus).
        /// </summary>
        public class SystemInfo
        {
            /// <summary>
            /// Timpul răsăritului (timestamp Unix).
            /// </summary>
            [JsonPropertyName("sunrise")]
            public long Sunrise { get; set; }

            /// <summary>
            /// Timpul apusului (timestamp Unix).
            /// </summary>
            [JsonPropertyName("sunset")]
            public long Sunset { get; set; }
        }
        #endregion

        #region Root Weather Response
        /// <summary>
        /// Modelul principal pentru răspunsul API-ului de vreme curentă.
        /// </summary>
        public class CurrentWeatherResponse
        {
            /// <summary>
            /// Coordonatele locației curente.
            /// </summary>
            [JsonPropertyName("coord")]
            public Coordinates? Coordinates { get; set; }

            /// <summary>
            /// Lista condițiilor meteo curente.
            /// </summary>
            [JsonPropertyName("weather")]
            public List<WeatherConditions>? WeatherConditions { get; set; }

            /// <summary>
            /// Metrici privind temperatura, presiunea și umiditatea.
            /// </summary>
            [JsonPropertyName("main")] 
            public WeatherMetrics? WeatherMetrics { get; set; }

            /// <summary>
            /// Informații despre vânt.
            /// </summary>
            [JsonPropertyName("wind")]
            public Wind? Wind { get; set; }

            /// <summary>
            /// Informații sistem (răsărit/apus).
            /// </summary>
            [JsonPropertyName("sys")]
            public SystemInfo? SystemInfo { get; set; }
        }
        #endregion
    }
}
