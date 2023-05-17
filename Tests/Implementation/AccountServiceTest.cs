using Delivery.DAL.Repositories;
using Delivery.Domain.Entity;
using Delivery.Domain.Enum;
using Delivery.Domain.Response;
using Delivery.Domain.ViewModel.Account;
using Delivery.Service.Implementation;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Implementation
{
    public class AccountServiceTests
    {
        [Fact]
        public async Task Register_NewUser_ReturnsSuccessResponse()
        {
            // Arrange
            var login = "newuser";
            var password = "password";
            var role = "user";
            var idAdress = 1;

            // Act
            var response = await AccountService.Register(login, password, role, idAdress);

            // Assert
            Xunit.Assert.NotNull(response);
            Xunit.Assert.IsType<BaseResponse<ClaimsIdentity>>(response);
            Xunit.Assert.Equal(StatusCode.OK, response.StatusCode);
            Xunit.Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task Register_ExistingUser_ReturnsErrorResponse()
        {
            // Arrange
            var existingUser = new User
            {
                Name = "existinguser",
                Password = "password",
                Role = "user",
                Adress = 2
            };

            // Act
            var response = await AccountService.Register(existingUser.Name, existingUser.Password, existingUser.Role, existingUser.Adress);

            // Assert
            Xunit.Assert.NotNull(response);
            Xunit.Assert.IsType<BaseResponse<ClaimsIdentity>>(response);
            Xunit.Assert.Equal(StatusCode.InternalServerError, response.StatusCode);
            Xunit.Assert.NotNull(response.Description);
        }

        [Fact]
        public async Task Login_ExistingUserWithCorrectPassword_ReturnsSuccessResponse()
        {
            // Arrange
            var existingUser = new User
            {
                Name = "existinguser",
                Password = "password",
                Role = "user",
                Adress = 2
            };

            // Act
            var response = await AccountService.Login(existingUser.Name, existingUser.Password);

            // Assert
            Xunit.Assert.NotNull(response);
            Xunit.Assert.IsType<BaseResponse<ClaimsIdentity>>(response);
            Xunit.Assert.Equal(StatusCode.OK, response.StatusCode);
            Xunit.Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task Login_NonExistingUser_ReturnsNotFoundResponse()
        {
            // Arrange
            var nonExistingUser = "nonexistinguser";

            // Act
            var response = await AccountService.Login(nonExistingUser, "password");

            // Assert
            Xunit.Assert.NotNull(response);
            Xunit.Assert.IsType<BaseResponse<ClaimsIdentity>>(response);
            Xunit.Assert.Equal(StatusCode.InternalServerError, response.StatusCode);
            Xunit.Assert.NotNull(response.Description);
        }

        [Fact]
        public async Task Login_ExistingUserWithIncorrectPassword_ReturnsErrorResponse()
        {
            // Arrange
            var existingUser = new User
            {
                Name = "existinguser",
                Password = "password",
                Role = "user",
                Adress = 2
            };

            // Act
            var response = await AccountService.Login(existingUser.Name, "incorrectpassword");

            // Assert
            Xunit.Assert.NotNull(response);
            Xunit.Assert.IsType<BaseResponse<ClaimsIdentity>>(response);
            Xunit.Assert.Equal(StatusCode.InternalServerError, response.StatusCode);
            Xunit.Assert.NotNull(response.Description);
        }
    }
}
