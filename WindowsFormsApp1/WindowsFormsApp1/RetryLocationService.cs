//-----------------------------------------------------------------------------
// Nume proiect:Weather App
// Fisier: RetryLocationService.cs
// Descriere: Implementare decorator serviciu reincercare 
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
    /// Implementare decorator serviciu reincercare 
    /// </summary>
    class RetryLocationService : ILocationService
    {
        #region Private Member Variable
        private ILocationService _inner;
        #endregion
        #region Public Constuctor
        public RetryLocationService(ILocationService inner)
        {
            _inner = inner;
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Reincercare pentru access la WeatherApp
        /// </summary>
        /// <returns>
        /// Obiect al clasei "LocationInfo" sau exceptie in caz de eroare
        /// </returns>>
        override public async Task<LocationInfo> GetLocationFromIpAsync()
        {
            LocationInfo location = await _inner.GetLocationFromIpAsync();
            int retries = 3;
            for (int i = 0; i < retries; i++)
            {
                try
                {
                    return await _inner.GetLocationFromIpAsync();
                }
                catch (Exception e)
                {
                    await Task.Delay(1000);
                }
            }
            return location;
        }
        #endregion
    }
}
