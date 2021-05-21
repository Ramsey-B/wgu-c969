using AutoFixture;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.FormViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerManagement.Tests.FormViewModelsTests
{
    public class ConsultantSchedulesViewModelTests
    {
        [Fact]
        public void ShouldGetDaysReport()
        {
            var fixture = new Fixture();
            var reports = fixture.CreateMany<ConsultantSchedule>().ToList();
            var appointmentRepMock = new Mock<IAppointmentRepository>();
            appointmentRepMock.Setup(m => m.GetConsultantSchedules(DateTime.Today, DateTime.Today.AddDays(1).AddSeconds(-1), null)).ReturnsAsync(reports);

            var contextMock = new Mock<IContext>();
            contextMock.Setup(m => m.GetService<IAppointmentRepository>()).Returns(appointmentRepMock.Object);

            var model = new ConsultantSchedulesViewModel(contextMock.Object);

            var result = model.GetReport(null, true, false).Result;

            Assert.Equal(reports, result);
        }

        [Fact]
        public void ShouldGetWeekReport()
        {
            var fixture = new Fixture();
            var reports = fixture.CreateMany<ConsultantSchedule>().ToList();
            var appointmentRepMock = new Mock<IAppointmentRepository>();
            appointmentRepMock.Setup(m => m.GetConsultantSchedules(DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek), DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek).AddDays(7), null)).ReturnsAsync(reports);

            var contextMock = new Mock<IContext>();
            contextMock.Setup(m => m.GetService<IAppointmentRepository>()).Returns(appointmentRepMock.Object);

            var model = new ConsultantSchedulesViewModel(contextMock.Object);

            var result = model.GetReport(null, false, true).Result;

            Assert.Equal(reports, result);
        }

        [Fact]
        public void ShouldGetMonthReport()
        {
            var fixture = new Fixture();
            var today = DateTime.Today;
            var reports = fixture.CreateMany<ConsultantSchedule>().ToList();
            var appointmentRepMock = new Mock<IAppointmentRepository>();
            appointmentRepMock.Setup(m => m.GetConsultantSchedules(new DateTime(today.Year, today.Month, 1), new DateTime(today.Year, today.Month, 1).AddMonths(1).AddDays(-1), null)).ReturnsAsync(reports);

            var contextMock = new Mock<IContext>();
            contextMock.Setup(m => m.GetService<IAppointmentRepository>()).Returns(appointmentRepMock.Object);

            var model = new ConsultantSchedulesViewModel(contextMock.Object);

            var result = model.GetReport(null, false, false).Result;

            Assert.Equal(reports, result);
        }

        [Fact]
        public void ShouldGetCrewReport()
        {
            var fixture = new Fixture();
            var today = DateTime.Today;
            var crew = "crew name";
            var reports = fixture.CreateMany<ConsultantSchedule>().ToList();
            var appointmentRepMock = new Mock<IAppointmentRepository>();
            appointmentRepMock.Setup(m => m.GetConsultantSchedules(new DateTime(today.Year, today.Month, 1), new DateTime(today.Year, today.Month, 1).AddMonths(1).AddDays(-1), crew)).ReturnsAsync(reports);

            var translatorMock = new Mock<ITranslator>();
            translatorMock.Setup(m => m.Translate("all", null)).Returns("all");

            var contextMock = new Mock<IContext>();
            contextMock.Setup(m => m.GetService<IAppointmentRepository>()).Returns(appointmentRepMock.Object);
            contextMock.Setup(m => m.GetService<ITranslator>()).Returns(translatorMock.Object);

            var model = new ConsultantSchedulesViewModel(contextMock.Object);

            var result = model.GetReport(crew, false, false).Result;

            Assert.Equal(reports, result);
        }
    }
}
