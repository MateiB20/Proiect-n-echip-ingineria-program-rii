using System;
using System.Globalization;
namespace LanguageModule
{
    /// <summary>
    /// Interfață pentru serviciile care observă și reacționează la schimbările de limbă (localizare).
    /// </summary>
    public interface ILanguageObserverService
    {
        /// <summary>
        /// Metodă apelată atunci când cultura aplicației se schimbă.
        /// </summary>
        /// <param name="newCulture">Noua cultură (ex: "RO", "EN", "FR").</param>
        void OnLanguageChanged(CultureInfo newCulture);
    }
}
