using System.Net;
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
                return RedirectToAction("Login", "User");
            }
        }

        return RedirectToAction("Register", "Account");
    }
}