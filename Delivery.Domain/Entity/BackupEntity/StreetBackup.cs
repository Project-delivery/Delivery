namespace Delivery.Domain.Entity.BackupEntity;

public class StreetBackup
{
    public string? name{ get; set; }
    public string? streettype{ get; set; }
    public List<HomeBackup>? homesList{ get; set; }
}