

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
    public class UnitTestAttachment
    {
        private ContextCreator _contextCreator;
        private IoTDBContext _dbContext;
        private ILogger _logger;
        private IConfiguration _configuration;
        private AttachmentController _controller;
        private Guid _ObjectId = Guid.NewGuid();
        public UnitTestAttachment()
        {
            _contextCreator = new ContextCreator();
            _contextCreator.SetAdminUserContext();

            _dbContext = _contextCreator.CreateDatabaseContext().Result;
            
            _logger = A.Fake<ILogger>();
            _configuration = A.Fake<IConfiguration>();
            _controller = new AttachmentController(_logger, _dbContext, _configuration);

            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = _contextCreator.GetHttpContext();
                        
        }
        
        private AttachmentViewModel GetViewModel()
        {
            AttachmentViewModel view = new AttachmentViewModel()
            {
                Name = "TestNameAttachment",
                Description = "TestDescriptionAttachment",
                ObjectId = _ObjectId,
                ObjectType = AttachmentModel.ObjectTypeEnum.PROJECT,
                AttachmentType = AttachmentModel.AttachmentTypeEnum.DOCUMENT,
                URL = "TestURLAttachment",
                Size = 1
            };
            return view;
        }
        
        [Fact]
        public void GetAll()
        {
            //Arrange
            Create();
            
            //Act
            ActionResult<APIResultDTO<List<AttachmentViewModel>>> result = _controller.GetAlls(null, AttachmentModel.ObjectTypeEnum.PROJECT,_ObjectId).Result;
            
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
            ActionResult<APIResultDTO<GridResult<AttachmentViewModel>>> result = _controller.GetAllsGrid(null, AttachmentModel.ObjectTypeEnum.PROJECT, _ObjectId).Result;
            
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
            AttachmentModel? model = _dbContext.Attachments.FirstOrDefault();
            
            //Act
            ActionResult<APIResultDTO<AttachmentViewModel>> result = _controller.Get(model.Id).Result;
            
            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }
        
        [Fact]
        public void Create()
        {
            //Arrange
            AttachmentViewModel view = GetViewModel();
            AppUserModel? user = _contextCreator.GetUser();

            //Act
            ActionResult<APIResultDTO<AttachmentViewModel>> result = _controller.Create(view).Result;

            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now,TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameAttachment");
            result.Value.Value.Description.Should().Be("TestDescriptionAttachment");
            result.Value.Value.URL.Should().Be("TestURLAttachment");
            result.Value.Value.Size.Should().Be(1);

        }

        [Fact]
        public void Update()
        {
            //Arrange
            Create();
            AttachmentViewModel view = GetViewModel();
            AttachmentModel model  = _dbContext.Attachments.FirstOrDefault(o => o.Name == view.Name);
            view.Name = "TestNameAttachmentB";
            view.Description = "TestDescriptionAttachmentB";
            view.URL = "TestURLAttachmentB";
            view.Size = 2;
            view.Id = model.Id;
            AppUserModel? user = _contextCreator.GetUser();
            
            //Act
            ActionResult<APIResultDTO<AttachmentViewModel>> result = _controller.Update(model.Id,view).Result;
            
            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.CreatedById.Should().Be(user.Id);
            result.Value.Value.UpdatedById.Should().Be(user.Id);
            result.Value.Value.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Updated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(60));
            result.Value.Value.Name.Should().Be("TestNameAttachmentB");
            result.Value.Value.Description.Should().Be("TestDescriptionAttachmentB");
            result.Value.Value.URL.Should().Be("TestURLAttachmentB");
            result.Value.Value.Size.Should().Be(2);
        }

        [Fact]
        public void Delete()
        {
            //Arrange
            Create();
            AttachmentModel? model = _dbContext.Attachments.FirstOrDefault();
            
            //Act
            ActionResult<APIResultDTO<AttachmentViewModel>> result = _controller.Delete(model.Id).Result;
            
            //Assert
            result.Value.IsOk.Should().BeTrue();
            result.Value.Value.Should().NotBeNull();
            result.Value.Value.Id.Should().Be(model.Id);
        }

    }
}