using System.Security.Claims;
using Delivery.Domain.Entity;
using Delivery.Domain.Enum;
using Delivery.Service.Implementation;
using Microsoft.AspNetCore.Authorization;
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


    private ClaimsIdentity Authenticate(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Role)
        };
        return new ClaimsIdentity(claims, "");
    }
}