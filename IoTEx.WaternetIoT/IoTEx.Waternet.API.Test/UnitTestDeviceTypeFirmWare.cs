

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
    public class UnitTestDeviceTypeFirmWare
    {
        private ContextCreator _contextCreator;
        private IoTDBContext _dbContext;
        private ILogger _logger;
        private IConfiguration _configuration;
        private DeviceTypeFirmwareController _controller;
        private Guid _deviceTypeId;
        private Guid _parserId;
        private Guid _supplierId;

        public UnitTestDeviceTypeFirmWare()
        {
            _contextCreator = new ContextCreator();
            _contextCreator.SetAdminUserContext();

            _dbContext = _contextCreator.CreateDatabaseContext().Result;

            _logger = A.Fake<ILogger>();
            _configuration = A.Fake<IConfiguration>();
            _controller = new DeviceTypeFirmwareController(_logger, _dbContext, _configuration);

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
                SupplierId = _supplierId,
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
        }
        private DeviceTypeFirmwareViewModel GetViewModel()
        {
            DeviceTypeFirmwareViewModel view = new DeviceTypeFirmwareViewModel()
            {
                Name = "TestNameDeviceTypeFirmWare",
                Description = "TestDescriptionDeviceTypeFirmWare",
                IsUsed = true,
                DeviceTypeId = _deviceTypeId,
                IsConfigurable = true,
                ParserId = _parserId
            };
            return view;
        }

        [Fact]
        public void GetAll()
        {
            //Arrange
            Create();

            //Act
            ActionResult<APIResultDTO<List<DeviceTypeFirmwareViewModel>>> result = _controller.GetAlls(null, _deviceTypeId).Result;

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
            ActionResult<APIResultDTO<GridResult<DeviceTypeFirmwareViewModel>>> result = _controller.GetAllsGrid(null, _deviceTypeId).Result;

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
            DeviceTypeFirmwareModel? model = _dbContext.DeviceTypeFirmwares.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<DeviceTypeFirmwareViewModel>> result = _controller.Get(model.Id, _deviceTypeId).Result;

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
            DeviceTypeFirmwareViewModel view = GetViewModel();
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<DeviceTypeFirmwareViewModel>> result = _controller.Create(_deviceTypeId, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameDeviceTypeFirmWare");
            result.Value.Value.Description.Should().Be("TestDescriptionDeviceTypeFirmWare");
            result.Value.Value.IsUsed.Should().BeTrue();
            result.Value.Value.IsConfigurable.Should().BeTrue();

        }

        [Fact]
        public void Update()
        {
            //Arrange
            Create();
            DeviceTypeFirmwareViewModel view = GetViewModel();
            DeviceTypeFirmwareModel model = _dbContext.DeviceTypeFirmwares.FirstOrDefault(o => o.Name == view.Name);
            view.Name = "TestNameDeviceTypeFirmWareB";
            view.Description = "TestDescriptionDeviceTypeFirmWareB";
            view.IsUsed = false;
            view.IsConfigurable = false;
            view.Id = model.Id;
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<DeviceTypeFirmwareViewModel>> result = _controller.Update(_deviceTypeId, model.Id, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameDeviceTypeFirmWareB");
            result.Value.Value.Description.Should().Be("TestDescriptionDeviceTypeFirmWareB");
            result.Value.Value.IsUsed.Should().BeFalse();
            result.Value.Value.IsConfigurable.Should().BeFalse();
        }

        [Fact]
        public void Delete()
        {
            //Arrange
            Create();
            DeviceTypeFirmwareModel? model = _dbContext.DeviceTypeFirmwares.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<DeviceTypeFirmwareViewModel>> result = _controller.Delete(_deviceTypeId, model.Id).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }
    }
}