
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
    public class UnitTestDevice
    {
        private ContextCreator _contextCreator;
        private IoTDBContext _dbContext;
        private ILogger _logger;
        private IConfiguration _configuration;
        private DeviceController _controller;
        private Guid _deviceTypeId;
        private Guid _deviceBatchId;
        private Guid _parserId;
        private Guid _deviceTypeFirmwareId;
        public UnitTestDevice()
        {
            _contextCreator = new ContextCreator();
            _contextCreator.SetAdminUserContext();

            _dbContext = _contextCreator.CreateDatabaseContext().Result;

            _logger = A.Fake<ILogger>();
            _configuration = A.Fake<IConfiguration>();
            _controller = new DeviceController(_logger, _dbContext, _configuration, null,null);

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
                Name = "TestNameDeviceTypeFirmware",
                Description = "TestDescriptionDeviceTypeFirmware",
                IsUsed = true,
                ParserId = _parserId,
                DeviceTypeId = _deviceTypeId,
                IsConfigurable = true,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                CreatedById = Guid.NewGuid(),
                UpdatedById = Guid.NewGuid()
            };
            _dbContext.DeviceTypeFirmwares.Add(deviceTypeFirmware);
            _dbContext.SaveChanges();
            _deviceTypeFirmwareId = deviceTypeFirmware.Id;
        }

        private DeviceViewModel GetViewModel()
        {
            DeviceViewModel view = new DeviceViewModel()
            {
                Name = "TestNameDevice",
                LastMessage = DateTime.Now,
                IsActive = true,
                IsTraced = true,
                SerialNr = "TestSerialNrDevice",
                IsChanged = true,
                HarwareVersion = "TestHarwareVersionDevice",
                Long = 2,
                Lat = 2,
                Altitude = 2,
                AssetUID = "TestAssetUIDDevice",
                SigfoxPAC = "TestSigfoxPACDevice",
                SigFoxId = "TestSigFoxIdDevice",
                SigfoxAPPKey = "TestSigfoxAPPKeyDevice",
                LORA_DEVEUI = "TestLORA_DEVEUIDevice",
                LORA_OTAA_APPEUI = "TestLORA_OTAA_APPEUIDevice",
                LORA_OTAA_APPKEY = "TestLORA_OTAA_APPKEYDevice",
                IMEI = "TestIMEIDevice",
                IMEIAppKey = "TestIMEIAppKeyDevice",
                ICCID = "TestICCIDDevice",
                PublishedDocDate = DateTime.Now,
                InstalledDate = DateTime.Now,
                DeviceTypeId = _deviceTypeId,
                DeviceBatchId = _deviceBatchId,
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
            ActionResult<APIResultDTO<List<DeviceViewModel>>> result = _controller.GetAlls(null, _deviceTypeId, _deviceBatchId).Result;

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
            ActionResult<APIResultDTO<GridResult<DeviceViewModel>>> result = _controller.GetAllsGrid(null, _deviceTypeId, _deviceBatchId).Result;

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
            DeviceModel? model = _dbContext.Devices.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<DeviceViewModel>> result = _controller.Get(model.Id, _deviceTypeId, _deviceBatchId).Result;

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
            DeviceViewModel view = GetViewModel();
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<DeviceViewModel>> result = _controller.Create(_deviceBatchId, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameDevice");
            result.Value.Value.IsActive.Should().BeTrue();
            result.Value.Value.IsTraced.Should().BeTrue();
            result.Value.Value.SerialNr.Should().Be("TestSerialNrDevice");
            result.Value.Value.IsChanged.Should().BeTrue();
            result.Value.Value.HarwareVersion.Should().Be("TestHarwareVersionDevice");
            //result.Value.Value.FirmWareVersion.Should().Be("TestFirmWareVersionDevice");
            result.Value.Value.Long.Should().Be(2);
            result.Value.Value.Lat.Should().Be(2);
            result.Value.Value.Altitude.Should().Be(2);
            result.Value.Value.AssetUID.Should().Be("TestAssetUIDDevice");
            result.Value.Value.SigfoxPAC.Should().Be("TestSigfoxPACDevice");
            result.Value.Value.SigFoxId.Should().Be("TestSigFoxIdDevice");
            result.Value.Value.SigfoxAPPKey.Should().Be("TestSigfoxAPPKeyDevice");
            result.Value.Value.LORA_DEVEUI.Should().Be("TestLORA_DEVEUIDevice");
            result.Value.Value.LORA_OTAA_APPEUI.Should().Be("TestLORA_OTAA_APPEUIDevice");
            result.Value.Value.LORA_OTAA_APPKEY.Should().Be("TestLORA_OTAA_APPKEYDevice");
            //result.Value.Value.LORA_ABP_APPSKey.Should().Be("TestLORA_ABP_APPSKeyDevice");
            //result.Value.Value.LORA_ABP_NwkSKey.Should().Be("TestLORA_ABP_NwkSKeyDevice");
            //result.Value.Value.LORA_ABP_devADDR.Should().Be("TestLORA_ABP_devADDRDevice");
            result.Value.Value.IMEI.Should().Be("TestIMEIDevice");
            result.Value.Value.IMEIAppKey.Should().Be("TestIMEIAppKeyDevice");
            result.Value.Value.ICCID.Should().Be("TestICCIDDevice");
        }

        [Fact]
        public void Update()
        {
            //Arrange
            Create();
            DeviceViewModel view = GetViewModel();
            DeviceModel model = _dbContext.Devices.FirstOrDefault(o => o.Name == view.Name);
            view.Name = "TestNameDeviceB";
            view.IsActive = false;
            view.IsTraced = false;
            view.SerialNr = "TestSerialNrDeviceB";
            view.IsChanged = false;
            view.HarwareVersion = "TestHarwareVersionDeviceB";
            view.Long = 3;
            view.Lat = 3;
            view.Altitude = 3;
            view.AssetUID = "TestAssetUIDDeviceB";
            view.SigfoxPAC = "TestSigfoxPACDeviceB";
            view.SigFoxId = "TestSigFoxIdDeviceB";
            view.SigfoxAPPKey = "TestSigfoxAPPKeyDeviceB";
            view.LORA_DEVEUI = "TestLORA_DEVEUIDeviceB";
            view.LORA_OTAA_APPEUI = "TestLORA_OTAA_APPEUIDeviceB";
            view.LORA_OTAA_APPKEY = "TestLORA_OTAA_APPKEYDeviceB";
            view.IMEI = "TestIMEIDeviceB";
            view.IMEIAppKey = "TestIMEIAppKeyDeviceB";
            view.ICCID = "TestICCIDDeviceB";
            view.Id = model.Id;
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<DeviceViewModel>> result = _controller.Update(_deviceBatchId, model.Id, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameDeviceB");
            result.Value.Value.IsActive.Should().BeFalse();
            result.Value.Value.IsTraced.Should().BeFalse();
            result.Value.Value.SerialNr.Should().Be("TestSerialNrDeviceB");
            result.Value.Value.IsChanged.Should().BeFalse();
            result.Value.Value.HarwareVersion.Should().Be("TestHarwareVersionDeviceB");
            //result.Value.Value.FirmWareVersion.Should().Be("TestFirmWareVersionDeviceB");
            result.Value.Value.Long.Should().Be(3);
            result.Value.Value.Lat.Should().Be(3);
            result.Value.Value.Altitude.Should().Be(3);
            result.Value.Value.AssetUID.Should().Be("TestAssetUIDDeviceB");
            result.Value.Value.SigfoxPAC.Should().Be("TestSigfoxPACDeviceB");
            result.Value.Value.SigFoxId.Should().Be("TestSigFoxIdDeviceB");
            result.Value.Value.SigfoxAPPKey.Should().Be("TestSigfoxAPPKeyDeviceB");
            result.Value.Value.LORA_DEVEUI.Should().Be("TestLORA_DEVEUIDeviceB");
            result.Value.Value.LORA_OTAA_APPEUI.Should().Be("TestLORA_OTAA_APPEUIDeviceB");
            result.Value.Value.LORA_OTAA_APPKEY.Should().Be("TestLORA_OTAA_APPKEYDeviceB");
            //result.Value.Value.LORA_ABP_APPSKey.Should().Be("TestLORA_ABP_APPSKeyDeviceB");
            //result.Value.Value.LORA_ABP_NwkSKey.Should().Be("TestLORA_ABP_NwkSKeyDeviceB");
            //result.Value.Value.LORA_ABP_devADDR.Should().Be("TestLORA_ABP_devADDRDeviceB");
            result.Value.Value.IMEI.Should().Be("TestIMEIDeviceB");
            result.Value.Value.IMEIAppKey.Should().Be("TestIMEIAppKeyDeviceB");
            result.Value.Value.ICCID.Should().Be("TestICCIDDeviceB");
        }

        [Fact]
        public void Delete()
        {
            //Arrange
            Create();
            DeviceModel? model = _dbContext.Devices.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<DeviceViewModel>> result = _controller.Delete(_deviceTypeId, _deviceBatchId, model.Id).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }
    }
}