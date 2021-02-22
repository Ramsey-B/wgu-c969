using CustomerManagement.Core.Interfaces;
using CustomerManagement.Data.Util;
using CustomerManagement.Translations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);

            using(var serviceProvider = services.BuildServiceProvider())
            {
                var form1 = serviceProvider.GetRequiredService<Form1>();
                Application.Run(form1);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services
                .AddScoped<Form1>()
                .AddScoped<ISqlOrm>(c => new SqlOrm("server=wgudb.ucertify.com;user id=U07Uzf;password=53689134933;database=U07Uzf;persistsecurityinfo=True"))
                .AddScoped<Translator>();
        }
    }
}
