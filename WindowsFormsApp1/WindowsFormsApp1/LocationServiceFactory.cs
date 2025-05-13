//-----------------------------------------------------------------------------
// Nume proiect:Weather App
// Fisier: LocationServiceFactory.cs
// Descriere: Implementare concreta a fabricii de "LocationService"
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
    /// Implementare concreta a fabricii de <see cref="LocationService"/>
    /// </summary>
    class LocationServiceFactory : ILocationServiceFactory
    {
        #region Public Method
        /// <summary>
        /// Metoda de creare a obiectelor <see cref="ILocationService"/>
        /// </summary>
        /// <returns>
        /// Un nou obiect <see cref="LocationService"/>
        /// </returns>>
        override public ILocationService CreateService()
        {
            return new LocationService();
        }
        #endregion
    }
}
