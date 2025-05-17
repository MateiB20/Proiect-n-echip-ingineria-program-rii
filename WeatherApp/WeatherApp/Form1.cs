//-----------------------------------------------------------------------------
// Nume proiect:Weather App
// Fisier: Form1.cs
// Descriere: Interfata principala a aplicatiei. Se ocupa de initializarea
// automata a locatiei utilizatorului folosind IP-ul, preluarea conditiilor
// meteo curente 
// si afisarea prognozei meteo pe următoarele 5 zile.
// Autori:
// - Andreea : buttonSearch_Click, GetWeather, GetForecast, convertDateTime
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
using WeatherModule;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form,IThemeObserverService,ILanguageObserverService
    {
        #region Private Member Variables
        private ThemeManagerService _themeManager;
        private LanguageManagerService _languageManager;
        private readonly IWeatherProviderFactory _factory;
        private IWeatherProvider _weatherProvider;
        private LocationService _locationService;
        private LoggingLocationService _loggingLocationService;

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
            _locationService=new LocationService();  
            _loggingLocationService =new LoggingLocationService(_locationService);
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
            GetWeather();
            GetForecast();
        }
        async void GetWeather()
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
                var weather = info?.WeatherConditions?.FirstOrDefault();
                if (weather != null && !string.IsNullOrWhiteSpace(weather.Icon))
                {
                    pictureBoxIcon.ImageLocation = $"https://openweathermap.org/img/w/{weather.Icon}.png";
                    labelCondition.Text = weather.Condition ?? "N/A";
                    labelDetails.Text = weather.Description ?? "N/A";
                }
                else
                {
                    pictureBoxIcon.ImageLocation = null; // sau o pictogramă implicită
                    labelCondition.Text = "N/A";
                    labelDetails.Text = "N/A";
                }
                valueSunrise.Text = ConvertDateTime(info.SystemInfo?.Sunrise ?? 0).ToShortTimeString();
                valueSunset.Text = ConvertDateTime(info.SystemInfo?.Sunset ?? 0).ToShortTimeString();
                valueWind.Text = info.Wind?.Speed.ToString() ?? "N/A";
                valuePressure.Text = info.WeatherMetrics?.Pressure.ToString() ?? "N/A";
                Latitude = info.Coordinates?.Latitude ?? 0;
                Longitude = info.Coordinates?.Longitude ?? 0;
                _loggingLocationService.GeneralLoggingMessage(textBoxCity.Text, Latitude, Longitude);

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
        async void GetForecast()
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

                if (forecastInfo?.ForecastEntries == null || !forecastInfo.ForecastEntries.Any())
                    throw new Exception("No forecast data available.");

                var today = DateTime.Now.Date;

                // Exclude ziua de azi și ia următoarele 5 zile
                var days = forecastInfo.ForecastEntries
                    .Where(e => ConvertDateTime(e.Timestamp).Date > today)
                    .GroupBy(e => ConvertDateTime(e.Timestamp).Date)
                    .Take(5);

                flowLayoutPanel.Controls.Clear();

                // Pentru fiecare zi creeaza un nou ForecastUC i setează valorile
                foreach (var group in days)
                {
                    var validEntries = group.Where(e => e.TemperatureInfo != null && e.WeatherDescriptions?.Any() == true).ToList();
                    if (!validEntries.Any()) continue;

                    var tempMin = validEntries.Min(x => x.TemperatureInfo!.MinimumTemperature);
                    var tempMax = validEntries.Max(x => x.TemperatureInfo!.MaximumTemperature);
                    var icon = validEntries.First().WeatherDescriptions![0].Icon;

                    var forecastUC = new ForecastUC
                    {
                        labelDate = { Text = group.Key.ToString("dddd", Thread.CurrentThread.CurrentUICulture) },
                        pictureBoxForecastIcon = { ImageLocation = string.IsNullOrWhiteSpace(icon) ? null : $"https://openweathermap.org/img/w/{icon}.png" },
                        labelTempMin = { Text = $"{tempMin:0} °C" },
                        labelTempMax = { Text = $"{tempMax:0} °C" }
                    };

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
            GetWeather();
            GetForecast();
            _themeManager.Register(this);
            flowLayoutPanel.BackColor = Color.FromArgb(120, 220, 200, 210);
            _languageManager.Register(this);
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            GetWeather();
            GetForecast();
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
