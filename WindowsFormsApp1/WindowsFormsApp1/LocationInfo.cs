//-----------------------------------------------------------------------------
// Nume proiect:Weather App
// Fisier: LocationInfo.cs
// Descriere: Model de date pentru deserializare raspuns JSON
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
    /// Model de date pentru deserializare raspuns JSON
    /// </summary>
    class LocationInfo
    {
        #region Private Member Variables
        private string _city;
        private string _country;
        private double _lat;
        private double _lon;
        #endregion
        #region Public Properties
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
