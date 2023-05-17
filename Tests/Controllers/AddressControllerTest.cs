using FakeItEasy;
using Microsoft.AspNetCore.Http;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Delivery.Models;
using Microsoft.Extensions.Logging;
using Delivery.Controllers;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Controllers
{
    public class AddressControllerTests
    {
        private readonly AdressController _controller;

        public AddressControllerTests()
        {
            // Arrange
            _controller = new AdressController();
        }

        [Fact]
        public async Task GetDistrictsById_ValidName_ReturnsJsonResult()
        {
            // Arrange
            var name = "1";

            // Act
            var result = await _controller.GetDistrictsById(name);

            // Assert
            result.Should().BeOfType<JsonResult>();
        }

        [Fact]
        public async Task GetRegions_ReturnsJsonResult()
        {
            // Act
            var result = await _controller.GetRegions();

            // Assert
            result.Should().BeOfType<JsonResult>();
        }

        [Fact]
        public IActionResult GetDistrictsById_ReturnsViewResult()
        {
            // Act
            var result = _controller.GetDistrictsById();

            // Assert
            return result.Should().BeOfType<ViewResult>().Subject;
        }

        [Fact]
        public async Task GetCitiesById_ValidName_ReturnsJsonResult()
        {
            // Arrange
            var name = "1";

            // Act
            var result = await _controller.GetCitiesById(name);

            // Assert
            result.Should().BeOfType<JsonResult>();
        }

        [Fact]
        public IActionResult GetCitiesById_ReturnsViewResult()
        {
            // Act
            var result = _controller.GetCitiesById();

            // Assert
            return result.Should().BeOfType<ViewResult>().Subject;
        }

        [Fact]
        public async Task GetStreetsById_ValidName_ReturnsJsonResult()
        {
            // Arrange
            var name = "1";

            // Act
            var result = await _controller.GetStreetsById(name);

            // Assert
            result.Should().BeOfType<JsonResult>();
        }

        [Fact]
        public IActionResult GetStreetsById_ReturnsViewResult()
        {
            // Act
            var result = _controller.GetStreetsById();

            // Assert
            return result.Should().BeOfType<ViewResult>().Subject;
        }

        [Fact]
        public async Task GetHouseById_ValidName_ReturnsJsonResult()
        {
            // Arrange
            var name = "1";

            // Act
            var result = await _controller.GetHouseById(name);

            // Assert
            result.Should().BeOfType<JsonResult>();
        }

        [Fact]
        public IActionResult GetHouseById_ReturnsViewResult()
        {
            // Act
            var result = _controller.GetHouseById();

            // Assert
            return result.Should().BeOfType<ViewResult>().Subject;
        }
    }
}
