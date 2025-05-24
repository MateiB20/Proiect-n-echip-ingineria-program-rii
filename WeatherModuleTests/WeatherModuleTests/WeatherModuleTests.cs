using System.Reflection;
using System.Text.Json;
using WeatherModule;


namespace WeatherModuleTests
{
    [TestClass]
    public class WeatherModuleTests
    {
        [TestMethod]
        public void Deserialize_CurrentWeatherResponse_Should_MapAllFieldsCorrectly()
        {
            string json = @"
            {
                ""coord"": { ""lon"": 10.0, ""lat"": 45.0 },
                ""weather"": [ { ""main"": ""Clear"", ""description"": ""clear sky"", ""icon"": ""01d"" } ],
                ""main"": { ""temp"": 23.5, ""pressure"": 1012, ""humidity"": 50 },
                ""wind"": { ""speed"": 3.4 },
                ""sys"": { ""sunrise"": 1625467200, ""sunset"": 1625520000 }
            }";

            var result = JsonSerializer.Deserialize<WeatherInfo.CurrentWeatherResponse>(json);

            Assert.IsNotNull(result);
            Assert.AreEqual(10.0, result.Coordinates.Longitude);
            Assert.AreEqual(45.0, result.Coordinates.Latitude);
            Assert.AreEqual("Clear", result.WeatherConditions[0].Condition);
            Assert.AreEqual(23.5, result.WeatherMetrics.Temperature);
            Assert.AreEqual(3.4, result.Wind.Speed);
            Assert.AreEqual(1625467200, result.SystemInfo.Sunrise);
        }

        [TestMethod]
        public void Initialize_ForecastEntry_Should_SetValuesCorrectly()
        {
            var entry = new WeatherForecast.ForecastEntry
            {
                Timestamp = 1234567890,
                TemperatureInfo = new WeatherForecast.TemperatureInfo
                {
                    MinimumTemperature = 12.3,
                    MaximumTemperature = 25.6
                },
                WeatherDescriptions = new List<WeatherForecast.WeatherDescription>
                {
                    new WeatherForecast.WeatherDescription
                    {
                        Condition = "Rain",
                        DetailedDescription = "light rain",
                        Icon = "10d"
                    }
                }
            };

            Assert.AreEqual(1234567890, entry.Timestamp);
            Assert.AreEqual(12.3, entry.TemperatureInfo.MinimumTemperature);
            Assert.AreEqual("Rain", entry.WeatherDescriptions[0].Condition);
        }


        [TestMethod]
        public void Deserialize_PartialJson_Should_HandleMissingFieldsGracefully()
        {
            string json = @"{ ""main"": { ""temp"": 18.0 } }";

            var result = JsonSerializer.Deserialize<WeatherInfo.CurrentWeatherResponse>(json);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.WeatherMetrics);
            Assert.AreEqual(18.0, result.WeatherMetrics.Temperature);
            Assert.IsNull(result.Coordinates);  // nu a fost în JSON
            Assert.IsNull(result.WeatherConditions);
        }

        [TestMethod]
        public void Deserialize_EmptyJson_Should_CreateValidObjectWithNullProperties()
        {
            string json = @"{ }";

            var result = JsonSerializer.Deserialize<WeatherInfo.CurrentWeatherResponse>(json);

            Assert.IsNotNull(result);
            Assert.IsNull(result.WeatherMetrics);
            Assert.IsNull(result.Coordinates);
            Assert.IsNull(result.WeatherConditions);
            Assert.IsNull(result.Wind);
            Assert.IsNull(result.SystemInfo);
        }

        [TestMethod]
        public void AllProperties_ShouldBeSettable()
        {
            var type = typeof(WeatherInfo.CurrentWeatherResponse);
            var instance = Activator.CreateInstance(type);

            foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (!prop.CanWrite) continue;

                object dummyValue = null;
                var propType = prop.PropertyType;

                if (propType == typeof(string))
                {
                    dummyValue = "test";
                }
                else if (propType == typeof(double))
                {
                    dummyValue = 1.0;
                }
                else if (propType == typeof(int))
                {
                    dummyValue = 1;
                }
                else if (propType == typeof(List<WeatherInfo.WeatherConditions>))
                {
                    dummyValue = new List<WeatherInfo.WeatherConditions>();
                }
                else if (propType.GetConstructor(Type.EmptyTypes) != null)
                {
                    dummyValue = Activator.CreateInstance(propType);
                }

                if (dummyValue != null)
                {
                    prop.SetValue(instance, dummyValue);
                    Assert.AreEqual(dummyValue, prop.GetValue(instance), $"Property {prop.Name} should be settable.");
                }
            }
        }

    }
}