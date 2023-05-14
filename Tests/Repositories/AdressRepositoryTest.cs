using Delivery.DAL.Repositories;
using Delivery.Domain.Entity;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Repositories
{
    public class AdressRepositoryTests
    {
        private readonly string _connectionString;

        public AdressRepositoryTests()
        {
            _connectionString = "Host=localhost;port=5432;Username=postgres;Password=998244353sql;Database=test";
        }

        [Fact]
        public async Task GetDistrictByRegion_ReturnsListOfDistricts()
        {
            // Arrange
            var regionId = 1;

            // Act
            var districts = await AdressRepository.GetDistrictByRegion(regionId);

            // Assert
            Xunit.Assert.NotNull(districts);
            Xunit.Assert.IsType<List<District>>(districts);
        }

        [Fact]
        public async Task GetCitiesByDistrict_ReturnsListOfCities()
        {
            // Arrange
            var districtId = 1;

            // Act
            var cities = await AdressRepository.GetCitiesByDistrict(districtId);

            // Assert
            Xunit.Assert.NotNull(cities);
            Xunit.Assert.IsType<List<City>>(cities);
        }

        [Fact]
        public async Task GetStreetsByCity_ReturnsListOfStreets()
        {
            // Arrange
            var cityId = 1;

            // Act
            var streets = await AdressRepository.GetStreetsByCity(cityId);

            // Assert
            Xunit.Assert.NotNull(streets);
            Xunit.Assert.IsType<List<Street>>(streets);
        }

        [Fact]
        public async Task GetHouseByStreet_ReturnsListOfAddresses()
        {
            // Arrange
            var streetId = 1;

            // Act
            var addresses = await AdressRepository.GetHouseByStreet(streetId);

            // Assert
            Xunit.Assert.NotNull(addresses);
            Xunit.Assert.IsType<List<Adress>>(addresses);
        }

        [Fact]
        public async Task GetRegions_ReturnsListOfRegions()
        {
            // Act
            var regions = await AdressRepository.GetRegions();

            // Assert
            Xunit.Assert.NotNull(regions);
            Xunit.Assert.IsType<List<Region>>(regions);
        }
    }
}

