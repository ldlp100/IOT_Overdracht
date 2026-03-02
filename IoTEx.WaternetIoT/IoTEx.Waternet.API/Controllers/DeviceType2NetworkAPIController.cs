 
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
    [Route("/api/deviceTypes/{deviceTypeId}/networkAPIs/")]

    public class DeviceType2NetworkAPIController : BaseController
    {
        public DeviceType2NetworkAPIController(ILogger logger, IoTDBContext context, IConfiguration configuration)
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
        public async Task<ActionResult<APIResultDTO<List<DeviceType2NetworkAPIViewModel>>>> GetAlls(APIRequestDTO request, 
            Guid deviceTypeId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceType2NetworkAPIViewModel.DefineMapper());
                IQueryable<DeviceType2NetworkAPIModel> instances = _dBcontext.DeviceType2NetworkAPIs
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.DeviceType)
                    .Include(o => o.NetworkAPI)
                    .Where(o => o.DeviceTypeId == deviceTypeId);

                APIResultDTO<List<DeviceType2NetworkAPIViewModel>> result = new APIResultDTO<List<DeviceType2NetworkAPIViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<DeviceType2NetworkAPIModel, DeviceType2NetworkAPIViewModel>
                    .DT(request, instances)
                    .Select(o => new DeviceType2NetworkAPIViewModel(o))
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
        public async Task<ActionResult<APIResultDTO<GridResult<DeviceType2NetworkAPIViewModel>>>> GetAllsGrid(APIRequestDTO request, 
            Guid deviceTypeId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceType2NetworkAPIViewModel.DefineMapper());
                IQueryable<DeviceType2NetworkAPIModel> instances = _dBcontext.DeviceType2NetworkAPIs
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.DeviceType)
                    .Include(o => o.NetworkAPI)
                    .Where(o => o.DeviceTypeId == deviceTypeId);

                APIResultDTO<GridResult<DeviceType2NetworkAPIViewModel>> result = new APIResultDTO<GridResult<DeviceType2NetworkAPIViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<DeviceType2NetworkAPIModel, DeviceType2NetworkAPIViewModel>
                    .DTGrid(request, instances, o => new DeviceType2NetworkAPIViewModel(o));

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
        public async Task<ActionResult<APIResultDTO<DeviceType2NetworkAPIViewModel>>> Get(Guid id, Guid deviceTypeId)
        {
            if (IsUserKnown())
            {
                DeviceType2NetworkAPIModel instance = await _dBcontext.DeviceType2NetworkAPIs
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.DeviceType)
                    .Include(o => o.NetworkAPI)
                    .FirstAsync(o => o.Id == id && o.DeviceTypeId == deviceTypeId);

                if (instance != null)
                {

                    APIResultDTO<DeviceType2NetworkAPIViewModel> result = new APIResultDTO<DeviceType2NetworkAPIViewModel>();
                    result.IsOk = true;
                    result.Value = new DeviceType2NetworkAPIViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceType2NetworkAPIViewModel>>> Create(Guid deviceTypeId,
            DeviceType2NetworkAPIViewModel dtoInstance)
        {
            if (IsUserKnown())
            {

                DeviceType2NetworkAPIModel instance = dtoInstance.Create(GetAppUser());
                instance.DeviceTypeId = deviceTypeId;

                _dBcontext.DeviceType2NetworkAPIs.Add(instance);
                _dBcontext.SaveChanges();
                _dBcontext.Entry<DeviceType2NetworkAPIModel>(instance).Reference(o => o.UpdatedBy).Load();
                _dBcontext.Entry<DeviceType2NetworkAPIModel>(instance).Reference(o => o.CreatedBy).Load();
                _dBcontext.Entry<DeviceType2NetworkAPIModel>(instance).Reference(o => o.DeviceType).Load();
                _dBcontext.Entry<DeviceType2NetworkAPIModel>(instance).Reference(o => o.NetworkAPI).Load();

                APIResultDTO<DeviceType2NetworkAPIViewModel> result = new APIResultDTO<DeviceType2NetworkAPIViewModel>();
                result.IsOk = true;
                result.Value = new DeviceType2NetworkAPIViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceType2NetworkAPIViewModel>>> Update(Guid deviceTypeId, Guid id,
            DeviceType2NetworkAPIViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                DeviceType2NetworkAPIModel instance = _dBcontext.DeviceType2NetworkAPIs
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.DeviceType)
                    .Include(o => o.NetworkAPI)
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
                    _dBcontext.Entry<DeviceType2NetworkAPIModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<DeviceType2NetworkAPIModel>(instance).Reference(o => o.CreatedBy).Load();
                    _dBcontext.Entry<DeviceType2NetworkAPIModel>(instance).Reference(o => o.DeviceType).Load();
                    _dBcontext.Entry<DeviceType2NetworkAPIModel>(instance).Reference(o => o.NetworkAPI).Load();
                    APIResultDTO<DeviceType2NetworkAPIViewModel> result = new APIResultDTO<DeviceType2NetworkAPIViewModel>();
                    result.IsOk = true;
                    result.Value = new DeviceType2NetworkAPIViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceType2NetworkAPIViewModel>>> Delete(Guid deviceTypeId, Guid id)
        {
            if (IsUserKnown())
            {
                DeviceType2NetworkAPIModel instance = await _dBcontext.DeviceType2NetworkAPIs
                    .FirstOrDefaultAsync(o => o.Id == id && o.DeviceTypeId == deviceTypeId);
                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.DeviceType2NetworkAPIs.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<DeviceType2NetworkAPIViewModel> result = new APIResultDTO<DeviceType2NetworkAPIViewModel>();
                result.IsOk = true;
                result.Value = new DeviceType2NetworkAPIViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }
    }


}
