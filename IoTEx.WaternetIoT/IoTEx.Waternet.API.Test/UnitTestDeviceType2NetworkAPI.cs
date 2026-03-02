

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
    public class UnitTestDeviceType2NetworkAPI
    {
        private ContextCreator _contextCreator;
        private IoTDBContext _dbContext;
        private ILogger _logger;
        private IConfiguration _configuration;
        private DeviceType2NetworkAPIController _controller;
        private Guid _deviceTypeId;
        private Guid _networkAPIId;
        public UnitTestDeviceType2NetworkAPI()
        {
            _contextCreator = new ContextCreator();
            _contextCreator.SetAdminUserContext();

            _dbContext = _contextCreator.CreateDatabaseContext().Result;

            _logger = A.Fake<ILogger>();
            _configuration = A.Fake<IConfiguration>();
            _controller = new DeviceType2NetworkAPIController(_logger, _dbContext, _configuration);

            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = _contextCreator.GetHttpContext();

        }

        private void CreateSeedData()
        {
            DeviceTypeModel deviceType = new DeviceTypeModel()
            {
                Name = "TestNameDeviceType",
                Description = "TestDescriptionDeviceType",
                SupplierId = Guid.NewGuid(),
                Created = DateTime.Now,
                Updated = DateTime.Now,
                CreatedById = Guid.NewGuid(),
                UpdatedById = Guid.NewGuid()
            };
            _dbContext.DeviceTypes.Add(deviceType);
            _dbContext.SaveChanges();
            _deviceTypeId = deviceType.Id;

            NetworkAPIModel networkAPIId = new NetworkAPIModel()
            {
                Name = "TestNameNetworkAPI",
                Description = "TestDescriptionNetworkAPI",
                IsLORA = true,
                IsSigFox = true,
                IsLTM = true,
                IsNBIoT = true,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                CreatedById = Guid.NewGuid(),
                UpdatedById = Guid.NewGuid()
            };
            _dbContext.NetworkAPIs.Add(networkAPIId);
            _dbContext.SaveChanges();
            _networkAPIId = networkAPIId.Id;
        }

        private DeviceType2NetworkAPIViewModel GetViewModel()
        {   
            DeviceType2NetworkAPIViewModel view = new DeviceType2NetworkAPIViewModel()
            {
                DeviceTypeId = _deviceTypeId,
                NetworkAPIId = _networkAPIId
            };
            return view;
        }

        [Fact]
        public void GetAll()
        {
            //Arrange
            Create();

            //Act
            ActionResult<APIResultDTO<List<DeviceType2NetworkAPIViewModel>>> result = _controller.GetAlls(null, _deviceTypeId).Result;

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
            ActionResult<APIResultDTO<GridResult<DeviceType2NetworkAPIViewModel>>> result = _controller.GetAllsGrid(null, _deviceTypeId).Result;

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
            DeviceType2NetworkAPIModel? model = _dbContext.DeviceType2NetworkAPIs.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<DeviceType2NetworkAPIViewModel>> result = _controller.Get(model.Id, _deviceTypeId).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }

        [Fact]
        public void Create()
        {
            //Arrange
            CreateSeedData();
            DeviceType2NetworkAPIViewModel view = GetViewModel();
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<DeviceType2NetworkAPIViewModel>> result = _controller.Create(_deviceTypeId, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));

        }

        [Fact]
        public void Update()
        {
            //Arrange
            Create();
            DeviceType2NetworkAPIViewModel view = GetViewModel();
            DeviceType2NetworkAPIModel model = _dbContext.DeviceType2NetworkAPIs.FirstOrDefault(o => o.DeviceTypeId == view.DeviceTypeId);
            view.Id = model.Id;
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<DeviceType2NetworkAPIViewModel>> result = _controller.Update(_deviceTypeId, model.Id, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
        }

        [Fact]
        public void Delete()
        {
            //Arrange
            Create();
            DeviceType2NetworkAPIModel? model = _dbContext.DeviceType2NetworkAPIs.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<DeviceType2NetworkAPIViewModel>> result = _controller.Delete(_deviceTypeId, model.Id).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }
    }
}