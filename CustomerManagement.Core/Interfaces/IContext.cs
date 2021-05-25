using CustomerManagement.Core.Models;

namespace CustomerManagement.Core.Interfaces
{
    public interface IContext
    {
        User CurrentUser { get; set; }
        T GetService<T>();
        void Navigate(INavigationPage page);
    }
}
