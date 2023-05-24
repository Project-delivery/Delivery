namespace Delivery.Domain.Entity.BackupEntity;

public class CityBackup
{
    public string? name{ get; set; }
    public string? categoryName{ get; set; }
    public string? deputatId{ get; set; }
    public List<StreetBackup>? streetsList{ get; set; }
}