
//using FakeItEasy;
//using FluentAssertions;
//using IoTEx.Waternet.API.Controllers;
//using IoTEx.Waternet.API.Test.Generic;
//using IoTEx.WaternetIoT.DAL;
//using IoTEx.WaternetIoT.Model.DTOModels.API;
//using IoTEx.WaternetIoT.Model.PortalModels;
//using IoTEx.WaternetIoT.Model.ViewModels;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Logging;

//namespace IoTEx.Waternet.API.Test
//{
//    public class UnitTestDeviceTypeFirmWareEventStateType
//    {
//        private ContextCreator _contextCreator;
//        private IoTDBContext _dbContext;
//        private ILogger _logger;
//        private IConfiguration _configuration;
//        private DeviceTypeFirmwareEventStateTypeController _controller;
//        private Guid _deviceTypeId;
//        private Guid _deviceTypeFirmwareId;
//        private Guid _deviceBatchId;
//        private Guid _deviceId;
//        public UnitTestDeviceTypeFirmWareEventStateType()
//        {
//            _contextCreator = new ContextCreator();
//            _contextCreator.SetAdminUserContext();

//            _dbContext = _contextCreator.CreateDatabaseContext().Result;

//            _logger = A.Fake<ILogger>();
//            _configuration = A.Fake<IConfiguration>();
//            _controller = new DeviceTypeFirmwareEventStateTypeController(_logger, _dbContext, _configuration);

//            _controller.ControllerContext = new ControllerContext();
//            _controller.ControllerContext.HttpContext = _contextCreator.GetHttpContext();

//        }

//        private void CreateSeedData()
//        {
//            DeviceTypeModel deviceType = new DeviceTypeModel()
//            {
//                Name = "TestNameDeviceType",
//                Description = "TestDescriptionDeviceType",
//                SupplierId = Guid.NewGuid(),
//                Created = DateTime.Now,
//                Updated = DateTime.Now,
//                CreatedById = Guid.NewGuid(),
//                UpdatedById = Guid.NewGuid()
//            };
//            _dbContext.DeviceTypes.Add(deviceType);
//            _dbContext.SaveChanges();
//            _deviceTypeId = deviceType.Id;

//            DeviceBatchModel deviceBatch = new DeviceBatchModel()
//            {
//                Name = "TestNameDeviceBatch",
//                DeviceTypeId = _deviceTypeId,
//                GroupId = Guid.NewGuid(),
//                Created = DateTime.Now,
//                Updated = DateTime.Now,
//                CreatedById = Guid.NewGuid(),
//                UpdatedById = Guid.NewGuid()
//            };
//            _dbContext.DeviceBatchs.Add(deviceBatch);
//            _dbContext.SaveChanges();
//            _deviceBatchId = deviceBatch.Id;

//            DeviceModel device = new DeviceModel()
//            {
//                Name = "TestNameDevice",
//                DeviceTypeId = _deviceTypeId,
//                DeviceBatchId = _deviceBatchId,
//                DeviceTypeFirmwareId = _deviceTypeFirmwareId,
//                Created = DateTime.Now,
//                Updated = DateTime.Now,
//                CreatedById = Guid.NewGuid(),
//                UpdatedById = Guid.NewGuid()
//            };
//            _dbContext.Devices.Add(device);
//            _dbContext.SaveChanges();
//            _deviceId = device.Id;

//            DeviceTypeFirmwareModel DeviceTypeFirmWare = new DeviceTypeFirmwareModel()
//            {
//                Name = "TestNameDeviceTypeFirmWare",
//                Description = "TestDescriptionDeviceTypeFirmWare",
//                IsUsed = true,
//                DeviceTypeId = _deviceTypeId,
//                IsConfigurable = true,
//                ParserId = Guid.NewGuid(),
//                Created = DateTime.Now,
//                Updated = DateTime.Now,
//                CreatedById = Guid.NewGuid(),
//                UpdatedById = Guid.NewGuid()
//            };
//            _dbContext.DeviceTypeFirmwares.Add(DeviceTypeFirmWare);
//            _dbContext.SaveChanges();
//            _deviceTypeFirmwareId = DeviceTypeFirmWare.Id;
//        }

//        private DeviceTypeFirmwareEventStateTypeViewModel GetViewModel()
//        {
//            DeviceTypeFirmwareEventStateTypeViewModel view = new DeviceTypeFirmwareEventStateTypeViewModel()
//            {
//                Name = "TestNameDeviceTypeFirmWareAlert",
//                Description = "TestDescriptionDeviceTypeFirmWareAlert",
//                IsAlert = true,
//                DeviceTypeFirmwareId = _deviceTypeFirmwareId
//            };
//            return view;
//        }

//        [Fact]
//        public void Create()
//        {
//            //Arrange
//            CreateSeedData();
//            DeviceTypeFirmwareEventStateTypeViewModel view = GetViewModel();
//            AppUserModel? user = _contextCreator.GetUser();

//            //Act
//            ActionResult<APIResultDTO<DeviceTypeFirmwareEventStateTypeViewModel>> result = _controller.Create(_deviceTypeId, _deviceTypeFirmwareId, view).Result;

//            //Assert
//            result.Value.IsOk.Should().BeTrue();
//            result.Value.Value.Should().NotBeNull();
//            result.Value.Value.CreatedById.Should().Be(user.Id);
//            result.Value.Value.UpdatedById.Should().Be(user.Id);
//            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
//            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
//            result.Value.Value.Name.Should().Be("TestNameDeviceTypeFirmWareAlert");
//            result.Value.Value.Description.Should().Be("TestDescriptionDeviceTypeFirmWareAlert");
//            result.Value.Value.IsAlert.Should().BeTrue();
//        }

//        [Fact]
//        public void GetAllForDevice()
//        {
//            //Arrange
//            Create();

//            //Act
//            ActionResult<APIResultDTO<List<DeviceTypeFirmwareEventStateTypeViewModel>>> result = _controller.GetAllsForDevice(null, _deviceId).Result;

//            //Assert
//            result.Value.IsOk.Should().BeTrue();
//            result.Value.Value.Should().NotBeNull();
//            result.Value.Value.Count().Should().Be(1);
//        }

//        [Fact]
//        public void GetAllForDeviceGrid()
//        {
//            //Arrange
//            Create();

//            //Act
//            ActionResult<APIResultDTO<GridResult<DeviceTypeFirmwareEventStateTypeViewModel>>> result = _controller.GetAllsForDeviceGrid(null, _deviceId).Result;

//            //Assert
//            result.Value.IsOk.Should().BeTrue();
//            result.Value.Value.Should().NotBeNull();
//            result.Value.Value.Data.Should().NotBeNull();
//            result.Value.Value.Data.Count().Should().Be(1);
//        }
//    }
//}