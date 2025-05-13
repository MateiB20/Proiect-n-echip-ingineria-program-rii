using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace WindowsFormsApp1
{
    /// <summary>
    /// Interfata pentru schimbarea limbii în care apare conținutul.
    /// </summary>
    public interface ILanguageObserverService
    {
        /// <summary>
        /// Metodă pentru schimbarea limbii conținutului.
        /// </summary>
        /// <param name="newCulture"></param>
        void OnLanguageChanged(CultureInfo newCulture);
    }
}
