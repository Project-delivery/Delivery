namespace Delivery.Domain.Entity;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CityCategory { get; set; }
    public string CategoryName { get; set; }
    public int Id_district { get; set; }
    public int DeputatId { get; set; }
}