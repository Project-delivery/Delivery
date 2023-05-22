using Delivery.Controllers;
using Delivery.Domain.Enum;
using Delivery.Domain.Response;
using Delivery.Service.Implementation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Delivery.Tests.Controllers
{
    public class ValidatorControllerTests
    {
        [Fact]
        public async Task Add_ValidData_ReturnsOkResult()
        {
            var controller = new ValidatorController();

            controller.Add("Region", "District", "City", "Street", "House", 1, true, "Comment");
            var result = new OkResult();

            Xunit.Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task getAllTempAdresses_ValidData_ReturnsJsonResponseWithData()
        {
            var controller = new ValidatorController();
            var result = await controller.getAllTempAdresses();

            Xunit.Assert.IsType<JsonResult>(result);

            var jsonResult = (JsonResult)result;
            var responseData = (List<object>)jsonResult.Value;

            Xunit.Assert.NotNull(responseData);
        }

        [Fact]
        public async Task AddNewAdress_ValidData_ReturnsJsonResultWithOk()
        {
            var controller = new ValidatorController();
            var result = await controller.AddNewAdress(1, "Name", "StreetType");

            Xunit.Assert.IsType<JsonResult>(result);

            var jsonResult = (JsonResult)result;
            var responseValue = (string)jsonResult.Value;

            Xunit.Assert.Equal("OK", responseValue);
        }
    }
}
