namespace RTFEditor
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// Erzeugt eine String Liste der gewünschten Schriftgrößen
    /// </summary>
    public class FontHeight : ObservableCollection<string>
    {
        public FontHeight()
        {
            Add("8"); Add("9"); Add("10"); Add("11"); Add("12"); Add("14"); Add("16"); Add("18"); 
            Add("20"); Add("22"); Add("24"); Add("26"); Add("28"); Add("36"); Add("48"); Add("72");
        }
    }
}
