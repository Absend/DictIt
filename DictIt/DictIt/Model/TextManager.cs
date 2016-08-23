namespace DictIt.Model
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Speech.Synthesis;

    public static class TextManager
    {
        private static bool IsMatching(string searchWord, string listWord)
        {
            searchWord = searchWord.ToLower();
            listWord = listWord.ToLower();
            if (listWord.Length < searchWord.Length)
                return false;
            return !searchWord.Where((t, i) => t != listWord[i]).Any();
        }

        public static string MatchedWord(string searchWord, IList<string> listItems)
        {
            foreach (var item in listItems)
            {
                if (searchWord != null && IsMatching(searchWord, item))
                {
                    int ind = listItems.IndexOf(item);
                    return listItems[ind];
                }
            }
            return null;
        }

        public static void SpeakTextFemale(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                var syntizer = new SpeechSynthesizer { Volume = 100, Rate = 0 };
                syntizer.SelectVoiceByHints(VoiceGender.Female);
                syntizer.Speak(text);
            }
        }

        public static void SpeakTextMale(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                var syntizer = new SpeechSynthesizer { Volume = 100, Rate = 0 };
                syntizer.SelectVoiceByHints(VoiceGender.Male);
                syntizer.Speak(text);
            }
        }
    }
}