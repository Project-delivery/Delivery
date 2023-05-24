using System.ComponentModel.DataAnnotations;
using Delivery.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Delivery.Domain;
using Delivery.Service.Implementation;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.IdentityModel.Tokens;

namespace Delivery.Controllers;

public class ValidatorController : Controller
{
    [HttpPost]
    [Authorize]
    public async void Add(string region, string district, string city, string street, string house, string street_id, string is_valid, string comment, string OldId = "-")
    {
        comment = comment ?? "";
        ValidatorService.Create(region, district, city, street, house, Convert.ToInt32(street_id), Convert.ToBoolean(is_valid), comment, OldId);
    }
    
    [HttpGet]
    //[Authorize]
    public async Task<IActionResult> getAllTempAdresses()
    {
        var response = await ValidatorService.GetAll();
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Json(response.Data);
        }
        return BadRequest(new {errorText="Invalid request"});
    }

    [HttpPost]
    [Authorize(Roles = "validator")]
    public async Task<IActionResult> AddNewAdress(string Id_street, string Name, string Id)
    {
        Console.WriteLine(Id_street);
        Console.WriteLine(Name);
        Console.WriteLine(Id);
        var response = await ValidatorService.AddNewAdress(Convert.ToInt32(Id_street), Name, Convert.ToInt32(Id));
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            //ValidatorRepository.Remove(Id);
            return Json("OK");
        }
        return Json(response.Description);
    }
    
    
    
}