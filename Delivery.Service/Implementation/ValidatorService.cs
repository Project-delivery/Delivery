using Delivery.DAL;
using Delivery.DAL.Repositories;
using Delivery.Domain.Entity;
using Delivery.Domain.Enum;
using Delivery.Domain.Response;

namespace Delivery.Service.Implementation;

public class ValidatorService
{

    public static async void Create(string region, string district, string city, string street, string house, int worker_id, bool is_valid, string comment)
    {
        TempAdress tempAdress = new TempAdress()
        {
            Region = region,
            District = district,
            City = city,
            Street = street,
            House = house,
            Worker_id = worker_id,
            Is_valid = is_valid,
            Comment = comment
        };
        ValidatorRepository.Create(tempAdress);
    }

    public static async Task<BaseResponse<string>> AddNewAdress(int Id_city, string Name)
    {
        try
        {
            var user = await ValidatorRepository.GetHouseByName(Id_city, Name);
            if (user.NumberHouse != null)
            {
                return new BaseResponse<string>()
                {
                    Description = "Такой дом уже есть",
                    StatusCode = StatusCode.InternalServerError
                };
            }

            ValidatorRepository.AddNewAdress(Id_city, Name);
            return new BaseResponse<string>()
            {
                Data = "OK",
                Description = "Оъект добавлен",
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<string>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
    
    public static async Task<BaseResponse<List<TempAdress>>> GetAll()
    {
        var baseResponse = new BaseResponse<List<TempAdress>>();
        try
        {
            var adresses = await ValidatorRepository.GetAll();
            if (adresses == null)
            {
                baseResponse.Description = "Нету временных адрессов";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }

            baseResponse.Data = adresses;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<TempAdress>>()
            {
                Description = $"[GetAll] : {ex.Message}"
            };
        }
    }
}