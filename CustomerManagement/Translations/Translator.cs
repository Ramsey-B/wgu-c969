using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace CustomerManagement.Translations
{
    public class Translator
    {
        public Translator()
        {
            GetDefaultLanguage();
        }

        private static readonly Dictionary<Languages, string> pathToTranslation = new Dictionary<Languages, string>()
        {
            { Languages.English, Directory.GetCurrentDirectory() + "\\Translations\\english.json" },
            { Languages.Spanish, Directory.GetCurrentDirectory() + "\\Translations\\spanish.json" }
        };

        private JObject translation;

        public void SetLanguage(Languages language)
        {
            translation = GetTranslation(language);
        }

        public string Translate(string key, object args = null)
        {
            // Allows the key to use dot notation
            var segments = key.Split('.');
            JToken translationToken = translation[segments[0]];
            for (int i = 1; i < segments.Length; i++)
            {
                translationToken = translationToken[segments[i]];
            }

            return AddArgs(translationToken, args);
        }

        private void GetDefaultLanguage()
        {
            switch (CultureInfo.CurrentUICulture.LCID)
            {
                case 1033:
                    SetLanguage(Languages.English);
                    break;
                case 2058:
                    SetLanguage(Languages.Spanish);
                    break;
                default:
                    SetLanguage(Languages.English);
                    break;
            }
        }

        private static JObject GetTranslation(Languages language)
        {
            var json = File.ReadAllText(pathToTranslation[language]);
            return JObject.Parse(json);
        }

        private string AddArgs(JToken token, object args)
        {
            var translation = token?.ToString() ?? "";

            if (args != null)
            {
                foreach (var property in args.GetType().GetProperties())
                {
                    translation = translation.Replace("{" + property.Name + "}", property.GetValue(args).ToString());
                }
            }

            return translation;
        }
    }

    public enum Languages
    {
        English,
        Spanish
    }
}
