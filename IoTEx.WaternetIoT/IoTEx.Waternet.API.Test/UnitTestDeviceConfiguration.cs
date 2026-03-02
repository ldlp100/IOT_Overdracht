
using FakeItEasy;
using FluentAssertions;
using IoTEx.Waternet.API.Controllers;
using IoTEx.Waternet.API.Test.Generic;
using IoTEx.WaternetIoT.DAL;
using IoTEx.WaternetIoT.Model.DTOs.API;
using IoTEx.WaternetIoT.Model.PortalModels;
using IoTEx.WaternetIoT.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
    
namespace IoTEx.Waternet.API.Test
{
    public class UnitTestDeviceConfiguration
    {
        private ContextCreator _contextCreator;
        private IoTDBContext _dbContext;
        private ILogger _logger;
        private IConfiguration _configuration;
        private DeviceConfigurationController _controller;
        private Guid _deviceTypeId;
        private Guid _deviceBatchId;
        private Guid _deviceId;
        private Guid _parserId;
        private Guid _deviceTypeFirmwareId;
        private Guid _deviceTypeFirmwareConfigurationId;

        public UnitTestDeviceConfiguration()
        {
            _contextCreator = new ContextCreator();
            _contextCreator.SetAdminUserContext();

            _dbContext = _contextCreator.CreateDatabaseContext().Result;

            _logger = A.Fake<ILogger>();
            _configuration = A.Fake<IConfiguration>();
            _controller = new DeviceConfigurationController(_logger, _dbContext, _configuration);

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

            ParserModel parser = new ParserModel()
            {
                Name = "TestNameParser",
                Description = "TestDescriptionParser",
                ClassName = "TestClassNameParser",
                Created = DateTime.Now,
                Updated = DateTime.Now,
                CreatedById = Guid.NewGuid(),
                UpdatedById = Guid.NewGuid()
            };
            _dbContext.Parsers.Add(parser);
            _dbContext.SaveChanges();
            _parserId = parser.Id;

            DeviceTypeFirmwareModel deviceTypeFirmware = new DeviceTypeFirmwareModel()
            {
                Name = "TestNameDeviceTypeFirmWare",
                Description = "TestDescriptionDeviceTypeFirmWare",
                IsUsed = true,
                DeviceTypeId = _deviceTypeId,
                IsConfigurable = true,
                ParserId = _parserId
            };
            _dbContext.DeviceTypeFirmwares.Add(deviceTypeFirmware);
            _dbContext.SaveChanges();
            _deviceTypeFirmwareId = deviceTypeFirmware.Id;

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

            DeviceTypeFirmwareConfigurationModel deviceTypeFirmwareConfiguration = new DeviceTypeFirmwareConfigurationModel()
            {
                Name = "TestNameDeviceTypeFirmwareConfiguration",
                Description = "TestDescriptionDeviceTypeFirmwareConfiguration",
                Symbol = "TestSymbolDeviceTypeFirmwareConfiguration",
                MinValue = 2,
                MaxValue = 2,
                MinLength = 2,
                MaxLength = 2,
                TypeName = "TestTypeNameDeviceTypeFirmwareConfiguration",
                Categories = "TestCategoriesDeviceTypeFirmwareConfiguration",
                RegEx = "TestRegExDeviceTypeFirmwareConfiguration",
                DefaultValue = "TestDefaultValueDeviceTypeFirmwareConfiguration",
                Role = 0,
                DeviceTypeFirmwareId = _deviceTypeFirmwareId,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                CreatedById = Guid.NewGuid(),
                UpdatedById = Guid.NewGuid()
            };
            _dbContext.DeviceTypeFirmware2Configurations.Add(deviceTypeFirmwareConfiguration);
            _dbContext.SaveChanges();
            _deviceTypeFirmwareConfigurationId = deviceTypeFirmwareConfiguration.Id;
        }

        private DeviceConfigurationViewModel GetViewModel()
        {
            DeviceConfigurationViewModel view = new DeviceConfigurationViewModel()
            {
                DeviceId = _deviceId,
                DeviceTypeFirmwareConfigurationId = _deviceTypeFirmwareConfigurationId,
                Value = "TestValueDeviceConfiguration"
            };
            return view;
        }

        [Fact]
        public void GetAll()
        {
            //Arrange
            Create();

            //Act
            ActionResult<APIResultDTO<List<DeviceConfigurationViewModel>>> result = _controller.GetAlls(null, _deviceTypeId, _deviceBatchId, _deviceId).Result;

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
            ActionResult<APIResultDTO<GridResult<DeviceConfigurationViewModel>>> result = _controller.GetAllsGrid(null, _deviceTypeId, _deviceBatchId, _deviceId).Result;

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
            DeviceConfigurationModel? model = _dbContext.Device2Configurations.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<DeviceConfigurationViewModel>> result = _controller.Get(model.Id, _deviceTypeId, _deviceBatchId, _deviceId).Result;

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
            DeviceConfigurationViewModel view = GetViewModel();
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<DeviceConfigurationViewModel>> result = _controller.Create(_deviceId, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Value.Should().Be("TestValueDeviceConfiguration");
        }

        [Fact]
        public void Update()
        {
            //Arrange
            Create();
            DeviceConfigurationViewModel view = GetViewModel();
            DeviceConfigurationModel model = _dbContext.Device2Configurations.FirstOrDefault(o => o.Value == view.Value);
            view.Value = "TestValueDeviceConfigurationB";
            view.Id = model.Id;
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<DeviceConfigurationViewModel>> result = _controller.Update(_deviceId, model.Id, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Value.Should().Be("TestValueDeviceConfigurationB");
        }

        [Fact]
        public void Delete()
        {
            //Arrange
            Create();
            DeviceConfigurationModel? model = _dbContext.Device2Configurations.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<DeviceConfigurationViewModel>> result = _controller.Delete(_deviceTypeId, _deviceBatchId, _deviceId, model.Id).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }
    }
}