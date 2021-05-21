
namespace CustomerManagement.Core.Interfaces
{
    public interface ITranslator
    {
        void SetLanguage(Languages language);
        string Translate(string key, object args = null);
    }

    public enum Languages // translatable languages
    {
        English,
        Spanish
    }
}
