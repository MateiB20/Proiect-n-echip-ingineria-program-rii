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
    public class LoggingLocationService : ILocationService
    {
        #region Private Member Variables
        private string _message;
        private ILocationService _inner;
        private static DateTime _lastLoggedTime = DateTime.MinValue;
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
            if ((DateTime.Now - _lastLoggedTime).TotalSeconds > 3)
            {
                _message = $"\n{DateTime.Now}:{location.City}, {location.Country}, {location.Lat}, {location.Lon}";
                string cale = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "istoric.txt");
                File.AppendAllText(cale, _message);
                _lastLoggedTime = DateTime.Now;
            }
            return location;
        }
        /// <summary>
        /// Scrie o intrare de log pentru o locatie specifica 
        /// </summary>
        /// <param name="city">
        /// Numele orașului pentru care se face logging
        /// </param>
        /// <param name="longitude">
        /// Longitudinea locatiei
        /// </param>
        /// <param name="latitude">
        /// Latitudinea locatiei
        /// </param>
        public void GeneralLoggingMessage(String city, double longitude, double latitude) 
        {
            if ((DateTime.Now - _lastLoggedTime).TotalSeconds > 3)
            {
                DateTime localNow = DateTime.Now;
                _message = $"\n{localNow}:{city}, {latitude}, {longitude}";
                string cale = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "istoric.txt");
                File.AppendAllText(cale, _message);
                _lastLoggedTime = DateTime.Now;
            }
        }
        #endregion
    }
}
