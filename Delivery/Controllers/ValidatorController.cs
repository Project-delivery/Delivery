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
    [Authorize(Roles = "admin")]
    public async void Add(string region, string district, string city, string street, string house, int worker_id, bool is_valid, string comment)
    {
        ValidatorService.Create(region, district, city, street, house, worker_id, is_valid, comment);
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

    [HttpGet]
    [Authorize(Roles = "validator")]
    public async Task<IActionResult> AddNewAdress(int StreetId, string Name, int Id)
    {
        var response = await ValidatorService.AddNewAdress(StreetId, Name);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            //ValidatorRepository.Remove(Id);
            return Json("OK");
        }
        return Json(response.Description);
    }
    
    
    
}