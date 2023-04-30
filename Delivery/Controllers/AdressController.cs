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
        else return BadRequest(new {errorText="Invalid request"});
    }

    [HttpGet]
    public IActionResult GetDistrictsByName()
    {
        return View();
    }
}