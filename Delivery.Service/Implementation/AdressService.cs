using System.Security.Claims;
using Delivery.DAL.Repositories;
using Delivery.Domain.Entity;
using Delivery.Domain.Enum;
using Delivery.Domain.Response;
using Delivery.Domain.ViewModel.Account;

namespace Delivery.Service.Implementation;

public class AdressService
{
    public static async Task<BaseResponse<List<District>>> GetDistrictByRegion(int _region)
    {
        var baseResponse = new BaseResponse<List<District>>();
        try
        {
            var districts = await AdressRepository.GetDistrictByRegion(_region);
            if (districts == null)
            {
                baseResponse.Description = "Районов не найдено";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }

            baseResponse.Data = districts;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<District>>()
            {
                Description = $"[GetDistrictByRegion] : {ex.Message}"
            };
        }
    }

    public static async Task<BaseResponse<List<City>>> GetCitiesByDistrict(int _district)
    {
        var baseResponse = new BaseResponse<List<City>>();
        try
        {
            var cities = await AdressRepository.GetCitiesByDistrict(_district);
            if (cities == null)
            {
                baseResponse.Description = "Городов не найдено";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }

            baseResponse.Data = cities;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<City>>()
            {
                Description = $"[GetCitiesByDistrict] : {ex.Message}"
            };
        }
    }
    
    public static async Task<BaseResponse<List<Street>>> GetStreetsByCity(int city)
    {
        var baseResponse = new BaseResponse<List<Street>>();
        try
        {
            var streets = await AdressRepository.GetStreetsByCity(city);
            if (streets == null)
            {
                baseResponse.Description = "Улиц не найдено";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }

            baseResponse.Data = streets;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<Street>>()
            {
                Description = $"[GetStreetsByCity] : {ex.Message}"
            };
        }
    }
    
    public static async Task<BaseResponse<List<Adress>>> GetHouseByStreet(int street)
    {
        var baseResponse = new BaseResponse<List<Adress>>();
        try
        {
            var houses = await AdressRepository.GetHouseByStreet(street);
            if (houses == null)
            {
                baseResponse.Description = "Домов не найдено";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }

            baseResponse.Data = houses;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<Adress>>()
            {
                Description = $"[GetStreetsByCity] : {ex.Message}"
            };
        }
    }

    public static async Task<BaseResponse<List<Region>>> GetRegion()
    {
        var baseResponse = new BaseResponse<List<Region>>();
        try
        {
            var regions = await AdressRepository.GetRegions();
            if (regions == null)
            {
                baseResponse.Description = "Регионов не найдено";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }

            baseResponse.Data = regions;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<Region>>()
            {
                Description = $"[GetRegions] : {ex.Message}"
            };
        }
    }
}