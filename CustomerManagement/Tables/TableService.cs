using CustomerManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagement.Tables
{
    public static class TableService
    {
        public static void SetData<T>(ref DataGridView table, List<T> data, Func<string, string> translation = null) where T : ITableItem, new()
        {
            if (translation == null)
            {
                translation = (string str) => str;
            }
            var instance = new T();
            var cols = instance.GetColumns(translation);

            foreach (var col in cols)
            {
                table.Columns.Add(col.Key, col.Value);
            }

            foreach (var item in data)
            {
                table.Rows.Add(item.GetRow());
            }
        }
    }
}
