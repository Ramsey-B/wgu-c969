using AutoFixture;
using CustomerManagement.Core.Exceptions;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Data.Repositories;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CustomerManagement.Test.RepositoryTests
{
    public class AppointmentRepositoryTests
    {
        private Fixture fixture = new Fixture();

        [Fact]
        public void ShouldGetAll()
        {
            var userId = 35;
            var customerId = 23;
            var start = DateTime.Now;
            var end = start.AddDays(1);
            var searchTerm = "test";
            var appointments = fixture.CreateMany<Appointment>().ToList();
            var expectedSqlSegment = " AND appointment.customerId = @customerId AND appointment.userId = @userId AND (username LIKE @searchTerm OR type LIKE @searchTerm OR customer.name LIKE @searchTerm OR crewName LIKE @searchTerm OR title LIKE @searchTerm OR description LIKE @searchTerm OR location LIKE @searchTerm)";

            var sqlMock = new Mock<ISqlOrm>();
            sqlMock.Setup(m => m.QueryListAsync<Appointment>(It.Is<string>(s => s.Contains(expectedSqlSegment)), It.Is<object>(o => JsonConvert.SerializeObject(o) == JsonConvert.SerializeObject(new { userId, customerId, start, end, searchTerm = $"%{searchTerm}%" })))).ReturnsAsync(appointments);

            var repo = new AppointmentRepository(sqlMock.Object);

            var result = repo.GetAllAsync(start, end, userId, customerId, searchTerm).Result;

            Assert.Equal(appointments, result);
        }

        [Fact]
        public void ShouldGetConsultantSchedules()
        {
            var start = DateTime.Now;
            var end = start.AddDays(1);
            var crewName = "test";
            var expectedResult = fixture.CreateMany<ConsultantSchedule>().ToList();
            var expectedSqlSegment = " AND crewName = @crewName";

            var sqlMock = new Mock<ISqlOrm>();
            sqlMock.Setup(m => m.QueryListAsync<ConsultantSchedule>(It.Is<string>(s => s.Contains(expectedSqlSegment)), It.Is<object>(o => JsonConvert.SerializeObject(o) == JsonConvert.SerializeObject(new { start, end, crewName })))).ReturnsAsync(expectedResult);

            var repo = new AppointmentRepository(sqlMock.Object);

            var result = repo.GetConsultantSchedules(start, end, crewName).Result;

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ShouldPreventCreateWithTitle()
        {
            var appointment = new Appointment() { Title = "" };

            var sqlMock = new Mock<ISqlOrm>();

            var repo = new AppointmentRepository(sqlMock.Object);

            var ex = Assert.ThrowsAsync<InvalidEntityException>(() => repo.CreateAsync(appointment)).Result;
            Assert.Equal("title", ex.PropertyName);
        }

        [Fact]
        public void ShouldPreventCreateWithType()
        {
            var appointment = new Appointment() { Title = "test", Type = "", Crew = "Test" };

            var sqlMock = new Mock<ISqlOrm>();

            var repo = new AppointmentRepository(sqlMock.Object);

            var ex = Assert.ThrowsAsync<InvalidEntityException>(() => repo.CreateAsync(appointment)).Result;
            Assert.Equal("type", ex.PropertyName);
        }

        [Fact]
        public void ShouldPreventOverlappingAppointments()
        {
            var appointment = new Appointment() { Title = "test", Type = "type", Crew = "test", UserId = 23, Start = DateTime.UtcNow, End = DateTime.UtcNow.AddDays(1) };

            var sqlMock = new Mock<ISqlOrm>();
            sqlMock.Setup(m => m.QueryAsync<Appointment>(It.IsAny<string>(), It.Is<object>(o => JsonConvert.SerializeObject(o) == JsonConvert.SerializeObject(new { userId = appointment.UserId, start = appointment.Start, end = appointment.End, crew = appointment.Crew, id = 0 })))).ReturnsAsync(new Appointment());

            var repo = new AppointmentRepository(sqlMock.Object);

            var ex = Assert.ThrowsAsync<OverlappingAppointmentException>(() => repo.CreateAsync(appointment)).Result;
        }

        [Fact]
        public void ShouldCreateAppointment()
        {
            var appointment = new Appointment() { Title = "test", Type = "type", Crew = "test", UserId = 23, Start = DateTime.UtcNow, End = DateTime.UtcNow.AddDays(1) };

            var sqlMock = new Mock<ISqlOrm>();
            sqlMock.Setup(m => m.QueryAsync<Appointment>(It.IsAny<string>(), It.Is<object>(o => JsonConvert.SerializeObject(o) == JsonConvert.SerializeObject(new { userId = appointment.UserId, start = appointment.Start, end = appointment.End, crew = appointment.Crew, id = 0 })))).ReturnsAsync((Appointment)null);
            sqlMock.Setup(m => m.CreateEntityAsync(It.IsAny<string>(), appointment)).ReturnsAsync(1).Verifiable();

            var repo = new AppointmentRepository(sqlMock.Object);

            var result = repo.CreateAsync(appointment).Result;

            sqlMock.Verify(m => m.CreateEntityAsync(It.IsAny<string>(), appointment), Times.Once);
            Assert.Equal(1, result);
        }

        [Fact]
        public void ShouldUpdateAppointment()
        {
            var appointment = new Appointment() { Title = "test", Type = "type", Crew = "Test", UserId = 23, Start = DateTime.UtcNow, End = DateTime.UtcNow.AddDays(1) };

            var sqlMock = new Mock<ISqlOrm>();
            sqlMock.Setup(m => m.QueryAsync<Appointment>(It.IsAny<string>(), It.Is<object>(o => JsonConvert.SerializeObject(o) == JsonConvert.SerializeObject(new { userId = appointment.UserId, start = appointment.Start, end = appointment.End, crew = appointment.Crew, id = 0 })))).ReturnsAsync((Appointment)null);
            sqlMock.Setup(m => m.ExecuteAsync(It.IsAny<string>(), appointment)).ReturnsAsync(1).Verifiable();

            var repo = new AppointmentRepository(sqlMock.Object);

            var result = repo.UpdateAsync(appointment).Result;

            sqlMock.Verify(m => m.ExecuteAsync(It.IsAny<string>(), appointment), Times.Once);
            Assert.Equal(1, result);
        }

        [Fact]
        public void ShouldDeleteAppointment()
        {
            var testId = 34;

            var sqlMock = new Mock<ISqlOrm>();
            sqlMock.Setup(m => m.DeleteAsync(testId, "appointment")).ReturnsAsync(43);

            var repo = new AppointmentRepository(sqlMock.Object);

            var result = repo.DeleteAsync(testId).Result;

            Assert.Equal(43, result);
        }
    }
}
