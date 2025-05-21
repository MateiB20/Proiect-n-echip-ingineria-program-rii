//-----------------------------------------------------------------------------
// Nume proiect:LanguageTests
// Fisier: LanguageTest.cs
// Descriere: Teste schimbare limbă.
// Autor: Izabela 
//
//-----------------------------------------------------------------------------

using LanguageModule;
using System.Globalization;

namespace LanguageTests
{
    [TestClass]
    public sealed class LanguageTest
    {
      /// <summary>
      /// Clasă privată ce simulează comportamentul formularului.
      /// Moștenește interfața observer și implementează metoda OnLanguageChanged similar cu form-ul.
      /// </summary>

        private class TestLanguageObserver:ILanguageObserverService

        {
            public CultureInfo ReceivedCulture { get; private set; }
            public void OnLanguageChanged(CultureInfo cultureInfo) 
            {
                ReceivedCulture = cultureInfo;
            }
        }
        /// <summary>
        /// Metodă de test pentru limba Română.
        /// </summary>
        [TestMethod]
        public void TestLimbaRomana()
        {
            
            var languageManager = new LanguageManagerService();
            var testObserver = new TestLanguageObserver();

            languageManager.Register(testObserver);
            languageManager.ChangeLanguage("ro");

            Assert.IsNotNull(testObserver.ReceivedCulture, "Observerul nu a fost notificat.");
            Assert.AreEqual("ro", testObserver.ReceivedCulture.Name, "Codul culturii nu este cel așteptat.");
        }
        /// <summary>
        /// Metodă de test pentru schimbarea limbii unui observer care a fost șters din listă.
        /// </summary>
        [TestMethod]
        public void TestObserverNull()
        {

            var languageManager = new LanguageManagerService();
            var testObserver = new TestLanguageObserver();

            languageManager.Register(testObserver);
            languageManager.UnRegister(testObserver);
            languageManager.ChangeLanguage("RO");

            Assert.IsNull(testObserver.ReceivedCulture, "Observerul nu ar trebui să fi fost notificat după dezregistrare.");
        }
        /// <summary>
        /// Metodă de test pentru lang code greșit.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CultureNotFoundException))]

        public void TestLangCodeGresit()
        {

            var languageManager = new LanguageManagerService();
            var testObserver = new TestLanguageObserver();

            languageManager.Register(testObserver);
            languageManager.ChangeLanguage("dfvdfv");

            Assert.AreEqual("fr", testObserver.ReceivedCulture.Name, "Codul culturii nu este cel așteptat.");
        }
        /// <summary>
        /// Metodă de test pentru a vedea comportamentul corect al tuturor observatorilor.
        /// </summary>
        [TestMethod]
        public void TestNotificareaTuturorObserverilor()
        {
            var manager = new LanguageManagerService();
            var observer1 = new TestLanguageObserver();
            var observer2 = new TestLanguageObserver();

            manager.Register(observer1);
            manager.Register(observer2);

            manager.ChangeLanguage("es-ES");

            Assert.AreEqual("es-ES", observer1.ReceivedCulture?.Name);
            Assert.AreEqual("es-ES", observer2.ReceivedCulture?.Name);
        }
        /// <summary>
        /// Metodă de test pentru limba Franceză.
        /// </summary>
        [TestMethod]
        public void TestLimbaFranceza()
        {

            var languageManager = new LanguageManagerService();
            var testObserver = new TestLanguageObserver();

            languageManager.Register(testObserver);
            languageManager.ChangeLanguage("fr");

            Assert.AreEqual("fr", testObserver.ReceivedCulture.Name, "Codul culturii nu este cel așteptat.");
        }
        /// <summary>
        /// Metodă de test pentru limba Germană.
        /// </summary>
        [TestMethod]
        public void TestLimbaGermana()
        {

            var languageManager = new LanguageManagerService();
            var testObserver = new TestLanguageObserver();

            languageManager.Register(testObserver);
            languageManager.ChangeLanguage("de");

            Assert.AreEqual("de", testObserver.ReceivedCulture.Name, "Codul culturii nu este cel așteptat.");
        }
    }
}
