namespace Delivery.Domain.Entity.BackupEntity;

public class RegionBackup
{
    public string? name { get; set; }
    public List<DistrictBackup>? districtsList { get; set; }
}