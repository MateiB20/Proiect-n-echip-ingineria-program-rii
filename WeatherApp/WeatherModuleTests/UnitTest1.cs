using System.Reflection;
using System.Text.Json;
using WeatherModule;

namespace WeatherModuleTests
{
    [TestClass]
    public class WeatherModuleTests
    { 
        [TestMethod]
        public void Deserialize_CurrentWeatherResponse_ShouldMapCorrectly()
        {
            string json = @"{
                ""coord"": { ""lon"": 25.6, ""lat"": 45.3 },
                ""weather"": [{ ""main"": ""Clear"", ""description"": ""clear sky"", ""icon"": ""01d"" }],
                ""main"": { ""temp"": 23.5, ""pressure"": 1012, ""humidity"": 40 },
                ""wind"": { ""speed"": 5.5 },
                ""sys"": { ""sunrise"": 1692694320, ""sunset"": 1692744120 }
            }";

            var response = JsonSerializer.Deserialize<WeatherInfo.CurrentWeatherResponse>(json);

            Assert.IsNotNull(response);
            Assert.AreEqual(25.6, response.Coordinates?.Longitude);
            Assert.AreEqual("Clear", response.WeatherConditions?.First().Condition);
            Assert.AreEqual(23.5, response.WeatherMetrics?.Temperature);
        }

        [TestMethod]
        public void ConvertDateTime_ValidUnixTimestamp_ReturnsCorrectDateTime()
        {
            var form = new Form1();
            long unixTime = 1609459200; // 1 Jan 2021, 00:00:00 UTC
            var result = form.ConvertDateTime(unixTime);

            Assert.AreEqual(new DateTime(2021, 1, 1, 0, 0, 0, DateTimeKind.Local), result);
        }


        [TestMethod]
        public void ForecastEntry_CalculateMinMaxTemperatures_ReturnsCorrectValues()
        {
            var entries = new List<WeatherForecast.ForecastEntry>
            {
                new() { TemperatureInfo = new() { MinimumTemperature = 10, MaximumTemperature = 15 }, Timestamp = 100 },
                new() { TemperatureInfo = new() { MinimumTemperature = 8, MaximumTemperature = 20 }, Timestamp = 101 },
            };

            var minTemp = entries.Min(e => e.TemperatureInfo!.MinimumTemperature);
            var maxTemp = entries.Max(e => e.TemperatureInfo!.MaximumTemperature);

            Assert.AreEqual(8, minTemp);
            Assert.AreEqual(20, maxTemp);
        }


        [TestMethod]
        public void ClearWeatherInfo_ResetsAllFields()
        {
            var form = new Form1();
            form.ClearWeatherInfo(); // ar trebui să faci `internal` pentru test

            Assert.AreEqual("N/A", form.labelCondition.Text);
            Assert.AreEqual(0, form.Latitude);
            Assert.AreEqual(0, form.Longitude);
        }


        [TestMethod]
        public async Task GetWeather_InvalidCity_ShowsError()
        {
            var mockProvider = new Mock<IWeatherProvider>();
            mockProvider.Setup(p => p.GetCurrentAsync("InvalidCity")).ReturnsAsync((WeatherInfo.CurrentWeatherResponse?)null);

            var form = new Form1();
            typeof(Form1).GetField("_weatherProvider", BindingFlags.NonPublic | BindingFlags.Instance)!
                .SetValue(form, mockProvider.Object);

            form.textBoxCity.Text = "InvalidCity";

            form.GetType().GetMethod("GetWeather", BindingFlags.NonPublic | BindingFlags.Instance)!
                .Invoke(form, null);

            // Testezi efectul (de ex. labelurile au "N/A")
            // Sau folosești un hook pentru MessageBox
        }

    }
}