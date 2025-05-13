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
        private List<ILanguageObserver> observers;
        private CultureInfo currentCulture;
        
        public LanguageManagerService()
        {
        
            observers = new List<ILanguageObserver>();
            currentCulture = CultureInfo.CurrentUICulture;
        }
    public void Register(ILanguageObserver observer)
        {
            if(!observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }
        public void UnRegister(ILanguageObserver observer)
        {
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }
        public void ChangeLanguage(string langCode)
        {
            var newCulture = new CultureInfo(langCode);
            CultureInfo.CurrentUICulture = newCulture;
            currentCulture = newCulture;

            foreach(var obs in observers)
            {
                obs.OnLanguageChanged(newCulture);
            }
        }
        public CultureInfo GetCurrentCulture() => currentCulture;

    }
}
