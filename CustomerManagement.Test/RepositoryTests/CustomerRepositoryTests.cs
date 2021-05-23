using AutoFixture;
using CustomerManagement.Core.Exceptions;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Data.Repositories;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace CustomerManagement.Test.RepositoryTests
{
    public class CustomerRepositoryTests
    {
        private Fixture fixture = new Fixture();

        [Theory]
        [InlineData("")]
        [InlineData("1James")]
        [InlineData("James!")]
        public void ShouldValidateName(string name)
        {
            var customer = new Customer { Name = name };

            var sqlMock = new Mock<ISqlOrm>();

            var repo = new CustomerRepository(sqlMock.Object);

            var ex = Assert.ThrowsAsync<InvalidEntityException>(() => repo.CreateAsync(customer)).Result;
            Assert.Equal("name", ex.PropertyName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("12345v")]
        [InlineData("1232!")]
        public void ShouldValidatePostalCode(string postalCode)
        {
            var customer = new Customer { Name = "James", PostalCode = postalCode };

            var sqlMock = new Mock<ISqlOrm>();

            var repo = new CustomerRepository(sqlMock.Object);

            var ex = Assert.ThrowsAsync<InvalidEntityException>(() => repo.CreateAsync(customer)).Result;
            Assert.Equal("postalCode", ex.PropertyName);
        }

        [Fact]
        public void ShouldValidateAddress1()
        {
            var customer = new Customer { Name = "James", PostalCode = "12345", Address1 = "" };

            var sqlMock = new Mock<ISqlOrm>();

            var repo = new CustomerRepository(sqlMock.Object);

            var ex = Assert.ThrowsAsync<InvalidEntityException>(() => repo.CreateAsync(customer)).Result;
            Assert.Equal("address1", ex.PropertyName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("12345123v")]
        [InlineData("1232123!")]
        public void ShouldValidatePhone(string phone)
        {
            var customer = new Customer { Name = "James", PostalCode = "12345", Address1 = "some street", Phone = phone };

            var sqlMock = new Mock<ISqlOrm>();

            var repo = new CustomerRepository(sqlMock.Object);

            var ex = Assert.ThrowsAsync<InvalidEntityException>(() => repo.CreateAsync(customer)).Result;
            Assert.Equal("phone", ex.PropertyName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("city1")]
        [InlineData("city!")]
        public void ShouldValidateCity(string city)
        {
            var customer = new Customer { Name = "James", PostalCode = "12345", Address1 = "some street", Phone = "1231231234", City = city};

            var sqlMock = new Mock<ISqlOrm>();

            var repo = new CustomerRepository(sqlMock.Object);

            var ex = Assert.ThrowsAsync<InvalidEntityException>(() => repo.CreateAsync(customer)).Result;
            Assert.Equal("city", ex.PropertyName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("country1")]
        [InlineData("country!")]
        public void ShouldValidateCountry(string country)
        {
            var customer = new Customer { Name = "James", PostalCode = "12345", Address1 = "some street", Phone = "1231231234", City = "city", Country = country };

            var sqlMock = new Mock<ISqlOrm>();

            var repo = new CustomerRepository(sqlMock.Object);

            var ex = Assert.ThrowsAsync<InvalidEntityException>(() => repo.CreateAsync(customer)).Result;
            Assert.Equal("country", ex.PropertyName);
        }

        [Fact]
        public void ShouldCreateCustomer()
        {
            var customer = new Customer { Name = "John-James'", PostalCode = "12345", Address1 = "some street", Phone = "1231231234", City = "city-town", Country = "country'" };

            var sqlMock = new Mock<ISqlOrm>();
            sqlMock.Setup(m => m.CreateEntityAsync(It.IsAny<string>(), It.Is<object>(o => MatchCustomer(o, customer)))).ReturnsAsync(32);

            var repo = new CustomerRepository(sqlMock.Object);

            var result = repo.CreateAsync(customer).Result;
            Assert.Equal(32, result);
        }

        private bool MatchCustomer(object o, Customer c)
        {
            var str = JsonConvert.SerializeObject(o);

            return str.Contains(c.Name) && str.Contains(c.PostalCode) && str.Contains(c.Address1) && str.Contains(c.Phone) && str.Contains(c.City) && str.Contains(c.Country);
        }
    }
}
