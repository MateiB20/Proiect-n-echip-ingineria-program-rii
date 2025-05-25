using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace LanguageModule
{
    /// <summary>
    /// Gestionar pentru limbajul (localizarea) aplicației. Permite schimbarea limbii
    /// și notificarea tuturor componentelor interesate (observatoare).
    /// </summary>
    public class LanguageManagerService
    {
        private List<ILanguageObserverService> _observers;
        private CultureInfo _currentCulture;

        /// <summary>
        /// Creează o nouă instanță a clasei <see cref="LanguageManagerService"/> și
        /// setează cultura curentă pe cea a sistemului.
        /// </summary>
        public LanguageManagerService()
        {

            _observers = new List<ILanguageObserverService>();
            _currentCulture = CultureInfo.CurrentUICulture;
        }

        /// <summary>
        /// Înregistrează un observator care va fi notificat la schimbarea limbii.
        /// </summary>
        /// <param name="observer">Observatorul de înregistrat.</param>
        /// <exception cref="ArgumentNullException">Dacă observatorul este null.</exception>
        public void Register(ILanguageObserverService observer)
        {
            if (observer == null)
                throw new ArgumentNullException(nameof(observer), "Observer cannot be null.");

            
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }

        }

        /// <summary>
        /// Dezînregistrează un observator.
        /// </summary>
        /// <param name="observer">Observatorul de dezînregistrat.</param>
        /// <exception cref="ArgumentNullException">Dacă observatorul este null.</exception>
        /// <exception cref="InvalidOperationException">Dacă observatorul nu a fost înregistrat anterior.</exception>
        public void UnRegister(ILanguageObserverService observer)
        {
            if (observer == null)
                throw new ArgumentNullException(nameof(observer), "Observer cannot be null.");

            if (!_observers.Contains(observer))
                throw new InvalidOperationException("Observer is not registered.");

            if (_observers.Contains(observer))
            {
                _observers.Remove(observer);
            }
        }

        /// <summary>
        /// Schimbă cultura aplicației și notifică toți observatorii înregistrați.
        /// </summary>
        /// <param name="langCode">Codul limbii (ex: "ro-RO", "en-US").</param>
        /// <exception cref="ArgumentException">Dacă codul de limbă este null sau gol.</exception>
        public void ChangeLanguage(string langCode)
        {
            if (string.IsNullOrWhiteSpace(langCode))
                throw new ArgumentException("Language code cannot be null or empty.", nameof(langCode));

            
            var newCulture = new CultureInfo(langCode);
            CultureInfo.CurrentUICulture = newCulture;
            _currentCulture = newCulture;


            foreach (var obs in _observers)
            {
                try
                {
                    obs.OnLanguageChanged(newCulture);

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ChangeLanguage: Eroare la notificarea observatorului: {obs.GetType().Name}");
                    Console.WriteLine($"ChangeLanguage: Detalii: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Returnează cultura curentă a aplicației.
        /// </summary>
        /// <returns>Obiect <see cref="CultureInfo"/> corespunzător limbii curente.</returns>
        public CultureInfo GetCurrentCulture() => _currentCulture;

    }
}
