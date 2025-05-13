//-----------------------------------------------------------------------------
// Nume proiect:Weather App
// Fisier: WeatherForecast.cs
// Descriere: Modele de date folosite pentru parsarea raspunsului de la API-ul
// meteo
// Autor: Andreea 
//
//-----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class WeatherForecast
    {
        #region Public Nested Classes
        /// <summary>
        /// Informatii despre temperatura pentru o intrare de prognoza.
        /// </summary>
        public class main
        {
            #region Public Nested Classes
            /// <summary>
            /// Temperatura minima estimata pentru intervalul de timp.
            /// </summary>
            public double temp_min { get; set; }
            /// <summary>
            /// Temperatura maxima estimata pentru intervalul de timp.
            /// </summary>
            public double temp_max { get; set; }
            #endregion
        }

        public class weather
        {
            #region Public Nested Classes
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
            #endregion
        }

        public class list
        {
            #region Public Nested Classes
            /// <summary>
            /// timestamp-ul prognozei
            /// </summary>
            public long dt { get; set; }
            public main main { get; set; }
            public List<weather> weather { get; set; }
            #endregion
        }

        public class ForecastInfo
        {
            #region Public Nested Classes
            public List<list> list { get; set; }
            #endregion
        }
        #endregion
    }
}
