using Microsoft.AspNetCore.Mvc;
using Delivery.Domain;
using Delivery.Service.Implementation;
using Microsoft.AspNetCore.Authorization;


namespace Delivery.Controllers;

public class AdressController : Controller
{
    //[Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> GetDistrictsById(int Name)
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
    public IActionResult GetDistrictsById()
    {
        return View();
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> GetCitiesById(int Name)
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
    public IActionResult GetCitiesById()
    {
        return View();
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> GetStreetsById(int Name)
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
    public IActionResult GetStreetsById()
    {
        return View();
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> GetHouseById(int Id_Street)
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
    public IActionResult GetHouseById()
    {
        return View();
    }
    
}