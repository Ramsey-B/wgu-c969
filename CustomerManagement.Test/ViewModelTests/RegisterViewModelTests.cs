using AutoFixture;
using CustomerManagement.Core.Exceptions;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.ViewModels;
using CustomerManagement.Logging;
using Moq;
using Xunit;

namespace CustomerManagement.Tests.FormViewModelsTests
{
    public class RegisterViewModelTests
    {
        [Fact]
        public void ShouldPreventEmptyUsername()
        {
            var expectedMsg = "This is some error";
            var translatorMock = new Mock<ITranslator>();
            translatorMock.Setup(m => m.Translate("register.usernameError", It.IsAny<object>())).Returns(expectedMsg);

            var contextMock = new Mock<IContext>();
            contextMock.Setup(m => m.GetService<ITranslator>()).Returns(translatorMock.Object);

            var model = new RegisterViewModel(contextMock.Object);

            var ex = Assert.ThrowsAsync<PublicException>(() => model.Register(new User { Username = "abc" }, "")).Result;
            Assert.Equal("invalid-username", ex.Id);
            Assert.Equal(expectedMsg, ex.Message);
        }

        [Fact]
        public void ShouldPreventDuplicateUsername()
        {
            var expectedMsg = "This is some error";
            var newUser = new User { Username = "test" };

            var translatorMock = new Mock<ITranslator>();
            translatorMock.Setup(m => m.Translate("register.usernameTakenError", It.IsAny<object>())).Returns(expectedMsg);

            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock.Setup(m => m.CheckUsernameExists(newUser.Username)).ReturnsAsync(true);

            var contextMock = new Mock<IContext>();
            contextMock.Setup(m => m.GetService<ITranslator>()).Returns(translatorMock.Object);
            contextMock.Setup(m => m.GetService<IUserRepository>()).Returns(userRepoMock.Object);

            var model = new RegisterViewModel(contextMock.Object);

            var ex = Assert.ThrowsAsync<PublicException>(() => model.Register(newUser, "")).Result;
            Assert.Equal("invalid-username", ex.Id);
            Assert.Equal(expectedMsg, ex.Message);
        }

        [Theory]
        [InlineData("short")] // too short
        [InlineData("password")] // no numbers
        [InlineData("password1")] // no capitals
        [InlineData("PASSWORD1")] // no lower case
        [InlineData("Password1")] // no special char
        public void ShouldPreventInvalidPasswords(string password)
        {
            var expectedMsg = "This is some error";
            var newUser = new User { Username = "test", Password = password };

            var translatorMock = new Mock<ITranslator>();
            translatorMock.Setup(m => m.Translate("register.passwordError", It.IsAny<object>())).Returns(expectedMsg);

            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock.Setup(m => m.CheckUsernameExists(newUser.Username)).ReturnsAsync(false);

            var contextMock = new Mock<IContext>();
            contextMock.Setup(m => m.GetService<ITranslator>()).Returns(translatorMock.Object);
            contextMock.Setup(m => m.GetService<IUserRepository>()).Returns(userRepoMock.Object);

            var model = new RegisterViewModel(contextMock.Object);

            var ex = Assert.ThrowsAsync<PublicException>(() => model.Register(newUser, "")).Result;
            Assert.Equal("invalid-password", ex.Id);
            Assert.Equal(expectedMsg, ex.Message);
        }

        [Fact]
        public void ShouldPreventNoMatchingPassword()
        {
            var expectedMsg = "This is some error";
            var newUser = new User { Username = "test", Password = "Passw0rd!" };

            var translatorMock = new Mock<ITranslator>();
            translatorMock.Setup(m => m.Translate("register.confirmPasswordError", It.IsAny<object>())).Returns(expectedMsg);

            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock.Setup(m => m.CheckUsernameExists(newUser.Username)).ReturnsAsync(false);

            var contextMock = new Mock<IContext>();
            contextMock.Setup(m => m.GetService<ITranslator>()).Returns(translatorMock.Object);
            contextMock.Setup(m => m.GetService<IUserRepository>()).Returns(userRepoMock.Object);

            var model = new RegisterViewModel(contextMock.Object);

            var ex = Assert.ThrowsAsync<PublicException>(() => model.Register(newUser, "doesnt match")).Result;
            Assert.Equal("invalid-password", ex.Id);
            Assert.Equal(expectedMsg, ex.Message);
        }

        [Fact]
        public void ShouldHandleUnexpectedErrors()
        {
            var expectedMsg = "This is some error";
            var newUser = new User { Username = "test", Password = "Passw0rd!" };

            var translatorMock = new Mock<ITranslator>();
            translatorMock.Setup(m => m.Translate("unexpectedError", It.IsAny<object>())).Returns(expectedMsg);

            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock.Setup(m => m.CheckUsernameExists(newUser.Username)).ReturnsAsync(false);
            userRepoMock.Setup(m => m.CreateAsync(It.Is<User>(r => r.Username == newUser.Username && r.Password == newUser.Password && r.Active == true && r.CreatedBy == newUser.Username && r.LastUpdatedBy == newUser.Username))).Throws(new System.Exception());

            var contextMock = new Mock<IContext>();
            contextMock.Setup(m => m.GetService<ITranslator>()).Returns(translatorMock.Object);
            contextMock.Setup(m => m.GetService<IUserRepository>()).Returns(userRepoMock.Object);

            var model = new RegisterViewModel(contextMock.Object);

            var ex = Assert.ThrowsAsync<PublicException>(() => model.Register(newUser, newUser.Password)).Result;
            Assert.Equal("unxpected-error", ex.Id);
            Assert.Equal(expectedMsg, ex.Message);
        }

        [Fact]
        public void ShouldCreateAUser()
        {
            var newUser = new User { Username = "test", Password = "Passw0rd!" };
            var fixture = new Fixture();
            var expectedUser = fixture.Create<User>();
            User actualUser = null;

            var translatorMock = new Mock<ITranslator>();

            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock.Setup(m => m.CheckUsernameExists(newUser.Username)).ReturnsAsync(false);
            userRepoMock.Setup(m => m.CreateAsync(It.Is<User>(r => r.Username == newUser.Username && r.Password == newUser.Password && r.Active == true && r.CreatedBy == newUser.Username && r.LastUpdatedBy == newUser.Username))).ReturnsAsync(expectedUser).Verifiable();

            var contextMock = new Mock<IContext>();
            contextMock.Setup(m => m.GetService<ILogger>()).Returns(new Logger());
            contextMock.Setup(m => m.GetService<ITranslator>()).Returns(translatorMock.Object);
            contextMock.Setup(m => m.GetService<IUserRepository>()).Returns(userRepoMock.Object);
            contextMock.SetupSet(p => p.CurrentUser = It.IsAny<User>()).Callback<User>(v => actualUser = v);

            var model = new RegisterViewModel(contextMock.Object);

            model.Register(newUser, newUser.Password).Wait();

            userRepoMock.Verify(m => m.CreateAsync(It.Is<User>(r => r.Username == newUser.Username && r.Password == newUser.Password && r.Active == true && r.CreatedBy == newUser.Username && r.LastUpdatedBy == newUser.Username)), Times.Once);
            Assert.Equal(expectedUser, actualUser);
        }
    }
}
