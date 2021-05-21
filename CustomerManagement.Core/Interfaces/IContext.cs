using CustomerManagement.Core.Models;
using System.Windows.Forms;

namespace CustomerManagement.Core.Interfaces
{
    public interface IContext
    {
        User CurrentUser { get; set; }
        T GetService<T>();
        void Navigate(Form form);
    }
}
