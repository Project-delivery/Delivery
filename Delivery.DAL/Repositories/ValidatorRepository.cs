using Delivery.Domain.Entity;
using Npgsql;

namespace Delivery.DAL.Repositories;

public class ValidatorRepository : ApplicationDbContext
{
    
    public static async void Create(TempAdress adress)
    {
        await using var dataSource = new NpgsqlConnection(ConnectionString);
        dataSource.Open();
        await using var addСommand = new NpgsqlCommand("INSERT INTO temp_adress(region, district, city, street, house, worker_id, is_valid, comment) VALUES ((@p1), (@p2), (@p3), (@p4), (@p5), (@p6), (@p7), (@p8))",
            dataSource)
        {
            Parameters =
            {
                new("p1", adress.Region),
                new("p2", adress.District),
                new("p3", adress.City),
                new ("p4", adress.Street),
                new ("p5", adress.House),
                new ("p6", adress.Worker_id),
                new ("p7", adress.Is_valid),
                new ("p8", adress.Comment)
            }
        };
        await addСommand.ExecuteNonQueryAsync();
    }

    public static async void AddNewAdress(int Id_city, string Name, string StreetType)
    {
        await using var dataSource = new NpgsqlConnection(ConnectionString);
        dataSource.Open();
        await using var addCommand = new NpgsqlCommand(
            $"INSERT INTO streets (name, streettype, id_city) VALUES ((@p1), (@p2), (@p3))",
            dataSource)
        {
            Parameters =
            {
                new("p1", Name),
                new("p2", StreetType),
                new("p3", Id_city)
            }
        };
        await addCommand.ExecuteNonQueryAsync();
    }
    public static async Task<List<TempAdress>> GetAll(bool isValid = false)
    {
        await using var dataSource = new NpgsqlConnection(ConnectionString);
        dataSource.Open();

        await using var command = new NpgsqlCommand($"SELECT * FROM temp_adress WHERE is_valid = TRUE OR is_valid = (@p1)", dataSource)
        {
            Parameters =
            {
                new ("p1", isValid)
            }
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
                    Worker_id = reader.GetInt32(i+6),
                    Is_valid = reader.GetBoolean(i+7),
                    Comment = reader.GetString(i+8)
                }
            );
        }
        return res;
    }

    public static async Task<Street> GetStreetByName(int idCity, string name, string streetType)
    {
        await using var dataSource = new NpgsqlConnection(ConnectionString);
        dataSource.Open();

        await using var command = new NpgsqlCommand($"SELECT * FROM streets WHERE id_city = (@p1) AND name = (@p2), AND streettype = (@p3)", dataSource)
        {
            Parameters =
            {
                new ("p1", idCity),
                new ("p2", name),
                new ("p3", streetType)
            }
        };
        await using var reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            var res = new Street()
            {
                Id = reader.GetInt32(0),
                
                Name = name,
                StreetType = streetType,
                Id_city = idCity
            };
            await reader.DisposeAsync();
            await dataSource.DisposeAsync();
            return res;
        }
        else
        { 
            await reader.DisposeAsync();
            await dataSource.DisposeAsync();
            return new Street() { Id = -1, Name = null, StreetType = null, Id_city = -1};
        }
    }
}