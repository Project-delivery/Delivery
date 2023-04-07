using Delivery.Domain.Entity;
using Delivery.Domain.Response;

namespace Delivery.Service.Interfaces;

public interface IUserService
{
    Task<IBaseResponse<IEnumerable<User>>> GetUsers();
    Task<IBaseResponse<User>> GetUserByName(string _name);
}