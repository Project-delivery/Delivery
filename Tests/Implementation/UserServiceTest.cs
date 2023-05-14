using Xunit;
using Delivery.DAL.Repositories;
using Delivery.Domain.Entity;
using Delivery.Domain.Enum;
using Delivery.Domain.Response;
using Delivery.Service.Implementation;
using System.Threading.Tasks;

namespace Delivery.Service.Tests.Implementation
{
    public class UserServiceTests
    {
        [Fact]
        public async Task GetUserByName_ExistingUser_ReturnsSuccessResponseWithData()
        {
            // Arrange
            string name = "JohnDoe";

            // Act
            var response = await UserService.GetUserByName(name);

            // Assert
            Xunit.Assert.NotNull(response);
            Xunit.Assert.IsType<BaseResponse<User>>(response);
            Xunit.Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetUserByName_NonExistingUser_ReturnsSuccessResponseWithoutData()
        {
            // Arrange
            string name = "NonExistingUser";

            // Act
            var response = await UserService.GetUserByName(name);

            // Assert
            Xunit.Assert.NotNull(response);
            Xunit.Assert.IsType<BaseResponse<User>>(response);
            Xunit.Assert.Null(response.Data);
        }
    }
}
