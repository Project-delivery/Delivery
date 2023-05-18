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

    public static async Task<BaseResponse<List<TempAdress>>> GetAll(bool isValid)
    {
        var baseResponse = new BaseResponse<List<TempAdress>>();
        try
        {
            var adresses = await ValidatorRepository.GetAll(isValid);
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