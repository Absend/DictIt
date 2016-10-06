namespace RTFEditor
{
    using System.Collections.ObjectModel;
    using System.Windows.Media;

    /// <summary>
    /// Erzeugt eine String Liste aller auf dem System installierten Schriftarten
    /// </summary>
    public class FontList : ObservableCollection<string> 
    { 
        public FontList() 
        {
            foreach (var f in Fonts.SystemFontFamilies)
            {                
                Add(f.ToString());                
            }  
        }   
    }
}
