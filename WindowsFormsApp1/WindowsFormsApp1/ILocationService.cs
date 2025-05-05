//-----------------------------------------------------------------------------
// Nume proiect:Weather App
// Fisier: ILocationService.cs
// Descriere: Interfata abstracta pentru servicii locatie curenta
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
    ///Interfata abstracta pentru servicii locatie curenta
    ///</summary>
    abstract class ILocationService
    {
        #region Abstract Public Method
        abstract public Task<LocationInfo> GetLocationFromIpAsync();
        #endregion
    }

}
