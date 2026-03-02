
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
    public class UnitTestUser2Project
    {
        private ContextCreator _contextCreator;
        private IoTDBContext _dbContext;
        private ILogger _logger;
        private IConfiguration _configuration;
        private User2ProjectController _controller;
        private Guid _groupId;
        private Guid _userId;

        public UnitTestUser2Project()
        {
            _contextCreator = new ContextCreator();
            _contextCreator.SetAdminUserContext();

            _dbContext = _contextCreator.CreateDatabaseContext().Result;

            _logger = A.Fake<ILogger>();
            _configuration = A.Fake<IConfiguration>();
            _controller = new User2ProjectController(_logger, _dbContext, _configuration);

            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = _contextCreator.GetHttpContext();

        }

        private void CreateSeedData()
        {
            ProjectModel group = new ProjectModel()
            {
                Name = "TestNameGroup",
                TargetDBString = "TestTargetDB",
                Description = "TestDescriptionGroup",
                Latitude = 2,
                Longitude = 2,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                CreatedById = Guid.NewGuid(),
                UpdatedById = Guid.NewGuid()
            };
            _dbContext.Projects.Add(group);
            _dbContext.SaveChanges();
            _groupId = group.Id;

            _dbContext.SaveChanges();
        }

        private User2ProjectViewModel GetViewModel()
        {
            User2ProjectViewModel view = new User2ProjectViewModel()
            {
                ProjectId = _groupId,
                UserId = _contextCreator.GetUser().Id
            };
            return view;
        }

        [Fact]
        public void GetAll()
        {
            //Arrange
            Create();

            //Act
            ActionResult<APIResultDTO<List<User2ProjectViewModel>>> result = _controller.GetAlls(null, _groupId).Result;

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
            ActionResult<APIResultDTO<GridResult<User2ProjectViewModel>>> result = _controller.GetAllsGrid(null, _groupId).Result;

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
            User2ProjectModel? model = _dbContext.User2Projects.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<User2ProjectViewModel>> result = _controller.Get(model.Id, _groupId).Result;

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
            User2ProjectViewModel view = GetViewModel();
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<User2ProjectViewModel>> result = _controller.Create(_groupId, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
        }

        [Fact]
        public void Update()
        {
            //Arrange
            Create();
            User2ProjectViewModel view = GetViewModel();
            User2ProjectModel model = _dbContext.User2Projects.FirstOrDefault(o => o.ProjectId == view.ProjectId);
            view.Id = model.Id;
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<User2ProjectViewModel>> result = _controller.Update(_groupId, model.Id, view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
        }

        [Fact]
        public void Delete()
        {
            //Arrange
            Create();
            User2ProjectModel? model = _dbContext.User2Projects.FirstOrDefault();

            //Act
            ActionResult<APIResultDTO<User2ProjectViewModel>> result = _controller.Delete(_groupId, model.Id).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }

        [Fact]
        public void GetMyProjectAll()
        {
            //Arrange
            Create();

            //Act
            ActionResult<APIResultDTO<List<User2ProjectViewModel>>> result = _controller.GetMyProjectAlls(null).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Count().Should().Be(1);
        }

        [Fact]
        public void GetMyProjectAllGrid()
        {
            //Arrange
            Create();

            //Act
            ActionResult<APIResultDTO<GridResult<User2ProjectViewModel>>> result = _controller.GetMyProjectAllsGrid(null).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Data.Should().NotBeNull();
            result.Value.Value.Data.Count().Should().Be(1);
        }
    }
}