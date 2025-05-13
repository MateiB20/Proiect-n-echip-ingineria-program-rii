using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeModule
{
    public interface IThemeObserverService
    {
        /// <summary>
        /// Metodă pentru schimbarea tematicii grafice a aplicației.
        /// </summary>
        /// <param name="appTheme"></param>
        public void OnThemeChanged(AppTheme appTheme);
    }

}
