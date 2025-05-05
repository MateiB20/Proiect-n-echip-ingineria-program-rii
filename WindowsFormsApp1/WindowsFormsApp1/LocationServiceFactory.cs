//-----------------------------------------------------------------------------
// Nume proiect:Weather App
// Fisier: LocationServiceFactory.cs
// Descriere: Implementare prin intermediul sablonului de proiectare Metoda Fabrica
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
    ///Implementare prin intermediul sablonului de proiectare Metoda Fabrica
    ///</summary>
    class LocationServiceFactory : ILocationServiceFactory
    {
        #region Public Method
        ///<summary>
        ///Functie creare serviciu
        ///</summary>
        ///<returns>
        ///un nou obiect <see cref="LocationService"/>
        ///</returns>>
        override public ILocationService CreateService()
        {
            return new LocationService();
        }
        #endregion
    }
}
