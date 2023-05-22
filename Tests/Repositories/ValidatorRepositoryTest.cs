using Xunit;
using Delivery.DAL.Repositories;
using Delivery.Domain.Entity;
using Npgsql;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Delivery.DAL.Tests.Repositories
{
    public class ValidatorRepositoryTests
    {
        private const string ConnectionString = "your_connection_string";

        [Fact]
        public async Task Create_ValidAddress_CreatesNewTempAddress()
        {
            // Arrange
            var address = new TempAdress
            {
                Region = "Region",
                District = "District",
                City = "City",
                Street = "Street",
                House = "House",
                Worker_id = 1,
                Is_valid = true,
                Comment = "Comment"
            };

            // Act
            ValidatorRepository.Create(address);

            // Assert
            var addresses = await GetAllTempAddresses();
            Xunit.Assert.Contains(addresses, a =>
                a.Region == address.Region &&
                a.District == address.District &&
                a.City == address.City &&
                a.Street == address.Street &&
                a.House == address.House &&
                a.Worker_id == address.Worker_id &&
                a.Is_valid == address.Is_valid &&
                a.Comment == address.Comment
            );
        }

        [Fact]
        public async Task AddNewAdress_ValidData_AddsNewStreet()
        {
            // Arrange
            var cityId = 1;
            var name = "StreetName";
            var streetType = "StreetType";

            // Act
            ValidatorRepository.AddNewAdress(cityId, name, streetType);

            // Assert
            var street = await GetStreetByName(cityId, name, streetType);
            Xunit.Assert.NotNull(street);
            Xunit.Assert.Equal(name, street.Name);
            Xunit.Assert.Equal(streetType, street.StreetType);
            Xunit.Assert.Equal(cityId, street.Id_city);
        }

        [Fact]
        public async Task GetAll_ValidFlag_ReturnsValidTempAddresses()
        {
            // Arrange
            var isValid = true;

            // Act
            var addresses = await ValidatorRepository.GetAll(isValid);

            // Assert
            Xunit.Assert.NotNull(addresses);
            Xunit.Assert.All(addresses, a => Xunit.Assert.True(a.Is_valid));
        }

        private async Task<List<TempAdress>> GetAllTempAddresses()
        {
            await using var connection = new NpgsqlConnection(ConnectionString);
            await connection.OpenAsync();

            var command = new NpgsqlCommand("SELECT * FROM temp_adress", connection);
            await using var reader = await command.ExecuteReaderAsync();

            var addresses = new List<TempAdress>();
            while (await reader.ReadAsync())
            {
                var address = new TempAdress
                {
                    Id = reader.GetInt32(0),
                    Region = reader.GetString(1),
                    District = reader.GetString(2),
                    City = reader.GetString(3),
                    Street = reader.GetString(4),
                    House = reader.GetString(5),
                    Worker_id = reader.GetInt32(6),
                    Is_valid = reader.GetBoolean(7),
                    Comment = reader.GetString(8)
                };
                addresses.Add(address);
            }

            return addresses;
        }

        private async Task<Street> GetStreetByName(int idCity, string name, string streetType)
        {
            await using var connection = new NpgsqlConnection(ConnectionString);
            await connection.OpenAsync();

            var command = new NpgsqlCommand("SELECT * FROM streets WHERE id_city = (@p1) AND name = (@p2) AND streettype = (@p3)", connection);
            command.Parameters.AddWithValue("p1", idCity);
            command.Parameters.AddWithValue("p2", name);
            command.Parameters.AddWithValue("p3", streetType);

            await using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                var street = new Street
                {
                    Id = reader.GetInt32(0),
                    Name = name,
                    StreetType = streetType,
                    Id_city = idCity
                };
                return street;
            }
            else
            {
                return null;
            }
        }
    }
}
