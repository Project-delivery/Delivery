using Delivery.DAL.Repositories;
using Delivery.Domain.Entity;
using Delivery.Domain.Enum;
using Delivery.Domain.Response;

namespace Delivery.Service.Implementation;

public class UserService 
{
    public static async Task<IBaseResponse<User>> GetUserByName(string _name)
    {
        var baseResponse = new BaseResponse<User>();
        try
        {
            var user = await UserRepository.GetUserByName(_name);
            if (user == null)
            {
                baseResponse.Description = "Пользователь не найден";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }

            baseResponse.Data = user;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<User>()
            {
                Description = $"[GetUserByName] : {ex.Message}"
            };
        }
    }
}