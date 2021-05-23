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
    public class UserRepositoryTests
    {
        private Fixture fixture = new Fixture();

        [Fact]
        public void ShouldGetUserExists()
        {
            var username = "test";
            var sqlMock = new Mock<ISqlOrm>();
            sqlMock.Setup(m => m.ExecuteAsync(It.IsAny<string>(), It.Is<object>(o => JsonConvert.SerializeObject(o) == JsonConvert.SerializeObject(new { username })))).ReturnsAsync(1);

            var repo = new UserRepository(sqlMock.Object);

            var result = repo.CheckUsernameExists(username).Result;

            Assert.True(result);
        }

        [Fact]
        public void ShouldGetUserNotExists()
        {
            var username = "test";
            var sqlMock = new Mock<ISqlOrm>();
            sqlMock.Setup(m => m.ExecuteAsync(It.IsAny<string>(), It.Is<object>(o => JsonConvert.SerializeObject(o) == JsonConvert.SerializeObject(new { username })))).ReturnsAsync(0);

            var repo = new UserRepository(sqlMock.Object);

            var result = repo.CheckUsernameExists(username).Result;

            Assert.False(result);
        }

        [Fact]
        public void ShouldHandleInvalidLogin()
        {
            var user = new User { Username = "test", Password = "password" };
            var sqlMock = new Mock<ISqlOrm>();
            sqlMock.Setup(m => m.QueryAsync<User>(It.IsAny<string>(), It.Is<object>(o => JsonConvert.SerializeObject(o).Contains(user.Username) && !JsonConvert.SerializeObject(o).Contains(user.Password)))).ReturnsAsync((User)null);

            var repo = new UserRepository(sqlMock.Object);

            var ex = Assert.ThrowsAsync<InvalidLoginException>(() => repo.LoginAsync(user)).Result;
            Assert.Equal(user.Username, ex.Username);
        }

        [Fact]
        public void ShouldHandleLogin()
        {
            var user = new User { Username = "test", Password = "password" };
            var expectedUser = fixture.Create<User>();
            var sqlMock = new Mock<ISqlOrm>();
            sqlMock.Setup(m => m.QueryAsync<User>(It.IsAny<string>(), It.Is<object>(o => JsonConvert.SerializeObject(o).Contains(user.Username) && !JsonConvert.SerializeObject(o).Contains(user.Password)))).ReturnsAsync(expectedUser);

            var repo = new UserRepository(sqlMock.Object);

            var result = repo.LoginAsync(user).Result;
            Assert.Equal(expectedUser, result);
        }

        [Fact]
        public void ShouldCreateLogin()
        {
            var user = fixture.Create<User>();
            var expectedUser = fixture.Create<User>();
            var sqlMock = new Mock<ISqlOrm>();
            sqlMock.Setup(m => m.CreateEntityAsync(It.IsAny<string>(), It.Is<object>(o => JsonConvert.SerializeObject(o).Contains(user.Username) && !JsonConvert.SerializeObject(o).Contains(user.Password))));
            sqlMock.Setup(m => m.QueryAsync<User>(It.IsAny<string>(), It.Is<object>(o => JsonConvert.SerializeObject(o).Contains(user.Username) && !JsonConvert.SerializeObject(o).Contains(user.Password)))).ReturnsAsync(expectedUser);

            var repo = new UserRepository(sqlMock.Object);

            var result = repo.LoginAsync(user).Result;
            Assert.Equal(expectedUser, result);
        }
    }
}
