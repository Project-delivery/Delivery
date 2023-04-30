using Delivery.Domain.Entity;
using Npgsql;

namespace Delivery.DAL.Repositories;

public class AdressRepository
{
    private static readonly string ConnectionString = "Host=localhost;port=5432;Username=postgres;Password=998244353sql;Database=test";

    private static async Task<Region> GetRegionByName(string name)
    {
        await using var dataSource = new NpgsqlConnection(ConnectionString);
        dataSource.Open();
        
        await using var command = new NpgsqlCommand($"SELECT * FROM regions WHERE name = (@p1)", dataSource)
        {
            Parameters =
            {
                new("p1", name)
            }
        };
        await using var reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            var res = new Region()
            {
                Id = reader.GetInt32(0),
                Name = name
            };
            await reader.DisposeAsync();
            await dataSource.DisposeAsync();
            return res;
        }
        else
        { 
            await reader.DisposeAsync();
            await dataSource.DisposeAsync();
            return new Region() { Id = -1, Name = null };
        }
    }
    
    public static async Task<List<District> > GetDistrictByRegion(string region)
    {
        await using var dataSource = new NpgsqlConnection(ConnectionString);
        dataSource.Open();

        Region _region = await GetRegionByName(region);
        
        await using var command = new NpgsqlCommand($"SELECT * FROM districts WHERE id_regions = (@p1)", dataSource)
        {
            Parameters =
            {
                new("p1", _region.Id)
            }
        };
        await using var reader = await command.ExecuteReaderAsync();
        var res = new List<District>() { };
        int i = 0;
        while (await reader.ReadAsync())
        {
            res.Add(
                new District(){Id = reader.GetInt32(i), Name = reader.GetString(i+1), Id_regions = reader.GetInt32(i+2)}
                );
        }
        return res;
    }

}