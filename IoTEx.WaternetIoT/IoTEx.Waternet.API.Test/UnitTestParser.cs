

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
    public class UnitTestParser
    {
        private ContextCreator _contextCreator;
        private IoTDBContext _dbContext;
        private ILogger _logger;
        private IConfiguration _configuration;
        private ParserController _controller;
        public UnitTestParser()
        {
            _contextCreator = new ContextCreator();
            _contextCreator.SetAdminUserContext();

            _dbContext = _contextCreator.CreateDatabaseContext().Result;
            
            _logger = A.Fake<ILogger>();
            _configuration = A.Fake<IConfiguration>();
            _controller = new ParserController(_logger, _dbContext, _configuration);

            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = _contextCreator.GetHttpContext();
                        
        }
        
        private ParserViewModel GetViewModel()
        {
            ParserViewModel view = new ParserViewModel()
            {
                Name = "TestNameParser",
                Description = "TestDescriptionParser",
                ClassName = "TestClassNameParser"
            };
            return view;
        }
        
        [Fact]
        public void GetAll()
        {
            //Arrange
            Create();
            
            //Act
            ActionResult<APIResultDTO<List<ParserViewModel>>> result = _controller.GetAlls(null).Result;
            
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
            ActionResult<APIResultDTO<GridResult<ParserViewModel>>> result = _controller.GetAllsGrid(null).Result;
            
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
            ParserModel? model = _dbContext.Parsers.FirstOrDefault();
            
            //Act
            ActionResult<APIResultDTO<ParserViewModel>> result = _controller.Get(model.Id).Result;
            
            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }
        
        [Fact]
        public void Create()
        {
            //Arrange
            ParserViewModel view = GetViewModel();
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<ParserViewModel>> result = _controller.Create(view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now,TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameParser");
            result.Value.Value.Description.Should().Be("TestDescriptionParser");
            result.Value.Value.ClassName.Should().Be("TestClassNameParser");

        }

        [Fact]
        public void Update()
        {
            //Arrange
            Create();
            ParserViewModel view = GetViewModel();
            ParserModel model  = _dbContext.Parsers.FirstOrDefault(o => o.Name == view.Name);
            view.Name = "TestNameParserB";
            view.Description = "TestDescriptionParserB";
            view.ClassName = "TestClassNameParserB";
            view.Id = model.Id;
            AppUserModel? user = _contextCreator.GetUser();
            
            //Act
            ActionResult<APIResultDTO<ParserViewModel>> result = _controller.Update(model.Id,view).Result;
            
            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameParserB");
            result.Value.Value.Description.Should().Be("TestDescriptionParserB");
            result.Value.Value.ClassName.Should().Be("TestClassNameParserB");
        }

        [Fact]
        public void Delete()
        {
            //Arrange
            Create();
            ParserModel? model = _dbContext.Parsers.FirstOrDefault();
            
            //Act
            ActionResult<APIResultDTO<ParserViewModel>> result = _controller.Delete(model.Id).Result;
            
            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }
    }
}