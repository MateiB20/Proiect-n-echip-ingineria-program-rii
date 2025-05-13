//-----------------------------------------------------------------------------
// Nume proiect:Weather App
// Fisier: LocationServiceException.cs
// Descriere: Clasa de Exceptie pentru a semnala erori în procesul serviciului
// de locatiei curenta
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
    /// Clasa de Exceptie pentru a semnala erori în procesul serviciului de locatiei curenta
    /// </summary>
    public class LocationServiceException : Exception
    {
        #region Private Member Variable
        private DateTime _localNow;
        #endregion
        #region Public Property
        /// <summary>
        /// timpul local la care a avut loc exceptia
        /// </summary>        
        DateTime LocalNow
        {
            get
            {
                return _localNow;
            }
            set
            {
                _localNow = value;
            }
        }
        #endregion
        public LocationServiceException(string message, DateTime localNow) : base(message)
        {
            _localNow = localNow;
        }
    }
}
