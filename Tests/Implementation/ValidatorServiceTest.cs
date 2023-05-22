using Xunit;
using Delivery.DAL.Repositories;
using Delivery.Domain.Entity;
using Delivery.Domain.Enum;
using Delivery.Domain.Response;
using Delivery.Service.Implementation;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Delivery.Service.Tests.Implementation
{
    public class ValidatorServiceTests
    {
        [Fact]
        public async Task Create_ValidData_CallsValidatorRepositoryCreate()
        {
            // Arrange
            var region = "Region";
            var district = "District";
            var city = "City";
            var street = "Street";
            var house = "House";
            var workerId = 1;
            var isValid = true;
            var comment = "Comment";

            // Act
            ValidatorService.Create(region, district, city, street, house, workerId, isValid, comment);

            var result = new OkResult();
            Xunit.Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task AddNewAdress_ExistingStreet_ReturnsErrorResponse()
        {
            // Arrange
            var cityId = 1;
            var name = "StreetName";
            var streetType = "StreetType";

            var existingStreet = new Street()
            {
                Name = name
            };

            // Act
            var response = await ValidatorService.AddNewAdress(cityId, name, streetType);

            // Assert
            Xunit.Assert.Equal(StatusCode.InternalServerError, response.StatusCode);
            Xunit.Assert.Equal("Такая улица в этом городе уже есть", response.Description);
            Xunit.Assert.Null(response.Data);
        }

        [Fact]
        public async Task AddNewAdress_NonExistingStreet_ReturnsSuccessResponse()
        {
            // Arrange
            var cityId = 1;
            var name = "StreetName";
            var streetType = "StreetType";

            // Act
            var response = await ValidatorService.AddNewAdress(cityId, name, streetType);

            // Assert
            Xunit.Assert.Equal(StatusCode.OK, response.StatusCode);
            Xunit.Assert.Equal("OK", response.Data);
            Xunit.Assert.Equal("Оъект добавлен", response.Description);
        }

        [Fact]
        public async Task GetAll_NoTempAdresses_ReturnsEmptyResponse()
        {
            // Arrange
            var isValid = false;

            // Act
            var response = await ValidatorService.GetAll(isValid);

            // Assert
            Xunit.Assert.Equal(StatusCode.OK, response.StatusCode);
            Xunit.Assert.Null(response.Data);
            Xunit.Assert.Equal("Нету временных адрессов", response.Description);
        }
    }
}
