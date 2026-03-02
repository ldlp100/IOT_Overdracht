
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
using Newtonsoft.Json.Linq;

namespace IoTEx.Waternet.API.Test
{
    public class UnitTestDevice2NetworkSetting
    {
        private ContextCreator _contextCreator;
        private IoTDBContext _dbContext;
        private ILogger _logger;
        private IConfiguration _configuration;
        private Device2NetworkSettingController _controller;
        private Guid _deviceTypeId;
        private Guid _deviceBatchId;
        private Guid _deviceId;
        private Guid _networkAPIId;
        private Guid _settingId;
        public UnitTestDevice2NetworkSetting()
        {
            _contextCreator = new ContextCreator();
            _contextCreator.SetAdminUserContext();

            _dbContext = _contextCreator.CreateDatabaseContext().Result;

            _logger = A.Fake<ILogger>();
            _configuration = A.Fake<IConfiguration>();
            _controller = new Device2NetworkSettingController(_logger, _dbContext, _configuration);

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

            NetworkAPIModel networkAPI = new NetworkAPIModel()
            {
                Name = "TestNameNetworkAPISetting",                
                Created = DateTime.Now,
                Updated = DateTime.Now,
                CreatedById = Guid.NewGuid(),
                UpdatedById = Guid.NewGuid()
            };
            _dbContext.NetworkAPIs.Add(networkAPI);
            _dbContext.SaveChanges();
            _networkAPIId = networkAPI.Id;

            NetworkAPISettingModel setting = new NetworkAPISettingModel()
            {
                Name = "TestNameNetworkAPISetting",
                Description = "TestDescriptionNetworkApiSetting",
                Value = "TestValueNetworkApiSetting",
                SecretId = "TestSecretIdNetworkApiSetting",
                IsSecret = true,
                IsDeviceInfo = true,
                NetworkAPIId = _networkAPIId,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                CreatedById = Guid.NewGuid(),
                UpdatedById = Guid.NewGuid()
            };

            _dbContext.NetworkAPISettings.Add(setting);
            _dbContext.SaveChanges();
            _settingId = setting.Id;
        }

        private Device2SNetworkAPISettingViewModel GetViewModel()
        {
            Device2SNetworkAPISettingViewModel view = new Device2SNetworkAPISettingViewModel()
            {
                DeviceId = _deviceId,
                SettingId = _settingId,
                Value = "TestValueDevice2SNetworkSetting"
            };
            return view;
        }

        [Fact]
        public void GetAll()
        {
            //Arrange
            Create();

            //Act
            ActionResult<APIResultDTO<List<Device2SNetworkAPISettingViewModel>>> result = _controller.GetAlls(null, _deviceId).Result;

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
            ActionResult<APIResultDTO<GridResult<Device2SNetworkAPISettingViewModel>>> result = _controller.GetAllsGrid(null, _deviceId).Result;

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
            Device2SNetworkAPISettingModel? model = _dbContext.Device2SNetworkAPISettings.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<Device2SNetworkAPISettingViewModel>> result = _controller.Get(model.Id, _deviceId).Result;

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
            Device2SNetworkAPISettingViewModel view = GetViewModel();
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<Device2SNetworkAPISettingViewModel>> result = _controller.Create(_deviceId, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Value.Should().Be("TestValueDevice2SNetworkSetting");
        }

        [Fact]
        public void Update()
        {
            //Arrange
            Create();
            Device2SNetworkAPISettingViewModel view = GetViewModel();
            Device2SNetworkAPISettingModel model = _dbContext.Device2SNetworkAPISettings.FirstOrDefault(o => o.DeviceId == view.DeviceId);
            view.Value = "TestValueDevice2SNetworkSettingB";
            view.Id = model.Id;
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<Device2SNetworkAPISettingViewModel>> result = _controller.Update(_deviceId, model.Id, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Value.Should().Be("TestValueDevice2SNetworkSettingB");
        }

        [Fact]
        public void Delete()
        {
            //Arrange
            Create();
            Device2SNetworkAPISettingModel? model = _dbContext.Device2SNetworkAPISettings.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<Device2SNetworkAPISettingViewModel>> result = _controller.Delete(_deviceId, model.Id).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }
    }
}