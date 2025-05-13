//-----------------------------------------------------------------------------
// Nume proiect:Weather App
// Fisier: ThemeManagerService.cs
// Descriere: Serviciu pentru inregistrarea observerilor si logica de schimbare a temei.
// Autor: Izabela 
//
//-----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Clasa Manager pentru gestionarea logicii de schimbare a temei.
    /// Fiecare observator este inregistrat.Tema se schimba in mod diferit in functie de implementarea specifica a metodei OnThemeChanged.
    /// </summary>
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
            if (!_observers.Contains(observer))
                _observers.Add(observer);
        }
        /// <summary>
        /// Metoda de eliminare a unui observator.
        /// </summary>
        /// <param name="observer"></param>
        public void Unregister(IThemeObserverService observer)
        {
            if(_observers.Contains(observer))
               _observers.Remove(observer);
        }
        /// <summary>
        /// Metoda pentru schimbarea temei.Pentru fiecare observator se apeleaza metoda implementata in clasa derivata.
        /// </summary>
        /// <param name="newTheme"></param>
        public void ChangeTheme(AppTheme newTheme)
        {
            _currentTheme = newTheme;
            foreach (var observer in _observers)
            {
                observer.OnThemeChanged(newTheme);
            }
        }
        /// <summary>
        /// Metoda de tip Get pentru obtinerea temei curente.
        /// </summary>
        /// <returns></returns>
        public AppTheme GetCurrentTheme() => _currentTheme;
    }
}
