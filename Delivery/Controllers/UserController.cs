using Delivery.DAL.Interfaces;
using Delivery.DAL.Repositories;
using Delivery.Domain.Entity;
using Delivery.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var response = await _userService.GetUserByName("admin");
        return View(new List<User> () { response.Data });
    }
}