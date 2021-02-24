using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Translations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagement.Forms
{
    public partial class ModifyAppointment : Form
    {
        private readonly Translator _translator;
        private readonly Context _context;
        private readonly IAppointmentRepository _appointmentRepository;

        public Customer Customer { get; set; }
        public Appointment Appointment { get; set; }
        public ModifyAppointment(Translator translator, Context context, IAppointmentRepository appointmentRepository)
        {
            _translator = translator;
            _context = context;
            _appointmentRepository = appointmentRepository;
            InitializeComponent();

            Shown += (object sender, EventArgs e) =>
            {
                TranslatePage();
            };
        }

        private void TranslatePage()
        {
            if (Appointment == null)
            {
                Name = _translator.Translate("appointment.addAppointment");
                Text = _translator.Translate("appointment.addAppointment");
            }
            else
            {
                Name = _translator.Translate("appointment.editAppointment");
                Text = _translator.Translate("appointment.editAppointment");
            }
            pageTitle.Text = _translator.Translate("appointment.modifyTitle", new { Customer.Name });
            titleLabel.Text = _translator.Translate("appointment.title");
            descriptionLabel.Text = _translator.Translate("appointment.description");
            locationLabel.Text = _translator.Translate("appointment.location");
            contactLabel.Text = _translator.Translate("appointment.contact");
            typeLabel.Text = _translator.Translate("appointment.type");
            urlLabel.Text = _translator.Translate("appointment.url");
            startLabel.Text = _translator.Translate("appointment.start");
            endLabel.Text = _translator.Translate("appointment.end");
            cancelBtn.Text = _translator.Translate("cancel");
            submitBtn.Text = _translator.Translate("submit");
        }
    }
}
