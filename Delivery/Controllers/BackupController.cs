using Delivery.Service.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Controllers;

public class BackupController : Controller
{
    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> AdressBackup()
    {
        return Json(await BackupService.AdressBackup());
    }
}