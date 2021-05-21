using AutoFixture;
using CustomerManagement.Core.Exceptions;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.FormViewModels;
using CustomerManagement.Logging;
using Moq;
using System;
using Xunit;

namespace CustomerManagement.Tests.FormViewModelsTests
{
    public class LoginViewModelTests
    {
        [Fact]
        public void ShouldRequireUsername()
        {
            var contextMock = new Mock<IContext>();

            var model = new LoginViewModel(contextMock.Object);

            var ex = Assert.ThrowsAsync<PublicException>(() => model.Login(new User() { Username = null })).Result;
            Assert.Equal("invalid-username", ex.Id);
        }

        [Fact]
        public void ShouldRequirePassword()
        {
            var contextMock = new Mock<IContext>();

            var model = new LoginViewModel(contextMock.Object);

            var ex = Assert.ThrowsAsync<PublicException>(() => model.Login(new User() { Username = "test", Password = null })).Result;
            Assert.Equal("invalid-password", ex.Id);
        }

        [Fact]
        public void ShouldHandleInvalidLogin()
        {
            var testLogin = new User { Username = "test", Password = "test" };
            var expectedEx = new InvalidLoginException(testLogin.Username);
            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock.Setup(m => m.LoginAsync(testLogin)).ThrowsAsync(expectedEx);

            var contextMock = new Mock<IContext>();
            contextMock.Setup(m => m.GetService<IUserRepository>()).Returns(userRepoMock.Object);
            contextMock.Setup(m => m.GetService<Logger>()).Returns(new Logger());

            var model = new LoginViewModel(contextMock.Object);

            var ex = Assert.ThrowsAsync<PublicException>(() => model.Login(testLogin)).Result;
            Assert.Equal("invalid-login", ex.Id);
        }

        [Fact]
        public void ShouldHandleUnexpectedErrors()
        {
            var testLogin = new User { Username = "test", Password = "test" };
            var expectedEx = new Exception(testLogin.Username);
            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock.Setup(m => m.LoginAsync(testLogin)).ThrowsAsync(expectedEx);

            var contextMock = new Mock<IContext>();
            contextMock.Setup(m => m.GetService<IUserRepository>()).Returns(userRepoMock.Object);
            contextMock.Setup(m => m.GetService<Logger>()).Returns(new Logger());

            var model = new LoginViewModel(contextMock.Object);

            var ex = Assert.ThrowsAsync<PublicException>(() => model.Login(testLogin)).Result;
            Assert.Equal("unexpected-login", ex.Id);
        }

        [Fact]
        public void ShouldLoginUser()
        {
            var fixture = new Fixture();
            var expectedUser = fixture.Create<User>();
            var testLogin = new User { Username = "test", Password = "test" };
            var expectedEx = new InvalidLoginException(testLogin.Username);
            User actualUser = null;

            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock.Setup(m => m.LoginAsync(testLogin)).ReturnsAsync(expectedUser).Verifiable();

            var contextMock = new Mock<IContext>();
            contextMock.Setup(m => m.GetService<IUserRepository>()).Returns(userRepoMock.Object);
            contextMock.Setup(m => m.GetService<Logger>()).Returns(new Logger());
            contextMock.SetupSet(p => p.CurrentUser = It.IsAny<User>()).Callback<User>(v => actualUser = v);

            var model = new LoginViewModel(contextMock.Object);

            model.Login(testLogin).Wait();

            userRepoMock.Verify(m => m.LoginAsync(testLogin), Times.Once);
            Assert.Equal(expectedUser, actualUser);
        }
    }
}
