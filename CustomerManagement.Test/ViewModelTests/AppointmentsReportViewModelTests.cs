using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace CustomerManagement.Tests.FormViewModelsTests
{
    public class AppointmentsReportViewModelTests
    {
        [Fact]
        public void ShouldReturnCorrectReport()
        {
            var testUserId = 4;
            var testYear = 2021;
            var testAppts = new List<Appointment>()
            {
                new Appointment() { Start = new DateTime(2021, 6, 1) },
                new Appointment() { Start = new DateTime(2021, 6, 1) },
                new Appointment() { Start = new DateTime(2021, 6, 1) },
                new Appointment() { Start = new DateTime(2021, 6, 1) },
            };
            var appointmentRepoMock = new Mock<IAppointmentRepository>();
            appointmentRepoMock.Setup(m => m.GetAllAsync(It.Is<DateTime>(d => d.Year == testYear && d.Month == 1 && d.Day == 1), It.Is<DateTime>(d => d.Year == testYear && d.Month == 12 && d.Day == 31), testUserId, null, null)).ReturnsAsync(testAppts);

            var translatorMock = new Mock<ITranslator>();
            translatorMock.Setup(m => m.Translate($"months.6", null)).Returns("June");

            var contextMock = new Mock<IContext>();
            contextMock.Setup(m => m.GetService<IAppointmentRepository>()).Returns(appointmentRepoMock.Object);
            contextMock.Setup(m => m.GetService<ITranslator>()).Returns(translatorMock.Object);
            contextMock.Setup(m => m.CurrentUser).Returns(new User { Id = testUserId });

            var model = new AppointmentsReportViewModel(contextMock.Object);

            var result = model.GetAppointmentReports(testYear).Result;

            Assert.NotNull(result.Find(r => r.Month == "June" && r.Count == testAppts.Count));
        }
    }
}
