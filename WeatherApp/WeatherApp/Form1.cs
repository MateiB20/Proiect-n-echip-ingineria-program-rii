//-----------------------------------------------------------------------------
// Nume proiect:Weather App
// Fisier: Form1.cs
// Descriere: Interfata principala a aplicatiei. Se ocupa de initializarea
// automata a locatiei utilizatorului folosind IP-ul, preluarea conditiilor
// meteo curente 
// si afisarea prognozei meteo pe următoarele 5 zile.
// Autori:
// - Andreea : buttonSearch_Click, getWeather, getForecast, convertDateTime
// - Matei : Form1_Load, InitializeAsync
// - Izabela : OnThemeChanged, ApplyThemeToControl, OnLanguageChanged
//-----------------------------------------------------------------------------
using Newtonsoft.Json;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using LanguageModule;
using ThemeModule;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form,IThemeObserverService,ILanguageObserverService
    {
        #region Private Member Variables
        private ThemeManagerService _themeManager;
        private LanguageManagerService _languageManager;
        private readonly IWeatherProviderFactory _factory;
        private IWeatherProvider _weatherProvider;

        #endregion
        #region Public Member Variables
        double Longitude, Latitude;
        //string APIKey = "70a0b01f4ce43960e5ff1f6891a6dfd3";
        #endregion
        #region Public Methods
        public Form1()
        {
            InitializeComponent();
            _themeManager = new ThemeManagerService();
            _languageManager = new LanguageManagerService();
            this.Load += Form1_Load;

            _factory = new WeatherProviderFactory(ApiKeys.LoadFromConfig());
            _weatherProvider = _factory.Create("OpenWeather");

        }
        public void OnThemeChanged(AppTheme theme)
        {
            //this.BackColor = theme == AppTheme.Dark ? Color.Black : Color.White;
            string imagePath = theme == AppTheme.Dark
       ? "Resources/darkBackground.jpg"
       : "Resources/lightBackground2.jpeg";
            this.BackgroundImage = Image.FromFile(imagePath);
            this.BackgroundImageLayout = ImageLayout.Stretch;

            foreach (Control ctrl in this.Controls)
            {
                     ApplyThemeToControl(ctrl, theme);
            }
        }
        public void OnLanguageChanged(CultureInfo newCulture)
        {
            Thread.CurrentThread.CurrentUICulture = newCulture;
            labelCity.Text = Dictionary.LabelOras;
            buttonSearch.Text = Dictionary.LabelCauta;
            buttonChangeTheme.Text = Dictionary.LabelSchimbaTema;
            labelSunrise.Text = Dictionary.LabelRasarit;
            labelSunset.Text = Dictionary.LabelApus;
            labelWind.Text = Dictionary.LabelVant;
            labelPressure.Text = Dictionary.LabelPresiune;
            getWeather();
            getForecast();
        }
        async void getWeather()
        {
            //using (WebClient webClient = new WebClient())
            //{
            //    webClient.Encoding = System.Text.Encoding.UTF8;
            //    string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric&lang={2}", textBoxCity.Text, APIKey, CultureInfo.CurrentUICulture.TwoLetterISOLanguageName);
            //    var json = webClient.DownloadString(url);
            //    WeatherInfo.root Info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);
            //    pictureBoxIcon.ImageLocation = "https://openweathermap.org/img/w/" + Info.weather[0].icon + ".png";
            //    labelCondition.Text = Info.weather[0].main;
            //    labelDetails.Text = Info.weather[0].description;
            //    valueSunset.Text = convertDateTime(Info.sys.sunset).ToShortTimeString();
            //    valueSunrise.Text = convertDateTime(Info.sys.sunrise).ToShortTimeString();
            //    valueWind.Text = Info.wind.speed.ToString();
            //    valuePressure.Text = Info.main.pressure.ToString();
            //    Longitude = Info.coord.lon;
            //    Latitude = Info.coord.lat;
            //}
            try
            {
                var info = await _weatherProvider.GetCurrentAsync(textBoxCity.Text);

                pictureBoxIcon.ImageLocation = $"https://openweathermap.org/img/w/{info.weather[0].icon}.png";
                labelCondition.Text = info.weather[0].main;
                labelDetails.Text = info.weather[0].description;
                valueSunrise.Text = ConvertDateTime(info.sys.sunrise).ToShortTimeString();
                valueSunset.Text = ConvertDateTime(info.sys.sunset).ToShortTimeString();
                valueWind.Text = info.wind.speed.ToString();
                valuePressure.Text = info.main.pressure.ToString();

                Latitude = info.coord.lat;
                Longitude = info.coord.lon;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                  $"Failed to get current weather:\n{ex.Message}",
                  "Weather Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        DateTime ConvertDateTime(long seconds)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(seconds).ToLocalTime();
            return day;
        }
        async void getForecast()
        {
            //using (WebClient webClient = new WebClient())
            //{
            //    webClient.Encoding = System.Text.Encoding.UTF8;
            //    string url = string.Format("https://api.openweathermap.org/data/2.5/forecast?lat={0}&lon={1}&appid={2}&units=metric&lang={2}", Latitude, Longitude, APIKey);
            //    var json = webClient.DownloadString(url);
            //    WeatherForecast.ForecastInfo forecastInfo = JsonConvert.DeserializeObject<WeatherForecast.ForecastInfo>(json);
            //    var today = DateTime.Now.Date;

            //    // Exclude ziua de azi dar pastreaza urmatoarele 5 zile
            //    var groupedByDay = forecastInfo.list

            //        // primele 5 zile viitoare
            //        .Where(entry => convertDateTime(entry.dt).Date > today)
            //        .GroupBy(entry => convertDateTime(entry.dt).Date)
            //        .Take(5);
            //    flowLayoutPanel.Controls.Clear();

            //    // Pentru fiecare zi creeaza un nou ForecastUC i setează valorile
            //    foreach (var group in groupedByDay)
            //    {
            //        var tempMin = group.Min(x => x.main.temp_min);
            //        var tempMax = group.Max(x => x.main.temp_max);
            //        var icon = group.First().weather[0].icon;
            //        ForecastUC forecastUC = new ForecastUC();

            //        // Afiseaza doar numele complet al zilei saptamanii
            //        forecastUC.labelDate.Text = group.Key.ToString("dddd", Thread.CurrentThread.CurrentUICulture);
            //        forecastUC.pictureBoxForecastIcon.ImageLocation = "https://openweathermap.org/img/w/" + icon + ".png";
            //        forecastUC.labelTempMin.Text = $"{tempMin:0} °C";
            //        forecastUC.labelTempMax.Text = $"{tempMax:0} °C";
            //        flowLayoutPanel.Controls.Add(forecastUC);
            //    }
            //}
            try
            {
                var forecastInfo = await _weatherProvider.GetForecastAsync(Latitude, Longitude);

                var today = DateTime.Now.Date;
                var days = forecastInfo.list
                    .Where(e => ConvertDateTime(e.dt).Date > today)
                    .GroupBy(e => ConvertDateTime(e.dt).Date)
                    .Take(5);

                flowLayoutPanel.Controls.Clear();
                foreach (var group in days)
                {
                    var tempMin = group.Min(x => x.main.temp_min);
                    var tempMax = group.Max(x => x.main.temp_max);
                    var icon = group.First().weather[0].icon;

                    ForecastUC forecastUC = new ForecastUC();
                    forecastUC.labelDate.Text = group.Key.ToString("dddd", Thread.CurrentThread.CurrentUICulture);
                    forecastUC.pictureBoxForecastIcon.ImageLocation = "https://openweathermap.org/img/w/" + icon + ".png";
                    forecastUC.labelTempMin.Text = $"{tempMin:0} °C";
                    forecastUC.labelTempMax.Text = $"{tempMax:0} °C";

                    flowLayoutPanel.Controls.Add(forecastUC);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                  $"Failed to get forecast:\n{ex.Message}",
                  "Forecast Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Private Methods
        private void ApplyThemeToControl(Control ctrl, AppTheme theme)
        {

            if (theme == AppTheme.Dark)
            {
                if (ctrl == flowLayoutPanel)
                {
                    ctrl.BackColor = Color.FromArgb(100, 200, 200, 200);
                }
                buttonChangeTheme.BackColor = Color.LightSteelBlue;
                buttonChangeTheme.ForeColor = Color.Navy;
                

            }
            else
            {
                if (ctrl == flowLayoutPanel)
                {
                    ctrl.BackColor = Color.FromArgb(120, 220, 200, 210); 
                }
                buttonChangeTheme.BackColor = Color.DarkSlateGray;
                buttonChangeTheme.ForeColor = Color.Snow;
            }
        
        }
        private async Task InitializeAsync()
        {
            LocationInfo location = await new RetryLocationService(
                           new LoggingLocationService(new LocationServiceFactory().CreateService())).GetLocationFromIpAsync();
            textBoxCity.Text= location.City;
            comboBoxChangeLanguage.SelectedIndex = 1;
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            await InitializeAsync();
            getWeather();
            getForecast();
            _themeManager.Register(this);
            flowLayoutPanel.BackColor = Color.FromArgb(120, 220, 200, 210);
            _languageManager.Register(this);
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            getWeather();
            getForecast();
        }
        private void pictureBoxIcon_Click(object sender, EventArgs e)
        {

        }
        private void buttonChangeTheme_Click(object sender, EventArgs e)
        {
            var newTheme = _themeManager.GetCurrentTheme() == AppTheme.Dark ? AppTheme.Light : AppTheme.Dark;
            _themeManager.ChangeTheme(newTheme);
        }

        private void comboBoxChangeWeatherProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = comboBoxChangeWeatherProvider.SelectedItem.ToString();
            _weatherProvider = _factory.Create(name);
        }

        private void comboBoxChangeLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedLang = comboBoxChangeLanguage.SelectedItem.ToString();
            _languageManager.ChangeLanguage(selectedLang);
        }
        #endregion
    }
}
