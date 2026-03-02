
using Azure.Storage.Blobs;
using IoTEx.WaternetIoT.DAL;
using IoTEx.WaternetIoT.Model.DTOs;
using IoTEx.WaternetIoT.Model.DTOs.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;


namespace IoTEx.Waternet.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/devices/{deviceId}/telemetries/")]

    public class DeviceTelemetryController : BaseController
    {
        protected BlobServiceClient _blobserviceClient;
        protected IKustoService _kustoService;

        public DeviceTelemetryController(ILogger logger, IoTDBContext context, IConfiguration configuration, IKustoService kustoService)
        {

            _dBcontext = context;
            _logger = logger;
            _configuration = configuration;
            _kustoService = kustoService;
        }

        //[HttpPost("all")]
        //[RequiredScopeOrAppPermission(
        //    AcceptedScope = new string[] { },
        //    AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        //)]
        //public async Task<ActionResult<APIResultDTO<List<DeviceTelemetryDTO>>>> GetAlls(
        //    APIRequestDTO request, Guid deviceTypeId, Guid deviceBatchId, Guid deviceId)
        //{
            
        //    if (IsUserKnown())
        //    {
        //        APIResultDTO<List<DeviceTelemetryDTO>> result = new APIResultDTO<List<DeviceTelemetryDTO>>();
        //        result.Value = _kustoService.GetTelemetriesForDevice(deviceId);
                
        //        result.IsOk = true;

        //        return result;
        //    }
        //    else
        //        return Unauthorized();
        //}
        [HttpGet("{window}/{startDate}/{endDate}")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] {_RoleIoTExAdmin, _RoleProjectAdmin, _RoleProjectGuest, _RoleProjectReader }
        )]
        public async Task<ActionResult<APIResultDTO<List<DeviceTelemetryAggregateDTO>>>> GetWindowAlls(
            Guid deviceId, DateTime startDate, DateTime endDate, string window )
        {

            if (IsUserKnown())
            {
                APIResultDTO<List<DeviceTelemetryAggregateDTO>> result = new APIResultDTO<List<DeviceTelemetryAggregateDTO>>();
                result.Value = _kustoService.GetAggregateTelemetriesForDevice(deviceId, startDate, endDate, window);

                result.IsOk = true;

                return result;
            }
            else
                return Unauthorized();
        }


    }
}
