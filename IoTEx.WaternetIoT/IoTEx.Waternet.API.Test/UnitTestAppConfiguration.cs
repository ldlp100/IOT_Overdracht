

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
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace IoTEx.Waternet.API.Test
{
    public class UnitTestAppConfiguration
    {
        private ContextCreator _contextCreator;
        private IoTDBContext _dbContext;
        private ILogger _logger;
        private IConfiguration _configuration;
        private AppConfigurationController _controller;
        public UnitTestAppConfiguration()
        {
            _contextCreator = new ContextCreator();
            _contextCreator.SetAdminUserContext();

            _dbContext = _contextCreator.CreateDatabaseContext().Result;

            _logger = A.Fake<ILogger>();
            _configuration = A.Fake<IConfiguration>();
            _controller = new AppConfigurationController(_logger, _dbContext, _configuration);

            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = _contextCreator.GetHttpContext();

        }

        private AppConfigurationViewModel GetViewModel()
        {
            AppConfigurationViewModel view = new AppConfigurationViewModel()
            {
                Name = "TestNameAppConfiguration",
                Description = "TestDescriptionAppConfiguration",
                Value = "TestValueAppConfiguration",
                IsDeletable = true,
                IsModifiable = true
            };
            return view;
        }

        [Fact]
        public void GetAll()
        {
            //Arrange
            Create();

            //Act
            ActionResult<APIResultDTO<List<AppConfigurationViewModel>>> result = _controller.GetAlls(null).Result;

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
            ActionResult<APIResultDTO<GridResult<AppConfigurationViewModel>>> result = _controller.GetAllsGrid(null).Result;

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
            AppConfigurationModel? model = _dbContext.AppConfigurations.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<AppConfigurationViewModel>> result = _controller.Get(model.Id).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }

        [Fact]
        public void Create()
        {
            //Arrange
            AppConfigurationViewModel view = GetViewModel();
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<AppConfigurationViewModel>> result = _controller.Create(view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameAppConfiguration");
            result.Value.Value.Description.Should().Be("TestDescriptionAppConfiguration");
            result.Value.Value.Value.Should().Be("TestValueAppConfiguration");
            result.Value.Value.IsDeletable.Should().BeTrue();
            result.Value.Value.IsModifiable.Should().BeTrue();
        }

        [Fact]
        public void Update()
        {
            //Arrange
            Create();
            AppConfigurationViewModel view = GetViewModel();
            AppConfigurationModel model = _dbContext.AppConfigurations.FirstOrDefault(o => o.Name == view.Name);
            view.Name = "TestNameAppConfigurationB";
            view.Description = "TestDescriptionAppConfigurationB";
            view.Value = "TestValueAppConfigurationB";
            view.IsDeletable = false;
            view.IsModifiable = false;
            view.Id = model.Id;
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<AppConfigurationViewModel>> result = _controller.Update(model.Id, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameAppConfigurationB");
            result.Value.Value.Description.Should().Be("TestDescriptionAppConfigurationB");
            result.Value.Value.Value.Should().Be("TestValueAppConfigurationB");
            result.Value.Value.IsDeletable.Should().BeFalse();
            result.Value.Value.IsModifiable.Should().BeFalse();
        }

        [Fact]
        public void Delete()
        {
            //Arrange
            Create();
            AppConfigurationModel? model = _dbContext.AppConfigurations.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<AppConfigurationViewModel>> result = _controller.Delete(model.Id).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }

    }
}