
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
    public class UnitTestDeviceTypeFirmWareMeasurementType
    {
        private ContextCreator _contextCreator;
        private IoTDBContext _dbContext;
        private ILogger _logger;
        private IConfiguration _configuration;
        private DeviceTypeFirmwareMeasurementTypeController _controller;
        private Guid _deviceTypeId;
        private Guid _deviceTypeFirmwareId;
        private Guid _deviceBatchId;
        private Guid _deviceId;
        public UnitTestDeviceTypeFirmWareMeasurementType()
        {
            _contextCreator = new ContextCreator();
            _contextCreator.SetAdminUserContext();

            _dbContext = _contextCreator.CreateDatabaseContext().Result;

            _logger = A.Fake<ILogger>();
            _configuration = A.Fake<IConfiguration>();
            _controller = new DeviceTypeFirmwareMeasurementTypeController(_logger, _dbContext, _configuration);

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

        private DeviceTypeFirmwareMeasurementTypeViewModel GetViewModel()
        {
            DeviceTypeFirmwareMeasurementTypeViewModel view = new DeviceTypeFirmwareMeasurementTypeViewModel()
            {
                Name = "TestNameDeviceTypeFirmWareMeasurementType",
                Description = "TestDescriptionDeviceTypeFirmWareMeasurementType",
                MeasurementTypeId = Guid.NewGuid(),
                UnitTypeId = Guid.NewGuid(),
                Unit = "TestUnitDeviceTypeFirmWareMeasurementType",
                MinMeas = 2,
                MaxMeas = 2,
                MinSensor = 2,
                MaxSensor = 2,
                OffsetValue = 2,
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
            ActionResult<APIResultDTO<List<DeviceTypeFirmwareMeasurementTypeViewModel>>> result = _controller.GetAlls(null, _deviceTypeId, _deviceTypeFirmwareId).Result;

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
            ActionResult<APIResultDTO<GridResult<DeviceTypeFirmwareMeasurementTypeViewModel>>> result = _controller.GetAllsGrid(null, _deviceTypeId, _deviceTypeFirmwareId).Result;

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
            DeviceTypeFirmwareMeasurementTypeModel? model = _dbContext.DeviceTypeFirmware2MeasurementTypes.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<DeviceTypeFirmwareMeasurementTypeViewModel>> result = _controller.Get(model.Id, _deviceTypeId, _deviceTypeFirmwareId).Result;

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
            DeviceTypeFirmwareMeasurementTypeViewModel view = GetViewModel();
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<DeviceTypeFirmwareMeasurementTypeViewModel>> result = _controller.Create(_deviceTypeId, _deviceTypeFirmwareId, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameDeviceTypeFirmWareMeasurementType");
            result.Value.Value.Description.Should().Be("TestDescriptionDeviceTypeFirmWareMeasurementType");
            result.Value.Value.Unit.Should().Be("TestUnitDeviceTypeFirmWareMeasurementType");
            result.Value.Value.MinMeas.Should().Be(2);
            result.Value.Value.MaxMeas.Should().Be(2);
            result.Value.Value.MinSensor.Should().Be(2);
            result.Value.Value.MaxSensor.Should().Be(2);
            result.Value.Value.OffsetValue.Should().Be(2);
        }

        [Fact]
        public void Update()
        {
            //Arrange
            Create();
            DeviceTypeFirmwareMeasurementTypeViewModel view = GetViewModel();
            DeviceTypeFirmwareMeasurementTypeModel model = _dbContext.DeviceTypeFirmware2MeasurementTypes.FirstOrDefault(o => o.Name == view.Name);
            view.Name = "TestNameDeviceTypeFirmWareMeasurementTypeB";
            view.Description = "TestDescriptionDeviceTypeFirmWareMeasurementTypeB";
            view.Unit = "TestUnitDeviceTypeFirmWareMeasurementTypeB";
            view.MinMeas = 3;
            view.MaxMeas = 3;
            view.MinSensor = 3;
            view.MaxSensor = 3;
            view.OffsetValue = 3;
            view.Id = model.Id;
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<DeviceTypeFirmwareMeasurementTypeViewModel>> result = _controller.Update(_deviceTypeId, _deviceTypeFirmwareId, model.Id, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameDeviceTypeFirmWareMeasurementTypeB");
            result.Value.Value.Description.Should().Be("TestDescriptionDeviceTypeFirmWareMeasurementTypeB");
            result.Value.Value.Unit.Should().Be("TestUnitDeviceTypeFirmWareMeasurementTypeB");
            result.Value.Value.MinMeas.Should().Be(3);
            result.Value.Value.MaxMeas.Should().Be(3);
            result.Value.Value.MinSensor.Should().Be(3);
            result.Value.Value.MaxSensor.Should().Be(3);
            result.Value.Value.OffsetValue.Should().Be(3);
        }

        [Fact]
        public void Delete()
        {
            //Arrange
            Create();
            DeviceTypeFirmwareMeasurementTypeModel? model = _dbContext.DeviceTypeFirmware2MeasurementTypes.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<DeviceTypeFirmwareMeasurementTypeViewModel>> result = _controller.Delete(_deviceTypeId, _deviceTypeFirmwareId, model.Id).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }

        [Fact]
        public void GetAllForDevice()
        {
            //Arrange
            Create();

            //Act
            ActionResult<APIResultDTO<List<DeviceTypeFirmwareMeasurementTypeViewModel>>> result = _controller.GetAllsForDevice(null, _deviceId).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Count().Should().Be(1);
        }

        [Fact]
        public void GetAllForDeviceGrid()
        {
            //Arrange
            Create();

            //Act
            ActionResult<APIResultDTO<GridResult<DeviceTypeFirmwareMeasurementTypeViewModel>>> result = _controller.GetAllsForDeviceGrid(null, _deviceId).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Data.Should().NotBeNull();
            result.Value.Value.Data.Count().Should().Be(1);
        }
    }
}