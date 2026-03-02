

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
using System.Text.RegularExpressions;

namespace IoTEx.Waternet.API.Test
{
    public class UnitTestProject
    {
        private ContextCreator _contextCreator;
        private IoTDBContext _dbContext;
        private ILogger _logger;
        private IConfiguration _configuration;
        private ProjectController _controller;
        public UnitTestProject()
        {
            _contextCreator = new ContextCreator();
            _contextCreator.SetAdminUserContext();

            _dbContext = _contextCreator.CreateDatabaseContext().Result;

            _logger = A.Fake<ILogger>();
            _configuration = A.Fake<IConfiguration>();
            _controller = new ProjectController(_logger, _dbContext, _configuration);

            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = _contextCreator.GetHttpContext();

        }

        private ProjectViewModel GetViewModel()
        {
            ProjectViewModel view = new ProjectViewModel()
            {
                Name = "TestNameGroup",
                TargetDBString = "TestTargetDB",
                Description = "TestDescriptionGroup",
                Latitude = 2,
                Longitude = 2
            };
            return view;
        }

        [Fact]
        public void GetAll()
        {
            //Arrange
            Create();

            //Act
            ActionResult<APIResultDTO<List<ProjectViewModel>>> result = _controller.GetAlls(null).Result;

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
            ActionResult<APIResultDTO<GridResult<ProjectViewModel>>> result = _controller.GetAllsGrid(null).Result;

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
            ProjectModel? model = _dbContext.Projects.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<ProjectViewModel>> result = _controller.Get(model.Id).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }

        [Fact]
        public void Create()
        {
            //Arrange
            ProjectViewModel view = GetViewModel();
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<ProjectViewModel>> result = _controller.Create(view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameGroup");
            result.Value.Value.TargetDBString.Should().Be("TestTargetDB");
            result.Value.Value.Description.Should().Be("TestDescriptionGroup");
            result.Value.Value.Latitude.Should().Be(2);
            result.Value.Value.Longitude.Should().Be(2);
        }

        [Fact]
        public void Update()
        {
            //Arrange
            Create();
            ProjectViewModel view = GetViewModel();
            ProjectModel model = _dbContext.Projects.FirstOrDefault(o => o.Name == view.Name);
            view.Name = "TestNameGroupB";
            view.TargetDBString = "TestTargetDBB";
            view.Description = "TestDescriptionGroupB";
            view.Latitude = 3;
            view.Longitude = 3;
            view.Id = model.Id;
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<ProjectViewModel>> result = _controller.Update(model.Id, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameGroupB");
            result.Value.Value.TargetDBString.Should().Be("TestTargetDBB");
            result.Value.Value.Description.Should().Be("TestDescriptionGroupB");
            result.Value.Value.Latitude.Should().Be(3);
            result.Value.Value.Longitude.Should().Be(3);
        }

        [Fact]
        public void Delete()
        {
            //Arrange
            Create();
            ProjectModel? model = _dbContext.Projects.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<ProjectViewModel>> result = _controller.Delete(model.Id).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }
    }
}