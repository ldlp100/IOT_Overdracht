
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
    [Route("devices/{deviceId}/eventStateTypes/")]
    public class DeviceTypeFirmwareEventStateTypeController : BaseController
    {
        public DeviceTypeFirmwareEventStateTypeController(ILogger logger, IoTDBContext context, IConfiguration configuration)
        {

            _dBcontext = context;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost("all")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<List<DeviceTypeFirmwareEventStateTypeViewModel>>>> GetAllsForDevice(
            APIRequestDTO request, Guid deviceId)
        {

            if (IsUserKnown())
            {
                DeviceModel device = _dBcontext.Devices.FirstOrDefault(o => o.Id == deviceId);
                if (device != null)
                {
                    DeviceTypeFirmwareEventStateTypeModel model = _dBcontext.DeviceTypeFirmware2EventStateTypes.First();
                    ManageMapper(request, DeviceTypeFirmwareEventStateTypeViewModel.DefineMapper());
                    IQueryable<DeviceTypeFirmwareEventStateTypeModel> instances = _dBcontext.DeviceTypeFirmware2EventStateTypes
                        .Include(o => o.CreatedBy)
                        .Include(o => o.UpdatedBy)
                        .Include(o => o.DeviceTypeFirmware)
                        .Where(o => o.DeviceTypeFirmwareId == device.DeviceTypeFirmwareId);

                    APIResultDTO<List<DeviceTypeFirmwareEventStateTypeViewModel>> result = new APIResultDTO<List<DeviceTypeFirmwareEventStateTypeViewModel>>();
                    result.IsOk = true;
                    result.Value = APIRequester<DeviceTypeFirmwareEventStateTypeModel, DeviceTypeFirmwareEventStateTypeViewModel>
                        .DT(request, instances)
                        .Select(o => new DeviceTypeFirmwareEventStateTypeViewModel(o))
                        .ToList();
                    return result;
                }
                else
                {
                    return NotFound();
                }
            }
            else
                return Unauthorized();
        }

        [HttpPost("all/grid")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<GridResult<DeviceTypeFirmwareEventStateTypeViewModel>>>> GetAllsForDeviceGrid(
            APIRequestDTO request, Guid deviceId)
        {

            if (IsUserKnown())
            {
                DeviceModel device = _dBcontext.Devices.FirstOrDefault(o => o.Id == deviceId);
                if (device != null)
                {
                    ManageMapper(request, DeviceTypeFirmwareEventStateTypeViewModel.DefineMapper());
                    IQueryable<DeviceTypeFirmwareEventStateTypeModel> instances = _dBcontext.DeviceTypeFirmware2EventStateTypes
                        .Include(o => o.CreatedBy)
                        .Include(o => o.UpdatedBy)
                        .Include(o => o.DeviceTypeFirmware)
                        .Where(o => o.DeviceTypeFirmwareId == device.DeviceTypeFirmwareId);

                    APIResultDTO<GridResult<DeviceTypeFirmwareEventStateTypeViewModel>> result = new APIResultDTO<GridResult<DeviceTypeFirmwareEventStateTypeViewModel>>();
                    result.IsOk = true;
                    result.Value = APIRequester<DeviceTypeFirmwareEventStateTypeModel, DeviceTypeFirmwareEventStateTypeViewModel>
                        .DTGrid(request, instances, o => new DeviceTypeFirmwareEventStateTypeViewModel(o));

                    return result;
                }
                else
                {
                    return NotFound();
                }
            }
            else
                return Unauthorized();
        }
    }
}
