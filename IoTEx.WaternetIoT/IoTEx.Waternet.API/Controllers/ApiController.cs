
using IoTEx.WaternetIoT.DAL;
using IoTEx.WaternetIoT.Model.DTOs.API;
using IoTEx.WaternetIoT.Model.PortalModels;
using IoTEx.WaternetIoT.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web.Resource;

namespace IoTEx.Waternet.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/")]
    public class ApiController : BaseController
    {
        public ApiController(ILogger logger, IoTDBContext context, IConfiguration configuration, IKustoService kustoService)
        {

            _dBcontext = context;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet("sayHello")]
        [RequiredScopeOrAppPermission(
    AcceptedScope = new string[] { },
    AcceptedAppPermission = new string[] { _RoleIoTExAdmin, _RoleProjectAdmin, _RoleProjectGuest, _RoleProjectReader }
)]
        public async Task<ActionResult<APIResultDTO<string>>> SayHello()
        {
            APIResultDTO<string> result = new APIResultDTO<string>();
            result.IsOk = true;
            result.Value = $"Hello {this.HttpContext?.User?.Identity?.Name}";
            return result;
        }


        [HttpGet("sayHelloUser")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin, _RoleProjectAdmin, _RoleProjectGuest, _RoleProjectReader }
        )]
        public async Task<ActionResult<APIResultDTO<string>>> SayHelloUser()
        {
            
            APIResultDTO<string> result = new APIResultDTO<string>();
            try
            {
                AppUserModel user = _dBcontext?.AppUsers.First();
                if (user != null)
                {
                    if (IsUserKnown())
                    {
                        result.IsOk = true;
                        result.Value = this.HttpContext.User.Identity.Name + " Known in Environment";
                    }
                    else
                    {
                        result.IsOk = false;
                        result.Error = this.HttpContext.User.Identity.Name + " Not Known in Environment"; ;
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsOk = false;
                result.Error = ex.Message + ex.StackTrace;
            }
            return result;
        }
    }
}
