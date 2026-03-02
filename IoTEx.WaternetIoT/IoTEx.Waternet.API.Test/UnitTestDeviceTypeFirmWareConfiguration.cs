
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
    public class UnitTestDeviceTypeFirmWareConfiguration
    {
        private ContextCreator _contextCreator;
        private IoTDBContext _dbContext;
        private ILogger _logger;
        private IConfiguration _configuration;
        private DeviceTypeFirmwareConfigurationController _controller;
        private Guid _deviceTypeId;
        private Guid _deviceTypeFirmwareId;
        private Guid _deviceBatchId;
        private Guid _deviceId;
        public UnitTestDeviceTypeFirmWareConfiguration()
        {
            _contextCreator = new ContextCreator();
            _contextCreator.SetAdminUserContext();

            _dbContext = _contextCreator.CreateDatabaseContext().Result;

            _logger = A.Fake<ILogger>();
            _configuration = A.Fake<IConfiguration>();
            _controller = new DeviceTypeFirmwareConfigurationController(_logger, _dbContext, _configuration);

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

            DeviceTypeFirmwareModel DeviceTypeFirmWare = new DeviceTypeFirmwareModel()
            {
                Name = "TestNameDeviceTypeFirmWare",
                Description = "TestDescriptionDeviceTypeFirmWare",
                IsUsed = true,
                DeviceTypeId = _deviceTypeId,
                //DeviceTypeFirmwareAlertId = Guid.NewGuid(),
                //DeviceTypeFirmwareMeasId = Guid.NewGuid(),
                //DeviceTypeFirmwareStateId = Guid.NewGuid(),
                IsConfigurable = true,
                ParserId = Guid.NewGuid(),
                Created = DateTime.Now,
                Updated = DateTime.Now,
                CreatedById = Guid.NewGuid(),
                UpdatedById = Guid.NewGuid()
            };
            _dbContext.DeviceTypeFirmwares.Add(DeviceTypeFirmWare);
            _dbContext.SaveChanges();
            _deviceTypeFirmwareId = DeviceTypeFirmWare.Id;

            DeviceBatchModel deviceBatch = new DeviceBatchModel()
            {
                Name = "TestNameDeviceBatch",
                DeviceTypeId = _deviceTypeId,
                GroupId = Guid.NewGuid(),
                Created = DateTime.Now,
                Updated = DateTime.Now,
                CreatedById = Guid.NewGuid(),
                UpdatedById = Guid.NewGuid()
            };
            _dbContext.DeviceBatchs.Add(deviceBatch);
            _dbContext.SaveChanges();
            _deviceBatchId = deviceBatch.Id;

            DeviceModel device = new DeviceModel()
            {
                Name = "TestNameDevice",
                DeviceBatchId = _deviceBatchId,
                DeviceTypeFirmwareId = _deviceTypeFirmwareId,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                CreatedById = Guid.NewGuid(),
                UpdatedById = Guid.NewGuid()
            };
            _dbContext.Devices.Add(device);
            _dbContext.SaveChanges();
            _deviceId = device.Id;
        }

        private DeviceTypeFirmwareConfigurationViewModel GetViewModel()
        {
            DeviceTypeFirmwareConfigurationViewModel view = new DeviceTypeFirmwareConfigurationViewModel()
            {
                Name = "TestNameDeviceTypeFirmWareConfiguration",
                Description = "TestDescriptionDeviceTypeFirmWareConfiguration",
                Symbol = "TestSymbolDeviceTypeFirmWareConfiguration",
                DefaultValue = "TestDefaultValueDeviceTypeFirmWareConfiguration",
                Role = DeviceTypeFirmwareConfigurationModel.ConfigurationRole.IoTWorker,
                DeviceTypeFirmwareId = _deviceTypeFirmwareId
            };
            return view;
        }

        [Fact]
        public void GetAll()
        {
            //Arrange
            Create();

            //Act
            ActionResult<APIResultDTO<List<DeviceTypeFirmwareConfigurationViewModel>>> result = _controller.GetAlls(null, _deviceTypeId, _deviceTypeFirmwareId).Result;

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
            ActionResult<APIResultDTO<GridResult<DeviceTypeFirmwareConfigurationViewModel>>> result = _controller.GetAllsGrid(null, _deviceTypeId, _deviceTypeFirmwareId).Result;

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
            DeviceTypeFirmwareConfigurationModel? model = _dbContext.DeviceTypeFirmware2Configurations.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<DeviceTypeFirmwareConfigurationViewModel>> result = _controller.Get(model.Id, _deviceTypeId, _deviceTypeFirmwareId).Result;

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
            DeviceTypeFirmwareConfigurationViewModel view = GetViewModel();
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<DeviceTypeFirmwareConfigurationViewModel>> result = _controller.Create(_deviceTypeId, _deviceTypeFirmwareId, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameDeviceTypeFirmWareConfiguration");
            result.Value.Value.Description.Should().Be("TestDescriptionDeviceTypeFirmWareConfiguration");
            result.Value.Value.Symbol.Should().Be("TestSymbolDeviceTypeFirmWareConfiguration");
            result.Value.Value.DefaultValue.Should().Be("TestDefaultValueDeviceTypeFirmWareConfiguration");
        }

        [Fact]
        public void Update()
        {
            //Arrange
            Create();
            DeviceTypeFirmwareConfigurationViewModel view = GetViewModel();
            DeviceTypeFirmwareConfigurationModel model = _dbContext.DeviceTypeFirmware2Configurations.FirstOrDefault(o => o.Name == view.Name);
            view.Name = "TestNameDeviceTypeFirmWareConfigurationB";
            view.Description = "TestDescriptionDeviceTypeFirmWareConfigurationB";
            view.Symbol = "TestSymbolDeviceTypeFirmWareConfigurationB";
            view.DefaultValue = "TestDefaultValueDeviceTypeFirmWareConfigurationB";
            view.Id = model.Id;
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<DeviceTypeFirmwareConfigurationViewModel>> result = _controller.Update(_deviceTypeId, _deviceTypeFirmwareId, model.Id, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameDeviceTypeFirmWareConfigurationB");
            result.Value.Value.Description.Should().Be("TestDescriptionDeviceTypeFirmWareConfigurationB");
            result.Value.Value.Symbol.Should().Be("TestSymbolDeviceTypeFirmWareConfigurationB");
            result.Value.Value.DefaultValue.Should().Be("TestDefaultValueDeviceTypeFirmWareConfigurationB");
        }

        [Fact]
        public void Delete()
        {
            //Arrange
            Create();
            DeviceTypeFirmwareConfigurationModel? model = _dbContext.DeviceTypeFirmware2Configurations.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<DeviceTypeFirmwareConfigurationViewModel>> result = _controller.Delete(_deviceTypeId, _deviceTypeFirmwareId, model.Id).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }

        [Fact]
        public void GetConfigurationsForDeviceAll()
        {
            //Arrange
            Create();
            DeviceTypeFirmwareConfigurationModel? model = _dbContext.DeviceTypeFirmware2Configurations.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<List<DeviceTypeFirmwareConfigurationViewModel>>> result = _controller.GetConfigurationsForDeviceAlls(null, model.Id, _deviceId).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Count().Should().Be(1);
        }

        [Fact]
        public void GetConfigurationsForDeviceAllGrid()
        {
            //Arrange
            Create();
            DeviceTypeFirmwareConfigurationModel? model = _dbContext.DeviceTypeFirmware2Configurations.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<GridResult<DeviceTypeFirmwareConfigurationViewModel>>> result = _controller.GetConfigurationsForDeviceAllsGrid(null, model.Id, _deviceId).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Data.Should().NotBeNull();
            result.Value.Value.Data.Count().Should().Be(1);
        }
    }
}