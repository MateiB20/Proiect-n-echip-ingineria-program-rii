using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using static System.Net.WebRequestMethods;
using Google.Cloud.Translation.V2;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string APIKey = "70a0b01f4ce43960e5ff1f6891a6dfd3";

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            getWeather();
            getForecast();
        }

        double longitude, latitude;
        void getWeather()
        {
            using (WebClient webClient = new WebClient())
            {
                string url = string.Format ("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric", textBoxCity.Text, APIKey);
                var json = webClient.DownloadString(url);
                WeatherInfo.root Info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);

                pictureBoxIcon.ImageLocation =  "https://openweathermap.org/img/w/" + Info.weather[0].icon +".png";
                labelCondition.Text = Info.weather[0].main;
                labelDetails.Text = Info.weather[0].description;
                
                valueSunset.Text = convertDateTime(Info.sys.sunset).ToShortTimeString();
                valueSunrise.Text = convertDateTime(Info.sys.sunrise).ToShortTimeString();
                
                valueWind.Text = Info.wind.speed.ToString();
                valuePressure.Text = Info.main.pressure.ToString();
                
                longitude = Info.coord.lon;
                latitude = Info.coord.lat;
            }
        }

        DateTime convertDateTime(long seconds)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(seconds).ToLocalTime();

            return day;
        }

        void getForecast()
        {
            using (WebClient webClient = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/forecast?lat={0}&lon={1}&appid={2}&units=metric", latitude, longitude, APIKey);
                var json = webClient.DownloadString(url);
                WeatherForecast.ForecastInfo forecastInfo = JsonConvert.DeserializeObject<WeatherForecast.ForecastInfo>(json);

                var today = DateTime.Now.Date;

                // Exclude ziua de azi, păstrează următoarele 5 zile
                var groupedByDay = forecastInfo.list
                    .Where(entry => convertDateTime(entry.dt).Date > today) // doar zile viitoare
                    .GroupBy(entry => convertDateTime(entry.dt).Date)
                    .Take(5);

                flowLayoutPanel.Controls.Clear();

                foreach (var group in groupedByDay)
                {
                    var tempMin = group.Min(x => x.main.temp_min);
                    var tempMax = group.Max(x => x.main.temp_max);
                    var icon = group.First().weather[0].icon;

                    ForecastUC forecastUC = new ForecastUC();
                    forecastUC.labelDate.Text = group.Key.ToString("dddd"); // ziua săptămânii
                    forecastUC.pictureBoxForecastIcon.ImageLocation = "https://openweathermap.org/img/w/" + icon + ".png";
                    forecastUC.labelTempMin.Text = $"{tempMin:0} °C";
                    forecastUC.labelTempMax.Text = $"{tempMax:0} °C";

                    flowLayoutPanel.Controls.Add(forecastUC);
                }
            }
        }

    }
}
