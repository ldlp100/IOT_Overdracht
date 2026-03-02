

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
    public class UnitTestSubEventStateType
    {
        private ContextCreator _contextCreator;
        private IoTDBContext _dbContext;
        private ILogger _logger;
        private IConfiguration _configuration;
        private DeviceTypeFirmwareSubStateController _controller;
        public UnitTestSubEventStateType()
        {
            _contextCreator = new ContextCreator();
            _contextCreator.SetAdminUserContext();

            _dbContext = _contextCreator.CreateDatabaseContext().Result;

            _logger = A.Fake<ILogger>();
            _configuration = A.Fake<IConfiguration>();
            _controller = new DeviceTypeFirmwareSubStateController(_logger, _dbContext, _configuration);

            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = _contextCreator.GetHttpContext();

        }

        private DeviceTypeEventState2SubStateTypeViewModel GetViewModel()
        {
            DeviceTypeEventState2SubStateTypeViewModel view = new DeviceTypeEventState2SubStateTypeViewModel()
            {
                Name = "TestNameSubEventStateType",
                Description = "TestDescriptionSubEventStateType",
                Value = 2,
                DeviceTypeEventStateTypeId = Guid.NewGuid()
            };
            return view;
        }

        [Fact]
        public void GetAll()
        {
            //Arrange
            Create();

            //Act
            ActionResult<APIResultDTO<List<DeviceTypeEventState2SubStateTypeViewModel>>> result = _controller.GetAlls(null).Result;

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
            ActionResult<APIResultDTO<GridResult<DeviceTypeEventState2SubStateTypeViewModel>>> result = _controller.GetAllsGrid(null).Result;

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
            DeviceTypeEventState2SubStateTypeModel? model = _dbContext.DeviceTypeEventState2SubStateTypes.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<DeviceTypeEventState2SubStateTypeViewModel>> result = _controller.Get(model.Id).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }

        [Fact]
        public void Create()
        {
            //Arrange
            DeviceTypeEventState2SubStateTypeViewModel view = GetViewModel();
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<DeviceTypeEventState2SubStateTypeViewModel>> result = _controller.Create(view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameSubEventStateType");
            result.Value.Value.Description.Should().Be("TestDescriptionSubEventStateType");
            result.Value.Value.Value.Should().Be(2);

        }

        [Fact]
        public void Update()
        {
            //Arrange
            Create();
            DeviceTypeEventState2SubStateTypeViewModel view = GetViewModel();
            DeviceTypeEventState2SubStateTypeModel model = _dbContext.DeviceTypeEventState2SubStateTypes.FirstOrDefault(o => o.Name == view.Name);
            view.Name = "TestNameEventStateTypeB";
            view.Description = "TestDescriptionSubEventStateTypeB";
            view.Value = 3;
            view.Id = model.Id;
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<DeviceTypeEventState2SubStateTypeViewModel>> result = _controller.Update(model.Id, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameEventStateTypeB");
            result.Value.Value.Description.Should().Be("TestDescriptionSubEventStateTypeB");
            result.Value.Value.Value.Should().Be(3);
        }

        [Fact]
        public void Delete()
        {
            //Arrange
            Create();
            DeviceTypeEventState2SubStateTypeModel? model = _dbContext.DeviceTypeEventState2SubStateTypes.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<DeviceTypeEventState2SubStateTypeViewModel>> result = _controller.Delete(model.Id).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }
    }
}