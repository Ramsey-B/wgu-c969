using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Data.Repositories;
using CustomerManagement.Translations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagement
{
    public partial class Form1 : Form
    {
        public Form1(ISqlOrm sqlOrm)
        {
            InitializeComponent();

            var trans = Translator.Translate("test.sub");
            Translator.SetLanguage(Languages.Spanish);
            trans = Translator.Translate("test");
            var cr = new AddressRepository(sqlOrm);

            try
            {
                //var test = sqlConnection.QueryAsync<object>("SELECT LAST_INSERT_ID();").Result;
                var test = cr.GetAsync(1).Result;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
