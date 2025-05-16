using System;
using System.Globalization;
namespace LanguageModule
{
    public interface ILanguageObserverService
    {
        void OnLanguageChanged(CultureInfo newCulture);
    }
}
