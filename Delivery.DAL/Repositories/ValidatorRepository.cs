using Delivery.Domain.Entity;
using Npgsql;

namespace Delivery.DAL.Repositories;

public class ValidatorRepository : ApplicationDbContext
{
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
}