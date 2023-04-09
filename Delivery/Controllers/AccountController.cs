using System.Net;
using Delivery.Domain.Entity;
using Delivery.Domain.ViewModel.Account;
using Delivery.Service.Implementation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var response = await AccountService.Register(model);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("Login", "Account");
            }
        }

        return RedirectToAction("Register", "Account");
    }
    
    public IActionResult Login()
    {
        return View();
    }

    public async Task<IActionResult> ProfilePage(User User)
    {
        var _user = await UserService.GetUserByName(User.Name);
        if (_user.Data==null) return RedirectToAction("Login", "Account");
        if (_user.Data.Password ==null) return RedirectToAction("Login", "Account");
        if (_user.Data.Password != User.Password) return RedirectToAction("Login", "Account");
        return View(_user.Data);
    }

}