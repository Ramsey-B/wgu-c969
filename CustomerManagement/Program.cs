﻿using CustomerManagement.Core.Interfaces;
using CustomerManagement.Data.Repositories;
using CustomerManagement.Data.Util;
using CustomerManagement.Forms.Customers;
using CustomerManagement.Logging;
using CustomerManagement.Translations;
using Microsoft.Extensions.DependencyInjection;
using System;
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
                // inits the project with the dashboard
                var dashboard = serviceProvider.GetRequiredService<Dashboard>();
                Application.Run(dashboard);
            }
        }

        // Setup the microsoft DI the same way as ASP.Net does.
        private static void ConfigureServices(ServiceCollection services)
        {
            services
                // Normally you would hide this in a config value.
                .AddScoped<ISqlOrm>(c => new SqlOrm("server=wgudb.ucertify.com;user id=U07Uzf;password=53689134933;database=U07Uzf;persistsecurityinfo=True"))
                .AddScoped<IAddressRepository, AddressRepository>()
                .AddScoped<ICustomerRepository, CustomerRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IAppointmentRepository, AppointmentRepository>()
                .AddScoped<Logger>()
                .AddScoped<Context>()
                .AddScoped<Translator>()
                .AddSingleton<Reminder>() // Must be a singleton to work.
                .AddScoped<Dashboard>();
        }
    }
}
