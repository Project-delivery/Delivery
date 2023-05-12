using Delivery.Domain.Entity;
using Npgsql;

namespace Delivery.DAL.Repositories;

public class AdressRepository
{
    private static readonly string ConnectionString = "Host=localhost;port=5432;Username=postgres;Password=998244353sql;Database=test";

    /*private static async Task<Region> GetRegionByName(string name)
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
    
    private static async Task<District> GetDistrictByName(string name)
    {
        await using var dataSource = new NpgsqlConnection(ConnectionString);
        dataSource.Open();
        
        await using var command = new NpgsqlCommand($"SELECT * FROM districts WHERE name = (@p1)", dataSource)
        {
            Parameters =
            {
                new("p1", name)
            }
        };
        await using var reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            var res = new District()
            {
                Id = reader.GetInt32(0),
                Name = name,
                Id_regions = reader.GetInt32(2)
            };
            await reader.DisposeAsync();
            await dataSource.DisposeAsync();
            return res;
        }
        else
        { 
            await reader.DisposeAsync();
            await dataSource.DisposeAsync();
            return new District() { Id = -1, Name = null, Id_regions = -1};
        }
    }
    
    private static async Task<City> GetCityByName(string name)
    {
        await using var dataSource = new NpgsqlConnection(ConnectionString);
        dataSource.Open();
        
        await using var command = new NpgsqlCommand($"SELECT * FROM cities WHERE name = (@p1)", dataSource)
        {
            Parameters =
            {
                new("p1", name)
            }
        };
        await using var reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            var res = new City()
            {
                Id = reader.GetInt32(0),
                Name = name,
                CategoryName = reader.GetString(3),
                Id_district = reader.GetInt32(4),
                DeputatId = reader.GetString(5)
            };
            await reader.DisposeAsync();
            await dataSource.DisposeAsync();
            return res;
        }
        else
        { 
            await reader.DisposeAsync();
            await dataSource.DisposeAsync();
            return new City() { Id = -1, Name = null, Id_district = -1};
        }
    }*/
    
    public static async Task<List<District> > GetDistrictByRegion(int region)
    {
        await using var dataSource = new NpgsqlConnection(ConnectionString);
        dataSource.Open();

        //Region _region = await GetRegionByName(region);
        
        await using var command = new NpgsqlCommand($"SELECT * FROM districts WHERE id_regions = (@p1)", dataSource)
        {
            Parameters =
            {
                new("p1", region)
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

    public static async Task<List<City>> GetCitiesByDistrict(int district)
    {
        await using var dataSource = new NpgsqlConnection(ConnectionString);
        dataSource.Open();

        //District _district = await GetDistrictByName(district);
        
        await using var command = new NpgsqlCommand($"SELECT * FROM cities WHERE district_id = (@p1)", dataSource)
        {
            Parameters =
            {
                new("p1", district)
            }
        };
        await using var reader = await command.ExecuteReaderAsync();
        var res = new List<City>() { };
        int i = 0;
        while (await reader.ReadAsync())
        {
            
            res.Add(
                new City()
                {
                    Id = reader.GetInt32(i),
                    Name = reader.GetString(i+1)
                }
            );
        }
        return res;
    }
    
    public static async Task<List<Street>> GetStreetsByCity(int city)
    {
        await using var dataSource = new NpgsqlConnection(ConnectionString);
        dataSource.Open();

        //City _city = await GetCityByName(city);
        
        await using var command = new NpgsqlCommand($"SELECT * FROM streets WHERE id_city = (@p1)", dataSource)
        {
            Parameters =
            {
                new("p1", city)
            }
        };
        await using var reader = await command.ExecuteReaderAsync();
        var res = new List<Street>() { };
        int i = 0;
        while (await reader.ReadAsync())
        {
            
            res.Add(
                new Street()
                {
                    Id = reader.GetInt32(i),
                    Name = reader.GetString(i+1)
                }
            );
        }
        return res;
    }
    
    public static async Task<List<Adress>> GetHouseByStreet(int street)
    {
        await using var dataSource = new NpgsqlConnection(ConnectionString);
        dataSource.Open();

        //City _city = await GetCityByName(city);
        
        await using var command = new NpgsqlCommand($"SELECT * FROM adress WHERE id_street = (@p1)", dataSource)
        {
            Parameters =
            {
                new("p1", street)
            }
        };
        await using var reader = await command.ExecuteReaderAsync();
        var res = new List<Adress>() { };
        int i = 0;
        while (await reader.ReadAsync())
        {
            
            res.Add(
                new Adress()
                {
                    Id = reader.GetInt32(i),
                    NumberHouse = reader.GetString(i+1)
                }
            );
        }
        return res;
    }

    public static async Task<List<Region>> GetRegions()
    {
        await using var dataSource = new NpgsqlConnection(ConnectionString);
        dataSource.Open();

        await using var command = new NpgsqlCommand($"SELECT * FROM regions", dataSource);
        await using var reader = await command.ExecuteReaderAsync();
        var res = new List<Region>() { };
        int i = 0;
        while (await reader.ReadAsync())
        {
            
            res.Add(
                new Region()
                {
                    Id = reader.GetInt32(i),
                    Name = reader.GetString(i+1)
                }
            );
        }
        return res;
    }
}