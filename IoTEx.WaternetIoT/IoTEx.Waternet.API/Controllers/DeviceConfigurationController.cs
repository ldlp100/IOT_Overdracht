
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
    [Route("/api/deviceTypes/{deviceTypeId}/deviceBatchs/{deviceBatchId}/devices/{deviceId}/configurations/")]

    public class DeviceConfigurationController : BaseController
    {
        public DeviceConfigurationController(ILogger logger, IoTDBContext context, IConfiguration configuration)
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
        public async Task<ActionResult<APIResultDTO<List<DeviceConfigurationViewModel>>>> GetAlls( 
            APIRequestDTO request, Guid deviceTypeId, Guid deviceBatchId, Guid deviceId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceConfigurationViewModel.DefineMapper());
                IQueryable<DeviceConfigurationModel> instances = _dBcontext.Device2Configurations
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Device)
                    .Include(o => o.DeviceTypeFirmwareConfiguration)
                    .Where(o => o.DeviceId == deviceId && o.Device.DeviceBatchId == deviceBatchId && o.Device.DeviceBatch.DeviceTypeId == deviceTypeId);

                APIResultDTO<List<DeviceConfigurationViewModel>> result = new APIResultDTO<List<DeviceConfigurationViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<DeviceConfigurationModel, DeviceConfigurationViewModel>
                    .DT(request, instances)
                    .Select(o => new DeviceConfigurationViewModel(o))
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
        public async Task<ActionResult<APIResultDTO<GridResult<DeviceConfigurationViewModel>>>> GetAllsGrid(
            APIRequestDTO request, Guid deviceTypeId, Guid deviceBatchId, Guid deviceId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceConfigurationViewModel.DefineMapper());
                IQueryable<DeviceConfigurationModel> instances = _dBcontext.Device2Configurations
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Device)
                    .Include(o => o.DeviceTypeFirmwareConfiguration)
                    .Where(o => o.DeviceId == deviceId && o.Device.DeviceBatchId == deviceBatchId && o.Device.DeviceBatch.DeviceTypeId == deviceTypeId);

                APIResultDTO<GridResult<DeviceConfigurationViewModel>> result = new APIResultDTO<GridResult<DeviceConfigurationViewModel>>();
                

                result.Value = APIRequester<DeviceConfigurationModel, DeviceConfigurationViewModel>
                    .DTGrid(request, instances, o => new DeviceConfigurationViewModel(o));

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
        public async Task<ActionResult<APIResultDTO<DeviceConfigurationViewModel>>> Get(Guid id,
            Guid deviceTypeId, Guid deviceBatchId, Guid deviceId)
        {
            if (IsUserKnown())
            {
                DeviceConfigurationModel instance = await _dBcontext.Device2Configurations
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Device)
                    .Include(o => o.DeviceTypeFirmwareConfiguration)
                    .FirstAsync(o => o.DeviceId == deviceId && o.Device.DeviceBatchId == deviceBatchId && o.Device.DeviceBatch.DeviceTypeId == deviceTypeId);

                if (instance != null)
                {

                    APIResultDTO<DeviceConfigurationViewModel> result = new APIResultDTO<DeviceConfigurationViewModel>();
                    result.IsOk = true;
                    result.Value = new DeviceConfigurationViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceConfigurationViewModel>>> Create(
            Guid deviceId, DeviceConfigurationViewModel dtoInstance)
        {
            if (IsUserKnown())
            {

                DeviceConfigurationModel instance = dtoInstance.Create(GetAppUser());
                instance.DeviceId = deviceId;

                _dBcontext.Device2Configurations.Add(instance);
                _dBcontext.SaveChanges();
                _dBcontext.Entry<DeviceConfigurationModel>(instance).Reference(o => o.UpdatedBy).Load();
                _dBcontext.Entry<DeviceConfigurationModel>(instance).Reference(o => o.CreatedBy).Load();
                _dBcontext.Entry<DeviceConfigurationModel>(instance).Reference(o => o.Device).Load();
                _dBcontext.Entry<DeviceConfigurationModel>(instance).Reference(o => o.DeviceTypeFirmwareConfiguration).Load();

                APIResultDTO<DeviceConfigurationViewModel> result = new APIResultDTO<DeviceConfigurationViewModel>();
                result.IsOk = true;
                result.Value = new DeviceConfigurationViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceConfigurationViewModel>>> Update(
            Guid deviceId, Guid id, DeviceConfigurationViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                DeviceConfigurationModel instance = _dBcontext.Device2Configurations
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Device)
                    .Include(o => o.DeviceTypeFirmwareConfiguration)
                    .FirstOrDefault(o => o.Id == id);

                if (instance == null)
                {
                    return NotFound();
                }

                instance = dtoInstance.Update(instance, GetAppUser());
                instance.DeviceId = deviceId;
                _dBcontext.Entry(instance).State = EntityState.Modified;

                try
                {
                    await _dBcontext.SaveChangesAsync();
                    _dBcontext.Entry<DeviceConfigurationModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<DeviceConfigurationModel>(instance).Reference(o => o.CreatedBy).Load();
                    _dBcontext.Entry<DeviceConfigurationModel>(instance).Reference(o => o.Device).Load();
                    _dBcontext.Entry<DeviceConfigurationModel>(instance).Reference(o => o.DeviceTypeFirmwareConfiguration).Load();
                    APIResultDTO<DeviceConfigurationViewModel> result = new APIResultDTO<DeviceConfigurationViewModel>();
                    result.IsOk = true;
                    result.Value = new DeviceConfigurationViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceConfigurationViewModel>>> Delete(
            Guid deviceTypeId, Guid deviceBatchId, Guid deviceId, Guid id)
        {
            if (IsUserKnown())
            {
                DeviceConfigurationModel instance = await _dBcontext.Device2Configurations
                    .FirstOrDefaultAsync(o => o.Id == id && o.DeviceId == deviceId && o.Device.DeviceBatchId == deviceBatchId && o.Device.DeviceBatch.DeviceTypeId == deviceTypeId);
                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.Device2Configurations.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<DeviceConfigurationViewModel> result = new APIResultDTO<DeviceConfigurationViewModel>();
                result.IsOk = true;
                result.Value = new DeviceConfigurationViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }
    }


}
