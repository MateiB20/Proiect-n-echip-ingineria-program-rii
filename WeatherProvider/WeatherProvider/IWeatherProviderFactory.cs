//-----------------------------------------------------------------------------
// Nume proiect: Weather App
// Fisier: IWeatherProviderFactory.cs
// Descriere: Interfata pentru fabrica de weather provider.
// Autor: Tonix
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
    /// Interfata pentru fabrica de weather provider.
    /// </summary>
    public interface IWeatherProviderFactory
    {
        IWeatherProvider Create(string providerName);
    }
}
