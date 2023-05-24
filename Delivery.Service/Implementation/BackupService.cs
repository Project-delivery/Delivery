using Delivery.DAL.Repositories;
using Delivery.Domain.Entity;
using Delivery.Domain.Entity.BackupEntity;
using Delivery.Domain.Response;

namespace Delivery.Service.Implementation;

public class BackupService
{
    public static async Task<List<RegionBackup>?> AdressBackup()
    {
        List<RegionBackup?> Backup = new List<RegionBackup?>();
        List<Region?> Regions = new List<Region?>();
        Regions = await AdressRepository.GetRegions();
        foreach (var region in Regions)
        {
            Console.WriteLine(region.Name);
            int RegionId = region.Id;
            List<DistrictBackup?> districtsList = new List<DistrictBackup?>();
            List<District?> Districts = new List<District?>();
            Districts = await AdressRepository.GetDistrictByRegion(RegionId);
            foreach (var district in Districts)
            {
                //Console.WriteLine(district.Name);
                int DistrictId = district.Id;
                List<CityBackup?> citiesList = new List<CityBackup?>();
                List<City?> Cities = new List<City?>();
                Cities = await AdressRepository.GetCitiesByDistrict(DistrictId);
                foreach (var city in Cities)
                {
                    //Console.WriteLine(city.Name);
                    int CitiId = city.Id;
                    List<StreetBackup?> streetList = new List<StreetBackup?>();
                    List<Street?> Streets = new List<Street?>();
                    Streets = await AdressRepository.GetStreetsByCity(CitiId);
                    foreach (var street in Streets)
                    {
                        //Console.WriteLine(street.Name);
                        int StreetId = street.Id;
                        List<HomeBackup?> housesList = new List<HomeBackup?>();
                        List<Adress?> Houses = new List<Adress?>();
                        Houses = await AdressRepository.GetHouseByStreet(StreetId);
                        foreach (var house in Houses)
                        {
                            //Console.WriteLine(house.NumberHouse);
                            housesList.Add(new HomeBackup()
                            {
                                num_house = house.NumberHouse,
                                deputat_id = house.DeputatId
                            });
                        }
                        streetList.Add(new StreetBackup()
                        {
                            homesList = housesList,
                            name = street.Name,
                            streettype = street.StreetType
                        });
                    }
                    citiesList.Add(new CityBackup()
                    {
                        categoryName = city.CategoryName,
                        deputatId = city.DeputatId,
                        name = city.Name,
                        streetsList = streetList
                    });
                }
                districtsList.Add(new DistrictBackup()
                {
                    citiesList = citiesList,
                    name = district.Name
                });
            }
            Backup.Add(new RegionBackup()
            {
                name = region.Name,
                districtsList = districtsList,
            });
        }
        Console.WriteLine("All is right");
        return Backup;
    }
}