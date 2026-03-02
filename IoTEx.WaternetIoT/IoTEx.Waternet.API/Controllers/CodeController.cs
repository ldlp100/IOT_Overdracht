
using IoTEx.Waternet.API.Common;
using IoTEx.WaternetIoT.DAL;
using IoTEx.WaternetIoT.Model.DTOs.API;
using IoTEx.WaternetIoT.Model.PortalModels;
using IoTEx.WaternetIoT.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web.Resource;

namespace IoTEx.Waternet.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/codes/")]
    public class CodeController : BaseController
    {
        public CodeController(ILogger logger, IoTDBContext context, IConfiguration configuration)
        {

            _dBcontext = context;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet("generateDataDefinition")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult> GenerateDataDefinition()
        {

            if (IsUserKnown())
            {
                CodeGenerator cg = new CodeGenerator();
                string result = cg.GenerateDataDefinition(_dBcontext);
                Response.ContentType = "Application/pdf";
                Response.Headers.Add("Content-Disposition", String.Format("attachment;filename=\"{0}\"", "code.txt"));
                Response.WriteAsync(result);
                return Ok();
            }
            else
                return Unauthorized();
        }

        // LATER
        [HttpPost("generateStorage")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult> GenerateStorage()
        {

            if (IsUserKnown())
            {

                return Ok();
            }
            else
                return Unauthorized();
        }
    }


}
