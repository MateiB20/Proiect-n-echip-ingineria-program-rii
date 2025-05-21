using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeModule
{
    public class ThemeManagerService
    {
        private List<IThemeObserverService> _observers;
        private AppTheme _currentTheme;
        /// <summary>
        /// Constructorul clasei.Se aloca spatiu pentru observeri si se seteaza tema implicita.
        /// </summary>
        public ThemeManagerService()
        {
            _observers = new List<IThemeObserverService>();
            _currentTheme = AppTheme.Light;
        }
        /// <summary>
        /// Metoda de inregistrare a observatorilor.
        /// </summary>
        /// <param name="observer"></param>
        public void Register(IThemeObserverService observer)
        {
            if (observer == null)
                throw new ArgumentNullException(nameof(observer), "Observer cannot be null.");

            if (!_observers.Contains(observer))
                _observers.Add(observer);
        }
        /// <summary>
        /// Metoda de eliminare a unui observator.
        /// </summary>
        /// <param name="observer"></param>
        public void Unregister(IThemeObserverService observer)
        {
            if (observer == null)
                throw new ArgumentNullException(nameof(observer), "Observer cannot be null.");

            if (!_observers.Contains(observer))
                throw new InvalidOperationException("Observer is not registered.");

            if (_observers.Contains(observer))
                _observers.Remove(observer);
        }
        /// <summary>
        /// Metoda pentru schimbarea temei.Pentru fiecare observator se apeleaza metoda implementata in clasa derivata.
        /// </summary>
        /// <param name="newTheme"></param>
        public void ChangeTheme(AppTheme newTheme)
        {
            if (newTheme==null)
                throw new ArgumentException("Theme cannot be null or empty.");

            _currentTheme = newTheme;
            foreach (var observer in _observers)
            {
                try
                {
                    observer.OnThemeChanged(newTheme);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Eroare la notificarea observatorului: {observer.GetType().Name}");
                    Console.WriteLine($"Detalii: {ex.Message}");
                }
            }
        }
        /// <summary>
        /// Metoda de tip Get pentru obtinerea temei curente.
        /// </summary>
        /// <returns></returns>
        public AppTheme GetCurrentTheme() => _currentTheme;
    }
}
