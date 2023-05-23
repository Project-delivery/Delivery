using Delivery.Models;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BackupController : ControllerBase
    {
        private readonly DatabaseBackup databaseBackup;

        public BackupController()
        {
            string connectionString = "сюда connection_string";
            databaseBackup = new DatabaseBackup(connectionString);
        }

        [HttpPost]
        public IActionResult CreateBackup()
        {
            string backupFilePath = "сюда куда сохранять";
            databaseBackup.BackupDatabase(backupFilePath);
            return Ok("Database backup created successfully.");
        }
    }
}
