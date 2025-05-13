//-----------------------------------------------------------------------------
// Nume proiect:Weather App
// Fisier: WeatherForecast.cs
// Descriere: TODO
// Autor: Andreea 
//
//-----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class WeatherForecast
    {
        //temp
        public class main 
        {
            public double temp_min { get; set; }
            public double temp_max { get; set; }

        }

        public class weather
        {
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class list
        {
            // day time
            public long dt { get; set; } 
            public main main { get; set; }
            public List<weather> weather { get; set; }
        }

        public class ForecastInfo
        {
            public List<list> list { get; set; }
        }
    }
}
