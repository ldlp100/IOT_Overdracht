
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
    public class UnitTestDeviceTypeFirmWareAlert
    {
        private ContextCreator _contextCreator;
        private IoTDBContext _dbContext;
        private ILogger _logger;
        private IConfiguration _configuration;
        private DeviceTypeFirmwareAlertController _controller;
        private Guid _deviceTypeId;
        private Guid _deviceTypeFirmwareId;
        private Guid _supplierId;
        private Guid _parserId;

        public UnitTestDeviceTypeFirmWareAlert()
        {
            _contextCreator = new ContextCreator();
            _contextCreator.SetAdminUserContext();

            _dbContext = _contextCreator.CreateDatabaseContext().Result;

            _logger = A.Fake<ILogger>();
            _configuration = A.Fake<IConfiguration>();
            _controller = new DeviceTypeFirmwareAlertController(_logger, _dbContext, _configuration);

            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = _contextCreator.GetHttpContext();

        }

        private void CreateSeedData()
        {
            SupplierModel supplier = new SupplierModel()
            {
                Name = "TestNameDeviceType",
                Description = "TestDescriptionDeviceType",
                TelNumber = "TestTelNumberDeviceType",
                Created = DateTime.Now,
                Updated = DateTime.Now,
                CreatedById = Guid.NewGuid(),
                UpdatedById = Guid.NewGuid()
            };
            _dbContext.Suppliers.Add(supplier);
            _dbContext.SaveChanges();
            _supplierId = supplier.Id;

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

            DeviceTypeFirmwareModel DeviceTypeFirmWare = new DeviceTypeFirmwareModel()
            {
                Name = "TestNameDeviceTypeFirmWare",
                Description = "TestDescriptionDeviceTypeFirmWare",
                IsUsed = true,
                DeviceTypeId = _deviceTypeId,
                IsConfigurable = true,
                ParserId = _parserId,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                CreatedById = Guid.NewGuid(),
                UpdatedById = Guid.NewGuid()
            };
            _dbContext.DeviceTypeFirmwares.Add(DeviceTypeFirmWare);
            _dbContext.SaveChanges();
            _deviceTypeFirmwareId = DeviceTypeFirmWare.Id;
        }

        private DeviceTypeFirmwareEventStateTypeViewModel GetViewModel()
        {
            DeviceTypeFirmwareEventStateTypeViewModel view = new DeviceTypeFirmwareEventStateTypeViewModel()
            {
                Name = "TestNameDeviceTypeFirmWareAlert",
                Description = "TestDescriptionDeviceTypeFirmWareAlert",
                IsAlert = true,
                DeviceTypeFirmwareId = _deviceTypeFirmwareId,
                DeviceTypeId = _deviceTypeId
            };
            return view;
        }

        [Fact]
        public void GetAll()
        {
            //Arrange
            Create();

            //Act
            ActionResult<APIResultDTO<List<DeviceTypeFirmwareEventStateTypeViewModel>>> result = _controller.GetAlls(null, _deviceTypeId, _deviceTypeFirmwareId).Result;

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
            ActionResult<APIResultDTO<GridResult<DeviceTypeFirmwareEventStateTypeViewModel>>> result = _controller.GetAllsGrid(null, _deviceTypeId, _deviceTypeFirmwareId).Result;

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
            DeviceTypeFirmwareEventStateTypeModel? model = _dbContext.DeviceTypeFirmware2EventStateTypes.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<DeviceTypeFirmwareEventStateTypeViewModel>> result = _controller.Get(model.Id, _deviceTypeId, _deviceTypeFirmwareId).Result;

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
            DeviceTypeFirmwareEventStateTypeViewModel view = GetViewModel();
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<DeviceTypeFirmwareEventStateTypeViewModel>> result = _controller.Create(_deviceTypeId, _deviceTypeFirmwareId, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameDeviceTypeFirmWareAlert");
            result.Value.Value.Description.Should().Be("TestDescriptionDeviceTypeFirmWareAlert");
            result.Value.Value.IsAlert.Should().BeTrue();
        }

        [Fact]
        public void Update()
        {
            //Arrange
            Create();
            DeviceTypeFirmwareEventStateTypeViewModel view = GetViewModel();
            DeviceTypeFirmwareEventStateTypeModel model = _dbContext.DeviceTypeFirmware2EventStateTypes.FirstOrDefault(o => o.Name == view.Name);
            view.Name = "TestNameDeviceTypeFirmWareAlertB";
            view.Description = "TestDescriptionDeviceTypeFirmWareAlertB";
            view.Id = model.Id;
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<DeviceTypeFirmwareEventStateTypeViewModel>> result = _controller.Update(_deviceTypeId, _deviceTypeFirmwareId, model.Id, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameDeviceTypeFirmWareAlertB");
            result.Value.Value.Description.Should().Be("TestDescriptionDeviceTypeFirmWareAlertB");
            result.Value.Value.IsAlert.Should().BeTrue();
        }

        [Fact]
        public void Delete()
        {
            //Arrange
            Create();
            DeviceTypeFirmwareEventStateTypeModel? model = _dbContext.DeviceTypeFirmware2EventStateTypes.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<DeviceTypeFirmwareEventStateTypeViewModel>> result = _controller.Delete(_deviceTypeId, _deviceTypeFirmwareId, model.Id).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }
    }
}