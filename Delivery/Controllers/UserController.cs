using Delivery.DAL.Interfaces;
using Delivery.DAL.Repositories;
using Delivery.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Controllers;

public class UserController : Controller
{
    public UserController()
    {
        
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        
        return View();
    }
}