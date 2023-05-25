using Microsoft.AspNetCore.Mvc;
using Delivery.Domain;
using Delivery.Service.Implementation;
using Microsoft.AspNetCore.Authorization;


namespace Delivery.Controllers;

public class AdressController : Controller
{
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetDistrictsById(string Name)
    {
        int Id = Convert.ToInt32(Name);
        Console.WriteLine(Name);
        Console.WriteLine(Id);
        Console.WriteLine("GetDistrictsById");
        var response = await AdressService.GetDistrictByRegion(Id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Json(response.Data);
        }
        return BadRequest(new {errorText="Invalid request"});
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetRegions()
    {
        Console.WriteLine("Вызван получение регионов");
        var response = await AdressService.GetRegion();
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Json(response.Data);
        }

        return BadRequest(new { errorText = "Invalid request" });
    }

    
    [HttpGet]
    [Authorize]
    public IActionResult GetDistrictsById()
    {
        return View();
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetCitiesById(string Name)
    {
        int Id = Convert.ToInt32(Name);
        Console.WriteLine(Name);
        Console.WriteLine(Id);
        Console.WriteLine("GetCitiesById");
        var response = await AdressService.GetCitiesByDistrict(Id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Json(response.Data);
        }
        return BadRequest(new {errorText="Invalid request"});
    }
    
    [HttpGet]
    [Authorize]
    public IActionResult GetCitiesById()
    {
        return View();
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetStreetsById(string Name)
    {
        int Id = Convert.ToInt32(Name);
        Console.WriteLine(Name);
        Console.WriteLine(Id);
        Console.WriteLine("GetStreetsById");
        var response = await AdressService.GetStreetsByCity(Id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Json(response.Data);
        }
        return BadRequest(new {errorText="Invalid request"});
    }
    
    [HttpGet]
    [Authorize]
    public IActionResult GetStreetsById()
    {
        return View();
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetHouseById(string Name)
    {
        int Id = Convert.ToInt32(Name);
        Console.WriteLine(Name);
        Console.WriteLine(Id);
        Console.WriteLine("GetHouseById");
        var response = await AdressService.GetHouseByStreet(Id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Json(response.Data);
        }
        return BadRequest(new {errorText="Invalid request"});
    }
    
    [HttpGet]
    [Authorize]
    public IActionResult GetHouseById()
    {
        return View();
    }
    
}