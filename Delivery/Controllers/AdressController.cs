using Microsoft.AspNetCore.Mvc;
using Delivery.Domain;
using Delivery.Service.Implementation;
using Microsoft.AspNetCore.Authorization;


namespace Delivery.Controllers;

public class AdressController : Controller
{
    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> GetDistrictsById(string Name)
    {
        int Id = Convert.ToInt32(Name);
        var response = await AdressService.GetDistrictByRegion(Id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Json(response.Data);
        }
        return BadRequest(new {errorText="Invalid request"});
    }

    [HttpGet]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> GetRegions()
    {
        var response = await AdressService.GetRegion();
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Json(response.Data);
        }

        return BadRequest(new { errorText = "Invalid request" });
    }

    [Authorize(Roles = "admin")]
    [HttpGet]
    public IActionResult GetDistrictsById()
    {
        return View();
    }

    //[Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> GetCitiesById(string Name)
    {
        int Id = Convert.ToInt32(Name);
        var response = await AdressService.GetCitiesByDistrict(Id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Json(response.Data);
        }
        return BadRequest(new {errorText="Invalid request"});
    }
    
    //[Authorize(Roles = "admin")]
    [HttpGet]
    public IActionResult GetCitiesById()
    {
        return View();
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> GetStreetsById(string Name)
    {
        int Id = Convert.ToInt32(Name);
        var response = await AdressService.GetStreetsByCity(Id);
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
    public async Task<IActionResult> GetHouseById(string Name)
    {
        int Id = Convert.ToInt32(Name);
        var response = await AdressService.GetHouseByStreet(Id);
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