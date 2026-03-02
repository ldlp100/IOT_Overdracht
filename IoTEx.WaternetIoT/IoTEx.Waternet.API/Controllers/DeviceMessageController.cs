
using Azure.Storage.Blobs;
using IoTEx.WaternetIoT.DAL;
using IoTEx.WaternetIoT.Model.DTOs;
using IoTEx.WaternetIoT.Model.DTOs.API;
using IoTEx.WaternetIoT.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Newtonsoft.Json;

namespace IoTEx.Waternet.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/deviceTypes/{deviceTypeId}/deviceBatchs/{deviceBatchId}/devices/{deviceId}/messages/")]

    public class DeviceMessageController : BaseController
    {
        protected BlobServiceClient _blobserviceClient;
        protected IKustoService _kustoService;

        
        public DeviceMessageController(ILogger logger, IoTDBContext context, IConfiguration configuration, IKustoService kustoService)
        {

            _dBcontext = context;
            _logger = logger;
            _configuration = configuration;
            _kustoService = kustoService;
        }

        [HttpPost("all")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<List<DeviceMessageViewModel>>>> GetAlls(
            APIRequestDTO request, Guid deviceTypeId, Guid deviceBatchId, Guid deviceId)
        {
            
            if (IsUserKnown())
            {
                int pageSize = (int)((request.PageSize==null)?10: request.PageSize);
                int skip = (int)((request.Page == null) ? 0 : request.Page);
                APIResultDTO<List<DeviceMessageViewModel>> result = new APIResultDTO<List<DeviceMessageViewModel>>();
                result.Value = _kustoService.GetMessagesForDevice(deviceId, skip, pageSize);
                
                result.IsOk = true;

                return result;
            }
            else
                return Unauthorized();
        }

        
        [HttpPost("all/grid")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<GridResult<DeviceMessageViewModel>>>> GetAllsGrid(
            APIRequestDTO request, Guid deviceTypeId, Guid deviceBatchId, Guid deviceId)
        {

            if (IsUserKnown())
            {
                int pageSize = (int)((request.PageSize == null) ? 10 : request.PageSize);
                int skip = (int)((request.Page == null) ? 0 : request.Page);
                APIResultDTO<GridResult<DeviceMessageViewModel>> result = new APIResultDTO<GridResult<DeviceMessageViewModel>>();
                result.Value = new GridResult<DeviceMessageViewModel>();
                List<DeviceMessageViewModel> data = new List<DeviceMessageViewModel>();
                bool isDesc = true;
                if (request.Sorts != null)
                {
                    APIRequestDTO.SortDesc sort = request.Sorts.FirstOrDefault(o => o.Member.ToLower() == "received");
                    if (sort != null)
                    {
                        isDesc = (sort != null && sort.Direction == APIRequestDTO.SortDesc.SortDirection.DESC);
                    }
                }
                result.Value.Data = _kustoService.GetMessagesForDevice(deviceId, skip, pageSize,isDesc);
                result.Value.Length = result.Value.Data.Count();
                result.IsOk = true;

                return result;
            }
            else
                return Unauthorized();
        }

        [HttpGet("{id}")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<DeviceMessageViewModel>>> Get(Guid id,
            Guid deviceTypeId, Guid deviceBatchId, Guid deviceId)
        {
            if (IsUserKnown())
            {

                APIResultDTO<DeviceMessageViewModel> result = new APIResultDTO<DeviceMessageViewModel>();
                
                result.IsOk = true;
                result.Value = _kustoService.GetMessageForDevice(deviceId, id);
            

                return result;
            }
            else
                return Unauthorized();
        }
        [HttpGet("{id}/content")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<DeviceMessageDTO>>> GetContent(Guid id,
            Guid deviceTypeId, Guid deviceBatchId, Guid deviceId)
        {
            if (IsUserKnown())
            {

                APIResultDTO<DeviceMessageDTO> result = new APIResultDTO<DeviceMessageDTO>();
                DeviceMessageViewModel  message = _kustoService.GetMessageForDevice(deviceId, id);
                if (string.IsNullOrEmpty(message.Content))
                {
                    result.IsOk = false;
                    result.Error = "No content found for message";
                    return result;
                }
                DeviceMessageDTO content = JsonConvert.DeserializeObject<DeviceMessageDTO>(message.Content);
                result.IsOk = true;
                result.Value = content;
                return result;
            }
            else
                return Unauthorized();
        }
        [HttpGet("last")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] {_RoleIoTExAdmin, _RoleProjectAdmin, _RoleProjectGuest, _RoleProjectReader }
        )]
        public async Task<ActionResult<APIResultDTO<DeviceMessageDTO>>> GetLast( Guid deviceTypeId, Guid deviceBatchId, Guid deviceId)
        {
            if (IsUserKnown())
            {

                APIResultDTO<DeviceMessageDTO> result = new APIResultDTO<DeviceMessageDTO>();
                DeviceMessageViewModel message = _kustoService.GetLastMessageForDevice(deviceId);
                if (message != null)
                {
                    if (string.IsNullOrEmpty(message.Content))
                    {
                        result.IsOk = false;
                        result.Error = "No content found for message";
                        return result;
                    }
                    DeviceMessageDTO content = JsonConvert.DeserializeObject<DeviceMessageDTO>(message.Content);
                    result.IsOk = true;
                    result.Value = content;
                    return result;
                }
                result.IsOk = false;
                result.Error = "NO MESSAGE FOR DEVICE";
                return result;
            }
            else
                return Unauthorized();
        }
    }
}
