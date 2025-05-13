//-----------------------------------------------------------------------------
// Nume proiect:Weather App
// Fisier: LocationInfo.cs
// Descriere: Aici se vor stoca dupa deserializare o parte din datele luate de la "http://ip-api.com/json/"
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
    ///Aici se vor stoca dupa deserializare o parte din datele luate de la "http://ip-api.com/json/"
    ///</summary>
    class LocationInfo
    {
        #region Private Member Variables
        private string _city;
        private string _country;
        private double _lat;
        private double _lon;
        #endregion
        #region Public Properties
        ///<summary>
        ///oras
        ///</summary>
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
            }
        }

        ///<summary>
        ///tara
        ///</summary>
        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
            }
        }

        ///<summary>
        ///latitudine
        ///</summary>
        public double Lat
        {
            get
            {
                return _lat;
            }
            set
            {
                _lat = value;
            }
        }

        ///<summary>
        ///longitudine
        ///</summary>
        public double Lon
        {
            get
            {
                return _lon;
            }
            set
            {
                _lon = value;
            }
        }
        #endregion
    }
}
