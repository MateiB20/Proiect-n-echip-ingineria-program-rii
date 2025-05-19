//-----------------------------------------------------------------------------
// Nume proiect: Weather App
// Fisier: Form1.cs
// Descriere: Interfata principala a aplicatiei. Se ocupa de:
// - Initializarea automata a locatiei utilizatorului folosind IP-ul
// - Preluarea conditiilor meteo curente
// - Afisarea prognozei meteo pe urmatoarele 5 zile
// - Aplicarea temei (dark/light)
// - Schimbarea limbii interfetei
// Autori:
// - Andreea : buttonSearch_Click, GetWeather, GetForecast, ConvertDateTime, ClearWeatherInfo, UI
// - Matei : Form1_Load, InitializeAsync
// - Izabela : OnThemeChanged, ApplyThemeToControl, OnLanguageChanged
//-----------------------------------------------------------------------------

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
    /// <summary>
    /// Formul principal al aplicatiei Weather App. Implementeaza observerii pentru tema si limba.
    /// </summary>
    public partial class Form1 : Form, IThemeObserverService, ILanguageObserverService
    {
        #region Private Member Variables

        private ThemeManagerService _themeManager;                     // Manager pentru tema
        private LanguageManagerService _languageManager;               // Manager pentru limba
        private readonly IWeatherProviderFactory _factory;             // Factory pentru furnizorul de vreme
        private IWeatherProvider _weatherProvider;                     // Furnizorul selectat de vreme
        private LocationService _locationService;                      // Serviciu pentru determinarea locatiei
        private LoggingLocationService _loggingLocationService;       // Serviciu cu logare pentru locatie

        #endregion

        #region Public Member Variables

        public double Longitude, Latitude;  // Coordonate actuale

        #endregion

        #region Constructor

        public Form1()
        {
            InitializeComponent();

            // Initializare servicii
            _themeManager = new ThemeManagerService();
            _languageManager = new LanguageManagerService();
            _locationService = new LocationService();
            _loggingLocationService = new LoggingLocationService(_locationService);

            // Factory + provider default
            _factory = new WeatherProviderFactory(ApiKeys.LoadFromConfig());
            _weatherProvider = _factory.Create("OpenWeather");

            // Event pentru incarcare formular
            this.Load += Form1_Load;
        }

        #endregion

        #region IThemeObserverService Implementation

        /// <summary>
        /// Actualizeaza tema aplicatiei cand utilizatorul o schimba.
        /// </summary>
        public void OnThemeChanged(AppTheme theme)
        {
            try
            {
                string imagePath = theme == AppTheme.Dark
                ? "Resources/dark.png"
                : "Resources/light.png";

                this.BackgroundImage = Image.FromFile(imagePath);
                this.BackgroundImageLayout = ImageLayout.Stretch;

                foreach (Control ctrl in this.Controls)
                {
                    ApplyThemeToControl(ctrl, theme);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        #endregion

        #region ILanguageObserverService Implementation

        /// <summary>
        /// Se apeleaza cand utilizatorul schimba limba aplicatiei.
        /// </summary>
        public void OnLanguageChanged(CultureInfo newCulture)
        {
            if(newCulture==null)
                throw new ArgumentNullException("OnLanguageChanged: Culture cannot be null ",nameof(newCulture));
            Thread.CurrentThread.CurrentUICulture = newCulture;
            try
            {
                // Actualizeaza toate textele
                labelCity.Text = Dictionary.LabelOras;
                buttonSearch.Text = Dictionary.LabelCauta;
                buttonChangeTheme.Text = Dictionary.LabelSchimbaTema;
                labelSunrise.Text = Dictionary.LabelRasarit;
                labelSunset.Text = Dictionary.LabelApus;
                labelWind.Text = Dictionary.LabelVant;
                labelPressure.Text = Dictionary.LabelPresiune;
                labelHumidity.Text = Dictionary.LabelUmiditate;
                // Reincarca datele meteo
                GetWeather();
                GetForecast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion

        #region Weather Handling

        /// <summary>
        /// Preia si afiseaza conditiile meteo curente.
        /// </summary>
        async void GetWeather()
        {
            try
            {
                var info = await _weatherProvider.GetCurrentAsync(textBoxCity.Text);

                if (info == null || info.WeatherConditions == null || !info.WeatherConditions.Any())
                {
                    MessageBox.Show("Orașul introdus nu a fost găsit. Vă rugăm să verificați denumirea.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearWeatherInfo();
                    return;
                }

                var weather = info.WeatherConditions.FirstOrDefault();

                pictureBoxIcon.ImageLocation = !string.IsNullOrWhiteSpace(weather?.Icon)
                    ? $"https://openweathermap.org/img/w/{weather.Icon}.png"
                    : null;

                labelCondition.Text = weather?.Condition ?? "N/A";
                labelDetails.Text = weather?.Description ?? "N/A";
                valueTemperature.Text = info.WeatherMetrics?.Temperature.ToString() + "°C" ?? "N/A";
                valueSunrise.Text = ConvertDateTime(info.SystemInfo?.Sunrise ?? 0).ToShortTimeString();
                valueSunset.Text = ConvertDateTime(info.SystemInfo?.Sunset ?? 0).ToShortTimeString();
                valueWind.Text = info.Wind?.Speed.ToString() + "km/h" ?? "N/A";
                valuePressure.Text = info.WeatherMetrics?.Pressure != null ? $"{(info.WeatherMetrics.Pressure / 1000.0):0.###} hPa" : "N/A";
                valueHumidity.Text = info.WeatherMetrics?.Humidity.ToString() + "%" ?? "N/A";

                Latitude = info.Coordinates?.Latitude ?? 0;
                Longitude = info.Coordinates?.Longitude ?? 0;

                _loggingLocationService.GeneralLoggingMessage(textBoxCity.Text, Latitude, Longitude);

                labelLocationTime.Text = $"{textBoxCity.Text}, {DateTime.Now:HH:mm}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Orașul introdus nu a fost găsit sau a apărut o eroare:\n{ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearWeatherInfo();
            }
        }

        /// <summary>
        /// Sterge informatiile meteo afisate.
        /// </summary>
        private void ClearWeatherInfo()
        {
            pictureBoxIcon.ImageLocation = null;
            labelCondition.Text = "N/A";
            labelDetails.Text = "N/A";
            valueTemperature.Text = "N/A";
            valueSunrise.Text = "N/A";
            valueSunset.Text = "N/A";
            valueWind.Text = "N/A";
            valuePressure.Text = "N/A";
            valueHumidity.Text = "N/A";
            labelLocationTime.Text = string.Empty;
            Latitude = 0;
            Longitude = 0;
        }

        /// <summary>
        /// Converteste un timestamp Unix in DateTime local.
        /// </summary>
        DateTime ConvertDateTime(long seconds)
        {
            DateTime day = new DateTime(1970, 1, 1).ToLocalTime();
            return day.AddSeconds(seconds).ToLocalTime();
        }

        /// <summary>
        /// Preia si afiseaza prognoza pe urmatoarele 5 zile.
        /// </summary>
        async void GetForecast()
        {
            try
            {
                var forecastInfo = await _weatherProvider.GetForecastAsync(Latitude, Longitude);

                if (forecastInfo?.ForecastEntries == null || !forecastInfo.ForecastEntries.Any())
                    throw new Exception("No forecast data available.");

                var today = DateTime.Now.Date;

                var days = forecastInfo.ForecastEntries
                    .Where(e => ConvertDateTime(e.Timestamp).Date > today)
                    .GroupBy(e => ConvertDateTime(e.Timestamp).Date)
                    .Take(5);

                flowLayoutPanel.Controls.Clear();

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
                MessageBox.Show($"Failed to get forecast:\n{ex.Message}", "Forecast Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Theme Handling

        /// <summary>
        /// Aplica stilul temei pentru fiecare control.
        /// </summary>
        private void ApplyThemeToControl(Control ctrl, AppTheme theme)
        {
            if (ctrl == null) 
                throw new ArgumentNullException("ApplyThemeToControl: Control null.");
           
;
            try
            {
                if (theme == AppTheme.Dark)
                {
                    if (ctrl == flowLayoutPanel)
                        ctrl.BackColor = Color.FromArgb(100, 200, 200, 200);

                    buttonChangeTheme.BackColor = Color.LightSteelBlue;
                    buttonChangeTheme.ForeColor = Color.Navy;
                }
                else
                {
                    if (ctrl == flowLayoutPanel)
                        ctrl.BackColor = Color.FromArgb(120, 220, 200, 210);

                    buttonChangeTheme.BackColor = Color.DarkSlateGray;
                    buttonChangeTheme.ForeColor = Color.Snow;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion

        #region Initialization

        /// <summary>
        /// Initializeaza orasul automat pe baza IP-ului utilizatorului.
        /// </summary>
        private async Task InitializeAsync()
        {
            LocationInfo location = await new RetryLocationService(
                new LoggingLocationService(new LocationServiceFactory().CreateService())
            ).GetLocationFromIpAsync();

            textBoxCity.Text = location.City;
            Longitude=location.Lon; 
            Latitude=location.Lat;
            comboBoxChangeLanguage.SelectedIndex = 1; // Default: romana
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await InitializeAsync();
            try
            {
                _themeManager.Register(this);
                _languageManager.Register(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            GetWeather();
            GetForecast();
           
            flowLayoutPanel.BackColor = Color.FromArgb(120, 220, 200, 210);

        }

        #endregion

        #region Event Handlers

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            GetWeather();
            GetForecast();
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

        private void pictureBoxIcon_Click(object sender, EventArgs e)
        {
            // Placeholder - nu se foloseste
        }

        #endregion
    }
}
