//-----------------------------------------------------------------------------
// Nume proiect:Weather App
// Fisier: LocationService.cs
// Descriere: Serviciu preluare date locatie curenta
// Autor: Matei 
//
//-----------------------------------------------------------------------------
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Serviciu preluare date locatie curenta
    /// </summary>
    public class LocationService : ILocationService
    {
        #region Public Method
        /// <summary>
        /// Trimitere cerere HTTP GET la un API public 
        /// </summary>
        /// <returns>
        /// Obiect al clasei "LocationInfo" sau exceptie in caz de eroare
        /// </returns>
        override public async Task<LocationInfo> GetLocationFromIpAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                string raspuns = await client.GetStringAsync("http://ip-api.com/json/");

                // Deserializare raspuns JSON
                var raspunsFormatat = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(raspuns.ToLower());
                return JsonConvert.DeserializeObject<LocationInfo>(raspunsFormatat);
            }
            catch (Exception e)
            {
                throw new LocationServiceException("Eroare obtinere informatii locatie curenta", DateTime.Now);
            }
        }
        #endregion
    }
}
