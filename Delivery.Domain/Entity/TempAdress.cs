namespace Delivery.Domain.Entity;

public class TempAdress
{
    public int Id { get; set; }
    public string Region { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string House { get; set; }
    public int Worker_id { get; set; }
    public bool Is_valid { get; set; }
    public string Comment { get; set; }
}