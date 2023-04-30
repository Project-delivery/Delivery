using System.Security.Claims;
using Delivery.DAL.Repositories;
using Delivery.Domain.Entity;
using Delivery.Domain.Enum;
using Delivery.Domain.Response;
using Delivery.Domain.ViewModel.Account;

namespace Delivery.Service.Implementation;

public class AdressService
{
    public static async Task<BaseResponse<List<District>>> GetDistrictByRegion(string _region)
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
}