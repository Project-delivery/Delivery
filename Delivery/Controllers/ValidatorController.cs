using Microsoft.AspNetCore.Mvc;
using Delivery.Domain;
using Delivery.Service.Implementation;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;

namespace Delivery.Controllers;

public class ValidatorController : Controller
{
    public async Task<IActionResult> getAllTempAdresses(bool isValid = false)
    {
        var response = await ValidatorService.GetAll(isValid);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Json(response.Data);
        }
        return BadRequest(new {errorText="Invalid request"});
    }
}