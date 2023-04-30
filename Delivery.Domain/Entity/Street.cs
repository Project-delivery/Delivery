using System.ComponentModel.DataAnnotations.Schema;

namespace Delivery.Domain.Entity;

public class Street
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string StreetType { get; set; }
    public int Id_city { get; set; }
}