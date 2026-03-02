

using FakeItEasy;
using FluentAssertions;
using IoTEx.Waternet.API.Controllers;
using IoTEx.Waternet.API.Test.Generic;
using IoTEx.WaternetIoT.DAL;
using IoTEx.WaternetIoT.Model.DTOs.API;
using IoTEx.WaternetIoT.Model.PortalModels;
using IoTEx.WaternetIoT.Model.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace IoTEx.Waternet.API.Test
{
    public class UnitTestNetworkAPI
    {
        private ContextCreator _contextCreator;
        private IoTDBContext _dbContext;
        private ILogger _logger;
        private IConfiguration _configuration;
        private NetworkAPIController _controller;
        public UnitTestNetworkAPI()
        {
            _contextCreator = new ContextCreator();
            _contextCreator.SetAdminUserContext();

            _dbContext = _contextCreator.CreateDatabaseContext().Result;

            _logger = A.Fake<ILogger>();
            _configuration = A.Fake<IConfiguration>();
            _controller = new NetworkAPIController(_logger, _dbContext, _configuration);

            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = _contextCreator.GetHttpContext();

        }

        private NetworkAPIViewModel GetViewModel()
        {
            NetworkAPIViewModel view = new NetworkAPIViewModel()
            {
                Name = "TestNameNetworkAPI",
                Description = "TestDescriptionNetworkAPI",
                IsLORA = true,
                IsSigFox = true,
                IsLTM = true,
                IsNBIoT = true
            };
            return view;
        }

        [Fact]
        public void GetAll()
        {
            //Arrange
            Create();

            //Act
            ActionResult<APIResultDTO<List<NetworkAPIViewModel>>> result = _controller.GetAlls(null).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Count().Should().Be(1);
        }

        [Fact]
        public void GetAllGrid()
        {
            //Arrange
            Create();

            //Act
            ActionResult<APIResultDTO<GridResult<NetworkAPIViewModel>>> result = _controller.GetAllsGrid(null).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Data.Should().NotBeNull();
            result.Value.Value.Data.Count().Should().Be(1);
        }

        [Fact]
        public void Get()
        {
            //Arrange
            Create();
            NetworkAPIModel? model = _dbContext.NetworkAPIs.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<NetworkAPIViewModel>> result = _controller.Get(model.Id).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }

        [Fact]
        public void Create()
        {
            //Arrange
            NetworkAPIViewModel view = GetViewModel();
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<NetworkAPIViewModel>> result = _controller.Create(view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameNetworkAPI");
            result.Value.Value.Description.Should().Be("TestDescriptionNetworkAPI");
            result.Value.Value.IsLORA.Should().BeTrue();
            result.Value.Value.IsSigFox.Should().BeTrue();
            result.Value.Value.IsLTM.Should().BeTrue();
            result.Value.Value.IsNBIoT.Should().BeTrue();

        }

        [Fact]
        public void Update()
        {
            //Arrange
            Create();
            NetworkAPIViewModel view = GetViewModel();
            NetworkAPIModel model = _dbContext.NetworkAPIs.FirstOrDefault(o => o.Name == view.Name);
            view.Name = "TestNameNetworkAPIB";
            view.Description = "TestDescriptionNetworkAPIB";
            view.IsLORA = false;
            view.IsSigFox = false;
            view.IsLTM = false;
            view.IsNBIoT = false;
            view.Id = model.Id;
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<NetworkAPIViewModel>> result = _controller.Update(model.Id, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameNetworkAPIB");
            result.Value.Value.Description.Should().Be("TestDescriptionNetworkAPIB");
            result.Value.Value.IsLORA.Should().BeFalse();
            result.Value.Value.IsSigFox.Should().BeFalse();
            result.Value.Value.IsLTM.Should().BeFalse();
            result.Value.Value.IsNBIoT.Should().BeFalse();
        }

        [Fact]
        public void Delete()
        {
            //Arrange
            Create();
            NetworkAPIModel? model = _dbContext.NetworkAPIs.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<NetworkAPIViewModel>> result = _controller.Delete(model.Id).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }
    }
}