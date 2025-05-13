using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace WindowsFormsApp1
{
    public interface ILanguageObserver
    {
        void OnLanguageChanged(CultureInfo newCulture);
    }
}
