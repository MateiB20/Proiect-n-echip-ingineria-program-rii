using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace LanguageModule
{
    public class LanguageManagerService
    {
        private List<ILanguageObserverService> _observers;
        private CultureInfo _currentCulture;

        public LanguageManagerService()
        {

            _observers = new List<ILanguageObserverService>();
            _currentCulture = CultureInfo.CurrentUICulture;
        }
        public void Register(ILanguageObserverService observer)
        {
            if (observer == null)
                throw new ArgumentNullException(nameof(observer), "Observer cannot be null.");

            if (_observers.Contains(observer))
                throw new InvalidOperationException("Observer is already registered.");

            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }

        }
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
        public CultureInfo GetCurrentCulture() => _currentCulture;

    }
}
