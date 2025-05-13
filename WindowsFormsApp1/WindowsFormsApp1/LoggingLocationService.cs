//-----------------------------------------------------------------------------
// Nume proiect:Weather App
// Fisier: LoggingLocationService.cs
// Descriere: Implementare serviciu logging prin intermediul sablonului de proiectare Decorator 
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
    ///<summary>
    ///Implementare serviciu logging prin intermediul sablonului de proiectare Decorator 
    ///</summary>
    class LoggingLocationService : ILocationService
    {
        #region Private Member Variables
        string _message;
        ILocationService _inner;
        #endregion
        #region Public Properties
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
        ///<summary>
        ///logging pentru access la WeatherApp
        ///</summary>
        ///<returns>
        ///obiect al clasei "LocationInfo" sau exceptie in caz de eroare
        ///</returns>>
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
