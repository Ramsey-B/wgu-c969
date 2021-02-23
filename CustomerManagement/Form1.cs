using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Data.Repositories;
using CustomerManagement.Logging;
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
        public Form1(IUserRepository userRepository)
        {
            InitializeComponent();
            var logger = new Logger();


            try
            {
                var user = new User()
                {
                    Name = "test",
                    Password = "sgegs",
                    Active = 1,
                    CreatedBy = "Ramsey",
                    LastUpdateBy = "Ramsey"
                };
                var test = userRepository.LoginAsync(user).Result;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
