using CustomerManagement.Core.Interfaces;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace CustomerManagement.Translations
{
    /// <summary>
    /// Custom translator inspired by the i18n npm library.
    /// </summary>
    public class Translator : ITranslator
    {
        public Translator()
        {
            GetDefaultLanguage();
        }

        // Grabs the file paths to the json translations
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


        /// <summary>
        /// Returns the translated string from the translation json files.
        /// key is the dot notated path to the translation in the json file.
        /// args replaces the {key} in the translation string with the arg value.
        /// </summary>
        public string Translate(string key, object args = null)
        {
            // Allows the key to use dot notation
            var segments = key.Split('.'); // 'one.two.three' = ['one', 'two', 'three']
            JToken translationToken = translation[segments[0]]; // sets the first token to the first segment ('one')
            for (int i = 1; i < segments.Length; i++) // i starts at one because line 42 
            {
                translationToken = translationToken[segments[i]]; // keeps digging down to the final segent ('three')
            }

            return AddArgs(translationToken, args);
        }

        private void GetDefaultLanguage()
        {
            switch (CultureInfo.CurrentUICulture.ThreeLetterISOLanguageName)
            {
                case "eng":
                    SetLanguage(Languages.English);
                    break;
                case "spa":
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
            var translation = token?.ToString() ?? ""; // converts the segment to a string ('three' -> "this is the translation {Test}")

            if (args != null)
            {
                foreach (var property in args.GetType().GetProperties()) // uses reflection to iterate the objects properties
                {
                    translation = translation.Replace("{" + property.Name + "}", property.GetValue(args).ToString()); // replaces the {key} with the object value 
                }
            }

            return translation;
        }
    }
}
