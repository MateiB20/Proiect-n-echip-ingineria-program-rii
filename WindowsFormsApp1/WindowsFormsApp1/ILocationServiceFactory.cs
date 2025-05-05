//-----------------------------------------------------------------------------
// Nume proiect:Weather App
// Fisier: ILocationServiceFactory.cs
// Descriere: Interfata abstracta pentru fabrica de servicii locatie curenta
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
    ///Interfata abstracta pentru fabrica de servicii locatie curenta
    ///</summary>
    abstract class ILocationServiceFactory
    {
        #region Abstract Public Method
        abstract public ILocationService CreateService();
        #endregion
    }

}
