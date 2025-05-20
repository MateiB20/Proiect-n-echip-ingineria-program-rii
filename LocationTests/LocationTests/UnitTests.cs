//-----------------------------------------------------------------------------
// Nume proiect:LocationTests
// Fisier: UnitTests.cs
// Descriere: Teste preluare date locatie curenta
// Autor: Matei 
//
//-----------------------------------------------------------------------------
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using System;
using System.Diagnostics;
using WindowsFormsApp1;
/// <summary>
/// Aceasta clasa contine teste ale unitatilor pentru clasele de tip Location
/// </summary>
[TestClass]
public class LocationTest
{
    /// <summary>
    /// Acest test validează preluarea cu succes a informatiilor despre locatie.
    /// <br/>
    /// Verifica daca orasul returnat de serviciu este "Iasi"
    /// </summary>
    [TestMethod]
    public async Task TestIasi() 
    {
        LocationInfo location = await new RetryLocationService(
            new LoggingLocationService(new LocationServiceFactory().CreateService())
        ).GetLocationFromIpAsync();
        Assert.AreEqual("Iași", location.City);
    }
    /// <summary>
    /// Acest test validează preluarea cu succes a informatiilor despre locatie.
    /// <br/>
    /// Verifica daca tara returnata de serviciu este "Romania"
    /// </summary>
    [TestMethod]
    public async Task TestRomania() 
    {
        LocationInfo location = await new RetryLocationService(
            new LoggingLocationService(new LocationServiceFactory().CreateService())
        ).GetLocationFromIpAsync();
        Assert.AreEqual("Romania", location.Country);
    }
    /// <summary>
    /// Acest test este conceput pentru a verifica daca exceptia corespunzatoare este 
    /// aruncata atunci cand apare o eroare din cauza lipsei unei conexiuni active
    /// la internet
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(LocationServiceException))]
    public async Task TestExceptieInternet()
    {
        LocationInfo location = await new RetryLocationService(
            new LoggingLocationService(new LocationServiceFactory().CreateService())
        ).GetLocationFromIpAsync();
        Assert.AreEqual("Iași", location.City);
    }
    /// <summary>
    /// Acest test este conceput pentru a verifica functionarea corespunzatoare a lui 
    /// "LoggingLocationService"
    /// </summary>
    [TestMethod]
    public async Task TestLog()
    {
        string cale = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "istoric.txt");
        string content = File.Exists(cale) ? File.ReadAllText(cale) : string.Empty;
        await Task.Delay(4500);
        int numar = content.Length;
        LocationInfo location = await new RetryLocationService(
            new LoggingLocationService(new LocationServiceFactory().CreateService())
        ).GetLocationFromIpAsync();
        await Task.Delay(4500);
        content = File.Exists(cale) ? File.ReadAllText(cale) : string.Empty;
        Assert.IsTrue(numar < content.Length);
    }
    /// <summary>
    /// Acest test este conceput pentru a verifica functionarea corespunzatoare a lui 
    /// "LocationServiceFactory"
    /// </summary>
    [TestMethod]
    public void TestFactory()
    {
        ILocationService locationService = new LocationServiceFactory().CreateService();
        Assert.IsInstanceOfType(locationService, typeof(LocationService));
    }
    /// <summary>
    /// Masoara durata totală a apelului complet (inclusiv retry-uri și logare),
    /// verificand ca aceasta sa nu depaseasca pragul de 4.5 secunde
    /// </summary>
    [TestMethod]
    public async Task TestPerformanta()
    {
        long startTicks = DateTime.Now.Ticks;
        await new RetryLocationService(
            new LoggingLocationService(new LocationServiceFactory().CreateService())
        ).GetLocationFromIpAsync();
        double diferenta = (DateTime.Now.Ticks - startTicks) / 10000.0;
        Assert.IsTrue(diferenta < 4500); 
    }
}