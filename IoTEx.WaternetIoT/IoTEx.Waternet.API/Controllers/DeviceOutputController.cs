
using IoTEx.WaternetIoT.DAL;
using IoTEx.WaternetIoT.Model.DTOs.API;
using IoTEx.WaternetIoT.Model.PortalModels;
using IoTEx.WaternetIoT.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web.Resource;
using System.Security.Cryptography;

namespace IoTEx.Waternet.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/deviceTypes/{deviceTypeId}/deviceBatchs/{deviceBatchId}/devices/{deviceId}/outputs/")]

    public class DeviceOutputController : BaseController
    {
        public DeviceOutputController(ILogger logger, IoTDBContext context, IConfiguration configuration)
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
        public async Task<ActionResult<APIResultDTO<List<DeviceOutputViewModel>>>> GetAlls( 
            APIRequestDTO request, Guid deviceTypeId, Guid deviceBatchId, Guid deviceId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceOutputViewModel.DefineMapper());
                IQueryable<DeviceOutputModel> instances = _dBcontext.Device2Outputs
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Device)
                    .Include(o => o.EventStateType)
                    .Include(o => o.MeasurementType)
                    .Include(o => o.UnitType)
                    .Where(o => o.DeviceId == deviceId && o.Device.DeviceBatchId == deviceBatchId && o.Device.DeviceBatch.DeviceTypeId == deviceTypeId);

                APIResultDTO<List<DeviceOutputViewModel>> result = new APIResultDTO<List<DeviceOutputViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<DeviceOutputModel, DeviceOutputViewModel>
                    .DT(request, instances)
                    .Select(o => new DeviceOutputViewModel(o))
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
        public async Task<ActionResult<APIResultDTO<GridResult<DeviceOutputViewModel>>>> GetAllsGrid(
            APIRequestDTO request, Guid deviceTypeId, Guid deviceBatchId, Guid deviceId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceOutputViewModel.DefineMapper());
                IQueryable<DeviceOutputModel> instances = _dBcontext.Device2Outputs
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Device)
                    .Include(o => o.EventStateType)
                    .Include(o => o.MeasurementType)
                    .Include(o => o.UnitType)
                    .Where(o => o.DeviceId == deviceId && o.Device.DeviceBatchId == deviceBatchId && o.Device.DeviceBatch.DeviceTypeId == deviceTypeId);

                APIResultDTO<GridResult<DeviceOutputViewModel>> result = new APIResultDTO<GridResult<DeviceOutputViewModel>>();
                result.IsOk = true;

                result.Value = APIRequester<DeviceOutputModel, DeviceOutputViewModel>
                    .DTGrid(request, instances, o => new DeviceOutputViewModel(o));

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
        public async Task<ActionResult<APIResultDTO<DeviceOutputViewModel>>> Get(Guid id,
            Guid deviceTypeId, Guid deviceBatchId, Guid deviceId)
        {
            if (IsUserKnown())
            {
                DeviceOutputModel instance = await _dBcontext.Device2Outputs
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Device)
                    .Include(o => o.EventStateType)
                    .Include(o => o.MeasurementType)
                    .Include(o => o.UnitType)
                    .FirstAsync(o => o.DeviceId == deviceId && o.Device.DeviceBatchId == deviceBatchId && o.Device.DeviceBatch.DeviceTypeId == deviceTypeId);

                if (instance != null)
                {

                    APIResultDTO<DeviceOutputViewModel> result = new APIResultDTO<DeviceOutputViewModel>();
                    result.IsOk = true;
                    result.Value = new DeviceOutputViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceOutputViewModel>>> Create(
            Guid deviceId, DeviceOutputViewModel dtoInstance)
        {
            if (IsUserKnown())
            {

                DeviceOutputModel instance = dtoInstance.Create(GetAppUser());
                instance.DeviceId = deviceId;

                _dBcontext.Device2Outputs.Add(instance);
                _dBcontext.SaveChanges();
                _dBcontext.Entry<DeviceOutputModel>(instance).Reference(o => o.UpdatedBy).Load();
                _dBcontext.Entry<DeviceOutputModel>(instance).Reference(o => o.CreatedBy).Load();
                _dBcontext.Entry<DeviceOutputModel>(instance).Reference(o => o.Device).Load();
                _dBcontext.Entry<DeviceOutputModel>(instance).Reference(o => o.EventStateType).Load();
                _dBcontext.Entry<DeviceOutputModel>(instance).Reference(o => o.MeasurementType).Load();
                _dBcontext.Entry<DeviceOutputModel>(instance).Reference(o => o.UnitType).Load();

                APIResultDTO<DeviceOutputViewModel> result = new APIResultDTO<DeviceOutputViewModel>();
                result.IsOk = true;
                result.Value = new DeviceOutputViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceOutputViewModel>>> Update(
            Guid deviceId, Guid id, DeviceOutputViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                DeviceOutputModel instance = _dBcontext.Device2Outputs
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Device)
                    .Include(o => o.EventStateType)
                    .Include(o => o.MeasurementType)
                    .Include(o => o.UnitType)
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
                    _dBcontext.Entry<DeviceOutputModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<DeviceOutputModel>(instance).Reference(o => o.CreatedBy).Load();
                    _dBcontext.Entry<DeviceOutputModel>(instance).Reference(o => o.Device).Load();
                    _dBcontext.Entry<DeviceOutputModel>(instance).Reference(o => o.EventStateType).Load();
                    _dBcontext.Entry<DeviceOutputModel>(instance).Reference(o => o.MeasurementType).Load();
                    _dBcontext.Entry<DeviceOutputModel>(instance).Reference(o => o.UnitType).Load();
                    APIResultDTO<DeviceOutputViewModel> result = new APIResultDTO<DeviceOutputViewModel>();
                    result.IsOk = true;
                    result.Value = new DeviceOutputViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceOutputViewModel>>> Delete(
            Guid deviceTypeId, Guid deviceBatchId, Guid deviceId, Guid id)
        {
            if (IsUserKnown())
            {
                DeviceOutputModel instance = await _dBcontext.Device2Outputs
                    .FirstOrDefaultAsync(o => o.Id == id && o.DeviceId == deviceId && o.Device.DeviceBatchId == deviceBatchId && o.Device.DeviceBatch.DeviceTypeId == deviceTypeId);
                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.Device2Outputs.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<DeviceOutputViewModel> result = new APIResultDTO<DeviceOutputViewModel>();
                result.IsOk = true;
                result.Value = new DeviceOutputViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }
    }


}
