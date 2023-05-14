using Delivery.DAL.Repositories;
using Delivery.Domain.Entity;
using Delivery.Domain.Enum;
using Delivery.Domain.Response;
using Delivery.Service.Implementation;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Implementation
{
    public class AdressServiceTests
    {
        [Fact]
        public async Task GetDistrictByRegion_ExistingRegion_ReturnsSuccessResponseWithData()
        {
            // Arrange
            int region = 1;

            // Act
            var response = await AdressService.GetDistrictByRegion(region);

            // Assert
            Xunit.Assert.NotNull(response);
            Xunit.Assert.IsType<BaseResponse<List<District>>>(response);
            Xunit.Assert.Equal(StatusCode.OK, response.StatusCode);
            Xunit.Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetDistrictByRegion_NonExistingRegion_ReturnsSuccessResponseWithoutData()
        {
            // Arrange
            int region = 99;

            // Act
            var response = await AdressService.GetDistrictByRegion(region);

            // Assert
            Xunit.Assert.NotNull(response);
            Xunit.Assert.IsType<BaseResponse<List<District>>>(response);
            Xunit.Assert.Equal(StatusCode.OK, response.StatusCode);
            Xunit.Assert.Null(response.Data);
        }

        [Fact]
        public async Task GetCitiesByDistrict_ExistingDistrict_ReturnsSuccessResponseWithData()
        {
            // Arrange
            int district = 1;

            // Act
            var response = await AdressService.GetCitiesByDistrict(district);

            // Assert
            Xunit.Assert.NotNull(response);
            Xunit.Assert.IsType<BaseResponse<List<City>>>(response);
            Xunit.Assert.Equal(StatusCode.OK, response.StatusCode);
            Xunit.Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetCitiesByDistrict_NonExistingDistrict_ReturnsSuccessResponseWithoutData()
        {
            // Arrange
            int district = 99;

            // Act
            var response = await AdressService.GetCitiesByDistrict(district);

            // Assert
            Xunit.Assert.NotNull(response);
            Xunit.Assert.IsType<BaseResponse<List<City>>>(response);
            Xunit.Assert.Equal(StatusCode.OK, response.StatusCode);
            Xunit.Assert.Null(response.Data);
        }

        [Fact]
        public async Task GetStreetsByCity_ExistingCity_ReturnsSuccessResponseWithData()
        {
            // Arrange
            int city = 1;

            // Act
            var response = await AdressService.GetStreetsByCity(city);

            // Assert
            Xunit.Assert.NotNull(response);
            Xunit.Assert.IsType<BaseResponse<List<Street>>>(response);
            Xunit.Assert.Equal(StatusCode.OK, response.StatusCode);
            Xunit.Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetStreetsByCity_NonExistingCity_ReturnsSuccessResponseWithoutData()
        {
            // Arrange
            int city = 99;

            // Act
            var response = await AdressService.GetStreetsByCity(city);

            // Assert
            Xunit.Assert.NotNull(response);
            Xunit.Assert.IsType<BaseResponse<List<Street>>>(response);
            Xunit.Assert.Equal(StatusCode.OK, response.StatusCode);
            Xunit.Assert.Null(response.Data);
        }

        [Fact]
        public async Task GetHouseByStreet_ExistingStreet_ReturnsSuccessResponseWithData()
        {
            // Arrange
            int street = 1;

            // Act
            var response = await AdressService.GetHouseByStreet(street);

            // Assert
            Xunit.Assert.NotNull(response);
            Xunit.Assert.IsType<BaseResponse<List<Adress>>>(response);
            Xunit.Assert.Equal(StatusCode.OK, response.StatusCode);
            Xunit.Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetHouseByStreet_NonExistingStreet_ReturnsSuccessResponseWithoutData()
        {
            // Arrange
            int street = 99;

            // Act
            var response = await AdressService.GetHouseByStreet(street);

            // Assert
            Xunit.Assert.NotNull(response);
            Xunit.Assert.IsType<BaseResponse<List<Adress>>>(response);
            Xunit.Assert.Equal(StatusCode.OK, response.StatusCode);
            Xunit.Assert.Null(response.Data);
        }

        [Fact]
        public async Task GetRegion_ReturnsSuccessResponseWithData()
        {
            // Act
            var response = await AdressService.GetRegion();

            // Assert
            Xunit.Assert.NotNull(response);
            Xunit.Assert.IsType<BaseResponse<List<Region>>>(response);
            Xunit.Assert.Equal(StatusCode.OK, response.StatusCode);
            Xunit.Assert.NotNull(response.Data);
        }
    }
}

