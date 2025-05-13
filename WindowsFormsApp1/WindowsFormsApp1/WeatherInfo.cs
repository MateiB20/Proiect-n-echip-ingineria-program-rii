//-----------------------------------------------------------------------------
// Nume proiect:Weather App
// Fisier: WeatherInfo.cs
// Descriere: Structuri de date utilizate pentru stocarea și manipularea
// informatiilor despre vreme obtinute de la API
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
    public class WeatherInfo
    {
        #region Public Nested Classes
        public class coord
        {
            #region Public Nested Classes
            public double lon { get; set; }
            public double lat { get; set; }
            #endregion
        }

        public class weather
        {
            #region Public Properties
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
            #endregion
        }

        public class main
        {
            #region Public Properties
            public double temp { get; set; }
            public double pressure { get; set; }
            public double humidity { get; set; }
            #endregion
        }

        public class wind
        {
            #region Public Properties
            public double speed { get; set; }
            #endregion
        }

        public class sys
        {
            #region Public Properties
            public long sunrise { get; set; }
            public long sunset { get; set; }
            #endregion
        }

        public class root
        {
            #region Public Properties
            public coord coord { get; set; }
            public List<weather> weather { get; set; }
            public main main { get; set; }

            public wind wind { get; set; }
            public sys sys { get; set; }
            #endregion
        }
        #endregion
    }
}
