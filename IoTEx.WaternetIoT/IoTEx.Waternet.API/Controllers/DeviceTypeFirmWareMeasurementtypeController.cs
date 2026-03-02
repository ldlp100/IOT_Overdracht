
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
    [Route("/api/deviceTypes/{deviceTypeId}/firmwares/{firmwareId}/measurements/")]

    public class DeviceTypeFirmwareMeasurementTypeController : BaseController
    {
        public DeviceTypeFirmwareMeasurementTypeController(ILogger logger, IoTDBContext context, IConfiguration configuration)
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
        public async Task<ActionResult<APIResultDTO<List<DeviceTypeFirmwareMeasurementTypeViewModel>>>> GetAlls(
            APIRequestDTO request, Guid deviceTypeId, Guid firmwareId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceTypeFirmwareMeasurementTypeViewModel.DefineMapper());
                IQueryable<DeviceTypeFirmwareMeasurementTypeModel> instances = _dBcontext.DeviceTypeFirmware2MeasurementTypes
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.DeviceTypeFirmware)
                    .Include(o => o.UnitType)
                    .Where(o => o.DeviceTypeFirmwareId == firmwareId && o.DeviceTypeFirmware.DeviceTypeId==deviceTypeId);

                APIResultDTO<List<DeviceTypeFirmwareMeasurementTypeViewModel>> result = new APIResultDTO<List<DeviceTypeFirmwareMeasurementTypeViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<DeviceTypeFirmwareMeasurementTypeModel, DeviceTypeFirmwareMeasurementTypeViewModel>
                    .DT(request, instances)
                    .Select(o => new DeviceTypeFirmwareMeasurementTypeViewModel(o))
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
        public async Task<ActionResult<APIResultDTO<GridResult<DeviceTypeFirmwareMeasurementTypeViewModel>>>> GetAllsGrid(
            APIRequestDTO request, Guid deviceTypeId, Guid firmwareId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceTypeFirmwareMeasurementTypeViewModel.DefineMapper());
                IQueryable<DeviceTypeFirmwareMeasurementTypeModel> instances = _dBcontext.DeviceTypeFirmware2MeasurementTypes
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.DeviceTypeFirmware)
                    .Include(o => o.UnitType)
                    .Where(o => o.DeviceTypeFirmwareId == firmwareId && o.DeviceTypeFirmware.DeviceTypeId == deviceTypeId);

                APIResultDTO<GridResult<DeviceTypeFirmwareMeasurementTypeViewModel>> result = new APIResultDTO<GridResult<DeviceTypeFirmwareMeasurementTypeViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<DeviceTypeFirmwareMeasurementTypeModel, DeviceTypeFirmwareMeasurementTypeViewModel>
                    .DTGrid(request, instances, o => new DeviceTypeFirmwareMeasurementTypeViewModel(o));

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
        public async Task<ActionResult<APIResultDTO<DeviceTypeFirmwareMeasurementTypeViewModel>>> Get(Guid id, Guid deviceTypeId, 
            Guid firmwareId)
        {
            if (IsUserKnown())
            {
                DeviceTypeFirmwareMeasurementTypeModel instance = await _dBcontext.DeviceTypeFirmware2MeasurementTypes
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.DeviceTypeFirmware)
                    .Include(o => o.UnitType)
                    .FirstAsync(o => o.Id == id && o.DeviceTypeFirmwareId == firmwareId && o.DeviceTypeFirmware.DeviceTypeId == deviceTypeId);

                if (instance != null)
                {

                    APIResultDTO<DeviceTypeFirmwareMeasurementTypeViewModel> result = new APIResultDTO<DeviceTypeFirmwareMeasurementTypeViewModel>();
                    result.IsOk = true;
                    result.Value = new DeviceTypeFirmwareMeasurementTypeViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceTypeFirmwareMeasurementTypeViewModel>>> Create(Guid deviceTypeId, 
            Guid firmwareId, DeviceTypeFirmwareMeasurementTypeViewModel dtoInstance)
        {
            if (IsUserKnown())
            {

                DeviceTypeFirmwareMeasurementTypeModel instance = dtoInstance.Create(GetAppUser());
                instance.DeviceTypeFirmwareId = firmwareId;

                _dBcontext.DeviceTypeFirmware2MeasurementTypes.Add(instance);
                _dBcontext.SaveChanges();
                _dBcontext.Entry<DeviceTypeFirmwareMeasurementTypeModel>(instance).Reference(o => o.UpdatedBy).Load();
                _dBcontext.Entry<DeviceTypeFirmwareMeasurementTypeModel>(instance).Reference(o => o.CreatedBy).Load();
                _dBcontext.Entry<DeviceTypeFirmwareMeasurementTypeModel>(instance).Reference(o => o.DeviceTypeFirmware).Load();
                _dBcontext.Entry<DeviceTypeFirmwareMeasurementTypeModel>(instance).Reference(o => o.UnitType).Load();

                APIResultDTO<DeviceTypeFirmwareMeasurementTypeViewModel> result = new APIResultDTO<DeviceTypeFirmwareMeasurementTypeViewModel>();
                result.IsOk = true;
                result.Value = new DeviceTypeFirmwareMeasurementTypeViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceTypeFirmwareMeasurementTypeViewModel>>> Update(Guid deviceTypeId, 
            Guid firmwareId, Guid id, DeviceTypeFirmwareMeasurementTypeViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                DeviceTypeFirmwareMeasurementTypeModel instance = _dBcontext.DeviceTypeFirmware2MeasurementTypes
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.DeviceTypeFirmware)
                    .Include(o => o.UnitType)
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
                    _dBcontext.Entry<DeviceTypeFirmwareMeasurementTypeModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<DeviceTypeFirmwareMeasurementTypeModel>(instance).Reference(o => o.CreatedBy).Load();
                    _dBcontext.Entry<DeviceTypeFirmwareMeasurementTypeModel>(instance).Reference(o => o.DeviceTypeFirmware).Load();
                    _dBcontext.Entry<DeviceTypeFirmwareMeasurementTypeModel>(instance).Reference(o => o.UnitType).Load();
                    APIResultDTO<DeviceTypeFirmwareMeasurementTypeViewModel> result = new APIResultDTO<DeviceTypeFirmwareMeasurementTypeViewModel>();
                    result.IsOk = true;
                    result.Value = new DeviceTypeFirmwareMeasurementTypeViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceTypeFirmwareMeasurementTypeViewModel>>> Delete(Guid deviceTypeId, 
            Guid firmwareId, Guid id)
        {
            if (IsUserKnown())
            {
                DeviceTypeFirmwareMeasurementTypeModel instance = await _dBcontext.DeviceTypeFirmware2MeasurementTypes
                    .FirstOrDefaultAsync(o => o.Id == id && o.DeviceTypeFirmwareId == firmwareId && o.DeviceTypeFirmware.DeviceTypeId == deviceTypeId);
                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.DeviceTypeFirmware2MeasurementTypes.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<DeviceTypeFirmwareMeasurementTypeViewModel> result = new APIResultDTO<DeviceTypeFirmwareMeasurementTypeViewModel>();
                result.IsOk = true;
                result.Value = new DeviceTypeFirmwareMeasurementTypeViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }

        [HttpPost("devices/{deviceId}/measurements/all")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<List<DeviceTypeFirmwareMeasurementTypeViewModel>>>> GetAllsForDevice(
            APIRequestDTO request, Guid deviceId)
        {

            if (IsUserKnown())
            {
                DeviceModel device = _dBcontext.Devices.FirstOrDefault(o => o.Id == deviceId);
                if (device != null)
                { 
                    ManageMapper(request, DeviceTypeFirmwareMeasurementTypeViewModel.DefineMapper());
                    IQueryable<DeviceTypeFirmwareMeasurementTypeModel> instances = _dBcontext.DeviceTypeFirmware2MeasurementTypes
                        .Include(o => o.CreatedBy)
                        .Include(o => o.UpdatedBy)
                        .Include(o => o.DeviceTypeFirmware)
                        .Include(o => o.UnitType)
                        .Where(o => o.DeviceTypeFirmwareId == device.DeviceTypeFirmwareId);
                    
                    APIResultDTO<List<DeviceTypeFirmwareMeasurementTypeViewModel>> result = new APIResultDTO<List<DeviceTypeFirmwareMeasurementTypeViewModel>>();
                    result.IsOk = true;
                    result.Value = APIRequester<DeviceTypeFirmwareMeasurementTypeModel, DeviceTypeFirmwareMeasurementTypeViewModel>
                        .DT(request, instances)
                        .Select(o => new DeviceTypeFirmwareMeasurementTypeViewModel(o))
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

        [HttpPost("devices/{deviceId}/measurements/all/grid")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<GridResult<DeviceTypeFirmwareMeasurementTypeViewModel>>>> GetAllsForDeviceGrid(
            APIRequestDTO request, Guid deviceId)
        {

            if (IsUserKnown())
            {
                DeviceModel device = _dBcontext.Devices.FirstOrDefault(o => o.Id == deviceId);
                if (device != null)
                {
                    ManageMapper(request, DeviceTypeFirmwareMeasurementTypeViewModel.DefineMapper());
                    IQueryable<DeviceTypeFirmwareMeasurementTypeModel> instances = _dBcontext.DeviceTypeFirmware2MeasurementTypes
                        .Include(o => o.CreatedBy)
                        .Include(o => o.UpdatedBy)
                        .Include(o => o.DeviceTypeFirmware)
                        .Include(o => o.UnitType)
                        .Where(o => o.DeviceTypeFirmwareId == device.DeviceTypeFirmwareId);

                    APIResultDTO<GridResult<DeviceTypeFirmwareMeasurementTypeViewModel>> result = new APIResultDTO<GridResult<DeviceTypeFirmwareMeasurementTypeViewModel>>();
                    result.IsOk = true;
                    result.Value = APIRequester<DeviceTypeFirmwareMeasurementTypeModel, DeviceTypeFirmwareMeasurementTypeViewModel>
                        .DTGrid(request, instances, o => new DeviceTypeFirmwareMeasurementTypeViewModel(o));

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
