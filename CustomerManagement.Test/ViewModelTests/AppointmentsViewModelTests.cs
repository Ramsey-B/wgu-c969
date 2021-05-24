using AutoFixture;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerManagement.Tests.FormViewModelsTests
{
    public class AppointmentsViewModelTests
    {
        [Fact]
        public void ShouldShowAllCustomersAppointments()
        {
            var fixture = new Fixture();
            var testUserId = 4;
            var testCustomer = new Customer { Id = 43 };
            var testSearchTerm = "search";
            var appointments = fixture.CreateMany<Appointment>();

            var appointmentRepoMock = new Mock<IAppointmentRepository>();
            appointmentRepoMock.Setup(m => m.GetAllAsync(DateTime.Today, DateTime.MaxValue, testUserId, testCustomer.Id, testSearchTerm)).ReturnsAsync(appointments.ToList());

            var contextMock = new Mock<IContext>();
            contextMock.Setup(m => m.CurrentUser).Returns(new User { Id = testUserId });
            contextMock.Setup(m => m.GetService<IAppointmentRepository>()).Returns(appointmentRepoMock.Object);

            var model = new AppointmentsViewModel(contextMock.Object);

            var result = model.GetAppointments(testSearchTerm, testCustomer, false, false).Result;

            Assert.Equal(appointments, result);
        }

        [Fact]
        public void ShouldShowTodaysAppointments()
        {
            var fixture = new Fixture();
            var testUserId = 4;
            var testSearchTerm = "search";
            var appointments = fixture.CreateMany<Appointment>();

            var appointmentRepoMock = new Mock<IAppointmentRepository>();
            appointmentRepoMock.Setup(m => m.GetAllAsync(DateTime.Today, DateTime.Today.AddDays(1).AddSeconds(-1), testUserId, null, testSearchTerm)).ReturnsAsync(appointments.ToList());

            var contextMock = new Mock<IContext>();
            contextMock.Setup(m => m.CurrentUser).Returns(new User { Id = testUserId });
            contextMock.Setup(m => m.GetService<IAppointmentRepository>()).Returns(appointmentRepoMock.Object);

            var model = new AppointmentsViewModel(contextMock.Object);

            var result = model.GetAppointments(testSearchTerm, null, true, false).Result;

            Assert.Equal(appointments, result);
        }

        [Fact]
        public void ShouldShowWeeksAppointments()
        {
            var fixture = new Fixture();
            var testUserId = 4;
            var testSearchTerm = "search";
            var appointments = fixture.CreateMany<Appointment>();

            var appointmentRepoMock = new Mock<IAppointmentRepository>();
            appointmentRepoMock.Setup(m => m.GetAllAsync(DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek), DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek).AddDays(7), testUserId, null, testSearchTerm)).ReturnsAsync(appointments.ToList());

            var contextMock = new Mock<IContext>();
            contextMock.Setup(m => m.CurrentUser).Returns(new User { Id = testUserId });
            contextMock.Setup(m => m.GetService<IAppointmentRepository>()).Returns(appointmentRepoMock.Object);

            var model = new AppointmentsViewModel(contextMock.Object);

            var result = model.GetAppointments(testSearchTerm, null, false, true).Result;

            Assert.Equal(appointments, result);
        }

        [Fact]
        public void ShouldShowMonthsAppointments()
        {
            var fixture = new Fixture();
            var testUserId = 4;
            var testSearchTerm = "search";
            var appointments = fixture.CreateMany<Appointment>();

            var appointmentRepoMock = new Mock<IAppointmentRepository>();
            appointmentRepoMock.Setup(m => m.GetAllAsync(new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1), testUserId, null, testSearchTerm)).ReturnsAsync(appointments.ToList());

            var contextMock = new Mock<IContext>();
            contextMock.Setup(m => m.CurrentUser).Returns(new User { Id = testUserId });
            contextMock.Setup(m => m.GetService<IAppointmentRepository>()).Returns(appointmentRepoMock.Object);

            var model = new AppointmentsViewModel(contextMock.Object);

            var result = model.GetAppointments(testSearchTerm, null, false, false).Result;

            Assert.Equal(appointments, result);
        }
    }
}
