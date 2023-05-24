using System.Net.Security;
using System.Security.Claims;
using Delivery.DAL.Repositories;
using Delivery.Domain.Entity;
using Delivery.Domain.Enum;
using Delivery.Domain.Response;
using Delivery.Domain.ViewModel.Account;

namespace Delivery.Service.Implementation;

public class AccountService
{
    public static async Task<BaseResponse<ClaimsIdentity>> Register(string Login, string Password, string Role, int Id_Adress)
    {
        try
        {
            var user = await UserRepository.GetUserByName(Login);
            if (user.Name != null)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = "Пользователь с таким именем уже есть",
                    StatusCode = StatusCode.InternalServerError
                };
            }

            user = new User()
            {
                Name = Login,
                Role = Role,
                Password = Password,
                Adress = Id_Adress
            };

            await UserRepository.Create(user);
            var result = Authenticate(user);
            return new BaseResponse<ClaimsIdentity>()
            {
                Data = result,
                Description = "Оъект добавлен",
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<ClaimsIdentity>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public static async Task<BaseResponse<ClaimsIdentity>> Login(string Name, string Password)
    {
        try
        {
            var user = await UserRepository.GetUserByName(Name);
            if (user == null)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = "Пользователь не найден"
                };
            }

            if (user.Password != Password)
            {
                return new BaseResponse<ClaimsIdentity>() 
                {
                    Description = "Неверный пароль"
                };
            }

            var result = Authenticate(user);
            return new BaseResponse<ClaimsIdentity>()
            {
                Data = result,
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<ClaimsIdentity>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    private static ClaimsIdentity Authenticate(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Role),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
        };
        return new (claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
    }
}