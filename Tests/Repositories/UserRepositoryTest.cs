using Delivery.DAL.Repositories;
using Delivery.Domain.Entity;
using Npgsql;
using System.Threading.Tasks;
using Xunit;

namespace Delivery.Tests.Repositories
{
    public class UserRepositoryTests
    {
        private readonly string _connectionString;

        public UserRepositoryTests()
        {
            _connectionString = "Host=localhost;port=5432;Username=postgres;Password=998244353sql;Database=delivery";
        }

        [Fact]
        public async Task GetUserByName_ExistingUser_ReturnsUser()
        {
            // Arrange
            var userName = "testuser";

            // Act
            var user = await UserRepository.GetUserByName(userName);

            // Assert
            Xunit.Assert.NotNull(user);
            Xunit.Assert.IsType<User>(user);
            Xunit.Assert.Equal(userName, user.Name);
        }

        [Fact]
        public async Task GetUserByName_NonExistingUser_ReturnsNullUser()
        {
            // Arrange
            var userName = "nonexistinguser";

            // Act
            var user = await UserRepository.GetUserByName(userName);

            // Assert
            Xunit.Assert.NotNull(user);
            Xunit.Assert.IsType<User>(user);
            Xunit.Assert.Equal(-1, user.Id);
            Xunit.Assert.Null(user.Name);
            Xunit.Assert.Null(user.Password);
            Xunit.Assert.Null(user.Role);
        }

        [Fact]
        public async Task Create_NewUser_ReturnsTrue()
        {
            // Arrange
            var newUser = new User
            {
                Name = "newuser",
                Password = "password",
                Role = "user",
                Adress = 123
            };

            // Act
            var result = await UserRepository.Create(newUser);

            // Assert
            Xunit.Assert.True(result);
        }

        [Fact]
        public async Task Create_ExistingUser_ReturnsFalse()
        {
            // Arrange
            var existingUser = new User
            {
                Name = "existinguser",
                Password = "password",
                Role = "user",
                Adress = 123
            };

            // Act
            var result = await UserRepository.Create(existingUser);

            // Assert
            Xunit.Assert.False(result);
        }
    }
}
