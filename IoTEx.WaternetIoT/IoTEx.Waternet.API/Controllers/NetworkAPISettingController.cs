using IoTEx.WaternetIoT.DAL;
using IoTEx.WaternetIoT.Model.DTOs.API;
using IoTEx.WaternetIoT.Model.PortalModels;
using IoTEx.WaternetIoT.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web.Resource;

namespace IoTEx.Waternet.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/networkAPIs/{networkAPIId}/settings/")]
    public class NetworkAPISettingController : BaseController
    {
        public NetworkAPISettingController(ILogger logger, IoTDBContext context, IConfiguration configuration)
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
        public async Task<ActionResult<APIResultDTO<List<NetworkAPISettingViewModel>>>> GetAlls(APIRequestDTO request,
            Guid networkAPIId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, NetworkAPISettingViewModel.DefineMapper());
                IQueryable<NetworkAPISettingModel> instances = _dBcontext.NetworkAPISettings
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Where(o => o.NetworkAPIId == networkAPIId);

                APIResultDTO<List<NetworkAPISettingViewModel>> result = new APIResultDTO<List<NetworkAPISettingViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<NetworkAPISettingModel, NetworkAPISettingViewModel>
                    .DT(request, instances)
                    .Select(o => new NetworkAPISettingViewModel(o))
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
        public async Task<ActionResult<APIResultDTO<GridResult<NetworkAPISettingViewModel>>>> GetAllsGrid(APIRequestDTO request,
            Guid networkAPIId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, NetworkAPISettingViewModel.DefineMapper());
                IQueryable<NetworkAPISettingModel> instances = _dBcontext.NetworkAPISettings
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Where(o => o.NetworkAPIId == networkAPIId);

                APIResultDTO<GridResult<NetworkAPISettingViewModel>> result = new APIResultDTO<GridResult<NetworkAPISettingViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<NetworkAPISettingModel, NetworkAPISettingViewModel>
                    .DTGrid(request, instances, o => new NetworkAPISettingViewModel(o));

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
        public async Task<ActionResult<APIResultDTO<NetworkAPISettingViewModel>>> Get(Guid id, Guid networkAPIId)
        {
            if (IsUserKnown())
            {
                NetworkAPISettingModel instance = await _dBcontext.NetworkAPISettings
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .FirstAsync(o => o.Id == id && o.NetworkAPIId == networkAPIId);

                if (instance != null)
                {

                    APIResultDTO<NetworkAPISettingViewModel> result = new APIResultDTO<NetworkAPISettingViewModel>();
                    result.IsOk = true;
                    result.Value = new NetworkAPISettingViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<NetworkAPISettingViewModel>>> Create(Guid networkAPIId,
            NetworkAPISettingViewModel dtoInstance)
        {
            if (IsUserKnown())
            {

                NetworkAPISettingModel instance = dtoInstance.Create(GetAppUser());
                instance.NetworkAPIId = networkAPIId;
                _dBcontext.NetworkAPISettings.Add(instance);
                _dBcontext.SaveChanges();
                _dBcontext.Entry<NetworkAPISettingModel>(instance).Reference(o => o.UpdatedBy).Load();
                _dBcontext.Entry<NetworkAPISettingModel>(instance).Reference(o => o.CreatedBy).Load();

                APIResultDTO<NetworkAPISettingViewModel> result = new APIResultDTO<NetworkAPISettingViewModel>();
                result.IsOk = true;
                result.Value = new NetworkAPISettingViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<NetworkAPISettingViewModel>>> Update(Guid networkAPIId, Guid id,
            NetworkAPISettingViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                NetworkAPISettingModel instance = _dBcontext.NetworkAPISettings
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .FirstOrDefault(o => o.Id == id);

                if (instance == null)
                {
                    return NotFound();
                }

                instance = dtoInstance.Update(instance, GetAppUser());
                instance.NetworkAPIId = networkAPIId;
                _dBcontext.Entry(instance).State = EntityState.Modified;

                try
                {
                    await _dBcontext.SaveChangesAsync();
                    _dBcontext.Entry<NetworkAPISettingModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<NetworkAPISettingModel>(instance).Reference(o => o.CreatedBy).Load();
                    APIResultDTO<NetworkAPISettingViewModel> result = new APIResultDTO<NetworkAPISettingViewModel>();
                    result.IsOk = true;
                    result.Value = new NetworkAPISettingViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<NetworkAPISettingViewModel>>> Delete(Guid networkAPIId, Guid id)
        {
            if (IsUserKnown())
            {
                NetworkAPISettingModel instance = await _dBcontext.NetworkAPISettings
                    .FirstOrDefaultAsync(o => o.Id == id && o.NetworkAPIId == networkAPIId);

                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.NetworkAPISettings.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<NetworkAPISettingViewModel> result = new APIResultDTO<NetworkAPISettingViewModel>();
                result.IsOk = true;
                result.Value = new NetworkAPISettingViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }
    }


}
