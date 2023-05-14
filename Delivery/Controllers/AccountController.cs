using System.IdentityModel.Tokens.Jwt;
using System.Net;
using Delivery.Domain.Entity;
using Delivery.Domain.jwt;
using Delivery.Domain.ViewModel.Account;
using Delivery.Service.Implementation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Delivery.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Authorize(Roles = "admin")]
    public IActionResult Register() => View();

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<bool> Register(string Login, string Password, string Role, string Adress)
    {

        int Id_Adress = Convert.ToInt32(Adress);
        var response = await AccountService.Register(Login, Password, Role, Id_Adress);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return true;
        }

        return false;
    }
    
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string Name, string Password)
    {
        if (ModelState.IsValid)
        {
            var response = await AccountService.Login(Name, Password);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                var now = DateTime.UtcNow;
                var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE, 
                    notBefore: now, 
                    claims: response.Data.Claims, 
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)), 
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
                var _response = new
                {
                    access_token = encodedJwt,
                    Name = response.Data.Name 
                };
                return Json(_response);
            }
        }
        return BadRequest(new {errorText="Invalid user name or password"});
    }

}