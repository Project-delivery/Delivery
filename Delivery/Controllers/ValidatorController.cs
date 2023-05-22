using System.ComponentModel.DataAnnotations;
using Delivery.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Delivery.Domain;
using Delivery.Service.Implementation;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Delivery.Controllers;

public class ValidatorController : Controller
{
    [Authorize(Roles = "admin")]
    public async void Add(string region, string district, string city, string street, string house, int worker_id, bool is_valid, string comment)
    {
        ValidatorService.Create(region, district, city, street, house, worker_id, is_valid, comment);
    }
    
    [Authorize]
    public async Task<IActionResult> getAllTempAdresses(bool isValid = false)
    {
        var response = await ValidatorService.GetAll(isValid);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Json(response.Data);
        }
        return BadRequest(new {errorText="Invalid request"});
    }

    [Authorize]
    public async Task<IActionResult> AddNewAdress(int city_Id, string Name, string StreetType)
    {
        var response = await ValidatorService.AddNewAdress(city_Id, Name, StreetType);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Json("OK");
        }
        return Json(response.Description);
    }
    
}