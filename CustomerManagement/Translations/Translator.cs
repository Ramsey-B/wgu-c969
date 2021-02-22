using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace CustomerManagement.Translations
{
    public class Translator
    {
        private static readonly Dictionary<Languages, string> pathToTranslation = new Dictionary<Languages, string>()
        {
            { Languages.English, Directory.GetCurrentDirectory() + "\\Translations\\english.json" },
            { Languages.Spanish, Directory.GetCurrentDirectory() + "\\Translations\\spanish.json" }
        };

        private JObject translation = GetTranslation(Languages.English); // Defaults to english

        public void SetLanguage(Languages language)
        {
            translation = GetTranslation(language);
        }

        public string Translate(string key)
        {
            // Allows the key to use dot notation
            var segments = key.Split('.');
            JToken translationToken = translation[segments[0]];
            for (int i = 1; i < segments.Length; i++)
            {
                translationToken = translationToken[segments[i]];
            }
            return translationToken.ToString();
        }

        private static JObject GetTranslation(Languages language)
        {
            var json = File.ReadAllText(pathToTranslation[language]);
            return JObject.Parse(json);
        }
    }

    public enum Languages
    {
        English,
        Spanish
    }
}
