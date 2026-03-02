
using Azure.Core;
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
    [Route("/api/deviceTypes/{deviceTypeId}/firmwares/{firmwareId}/configurations/")]

    public class DeviceTypeFirmwareConfigurationController : BaseController
    {
        public DeviceTypeFirmwareConfigurationController(ILogger logger, IoTDBContext context, IConfiguration configuration)
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
        public async Task<ActionResult<APIResultDTO<List<DeviceTypeFirmwareConfigurationViewModel>>>> GetAlls(
            APIRequestDTO request, Guid deviceTypeId, Guid firmwareId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceTypeFirmwareConfigurationViewModel.DefineMapper());
                IQueryable<DeviceTypeFirmwareConfigurationModel> instances = _dBcontext.DeviceTypeFirmware2Configurations
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o=>o.DeviceTypeFirmware)
                    .Where(o => o.DeviceTypeFirmwareId == firmwareId && o.DeviceTypeFirmware.DeviceTypeId==deviceTypeId);

                APIResultDTO<List<DeviceTypeFirmwareConfigurationViewModel>> result = new APIResultDTO<List<DeviceTypeFirmwareConfigurationViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<DeviceTypeFirmwareConfigurationModel, DeviceTypeFirmwareConfigurationViewModel>
                    .DT(request, instances)
                    .Select(o => new DeviceTypeFirmwareConfigurationViewModel(o))
                    .ToList();

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
        public async Task<ActionResult<APIResultDTO<GridResult<DeviceTypeFirmwareConfigurationViewModel>>>> GetAllsGrid(
            APIRequestDTO request, Guid deviceTypeId, Guid firmwareId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceTypeFirmwareConfigurationViewModel.DefineMapper());
                IQueryable<DeviceTypeFirmwareConfigurationModel> instances = _dBcontext.DeviceTypeFirmware2Configurations
                    .Include(o => o.CreatedBy).Include(o => o.UpdatedBy).Include(o => o.DeviceTypeFirmware)
                    .Where(o => o.DeviceTypeFirmwareId == firmwareId && o.DeviceTypeFirmware.DeviceTypeId == deviceTypeId);

                APIResultDTO<GridResult<DeviceTypeFirmwareConfigurationViewModel>> result = new APIResultDTO<GridResult<DeviceTypeFirmwareConfigurationViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<DeviceTypeFirmwareConfigurationModel, DeviceTypeFirmwareConfigurationViewModel>
                    .DTGrid(request, instances, o => new DeviceTypeFirmwareConfigurationViewModel(o));

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
        public async Task<ActionResult<APIResultDTO<DeviceTypeFirmwareConfigurationViewModel>>> Get(Guid id, Guid deviceTypeId, 
            Guid firmwareId)
        {
            if (IsUserKnown())
            {
                DeviceTypeFirmwareConfigurationModel instance = await _dBcontext.DeviceTypeFirmware2Configurations
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.DeviceTypeFirmware)
                    .FirstAsync(o => o.Id == id && o.DeviceTypeFirmwareId == firmwareId && o.DeviceTypeFirmware.DeviceTypeId == deviceTypeId);

                if (instance != null)
                {

                    APIResultDTO<DeviceTypeFirmwareConfigurationViewModel> result = new APIResultDTO<DeviceTypeFirmwareConfigurationViewModel>();
                    result.IsOk = true;
                    result.Value = new DeviceTypeFirmwareConfigurationViewModel(instance);
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

        [HttpPost]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<DeviceTypeFirmwareConfigurationViewModel>>> Create(Guid deviceTypeId, 
            Guid firmwareId, DeviceTypeFirmwareConfigurationViewModel dtoInstance)
        {
            if (IsUserKnown())
            {

                DeviceTypeFirmwareConfigurationModel instance = dtoInstance.Create(GetAppUser());
                instance.DeviceTypeFirmwareId = firmwareId;

                _dBcontext.DeviceTypeFirmware2Configurations.Add(instance);
                _dBcontext.SaveChanges();
                _dBcontext.Entry<DeviceTypeFirmwareConfigurationModel>(instance).Reference(o => o.UpdatedBy).Load();
                _dBcontext.Entry<DeviceTypeFirmwareConfigurationModel>(instance).Reference(o => o.CreatedBy).Load();
                _dBcontext.Entry<DeviceTypeFirmwareConfigurationModel>(instance).Reference(o => o.DeviceTypeFirmware).Load();

                APIResultDTO<DeviceTypeFirmwareConfigurationViewModel> result = new APIResultDTO<DeviceTypeFirmwareConfigurationViewModel>();
                result.IsOk = true;
                result.Value = new DeviceTypeFirmwareConfigurationViewModel(instance);
                return result;
            }
            else
                return Unauthorized();
        }

        [HttpPut("{id}")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<DeviceTypeFirmwareConfigurationViewModel>>> Update(Guid deviceTypeId, 
            Guid firmwareId, Guid id, DeviceTypeFirmwareConfigurationViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                DeviceTypeFirmwareConfigurationModel instance = _dBcontext.DeviceTypeFirmware2Configurations
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.DeviceTypeFirmware)
                    .FirstOrDefault(o => o.Id == id);

                if (instance == null)
                {
                    return NotFound();
                }

                instance = dtoInstance.Update(instance, GetAppUser());
                instance.DeviceTypeFirmwareId = firmwareId;
                _dBcontext.Entry(instance).State = EntityState.Modified;

                try
                {
                    await _dBcontext.SaveChangesAsync();
                    _dBcontext.Entry<DeviceTypeFirmwareConfigurationModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<DeviceTypeFirmwareConfigurationModel>(instance).Reference(o => o.CreatedBy).Load();
                    _dBcontext.Entry<DeviceTypeFirmwareConfigurationModel>(instance).Reference(o => o.DeviceTypeFirmware).Load();
                    APIResultDTO<DeviceTypeFirmwareConfigurationViewModel> result = new APIResultDTO<DeviceTypeFirmwareConfigurationViewModel>();
                    result.IsOk = true;
                    result.Value = new DeviceTypeFirmwareConfigurationViewModel(instance);
                    return result;
                }
                catch
                {
                    throw;
                }
            }
            else
                return Unauthorized();

        }

        [HttpDelete("{id}")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<DeviceTypeFirmwareConfigurationViewModel>>> Delete(Guid deviceTypeId, 
            Guid firmwareId, Guid id)
        {
            if (IsUserKnown())
            {
                DeviceTypeFirmwareConfigurationModel instance = await _dBcontext.DeviceTypeFirmware2Configurations
                    .FirstOrDefaultAsync(o => o.Id == id && o.DeviceTypeFirmwareId == firmwareId && o.DeviceTypeFirmware.DeviceTypeId == deviceTypeId);
                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.DeviceTypeFirmware2Configurations.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<DeviceTypeFirmwareConfigurationViewModel> result = new APIResultDTO<DeviceTypeFirmwareConfigurationViewModel>();
                result.IsOk = true;
                result.Value = new DeviceTypeFirmwareConfigurationViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }

        [HttpGet("/api/devices/{deviceId}/configurations/all")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<List<DeviceTypeFirmwareConfigurationViewModel>>>> GetConfigurationsForDeviceAlls(APIRequestDTO request,Guid id, Guid deviceId)
        {
            if (IsUserKnown())
            {
                DeviceModel device = _dBcontext.Devices.FirstOrDefault(d => d.Id == deviceId);
                if (device != null)
                {
                    ManageMapper(request, DeviceTypeFirmwareConfigurationViewModel.DefineMapper());

                    IQueryable<DeviceTypeFirmwareConfigurationModel> instances = _dBcontext.DeviceTypeFirmware2Configurations
                        .Include(o => o.CreatedBy)
                        .Include(o => o.UpdatedBy)
                        .Include(o => o.DeviceTypeFirmware)
                        .Where(o => o.Id == id && o.DeviceTypeFirmwareId == device.DeviceTypeFirmwareId && 
                                        o.DeviceTypeFirmware.DeviceTypeId == device.DeviceBatch.DeviceTypeId);

                    if (instances != null)
                    {
                        APIResultDTO<List<DeviceTypeFirmwareConfigurationViewModel>> result = new APIResultDTO<List<DeviceTypeFirmwareConfigurationViewModel>>();
                        result.IsOk = true;
                        result.Value = APIRequester<DeviceTypeFirmwareConfigurationModel, DeviceTypeFirmwareConfigurationViewModel>
                            .DT(request, instances)
                            .Select(o => new DeviceTypeFirmwareConfigurationViewModel(o))
                            .ToList();
                        return result;
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            else
                return Unauthorized();
        }

        [HttpGet("/api/devices/{deviceId}/configurations/all/grid")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<GridResult<DeviceTypeFirmwareConfigurationViewModel>>>> GetConfigurationsForDeviceAllsGrid(APIRequestDTO request, Guid id, Guid deviceId)
        {
            if (IsUserKnown())
            {
                DeviceModel device = _dBcontext.Devices.FirstOrDefault(d => d.Id == deviceId);
                if (device != null)
                {
                    ManageMapper(request, DeviceTypeFirmwareConfigurationViewModel.DefineMapper());

                    IQueryable<DeviceTypeFirmwareConfigurationModel> instances = _dBcontext.DeviceTypeFirmware2Configurations
                        .Include(o => o.CreatedBy)
                        .Include(o => o.UpdatedBy)
                        .Include(o => o.DeviceTypeFirmware)
                        .Where(o => o.Id == id && o.DeviceTypeFirmwareId == device.DeviceTypeFirmwareId &&
                                        o.DeviceTypeFirmware.DeviceTypeId == device.DeviceBatch.DeviceTypeId);

                    if (instances != null)
                    {
                        APIResultDTO<GridResult<DeviceTypeFirmwareConfigurationViewModel>> result = new APIResultDTO<GridResult<DeviceTypeFirmwareConfigurationViewModel>>();
                        result.IsOk = true;
                        result.Value = APIRequester<DeviceTypeFirmwareConfigurationModel, DeviceTypeFirmwareConfigurationViewModel>
                            .DTGrid(request, instances, o => new DeviceTypeFirmwareConfigurationViewModel(o));
                        return result;
                    }
                    else
                    {
                        return NotFound();
                    }
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
