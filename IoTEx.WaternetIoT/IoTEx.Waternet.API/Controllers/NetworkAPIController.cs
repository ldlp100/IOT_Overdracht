
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
    [Route("/api/networkAPIs/")]
    public class NetworkAPIController : BaseController
    {
        public NetworkAPIController(ILogger logger, IoTDBContext context, IConfiguration configuration)
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
        public async Task<ActionResult<APIResultDTO<List<NetworkAPIViewModel>>>> GetAlls(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, NetworkAPIViewModel.DefineMapper());
                IQueryable<NetworkAPIModel> instances = _dBcontext.NetworkAPIs
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy);

                APIResultDTO<List<NetworkAPIViewModel>> result = new APIResultDTO<List<NetworkAPIViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<NetworkAPIModel, NetworkAPIViewModel>
                    .DT(request, instances)
                    .Select(o => new NetworkAPIViewModel(o))
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
        public async Task<ActionResult<APIResultDTO<GridResult<NetworkAPIViewModel>>>> GetAllsGrid(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, NetworkAPIViewModel.DefineMapper());
                IQueryable<NetworkAPIModel> instances = _dBcontext.NetworkAPIs
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy);
                APIResultDTO<GridResult<NetworkAPIViewModel>> result = new APIResultDTO<GridResult<NetworkAPIViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<NetworkAPIModel, NetworkAPIViewModel>
                    .DTGrid(request, instances, o => new NetworkAPIViewModel(o));

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
        public async Task<ActionResult<APIResultDTO<NetworkAPIViewModel>>> Get(Guid id)
        {
            if (IsUserKnown())
            {
                NetworkAPIModel instance = await _dBcontext.NetworkAPIs
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .FirstAsync(o => o.Id == id);
                if (instance != null)
                {
                    
                    APIResultDTO<NetworkAPIViewModel> result = new APIResultDTO<NetworkAPIViewModel>();
                    result.IsOk = true;
                    result.Value = new NetworkAPIViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<NetworkAPIViewModel>>> Create(NetworkAPIViewModel dtoInstance)
        {
            if (IsUserKnown())
            {

                NetworkAPIModel instance = dtoInstance.Create(GetAppUser());

                _dBcontext.NetworkAPIs.Add(instance);
                _dBcontext.SaveChanges();
                _dBcontext.Entry<NetworkAPIModel>(instance).Reference(o => o.UpdatedBy).Load();
                _dBcontext.Entry<NetworkAPIModel>(instance).Reference(o => o.CreatedBy).Load();

                APIResultDTO<NetworkAPIViewModel> result = new APIResultDTO<NetworkAPIViewModel>();
                result.IsOk = true;
                result.Value = new NetworkAPIViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<NetworkAPIViewModel>>> Update(Guid id, NetworkAPIViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                NetworkAPIModel instance = _dBcontext.NetworkAPIs
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .FirstOrDefault(o => o.Id == id);
                if (instance == null)
                {
                    return NotFound();
                }
                
                instance = dtoInstance.Update(instance, GetAppUser());
                _dBcontext.Entry(instance).State = EntityState.Modified;

                try
                {
                    await _dBcontext.SaveChangesAsync();
                    _dBcontext.Entry<NetworkAPIModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<NetworkAPIModel>(instance).Reference(o => o.CreatedBy).Load();
                    APIResultDTO<NetworkAPIViewModel> result = new APIResultDTO<NetworkAPIViewModel>();
                    result.IsOk = true;
                    result.Value = new NetworkAPIViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<NetworkAPIViewModel>>> Delete(Guid id)
        {
            if (IsUserKnown())
            {
                NetworkAPIModel instance = await _dBcontext.NetworkAPIs.FirstOrDefaultAsync(o => o.Id == id);
                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.NetworkAPIs.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<NetworkAPIViewModel> result = new APIResultDTO<NetworkAPIViewModel>();
                result.IsOk = true;
                result.Value = new NetworkAPIViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }
    }


}
