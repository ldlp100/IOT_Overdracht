

using FakeItEasy;
using FluentAssertions;
using IoTEx.Waternet.API.Controllers;
using IoTEx.Waternet.API.Test.Generic;
using IoTEx.WaternetIoT.DAL;
using IoTEx.WaternetIoT.Model.DTOs.API;
using IoTEx.WaternetIoT.Model.PortalModels;
using IoTEx.WaternetIoT.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
    
namespace IoTEx.Waternet.API.Test
{
    public class UnitTestDeviceBatch
    {
        private ContextCreator _contextCreator;
        private IoTDBContext _dbContext;
        private ILogger _logger;
        private IConfiguration _configuration;
        private DeviceBatchController _controller;
        private Guid _deviceTypeId;
        public UnitTestDeviceBatch()
        {
            _contextCreator = new ContextCreator();
            _contextCreator.SetAdminUserContext();

            _dbContext = _contextCreator.CreateDatabaseContext().Result;
            
            _logger = A.Fake<ILogger>();
            _configuration = A.Fake<IConfiguration>();
            _controller = new DeviceBatchController(_logger, _dbContext, _configuration,null,null);

            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = _contextCreator.GetHttpContext();

            _deviceTypeId = Guid.NewGuid();
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
        }

        private DeviceBatchViewModel GetViewModel()
        {
            DeviceBatchViewModel view = new DeviceBatchViewModel()
            {
                Name = "TestNameDeviceBatch",
                DeviceTypeId = _deviceTypeId,
                GroupId = Guid.NewGuid(),
            };
            return view;
        }

        [Fact]
        public void GetAll()
        {
            //Arrange
            Create();

            //Act
            ActionResult<APIResultDTO<List<DeviceBatchViewModel>>> result = _controller.GetAlls(null, _deviceTypeId).Result;

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
            ActionResult<APIResultDTO<GridResult<DeviceBatchViewModel>>> result = _controller.GetAllsGrid(null, _deviceTypeId).Result;

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
            DeviceBatchModel? model = _dbContext.DeviceBatchs.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<DeviceBatchViewModel>> result = _controller.Get(model.Id, _deviceTypeId).Result;

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
            DeviceBatchViewModel view = GetViewModel();
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<DeviceBatchViewModel>> result = _controller.Create(_deviceTypeId, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameDeviceBatch");

        }

        [Fact]
        public void Update()
        {
            //Arrange
            Create();
            DeviceBatchViewModel view = GetViewModel();
            DeviceBatchModel model = _dbContext.DeviceBatchs.FirstOrDefault(o => o.Name == view.Name);
            view.Name = "TestNameDeviceBatchB";
            view.Id = model.Id;
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<DeviceBatchViewModel>> result = _controller.Update(_deviceTypeId, model.Id, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameDeviceBatchB");
        }

        [Fact]
        public void Delete()
        {
            //Arrange
            Create();
            DeviceBatchModel? model = _dbContext.DeviceBatchs.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<DeviceBatchViewModel>> result = _controller.Delete(_deviceTypeId, model.Id).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }

        [Fact]
        public void GetAllImportDeviceBatchFile()
        {
            //Arrange
            Create();

            //Act
            ActionResult<APIResultDTO<List<DeviceBatchViewModel>>> result = _controller.GetAllsImportDeviceBatchFile(null, _deviceTypeId).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Count().Should().Be(1);
        }

        [Fact]
        public void GetAllImportDeviceBatchFileGrid()
        {
            //Arrange
            Create();

            //Act
            ActionResult<APIResultDTO<GridResult<DeviceBatchViewModel>>> result = _controller.GetAllsImportDeviceBatchFileGrid(null, _deviceTypeId).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Data.Should().NotBeNull();
            result.Value.Value.Data.Count().Should().Be(1);
        }
    }
}