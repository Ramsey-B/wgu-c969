using AutoFixture;
using CustomerManagement.Core.Exceptions;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.ViewModels;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerManagement.Tests.ViewModelsTests
{
    public class ModifyAppointmentViewModelTests
    {
        private Fixture fixture = new Fixture();
        public static IEnumerable<object[]> invalidDates =>
            new List<object[]>
            {
                new object[] { DateTime.Today.ToLocalTime().AddHours(2), DateTime.Today.ToLocalTime().AddHours(10) }, // before open
                new object[] { DateTime.Today.ToLocalTime().AddHours(10), DateTime.Today.ToLocalTime().AddHours(20) }, // after close
                new object[] { DateTime.Now.ToLocalTime().AddHours(-1), DateTime.Today.ToLocalTime().AddHours(10)}, // start in the past
                new object[] { DateTime.Today.ToLocalTime().AddHours(10), DateTime.Today.ToLocalTime().AddHours(12).AddYears(1) }, // different years
                new object[] { DateTime.Today.ToLocalTime().AddHours(10).AddDays(1), DateTime.Today.ToLocalTime().AddHours(12).AddMonths(2) }, // differenct months
                new object[] { DateTime.Today.ToLocalTime().AddHours(10).AddDays(1), DateTime.Today.ToLocalTime().AddHours(20) }, // differenct days
                new object[] { DateTime.Today.ToLocalTime().AddHours(12), DateTime.Today.ToLocalTime().AddHours(10) }, // start after end
            };

        [Theory]
        [MemberData(nameof(invalidDates))]
        public void ShouldValidateBusinessHours(DateTime start, DateTime end)
        {
            Func<Appointment, Task<int>> callback = a => Task.FromResult(1);
            var expectedMsg = "This is a bad time";
            var appointment = new Appointment { Start = start, End = end };

            var translatorMock = new Mock<ITranslator>();
            translatorMock.Setup(m => m.Translate("appointment.outOfHoursError", It.IsAny<object>())).Returns(expectedMsg);

            var contextMock = new Mock<IContext>();
            contextMock.Setup(m => m.GetService<ITranslator>()).Returns(translatorMock.Object);

            var model = new ModifyAppointmentViewModel(contextMock.Object);

            var ex = Assert.ThrowsAsync<PublicException>(() => model.SubmitAsync(appointment, callback)).Result;
            Assert.Equal("out-of-business-hours", ex.Id);
            Assert.Equal(expectedMsg, ex.Message);
        }

        [Fact]
        public void ShouldHandleInvalidEntries()
        {
            var expectedMsg = "This is an invalid input";
            var appointment = fixture.Create<Appointment>();
            appointment.Start = DateTime.Today.AddDays(1).AddHours(10);
            appointment.End = DateTime.Today.AddDays(1).AddHours(12);
            Func<Appointment, Task<int>> callback = a => throw new InvalidEntityException("someProp");

            var translatorMock = new Mock<ITranslator>();
            translatorMock.Setup(m => m.Translate("appointment.requiredFieldError", It.IsAny<object>())).Returns(expectedMsg);

            var contextMock = new Mock<IContext>();
            contextMock.Setup(m => m.GetService<ITranslator>()).Returns(translatorMock.Object);

            var model = new ModifyAppointmentViewModel(contextMock.Object);

            var ex = Assert.ThrowsAsync<PublicException>(() => model.SubmitAsync(appointment, callback)).Result;
            Assert.Equal("required-field-error", ex.Id);
            Assert.Equal(expectedMsg, ex.Message);
        }

        [Fact]
        public void ShouldHandleOverlappingError()
        {
            var expectedMsg = "This is an invalid time slot";
            var appointment = fixture.Create<Appointment>();
            appointment.Start = DateTime.Today.AddDays(1).AddHours(10);
            appointment.End = DateTime.Today.AddDays(1).AddHours(12);
            Func<Appointment, Task<int>> callback = a => throw new OverlappingAppointmentException(DateTime.Today, DateTime.Now);

            var translatorMock = new Mock<ITranslator>();
            translatorMock.Setup(m => m.Translate("appointment.overlappingAppointmentError", It.IsAny<object>())).Returns(expectedMsg);

            var contextMock = new Mock<IContext>();
            contextMock.Setup(m => m.GetService<ITranslator>()).Returns(translatorMock.Object);

            var model = new ModifyAppointmentViewModel(contextMock.Object);

            var ex = Assert.ThrowsAsync<PublicException>(() => model.SubmitAsync(appointment, callback)).Result;
            Assert.Equal("overlapping-appointment", ex.Id);
            Assert.Equal(expectedMsg, ex.Message);
        }

        [Fact]
        public void ShouldHandleUnexpectedErrors()
        {
            var expectedMsg = "This is an invalid time slot";
            var appointment = fixture.Create<Appointment>();
            appointment.Start = DateTime.Today.AddDays(1).AddHours(10);
            appointment.End = DateTime.Today.AddDays(1).AddHours(12);
            Func<Appointment, Task<int>> callback = a => throw new Exception();

            var translatorMock = new Mock<ITranslator>();
            translatorMock.Setup(m => m.Translate("unexpectedError", It.IsAny<object>())).Returns(expectedMsg);

            var contextMock = new Mock<IContext>();
            contextMock.Setup(m => m.GetService<ITranslator>()).Returns(translatorMock.Object);

            var model = new ModifyAppointmentViewModel(contextMock.Object);

            var ex = Assert.ThrowsAsync<PublicException>(() => model.SubmitAsync(appointment, callback)).Result;
            Assert.Equal("unexpected-error", ex.Id);
            Assert.Equal(expectedMsg, ex.Message);
        }

        [Fact]
        public void ShouldExecuteCallback()
        {
            var appointment = fixture.Create<Appointment>();
            appointment.Start = DateTime.Today.AddDays(1).AddHours(10);
            appointment.End = DateTime.Today.AddDays(1).AddHours(12);
            var count = 0;
            Func<Appointment, Task<int>> callback = a =>
            {
                var expectedAppt = appointment;
                expectedAppt.Start = appointment.Start.ToUniversalTime();
                expectedAppt.End = appointment.End.ToUniversalTime();
                if (JsonConvert.SerializeObject(a) == JsonConvert.SerializeObject(expectedAppt))
                {
                    count++;
                    return Task.FromResult(1);
                }

                return Task.FromResult(0);
            };

            var translatorMock = new Mock<ITranslator>();

            var contextMock = new Mock<IContext>();
            contextMock.Setup(m => m.GetService<ITranslator>()).Returns(translatorMock.Object);

            var model = new ModifyAppointmentViewModel(contextMock.Object);

            model.SubmitAsync(appointment, callback).Wait();

            Assert.Equal(1, count);
        }
    }
}
