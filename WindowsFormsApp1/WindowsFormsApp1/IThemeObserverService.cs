//-----------------------------------------------------------------------------
// Nume proiect:Weather App
// Fisier: IThemeObserverService.cs
// Descriere: Interfata pentru implementarea schimbarii tematicii grafice cu design patternul Observer.
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
    /// Enum pentru stocarea tipului de tema.
    /// </summary>
    public enum AppTheme{
        Light,
        Dark
    }
    /// <summary>
    /// Interfata pentru schimbarea tematicii grafice.
    /// </summary>
    public interface IThemeObserverService
    {
        public void OnThemeChanged(AppTheme appTheme);
    }
}
