using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace WeatherProviderTests
{
    [TestClass]
    public class WeatherProviderFactoryTests
    {
        [TestMethod]
        public void Create_WithOpenWeather_ReturnsOpenWeatherProvider()
        {
            var keys = ApiKeys.LoadFromConfig();
            var factory = new WeatherProviderFactory(keys);
            var provider = factory.Create("openweather");
            Assert.IsInstanceOfType(provider, typeof(OpenWeatherProvider));
        }

        [TestMethod]
        public void Create_WithWeatherBit_ReturnsWeatherBitProvider()
        {
            var keys = ApiKeys.LoadFromConfig();
            var factory = new WeatherProviderFactory(keys);
            var provider = factory.Create("weatherbit");
            Assert.IsInstanceOfType(provider, typeof(WeatherBitProvider));
        }

        [TestMethod]
        public void Create_WithWttr_ReturnsWttrProvider()
        {
            var keys = ApiKeys.LoadFromConfig();
            var factory = new WeatherProviderFactory(keys);
            var provider = factory.Create("wttr");
            Assert.IsInstanceOfType(provider, typeof(WttrProvider));
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Create_WithUnknownProvider_ThrowsNotSupported()
        {
            var keys = ApiKeys.LoadFromConfig();
            var factory = new WeatherProviderFactory(keys);
            factory.Create("unknown");
        }
    }
}
