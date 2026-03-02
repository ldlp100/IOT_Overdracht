using IoTEx.WaternetIoT.DAL;
using IoTEx.WaternetIoT.Model.PortalModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IoTEx.Waternet.API.Test.Generic
{
    public class ContextCreator
    {
        public enum UserTypeEnum { Admin, Project};
        public UserTypeEnum UserType { get; set; }
        public IoTDBContext dbContext { get; set; }
        public void SetAdminUserContext()
        {
            UserType= UserTypeEnum.Admin;
        }
        public void SetProjectUserContext()
        {
            UserType= UserTypeEnum.Project;
        }
        public AppUserModel? GetUser()
        {
            AppUserModel? appUser = null;
            if (UserType == UserTypeEnum.Admin)
            {
                appUser = dbContext.AppUsers.FirstOrDefault(o => o.Username == "admin@iotexcellence.com");
            }
            else if (UserType == UserTypeEnum.Project)
            {
                appUser = dbContext.AppUsers.FirstOrDefault(o => o.Username == "project@iotexcellence.com");
            }
            return appUser;
        }

        private void CreateSeedData()
        {
            dbContext.AppUsers.Add(new WaternetIoT.Model.PortalModels.AppUserModel()
            {
                Username = "admin@iotexcellence.com",
                Role = WaternetIoT.Model.PortalModels.AppUserModel.RoleEnum.Admin
            });
            dbContext.AppUsers.Add(new WaternetIoT.Model.PortalModels.AppUserModel()
            {
                Username = "project1@iotexcellence.com",
                Role = WaternetIoT.Model.PortalModels.AppUserModel.RoleEnum.Contributor
            });
            dbContext.SaveChanges();
        }
        public async Task<IoTDBContext> CreateDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<IoTDBContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            dbContext = new IoTDBContext(options);

            dbContext.Database.EnsureCreated();

            if (await dbContext.AppUsers.CountAsync() <= 0)
            {
                //Create Seed Data
                CreateSeedData();
            }
            return dbContext;
        }

        public HttpContext GetHttpContext()
        {
            
            HttpContext httpContext = new DefaultHttpContext();
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "username"),
                new Claim(ClaimTypes.NameIdentifier, "userId"),
                new Claim("name", "User Tester"),
                new Claim("preferred_username",GetUser().Username)
            };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            httpContext.User = claimsPrincipal;
            return httpContext;
        }
    }
}
