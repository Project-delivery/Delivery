namespace Delivery.Domain.Entity.BackupEntity;

public class DistrictBackup
{
    public string? name{ get; set; }
    public List<CityBackup>? citiesList{ get; set; }
}