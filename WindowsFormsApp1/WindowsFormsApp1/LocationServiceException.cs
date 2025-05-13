//-----------------------------------------------------------------------------
// Nume proiect:Weather App
// Fisier: LocationServiceException.cs
// Descriere: Clasa de Exceptie pentruLocationService
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
    ///Clasa de Exceptie pentru <see cref="LocationService"/>
    ///</summary>
    public class LocationServiceException : Exception
    {
        #region Private Member Variable
        DateTime _localNow;
        #endregion
        #region Public Property
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
