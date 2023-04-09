using Delivery.DAL.Repositories;
using Delivery.Domain.Entity;
using Delivery.Service.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Controllers;

public class UserController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    public async Task<IActionResult> ProfilePage(User User)
    {
        var _user = await UserService.GetUserByName(User.Name);
        if (_user.Data==null) return RedirectToAction("Login", "User");
        if (_user.Data.Password ==null) return RedirectToAction("Login", "User");
        if (_user.Data.Password != User.Password) return RedirectToAction("Login", "User");
        return View(_user.Data);
    }

    /*public IActionResult Register()
    {
        return View();
    }*/
}