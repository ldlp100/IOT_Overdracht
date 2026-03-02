
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
    public class UnitTestDeviceCalibration
    {
        private ContextCreator _contextCreator;
        private IoTDBContext _dbContext;
        private ILogger _logger;
        private IConfiguration _configuration;
        private DeviceCalibrationController _controller;
        private Guid _deviceTypeId;
        private Guid _deviceBatchId;
        private Guid _deviceId;
        public UnitTestDeviceCalibration()
        {
            _contextCreator = new ContextCreator();
            _contextCreator.SetAdminUserContext();

            _dbContext = _contextCreator.CreateDatabaseContext().Result;

            _logger = A.Fake<ILogger>();
            _configuration = A.Fake<IConfiguration>();
            _controller = new DeviceCalibrationController(_logger, _dbContext, _configuration);

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

            DeviceModel device = new DeviceModel()
            {
                Name = "TestNameDevice",
                DeviceBatchId = _deviceBatchId,
                DeviceTypeFirmwareId = Guid.NewGuid(),
                Created = DateTime.Now,
                Updated = DateTime.Now,
                CreatedById = Guid.NewGuid(),
                UpdatedById = Guid.NewGuid()
            };
            _dbContext.Devices.Add(device);
            _dbContext.SaveChanges();
            _deviceId = device.Id;
        }

        private DeviceCalibrationViewModel GetViewModel()
        {
            DeviceCalibrationViewModel view = new DeviceCalibrationViewModel()
            {
                DeviceId = _deviceId,
                MinMeas = 2,
                MaxMeas = 2,
                MinReal = 2,
                MaxReal = 2,
                OffsetValue = 2,
                DeviceTypeFirmware2MeasurementTypeId = Guid.NewGuid()
            };
            return view;
        }

        [Fact]
        public void GetAll()
        {
            //Arrange
            Create();

            //Act
            ActionResult<APIResultDTO<List<DeviceCalibrationViewModel>>> result = _controller.GetAlls(null, _deviceTypeId, _deviceBatchId, _deviceId).Result;

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
            ActionResult<APIResultDTO<GridResult<DeviceCalibrationViewModel>>> result = _controller.GetAllsGrid(null, _deviceTypeId, _deviceBatchId, _deviceId).Result;

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
            DeviceCalibrationModel? model = _dbContext.Device2Calibrations.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<DeviceCalibrationViewModel>> result = _controller.Get(model.Id, _deviceTypeId, _deviceBatchId, _deviceId).Result;

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
            DeviceCalibrationViewModel view = GetViewModel();
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<DeviceCalibrationViewModel>> result = _controller.Create(_deviceId, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.MinMeas.Should().Be(2);
            result.Value.Value.MaxMeas.Should().Be(2);
            result.Value.Value.MinReal.Should().Be(2);
            result.Value.Value.MaxReal.Should().Be(2);
            result.Value.Value.OffsetValue.Should().Be(2);
        }

        [Fact]
        public void Update()
        {
            //Arrange
            Create();
            DeviceCalibrationViewModel view = GetViewModel();
            DeviceCalibrationModel model = _dbContext.Device2Calibrations.FirstOrDefault(o => o.MinMeas == view.MinMeas);
            view.MinMeas = 3;
            view.MaxMeas = 3;
            view.MinReal = 3;
            view.MaxReal = 3;
            view.OffsetValue = 3;
            view.Id = model.Id;
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<DeviceCalibrationViewModel>> result = _controller.Update(_deviceId, model.Id, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.MinMeas.Should().Be(3);
            result.Value.Value.MaxMeas.Should().Be(3);
            result.Value.Value.MinReal.Should().Be(3);
            result.Value.Value.MaxReal.Should().Be(3);
            result.Value.Value.OffsetValue.Should().Be(3);
        }

        [Fact]
        public void Delete()
        {
            //Arrange
            Create();
            DeviceCalibrationModel? model = _dbContext.Device2Calibrations.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<DeviceCalibrationViewModel>> result = _controller.Delete(_deviceTypeId, _deviceBatchId, _deviceId, model.Id).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }
    }
}