using Microsoft.AspNetCore.Mvc;
using Delivery.Domain;
using Delivery.Service.Implementation;


namespace Delivery.Controllers;

public class AdressController : Controller
{
    [HttpPost]
    public async Task<IActionResult> GetDistrictsByName(string Name)
    {
        var response = await AdressService.GetDistrictByRegion(Name);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Json(response.Data);
        }
        return BadRequest(new {errorText="Invalid request"});
    }

    [HttpGet]
    public IActionResult GetDistrictsByName()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> GetCitiesByName(string Name)
    {
        var response = await AdressService.GetCitiesByDistrict(Name);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Json(response.Data);
        }
        return BadRequest(new {errorText="Invalid request"});
    }
    
    [HttpGet]
    public IActionResult GetCitiesByName()
    {
        return View();
    }
}