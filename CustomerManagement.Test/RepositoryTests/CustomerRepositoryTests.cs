using AutoFixture;
using CustomerManagement.Core.Exceptions;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Data.Repositories;
using Moq;
using Newtonsoft.Json;
using System.Linq;
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

        [Fact]
        public void ShouldUpdateCustomer()
        {
            var customer = new Customer { Name = "John-James'", PostalCode = "12345", Address1 = "some street", Phone = "1231231234", City = "city-town", Country = "country'" };

            var sqlMock = new Mock<ISqlOrm>();
            sqlMock.Setup(m => m.ExecuteAsync(It.IsAny<string>(), It.Is<object>(o => MatchCustomer(o, customer)))).ReturnsAsync(32);

            var repo = new CustomerRepository(sqlMock.Object);

            var result = repo.UpdateAsync(customer).Result;
            Assert.Equal(4, result);
        }

        [Fact]
        public void ShouldDeleteCustomer()
        {
            var customerId = 2;

            var sqlMock = new Mock<ISqlOrm>();
            sqlMock.Setup(m => m.DeleteAsync(customerId, "customer")).ReturnsAsync(32);

            var repo = new CustomerRepository(sqlMock.Object);

            var result = repo.DeleteAsync(customerId).Result;
            Assert.Equal(32, result);
        }

        [Fact]
        public void ShouldGetCustomer()
        {
            var customerId = 2;
            var customer = fixture.Create<Customer>();

            var sqlMock = new Mock<ISqlOrm>();
            sqlMock.Setup(m => m.QueryAsync<Customer>(It.Is<string>(s => s.Contains(" WHERE customer.id = @id")), It.Is<object>(o => JsonConvert.SerializeObject(o).Contains(customerId.ToString())))).ReturnsAsync(customer);

            var repo = new CustomerRepository(sqlMock.Object);

            var result = repo.GetAsync(customerId).Result;
            Assert.Equal(customer, result);
        }

        [Fact]
        public void ShouldGetAllCustomers()
        {
            var searchTerm = "test search";
            var customers = fixture.CreateMany<Customer>().ToList();

            var sqlMock = new Mock<ISqlOrm>();
            sqlMock.Setup(m => m.QueryListAsync<Customer>(It.Is<string>(s => s.Contains(" WHERE customer.name LIKE @searchTerm OR address.phone LIKE @searchTerm OR address.address1 LIKE @searchTerm OR address.address2 LIKE @searchTerm OR city.name LIKE @searchTerm OR country.name LIKE @searchTerm")), It.Is<object>(o => JsonConvert.SerializeObject(o).Contains($"%{searchTerm}%")))).ReturnsAsync(customers);

            var repo = new CustomerRepository(sqlMock.Object);

            var result = repo.GetAllAsync(searchTerm).Result;
            Assert.Equal(customers, result);
        }

        private bool MatchCustomer(object o, Customer c)
        {
            var str = JsonConvert.SerializeObject(o);

            return str.Contains(c.Name) && str.Contains(c.PostalCode) && str.Contains(c.Address1) && str.Contains(c.Phone) && str.Contains(c.City) && str.Contains(c.Country);
        }
    }
}
