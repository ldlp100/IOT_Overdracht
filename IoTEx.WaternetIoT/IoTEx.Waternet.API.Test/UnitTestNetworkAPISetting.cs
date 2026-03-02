
using FakeItEasy;
using FluentAssertions;
using IoTEx.Waternet.API.Controllers;
using IoTEx.Waternet.API.Test.Generic;
using IoTEx.WaternetIoT.DAL;
using IoTEx.WaternetIoT.Model.DTOs.API;
using IoTEx.WaternetIoT.Model.PortalModels;
using IoTEx.WaternetIoT.Model.ViewModels;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace IoTEx.Waternet.API.Test
{
    public class UnitTestNetworkAPISetting
    {
        private ContextCreator _contextCreator;
        private IoTDBContext _dbContext;
        private ILogger _logger;
        private IConfiguration _configuration;
        private NetworkAPISettingController _controller;
        private Guid _networkAPIId;
        public UnitTestNetworkAPISetting()
        {
            _contextCreator = new ContextCreator();
            _contextCreator.SetAdminUserContext();

            _dbContext = _contextCreator.CreateDatabaseContext().Result;

            _logger = A.Fake<ILogger>();
            _configuration = A.Fake<IConfiguration>();
            _controller = new NetworkAPISettingController(_logger, _dbContext, _configuration);

            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = _contextCreator.GetHttpContext();

        }

        private void CreateSeedData()
        {
            NetworkAPIModel networkAPI = new NetworkAPIModel()
            {
                Name = "TestNameNetworkAPISetting",
                Created=DateTime.Now,
                Updated = DateTime.Now,
                CreatedById = Guid.NewGuid(),
                UpdatedById = Guid.NewGuid()
            };
            _dbContext.NetworkAPIs.Add(networkAPI);
            _dbContext.SaveChanges();
            _networkAPIId = networkAPI.Id;
        }

        private NetworkAPISettingViewModel GetViewModel()
        {
            NetworkAPISettingViewModel view = new NetworkAPISettingViewModel()
            {
                Name = "TestNameNetworkAPISetting",
                Description = "TestDescriptionNetworkApiSetting",
                Value = "TestValueNetworkApiSetting",
                SecretId = "TestSecretIdNetworkApiSetting",
                IsSecret = true,
                IsDeviceInfo = true,
                NetworkAPIId = _networkAPIId
            };
            return view;
        }

        [Fact]
        public void GetAll()
        {
            //Arrange
            Create();

            //Act
            ActionResult<APIResultDTO<List<NetworkAPISettingViewModel>>> result = _controller.GetAlls(null, _networkAPIId).Result;

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
            ActionResult<APIResultDTO<GridResult<NetworkAPISettingViewModel>>> result = _controller.GetAllsGrid(null, _networkAPIId).Result;

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
            NetworkAPISettingModel? model = _dbContext.NetworkAPISettings.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<NetworkAPISettingViewModel>> result = _controller.Get(model.Id, _networkAPIId).Result;

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
            NetworkAPISettingViewModel view = GetViewModel();
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<NetworkAPISettingViewModel>> result = _controller.Create(_networkAPIId,view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameNetworkAPISetting");
            result.Value.Value.Description.Should().Be("TestDescriptionNetworkApiSetting");
            result.Value.Value.SecretId.Should().Be("TestSecretIdNetworkApiSetting");
            result.Value.Value.IsSecret.Should().BeTrue();
            result.Value.Value.IsDeviceInfo.Should().BeTrue();
        }

        [Fact]
        public void Update()
        {
            //Arrange
            Create();
            NetworkAPISettingViewModel view = GetViewModel();
            NetworkAPISettingModel model = _dbContext.NetworkAPISettings.FirstOrDefault(o => o.Name == view.Name);
            view.Name = "TestNameNetworkAPISettingB";
            view.Description = "TestDescriptionNetworkApiSettingB";
            view.SecretId = "TestSecretIdNetworkApiSettingB";
            view.IsSecret = false;
            view.IsDeviceInfo = false;
            view.Id = model.Id;
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<NetworkAPISettingViewModel>> result = _controller.Update(_networkAPIId,model.Id, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameNetworkAPISettingB");
            result.Value.Value.Description.Should().Be("TestDescriptionNetworkApiSettingB");
            result.Value.Value.SecretId.Should().Be("TestSecretIdNetworkApiSettingB");
            result.Value.Value.IsSecret.Should().BeFalse();
            result.Value.Value.IsDeviceInfo.Should().BeFalse();
        }

        [Fact]
        public void Delete()
        {
            //Arrange
            Create();
            NetworkAPISettingModel? model = _dbContext.NetworkAPISettings.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<NetworkAPISettingViewModel>> result = _controller.Delete(_networkAPIId,model.Id).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }
    }
}