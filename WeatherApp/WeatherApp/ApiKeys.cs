//-----------------------------------------------------------------------------
// Nume proiect: Weather App
// Fisier: ApiKeys.cs
// Descriere: Fetch la cheile api din Dictionarul extern
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
    /// Fetch la cheile api din Dictionarul extern
    /// </summary>
    public class ApiKeys
    {
        public string OpenWeather { get; private set; }
        public string WeatherStack { get; private set; }
        private ApiKeys() { }

        public static ApiKeys LoadFromConfig()
        {
            return new ApiKeys
            {
                OpenWeather = ApiKeysDictionary.OpenWeather,
                WeatherStack = ApiKeysDictionary.WeatherStack
            }; 
        }
    }

}
