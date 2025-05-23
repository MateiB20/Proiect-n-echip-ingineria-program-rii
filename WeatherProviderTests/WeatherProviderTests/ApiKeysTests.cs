using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace WeatherProviderTests
{
    [TestClass]
    public class ApiKeysTests
    {
        [TestMethod]
        public void LoadFromConfig_ReturnsCorrectKeys1()
        {
            var keys = ApiKeys.LoadFromConfig();
            Assert.IsFalse(string.IsNullOrEmpty(keys.OpenWeather));
        }
        [TestMethod]
        public void LoadFromConfig_ReturnsCorrectKeys2()
        {
            var keys = ApiKeys.LoadFromConfig();
            Assert.IsFalse(string.IsNullOrEmpty(keys.WeatherBit));
       }
    }
}
