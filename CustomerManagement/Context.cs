﻿using CustomerManagement.Core.Models;
using CustomerManagement.Forms;
using CustomerManagement.Translations;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagement
{
    public class Context
    {
        private readonly Login _login;
        private readonly IServiceProvider _servicePorvider;
        private User _currentUser;

        public Context(Login login, IServiceProvider serviceProvider)
        {
            _login = login;
            _servicePorvider = serviceProvider;

            _login.FormClosed += (object sender, FormClosedEventArgs e) =>
            {
                _currentUser = _login.User;
            };
        }

        public User CurrentUser
        {
            get { return Authenticate(); }
            set { _currentUser = value; }
        }

        public T GetService<T>()
        {
            return _servicePorvider.GetRequiredService<T>();
        }

        public async Task HandleReminders(List<Appointment> appointments)
        {
            //appointments = appointments.FindAll(appt => appt.Start > DateTime.UtcNow.AddMinutes(-1) && appt.Start < DateTime.UtcNow.AddDays(1));
            for (int i = 0; i < appointments.Count; i++)
            {
                appointments[i].Start = DateTime.UtcNow.AddMinutes(i + 15);
            }
            
            appointments = appointments.OrderBy(appt => appt.Start).ToList();

            foreach (var appt in appointments)
            {
                await Task.Run(async () => 
                {
                    var timeToGo = appt.Start - DateTime.UtcNow.AddMinutes(15);
                    if (timeToGo.Ticks > 0) // The appointment is over 15 mins from now
                    {
                        await Task.Delay(timeToGo);
                    }
                    MessageBox.Show($"Alert: You have an appointment in {timeToGo.Minutes + 15} minutes with {appt.CustomerName} at {appt.Start.ToLocalTime()}!");
                });
            }
        }

        private User Authenticate()
        {
            if (_currentUser == null)
            {
                _login.ShowDialog();
            }
            return _currentUser;
        }
    }
}
