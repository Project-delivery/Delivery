using Delivery.DAL.Interfaces;
using Delivery.Domain.Entity;
using Delivery.Domain.Enum;
using Delivery.Domain.Response;
using Delivery.Service.Interfaces;

namespace Delivery.Service.Implementation;

public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IBaseResponse<IEnumerable<User>>> GetUsers()
    {
        var baseResponse = new BaseResponse<IEnumerable<User>>();
        try
        {
            var users = _userRepository.Select();
            if (users.Count() == 0)
            {
                baseResponse.Description = "Найдено 0 элементов";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }

            baseResponse.Data = users;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<IEnumerable<User>>()
            {
                Description = $"[GetUsers] : {ex.Message}"
            };
        }
    }

    public async Task<IBaseResponse<User>> GetUserByName(string _name)
    {
        var baseResponse = new BaseResponse<User>();
        try
        {
            var user = _userRepository.GetUserByName(_name);
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