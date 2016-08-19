namespace DictIt.Model
{
    public static class Logger
    {
        public static string ItemSaved(string item)
        {
            return string.Format("{0} saved!", item);
        }
    }
}
