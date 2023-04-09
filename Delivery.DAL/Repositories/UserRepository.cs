using Delivery.Domain.Entity;
using Npgsql;

namespace Delivery.DAL.Repositories;

public class UserRepository
{
    private static readonly string ConnectionString = "Host=localhost;port=5432;Username=admin;Password=admin;Database=practice";

    public static async Task<User> GetUserByName(string name)
    {
        await using var dataSource = new NpgsqlConnection(ConnectionString);
        dataSource.Open();
        
        await using var command = new NpgsqlCommand($"SELECT * FROM users WHERE login = (@p1)", dataSource)
        {
            Parameters =
            {
                new("p1", name)
            }
        };
        await using var reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            var res = new User()
            {
                Id = reader.GetInt32(0),
                
                Name = name,
                Password = reader.GetString(2),
                Role = reader.GetString(3)
            };
            await reader.DisposeAsync();
            await dataSource.DisposeAsync();
            return res;
        }
        else
        { 
            await reader.DisposeAsync();
            await dataSource.DisposeAsync();
            return new User() { Id = -1, Name = null, Password = null, Role = null };
        }
    }

    public static async Task<bool> Create(User user)
    {
        await using var dataSource = new NpgsqlConnection(ConnectionString);
        dataSource.Open();
        await using var command = new NpgsqlCommand($"SELECT * FROM users WHERE login = (@p1)", dataSource)
        {
            Parameters =
            {
                new("p1", user.Name)
            }
        };
        await using var reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            return false;
        }
        await reader.DisposeAsync();
        await using var addСommand = new NpgsqlCommand("INSERT INTO users(login, password, role) VALUES ((@p1), (@p2), (@p3))",
            dataSource)
        {
            Parameters =
            {
                new("p1", user.Name),
                new("p2", user.Password),
                new("p3", user.Role)
            }
        };
        await addСommand.ExecuteNonQueryAsync();
        return true;
    }
    
}