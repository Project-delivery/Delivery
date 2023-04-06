using Delivery.Domain.Entity;
using System.Collections.Generic;

namespace Delivery.DAL.Interfaces;
public interface IUserRepository
{
    User GetUserByName(string name);
    User Get(int id);
    List<User> Select();
    
}