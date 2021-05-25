using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.ViewModels;
using CustomerManagement.Tables;
using CustomerManagement.Translations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace CustomerManagement.Forms
{
    public partial class ConsultantSchedules : Form
    {
        private readonly IContext _context;
        private readonly ITranslator _translator;
        private readonly ConsultantSchedulesViewModel _viewModel;

        public ConsultantSchedules(IContext context)
        {
            _context = context;
            _translator = _context.GetService<ITranslator>();
            _viewModel = new ConsultantSchedulesViewModel(context);
            InitializeComponent();
            Translate();
            AddCrewNames().Wait();
            GetReport().Wait();

            monthRadio.Click += async (object sender, EventArgs e) =>
            {
                dayRadio.Checked = false;
                weekRadio.Checked = false;
                monthRadio.Checked = true;
                await GetReport();
            };

            weekRadio.Click += async (object sender, EventArgs e) =>
            {
                dayRadio.Checked = false;
                weekRadio.Checked = true;
                monthRadio.Checked = false;
                await GetReport();
            };

            dayRadio.Click += async (object sender, EventArgs e) =>
            {
                dayRadio.Checked = true;
                weekRadio.Checked = false;
                monthRadio.Checked = false;
                await GetReport();
            };
        }

        private async Task AddCrewNames()
        {
            var crewNames = await _viewModel.GetCrewNames();
            crewNames = crewNames.Distinct().ToList();

            var all = _translator.Translate("all");
            crewSelect.Items.Add(all);
            crewNames.ForEach(n => crewSelect.Items.Add(n));
            crewSelect.SelectedItem = all;
            crewSelect.SelectedValueChanged += async (object sender, EventArgs e) => await GetReport();
        }

        private async Task GetReport()
        {
            var results = await _viewModel.GetReport(crewSelect.SelectedItem?.ToString(), dayRadio.Checked, weekRadio.Checked) ?? new List<ConsultantSchedule>();

            TableService.SetData(ref reportTable, results, (key) => _translator.Translate($"consultantSchedules.{key}"));
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            await GetReport();
        }

        private void Translate()
        {
            Name = _translator.Translate("consultantSchedules.pageTitle");
            Text = _translator.Translate("consultantSchedules.pageTitle");
            pageHeader.Text = _translator.Translate("consultantSchedules.pageHeader");
            monthRadio.Text = _translator.Translate("month");
            weekRadio.Text = _translator.Translate("week");
            closeBtn.Text = _translator.Translate("close");
        }
    }
}
