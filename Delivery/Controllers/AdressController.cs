using Microsoft.AspNetCore.Mvc;
using Delivery.Domain;
using Delivery.Service.Implementation;
using Microsoft.AspNetCore.Authorization;


namespace Delivery.Controllers;

public class AdressController : Controller
{
    //[Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> GetDistrictsByName(int Name)
    {
        var response = await AdressService.GetDistrictByRegion(Name);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Json(response.Data);
        }
        return BadRequest(new {errorText="Invalid request"});
    }

    [HttpGet]
    public async Task<IActionResult> GetRegions()
    {
        var response = await AdressService.GetRegion();
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Json(response.Data);
        }

        return BadRequest(new { errorText = "Invalid request" });
    }

    //[Authorize(Roles = "admin")]
    [HttpGet]
    public IActionResult GetDistrictsByName()
    {
        return View();
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> GetCitiesByName(int Name)
    {
        var response = await AdressService.GetCitiesByDistrict(Name);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Json(response.Data);
        }
        return BadRequest(new {errorText="Invalid request"});
    }
    
    [Authorize(Roles = "admin")]
    [HttpGet]
    public IActionResult GetCitiesByName()
    {
        return View();
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> GetStreetsByName(int Name)
    {
        var response = await AdressService.GetStreetsByCity(Name);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Json(response.Data);
        }
        return BadRequest(new {errorText="Invalid request"});
    }
    
    [Authorize(Roles = "admin")]
    [HttpGet]
    public IActionResult GetStreetsByName()
    {
        return View();
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> GetHouseByName(int Id_Street)
    {
        var response = await AdressService.GetHouseByStreet(Id_Street);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Json(response.Data);
        }
        return BadRequest(new {errorText="Invalid request"});
    }

    [Authorize(Roles = "admin")]
    [HttpGet]
    public IActionResult GetHouseByName()
    {
        return View();
    }
    
}