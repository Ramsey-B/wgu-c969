using AutoFixture;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Data.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CustomerManagement.Test.RepositoryTests
{
    public class AddressRepositoryTests
    {
        private Fixture fixture = new Fixture();

        [Fact]
        public void ShouldCreateAddress()
        {
            var newAddress = fixture.Create<Address>();
            var countryId = 12;
            var cityId = 32;
            var addressId = 53;

            var sqlMock = new Mock<ISqlOrm>();
            sqlMock.Setup(m => m.CreateEntityAsync(It.IsAny<string>(), newAddress.City.Country)).ReturnsAsync(countryId);
            sqlMock.Setup(m => m.CreateEntityAsync(It.IsAny<string>(), It.Is<City>(c => c.CountryId == countryId))).ReturnsAsync(cityId);
            sqlMock.Setup(m => m.CreateEntityAsync(It.IsAny<string>(), It.Is<Address>(c => c.CityId == cityId))).ReturnsAsync(addressId);

            var repo = new AddressRepository(sqlMock.Object);

            var result = repo.CreateAsync(newAddress).Result;

            Assert.Equal(addressId, result);
        }

        [Fact]
        public void ShouldUpdateAddress()
        {
            var newAddress = fixture.Create<Address>();

            var sqlMock = new Mock<ISqlOrm>();
            sqlMock.Setup(m => m.ExecuteAsync(It.IsAny<string>(), newAddress.City.Country)).ReturnsAsync(1);
            sqlMock.Setup(m => m.ExecuteAsync(It.IsAny<string>(), newAddress.City)).ReturnsAsync(1);
            sqlMock.Setup(m => m.ExecuteAsync(It.IsAny<string>(), newAddress)).ReturnsAsync(1);

            var repo = new AddressRepository(sqlMock.Object);

            var result = repo.UpdateAsync(newAddress).Result;

            Assert.Equal(3, result);
        }
    }
}
