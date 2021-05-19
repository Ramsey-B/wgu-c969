using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Core.Interfaces
{
    public interface ITableItem
    {
        Dictionary<string, string> GetColumns(Func<string, string> translation);
        object[] GetRow();
    }
}
