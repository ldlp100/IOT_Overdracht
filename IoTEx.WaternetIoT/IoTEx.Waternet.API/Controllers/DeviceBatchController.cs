
using Azure.Storage.Blobs;
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
    [Route("/api/deviceTypes/{deviceTypeId}/deviceBatchs/")]

    public class DeviceBatchController : BaseController
    {
        private BlobServiceClient _blobServiceClient;
        private IKustoService _kustoService;
        public DeviceBatchController(ILogger logger, IoTDBContext context, IConfiguration configuration, 
            BlobServiceClient blobServiceClient, IKustoService kustoService)
        {

            _dBcontext = context;
            _logger = logger;
            _configuration = configuration;
            _blobServiceClient = blobServiceClient;
            _kustoService = kustoService;
        }

        [HttpPost("/api/devices/all")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<List<DeviceBatchViewModel>>>> GetAllsDevices(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceBatchViewModel.DefineMapper());
                IQueryable<DeviceBatchModel> instances = _dBcontext.DeviceBatchs
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy);

                APIResultDTO<List<DeviceBatchViewModel>> result = new APIResultDTO<List<DeviceBatchViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<DeviceBatchModel, DeviceBatchViewModel>
                    .DT(request, instances)
                    .Select(o => new DeviceBatchViewModel(o))
                    .ToList();

                return result;
            }
            else
                return Unauthorized();
        }

        [HttpPost("all")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<List<DeviceBatchViewModel>>>> GetAlls(APIRequestDTO request, 
            Guid deviceTypeId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceBatchViewModel.DefineMapper());
                IQueryable<DeviceBatchModel> instances = _dBcontext.DeviceBatchs
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Where(o => o.DeviceTypeId == deviceTypeId);

                APIResultDTO<List<DeviceBatchViewModel>> result = new APIResultDTO<List<DeviceBatchViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<DeviceBatchModel, DeviceBatchViewModel>
                    .DT(request, instances)
                    .Select(o => new DeviceBatchViewModel(o))
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
        public async Task<ActionResult<APIResultDTO<GridResult<DeviceBatchViewModel>>>> GetAllsGrid(APIRequestDTO request, 
            Guid deviceTypeId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceBatchViewModel.DefineMapper());
                IQueryable<DeviceBatchModel> instances = _dBcontext.DeviceBatchs
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Where(o => o.DeviceTypeId == deviceTypeId);

                APIResultDTO<GridResult<DeviceBatchViewModel>> result = new APIResultDTO<GridResult<DeviceBatchViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<DeviceBatchModel, DeviceBatchViewModel>
                    .DTGrid(request, instances, o => new DeviceBatchViewModel(o));

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
        public async Task<ActionResult<APIResultDTO<DeviceBatchViewModel>>> Get(Guid id, Guid deviceTypeId)
        {
            if (IsUserKnown())
            {
                DeviceBatchModel instance = await _dBcontext.DeviceBatchs
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .FirstOrDefaultAsync(o => o.Id == id  && o.DeviceTypeId==deviceTypeId);

                if (instance != null)
                {
                    
                    APIResultDTO<DeviceBatchViewModel> result = new APIResultDTO<DeviceBatchViewModel>();
                    result.IsOk = true;
                    result.Value = new DeviceBatchViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceBatchViewModel>>> Create(Guid deviceTypeId, 
            DeviceBatchViewModel dtoInstance)
        {
            if (IsUserKnown())
            {

                DeviceBatchModel instance = dtoInstance.Create(GetAppUser());
                instance.DeviceTypeId = deviceTypeId;
                _dBcontext.DeviceBatchs.Add(instance);
                _dBcontext.SaveChanges();
                _dBcontext.Entry<DeviceBatchModel>(instance).Reference(o => o.UpdatedBy).Load();
                _dBcontext.Entry<DeviceBatchModel>(instance).Reference(o => o.CreatedBy).Load();

                APIResultDTO<DeviceBatchViewModel> result = new APIResultDTO<DeviceBatchViewModel>();
                result.IsOk = true;
                result.Value = new DeviceBatchViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceBatchViewModel>>> Update(Guid deviceTypeId, Guid id, 
            DeviceBatchViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                DeviceBatchModel instance = _dBcontext.DeviceBatchs
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .FirstOrDefault(o => o.Id == id);

                if (instance == null)
                {
                    return NotFound();
                }
                
                instance = dtoInstance.Update(instance, GetAppUser());
                instance.DeviceTypeId = deviceTypeId;
                _dBcontext.Entry(instance).State = EntityState.Modified;

                try
                {
                    await _dBcontext.SaveChangesAsync();
                    _dBcontext.Entry<DeviceBatchModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<DeviceBatchModel>(instance).Reference(o => o.CreatedBy).Load();
                    APIResultDTO<DeviceBatchViewModel> result = new APIResultDTO<DeviceBatchViewModel>();
                    result.IsOk = true;
                    result.Value = new DeviceBatchViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceBatchViewModel>>> Delete(Guid deviceTypeId, Guid id)
        {
            if (IsUserKnown())
            {
                DeviceBatchModel instance = await _dBcontext.DeviceBatchs
                    .FirstOrDefaultAsync(o => o.Id == id && o.DeviceTypeId==deviceTypeId);

                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.DeviceBatchs.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<DeviceBatchViewModel> result = new APIResultDTO<DeviceBatchViewModel>();
                result.IsOk = true;
                result.Value = new DeviceBatchViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }

        [HttpPost("importDeviceBatchFiles/all")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<List<DeviceBatchViewModel>>>> GetAllsImportDeviceBatchFile(APIRequestDTO request,
            Guid deviceTypeId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceBatchViewModel.DefineMapper());
                IQueryable<DeviceBatchModel> instances = _dBcontext.DeviceBatchs
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Where(o => o.DeviceTypeId == deviceTypeId);

                APIResultDTO<List<DeviceBatchViewModel>> result = new APIResultDTO<List<DeviceBatchViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<DeviceBatchModel, DeviceBatchViewModel>
                    .DT(request, instances)
                    .Select(o => new DeviceBatchViewModel(o))
                    .ToList();

                return result;
            }
            else
                return Unauthorized();
        }

        [HttpPost("importDeviceBatchFiles/all/grid")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<GridResult<DeviceBatchViewModel>>>> GetAllsImportDeviceBatchFileGrid(APIRequestDTO request,
            Guid deviceTypeId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceBatchViewModel.DefineMapper());
                IQueryable<DeviceBatchModel> instances = _dBcontext.DeviceBatchs
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Where(o => o.DeviceTypeId == deviceTypeId);

                APIResultDTO<GridResult<DeviceBatchViewModel>> result = new APIResultDTO<GridResult<DeviceBatchViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<DeviceBatchModel, DeviceBatchViewModel>
                    .DTGrid(request, instances, o => new DeviceBatchViewModel(o));

                return result;
            }
            else
                return Unauthorized();
        }

        [HttpPost("{id}/publish")]
        [RequiredScopeOrAppPermission(
             AcceptedScope = new string[] { },
             AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
         )]
        public async Task<ActionResult<APIResultDTO<string>>> PublishBatch(
             Guid deviceTypeId, Guid id)
        {
            APIResultDTO<string> result = new APIResultDTO<string>();

            if (IsUserKnown())
            {
                List<DeviceModel> devices = _dBcontext.Devices.Where(d => d.DeviceBatchId == id).ToList();
                int counter = 0;
                foreach (DeviceModel device in devices)
                {
                    DeviceController deviceController = new DeviceController(_logger,_dBcontext,_configuration, _blobServiceClient, _kustoService);
                    
                    APIResultDTO<string> subresult = (await deviceController.PublishDeviceInternal( deviceTypeId, id, device.Id, GetAppUser()));
                    if (subresult.IsOk) counter++;
                }
                if (counter == devices.Count())
                {
                    result.IsOk = true;
                    result.Value = counter + " out of " + devices.Count() + " devices published.";
                }
                else
                {
                    result.IsOk = false;
                    result.Error = counter + " out of " + devices.Count() + " devices published.";
                }
                return result;
            }
            else
                return Unauthorized();
        }
    }
}
