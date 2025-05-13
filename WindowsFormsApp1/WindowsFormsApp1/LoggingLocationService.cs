//-----------------------------------------------------------------------------
// Nume proiect:Weather App
// Fisier: LoggingLocationService.cs
// Descriere: Implementare decorator serviciu logging 
// Autor: Matei  
//
//-----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Implementare decorator serviciu logging 
    /// </summary>
    class LoggingLocationService : ILocationService
    {
        #region Private Member Variables
        private string _message;
        private ILocationService _inner;
        #endregion
        #region Public Properties
        /// <summary>
        /// Salveaza inregistrari despre locatie si timpul local al accesarii
        /// </summary>
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
            }
        }
        #endregion
        #region Public Constuctor
        public LoggingLocationService(ILocationService inner)
        {
            _inner = inner;
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Logging pentru access la WeatherApp
        /// </summary>
        /// <returns>
        /// Obiect al clasei "LocationInfo" sau exceptie in caz de eroare
        /// </returns>>
        override public async Task<LocationInfo> GetLocationFromIpAsync()
        {
            LocationInfo location = await _inner.GetLocationFromIpAsync();
            DateTime localNow = DateTime.Now;
            _message = $"{localNow}:{location.City}, {location.Country}, {location.Lat}, {location.Lon}";
            return location;
        }
        #endregion
    }
}
