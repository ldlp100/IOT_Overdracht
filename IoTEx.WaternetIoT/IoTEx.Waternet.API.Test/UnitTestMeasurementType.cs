

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
    public class UnitTestMeasurementType
    {
        private ContextCreator _contextCreator;
        private IoTDBContext _dbContext;
        private ILogger _logger;
        private IConfiguration _configuration;
        private MeasurementTypeController _controller;
        public UnitTestMeasurementType()
        {
            _contextCreator = new ContextCreator();
            _contextCreator.SetAdminUserContext();

            _dbContext = _contextCreator.CreateDatabaseContext().Result;
            
            _logger = A.Fake<ILogger>();
            _configuration = A.Fake<IConfiguration>();
            _controller = new MeasurementTypeController(_logger, _dbContext, _configuration);

            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = _contextCreator.GetHttpContext();
                        
        }
        
        private MeasurementTypeViewModel GetViewModel()
        {
            MeasurementTypeViewModel view = new MeasurementTypeViewModel()
            {
                Name = "TestNameMeasurementType",
                Description = "TestDescriptionMeasurementType",
                UnitTypeId = Guid.NewGuid()
            };
            return view;
        }
        
        [Fact]
        public void GetAll()
        {
            //Arrange
            Create();
            
            //Act
            ActionResult<APIResultDTO<List<MeasurementTypeViewModel>>> result = _controller.GetAlls(null).Result;
            
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
            ActionResult<APIResultDTO<GridResult<MeasurementTypeViewModel>>> result = _controller.GetAllsGrid(null).Result;
            
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
            MeasurementTypeModel? model = _dbContext.MeasurementTypes.FirstOrDefault();
            
            //Act
            ActionResult<APIResultDTO<MeasurementTypeViewModel>> result = _controller.Get(model.Id).Result;
            
            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }
        
        [Fact]
        public void Create()
        {
            //Arrange
            MeasurementTypeViewModel view = GetViewModel();
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<MeasurementTypeViewModel>> result = _controller.Create(view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now,TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameMeasurementType");
            result.Value.Value.Description.Should().Be("TestDescriptionMeasurementType");

        }

        [Fact]
        public void Update()
        {
            //Arrange
            Create();
            MeasurementTypeViewModel view = GetViewModel();
            MeasurementTypeModel model  = _dbContext.MeasurementTypes.FirstOrDefault(o => o.Name == view.Name);
            view.Name = "TestNameMeasurementTypeB";
            view.Description = "TestDescriptionMeasurementTypeB";
            view.Id = model.Id;
            AppUserModel? user = _contextCreator.GetUser();
            
            //Act
            ActionResult<APIResultDTO<MeasurementTypeViewModel>> result = _controller.Update(model.Id,view).Result;
            
            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameMeasurementTypeB");
            result.Value.Value.Description.Should().Be("TestDescriptionMeasurementTypeB");
        }

        [Fact]
        public void Delete()
        {
            //Arrange
            Create();
            MeasurementTypeModel? model = _dbContext.MeasurementTypes.FirstOrDefault();
            
            //Act
            ActionResult<APIResultDTO<MeasurementTypeViewModel>> result = _controller.Delete(model.Id).Result;
            
            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }
    }
}