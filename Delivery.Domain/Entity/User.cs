using System.ComponentModel.DataAnnotations.Schema;
using Delivery.Domain.Enum;

namespace Delivery.Domain.Entity;
[Table("users")]
public class User
{
    public int Id { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
}

