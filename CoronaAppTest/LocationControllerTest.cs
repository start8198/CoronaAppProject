using CoronaAppProject.Controllers;
using Dal;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using Newtonsoft.Json;
using Services;
using Services.Models;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CoronaAppTest
{
    public class LocationControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public LocationControllerTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void GetAllTest()
        {
            List<Patient> patients = null;
            Mock<ILocationRepository> mock = new Mock<ILocationRepository>();
            var controller = new LocationsController(mock.Object);
            mock.Setup(x => x.GetLocations()).Returns(Task.FromResult(patients));
            var response = controller.Get();
            Assert.NotNull(response);
        }
        [Fact]
        public async void GetByCityTest()
        {
            var city = "Jerusalem";
            List<Location> locations = null;
            Mock<ILocationRepository> mock = new Mock<ILocationRepository>();
            var controller = new LocationsController(mock.Object);
            mock.Setup(x => x.GetLocation(String.Empty)).Returns(Task.FromResult(locations));
            var response = controller.GetLocation(city);
            Assert.NotNull(response);
        }

    }
}

