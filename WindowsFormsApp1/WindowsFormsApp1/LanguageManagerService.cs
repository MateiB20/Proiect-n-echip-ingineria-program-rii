using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace WindowsFormsApp1
{
   public  class LanguageManagerService
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
            if(!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }
        public void UnRegister(ILanguageObserverService observer)
        {
            if (_observers.Contains(observer))
            {
                _observers.Remove(observer);
            }
        }
        public void ChangeLanguage(string langCode)
        {
            var newCulture = new CultureInfo(langCode);
            CultureInfo.CurrentUICulture = newCulture;
            _currentCulture = newCulture;

            foreach(var obs in _observers)
            {
                obs.OnLanguageChanged(newCulture);
            }
        }
        public CultureInfo GetCurrentCulture() => _currentCulture;

    }
}
