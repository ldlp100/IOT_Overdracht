
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
    [Route("/api/deviceTypes/{deviceTypeId}/deviceBatchs/{deviceBatchId}/devices/{deviceId}/calibrations/")]

    public class DeviceCalibrationController : BaseController
    {
        public DeviceCalibrationController(ILogger logger, IoTDBContext context, IConfiguration configuration)
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
        public async Task<ActionResult<APIResultDTO<List<DeviceCalibrationViewModel>>>> GetAlls( 
            APIRequestDTO request, Guid deviceTypeId, Guid deviceBatchId, Guid deviceId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceCalibrationViewModel.DefineMapper());
                IQueryable<DeviceCalibrationModel> instances = _dBcontext.Device2Calibrations
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Device)
                    .Include(o => o.DeviceTypeFirmware2MeasurementType)
                    .Where(o => o.DeviceId == deviceId && o.Device.DeviceBatchId == deviceBatchId && o.Device.DeviceBatch.DeviceTypeId == deviceTypeId);

                APIResultDTO<List<DeviceCalibrationViewModel>> result = new APIResultDTO<List<DeviceCalibrationViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<DeviceCalibrationModel, DeviceCalibrationViewModel>
                    .DT(request, instances)
                    .Select(o => new DeviceCalibrationViewModel(o))
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
        public async Task<ActionResult<APIResultDTO<GridResult<DeviceCalibrationViewModel>>>> GetAllsGrid(
            APIRequestDTO request, Guid deviceTypeId, Guid deviceBatchId, Guid deviceId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceCalibrationViewModel.DefineMapper());
                IQueryable<DeviceCalibrationModel> instances = _dBcontext.Device2Calibrations
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Device)
                    .Include(o => o.DeviceTypeFirmware2MeasurementType)
                    .Where(o => o.DeviceId == deviceId && o.Device.DeviceBatchId == deviceBatchId && o.Device.DeviceBatch.DeviceTypeId == deviceTypeId);

                APIResultDTO<GridResult<DeviceCalibrationViewModel>> result = new APIResultDTO<GridResult<DeviceCalibrationViewModel>>();
                result.IsOk = true;

                result.Value = APIRequester<DeviceCalibrationModel, DeviceCalibrationViewModel>
                    .DTGrid(request, instances, o => new DeviceCalibrationViewModel(o));

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
        public async Task<ActionResult<APIResultDTO<DeviceCalibrationViewModel>>> Get(Guid id,
            Guid deviceTypeId, Guid deviceBatchId, Guid deviceId)
        {
            if (IsUserKnown())
            {
                DeviceCalibrationModel instance = await _dBcontext.Device2Calibrations
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Device)
                    .Include(o => o.DeviceTypeFirmware2MeasurementType)
                    .FirstAsync(o => o.DeviceId == deviceId && o.Device.DeviceBatchId == deviceBatchId && o.Device.DeviceBatch.DeviceTypeId == deviceTypeId);

                if (instance != null)
                {

                    APIResultDTO<DeviceCalibrationViewModel> result = new APIResultDTO<DeviceCalibrationViewModel>();
                    result.IsOk = true;
                    result.Value = new DeviceCalibrationViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceCalibrationViewModel>>> Create(
            Guid deviceId, DeviceCalibrationViewModel dtoInstance)
        {
            if (IsUserKnown())
            {

                DeviceCalibrationModel instance = dtoInstance.Create(GetAppUser());
                instance.DeviceId = deviceId;

                _dBcontext.Device2Calibrations.Add(instance);
                _dBcontext.SaveChanges();
                _dBcontext.Entry<DeviceCalibrationModel>(instance).Reference(o => o.UpdatedBy).Load();
                _dBcontext.Entry<DeviceCalibrationModel>(instance).Reference(o => o.CreatedBy).Load();
                _dBcontext.Entry<DeviceCalibrationModel>(instance).Reference(o => o.Device).Load();
                _dBcontext.Entry<DeviceCalibrationModel>(instance).Reference(o => o.DeviceTypeFirmware2MeasurementType).Load();

                APIResultDTO<DeviceCalibrationViewModel> result = new APIResultDTO<DeviceCalibrationViewModel>();
                result.IsOk = true;
                result.Value = new DeviceCalibrationViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceCalibrationViewModel>>> Update(
            Guid deviceId, Guid id, DeviceCalibrationViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                DeviceCalibrationModel instance = _dBcontext.Device2Calibrations
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Device)
                    .Include(o => o.DeviceTypeFirmware2MeasurementType)
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
                    _dBcontext.Entry<DeviceCalibrationModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<DeviceCalibrationModel>(instance).Reference(o => o.CreatedBy).Load();
                    _dBcontext.Entry<DeviceCalibrationModel>(instance).Reference(o => o.Device).Load();
                    _dBcontext.Entry<DeviceCalibrationModel>(instance).Reference(o => o.DeviceTypeFirmware2MeasurementType).Load();
                    APIResultDTO<DeviceCalibrationViewModel> result = new APIResultDTO<DeviceCalibrationViewModel>();
                    result.IsOk = true;
                    result.Value = new DeviceCalibrationViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceCalibrationViewModel>>> Delete(
            Guid deviceTypeId, Guid deviceBatchId, Guid deviceId, Guid id)
        {
            if (IsUserKnown())
            {
                DeviceCalibrationModel instance = await _dBcontext.Device2Calibrations
                    .FirstOrDefaultAsync(o => o.Id == id && o.DeviceId == deviceId && o.Device.DeviceBatchId == deviceBatchId && o.Device.DeviceBatch.DeviceTypeId == deviceTypeId);
                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.Device2Calibrations.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<DeviceCalibrationViewModel> result = new APIResultDTO<DeviceCalibrationViewModel>();
                result.IsOk = true;
                result.Value = new DeviceCalibrationViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }
    }


}
