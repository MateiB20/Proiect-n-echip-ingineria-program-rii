//-----------------------------------------------------------------------------
// Nume proiect:ThemeTests
// Fisier: ThemeTest.cs
// Descriere: Teste preluare schimbare temă.
// Autor: Izabela 
//
//-----------------------------------------------------------------------------

using ThemeModule;

namespace ThemeTests
{
    [TestClass]
    public sealed class ThemeTest
    {
        private class TestThemeObserver : IThemeObserverService
        {
            /// <summary>
            /// Clasă privată ce simulează comportamentul formularului.
            /// Moștenește interfața observer și implementează metoda OnThemeChanged similar cu form-ul.
            /// </summary>

            public AppTheme? ReceivedTheme { get; private set; }

            public void OnThemeChanged(AppTheme theme)
            {
                ReceivedTheme = theme;
            }
        }
        /// <summary>
        /// Metodă de test pentru notificare observator.
        /// </summary>
        [TestMethod]
        public void TestNotificareObserver()
        {
            var manager = new ThemeManagerService();
            var testObserver = new TestThemeObserver();

            manager.Register(testObserver);
            manager.ChangeTheme(AppTheme.Dark);

            Assert.AreEqual(AppTheme.Dark, testObserver.ReceivedTheme, "Observatorul nu a primit tema corectă.");
        }
        /// <summary>
        /// Metodă de test pentru înregistrare dublă.
        /// </summary>
        [TestMethod]
        public void TestInregistrareDubla()
        {
            var manager = new ThemeManagerService();
            var observer = new TestThemeObserver();

            manager.Register(observer);
            manager.Register(observer); 

            manager.ChangeTheme(AppTheme.Dark);

            Assert.AreEqual(AppTheme.Dark, observer.ReceivedTheme);
        }
        /// <summary>
        /// Metodă de test pentru tematica default.
        /// </summary>
        [TestMethod]
        public void TestTemaDefault()
        {
            var manager = new ThemeManagerService();

            Assert.AreEqual(AppTheme.Light, manager.GetCurrentTheme(), "Tema implicită trebuie să fie Light.");
        }
        /// <summary>
        /// Metodă de test pentru inregistrare obiect null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestInregistrareNull()
        {
            var manager = new ThemeManagerService();
            manager.Register(null);
        }
        /// <summary>
        /// Metodă de test pentru UnRegister obiect null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestUnregisterNull()
        {
            var manager = new ThemeManagerService();
            manager.Unregister(null);
        }
        /// <summary>
        /// Metodă de test pentru UnRegister obiect neînregistrat.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Unregister_UnregisteredObserver_ShouldThrow()
        {
            var manager = new ThemeManagerService();
            var observer = new TestThemeObserver();
            manager.Unregister(observer);
        }
    }
}
