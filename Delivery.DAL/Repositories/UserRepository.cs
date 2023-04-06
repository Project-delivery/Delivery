using Delivery.DAL.Interfaces;
using Delivery.Domain.Entity;
using Delivery.Domain.Enum;
using System.Collections.Generic;

namespace Delivery.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private List<User> _users = new List<User>()
    {
        new User() { Id = 0, Name = "admin", Password = "1234", Role = Role.Admin },
        new User() { Id = 1, Name = "validator", Password = "1234", Role = Role.Validator },
        new User() { Id = 2, Name = "worker", Password = "1234", Role = Role.Worker }
    };
    User IUserRepository.GetUserByName(string name)
    {
        return _users.Where(user => user.Name == name).FirstOrDefault();
    }

    User IUserRepository.Get(int id)
    {
        return _users.Where(user => user.Id == id).FirstOrDefault();
    }
    List<User> IUserRepository.Select()
    {
        return _users;
    }
}