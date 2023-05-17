using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;
using System.Net;

namespace Tests.Controllers
{
    public class AccountControllerTest
    {
        private readonly ILogger<AccountController> _logger;
        private AccountController _accountController;

        public AccountControllerTest()
        {
            _logger = A.Fake<ILogger<AccountController>>();
            _accountController = new AccountController(_logger);
        }

        [Fact]
        public void Register_WithValidRole_ReturnsViewResult()
        {
            // Act
            var result = _accountController.Register();

            // Assert
            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public async Task Register_WithValidParameters_ReturnsTrue()
        {
            // Arrange
            var login = "testUser";
            var password = "testPassword";
            var role = "worker";
            var address = "123";

            // Act
            var result = await _accountController.Register(login, password, role, address);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task Register_WithInvalidParameters_ReturnsFalse()
        {
            // Arrange
            var login = "testUser";
            var password = "testPassword";
            var role = "admin";
            var address = "2134d1324d234"; // Invalid address format

            // Act
            var result = await _accountController.Register(login, password, role, address);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Login_ReturnsViewResult()
        {
            // Act
            var result = _accountController.Login();

            // Assert
            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public async Task Login_WithValidCredentials_ReturnsJsonResponse()
        {
            // Arrange
            var name = "admin";
            var password = "admin";

            // Act
            var result = await _accountController.Login(name, password) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            var response = result.Value as dynamic;
            response.access_token.Should().NotBeNull();
            response.Name.Should().Be(name);
        }

        [Fact]
        public async Task Login_WithInvalidCredentials_ReturnsBadRequest()
        {
            // Arrange
            var name = "testUser";
            var password = "invalidPassword";

            // Act
            var result = await _accountController.Login(name, password) as BadRequestObjectResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
        }
    }
}
