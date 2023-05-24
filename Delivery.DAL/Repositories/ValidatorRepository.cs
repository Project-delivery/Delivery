using Delivery.Domain.Entity;
using Npgsql;

namespace Delivery.DAL.Repositories;

public class ValidatorRepository : ApplicationDbContext
{
    
    
    public static async void Create(TempAdress adress)
    {
        await using var dataSource = new NpgsqlConnection(ConnectionString);
        dataSource.Open();
        await using var addСommand = new NpgsqlCommand("INSERT INTO temp_adress(region, district, city, street, house, street_id, is_valid, comment) VALUES ((@p1), (@p2), (@p3), (@p4), (@p5), (@p6), (@p7), (@p8))",
            dataSource)
        {
            Parameters =
            {
                new("p1", adress.Region),
                new("p2", adress.District),
                new("p3", adress.City),
                new ("p4", adress.Street),
                new ("p5", adress.House),
                new ("p6", adress.Street_id),
                new ("p7", adress.Is_valid),
                new ("p8", adress.Comment)
            }
        };
        await addСommand.ExecuteNonQueryAsync();
    }

    public static async void AddNewAdress(int Id_street, string Name)
    {
        await using var dataSource = new NpgsqlConnection(ConnectionString);
        dataSource.Open();
        await using var addCommand = new NpgsqlCommand(
            $"INSERT INTO adress (num_house, id_street) VALUES ((@p1), (@p2))",
            dataSource)
        {
            Parameters =
            {
                new("p1", Name),
                new("p2", Id_street)
            }
        };
        await addCommand.ExecuteNonQueryAsync();
    }
    public static async Task<List<TempAdress>> GetAll()
    {
        await using var dataSource = new NpgsqlConnection(ConnectionString);
        dataSource.Open();

        await using var command = new NpgsqlCommand($"SELECT * FROM temp_adress WHERE is_valid = FALSE", dataSource)
        {
        };
        await using var reader = await command.ExecuteReaderAsync();
        var res = new List<TempAdress>() { };
        int i = 0;
        while (await reader.ReadAsync())
        {
            
            res.Add(
                new TempAdress()
                {
                    Id = reader.GetInt32(i),
                    Region = reader.GetString(i+1),
                    District = reader.GetString(i+2),
                    City = reader.GetString(i+3),
                    Street = reader.GetString(i+4),
                    House = reader.GetString(i+5),
                    Is_valid = reader.GetBoolean(i+6),
                    Comment = reader.GetString(i+7),
                    Street_id = reader.GetInt32(i+8)
                }
            );
        }
        return res;
    }
    
    public static async void Remove(int id)
    {
        await using var dataSource = new NpgsqlConnection(ConnectionString);
        dataSource.Open();

        await using var command = new NpgsqlCommand($"DELETE FROM temp_adress WHERE id = (@p1)", dataSource)
        {
            Parameters =
            {
                new ("p1", id)
            }
        };
        int reader = await command.ExecuteNonQueryAsync();
        return;
    }

    public static async Task<Adress> GetHouseByName(int idStreet, string name)
    {
        await using var dataSource = new NpgsqlConnection(ConnectionString);
        dataSource.Open();

        await using var command = new NpgsqlCommand($"SELECT * FROM adress WHERE id_street = (@p1) AND name = (@p2)", dataSource)
        {
            Parameters =
            {
                new ("p1", idStreet),
                new ("p2", name)
            }
        };
        await using var reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            var res = new Adress()
            {
                Id = reader.GetInt32(0),
                
                NumberHouse = name,
                Id_Street = idStreet
            };
            await reader.DisposeAsync();
            await dataSource.DisposeAsync();
            return res;
        }
        else
        { 
            await reader.DisposeAsync();
            await dataSource.DisposeAsync();
            return new Adress() { Id = -1, NumberHouse = null, Id_Street = -1};
        }
    }
}