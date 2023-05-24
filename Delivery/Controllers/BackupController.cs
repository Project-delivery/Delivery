using Delivery.Service.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Controllers;

public class BackupController : Controller
{
    public async Task<IActionResult> AdressBackup()
    {
        return Json(await BackupService.AdressBackup());
    }
}