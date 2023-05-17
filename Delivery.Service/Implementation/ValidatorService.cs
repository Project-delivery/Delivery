using Delivery.DAL;
using Delivery.DAL.Repositories;
using Delivery.Domain.Entity;
using Delivery.Domain.Enum;
using Delivery.Domain.Response;

namespace Delivery.Service.Implementation;

public class ValidatorService
{
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