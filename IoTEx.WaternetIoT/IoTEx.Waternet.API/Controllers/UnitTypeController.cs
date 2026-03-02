
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
    [Route("/api/unitTypes/")]
    public class UnitTypeController : BaseController
    {
        public UnitTypeController(ILogger logger, IoTDBContext context, IConfiguration configuration)
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
        public async Task<ActionResult<APIResultDTO<List<UnitTypeViewModel>>>> GetAlls(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, UnitTypeViewModel.DefineMapper());
                IQueryable<UnitTypeModel> instances = _dBcontext.UnitTypes
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy);

                APIResultDTO<List<UnitTypeViewModel>> result = new APIResultDTO<List<UnitTypeViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<UnitTypeModel, UnitTypeViewModel>
                    .DT(request, instances)
                    .Select(o => new UnitTypeViewModel(o))
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
        public async Task<ActionResult<APIResultDTO<GridResult<UnitTypeViewModel>>>> GetAllsGrid(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, UnitTypeViewModel.DefineMapper());
                IQueryable<UnitTypeModel> instances = _dBcontext.UnitTypes
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy);
                APIResultDTO<GridResult<UnitTypeViewModel>> result = new APIResultDTO<GridResult<UnitTypeViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<UnitTypeModel, UnitTypeViewModel>
                    .DTGrid(request, instances, o => new UnitTypeViewModel(o));

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
        public async Task<ActionResult<APIResultDTO<UnitTypeViewModel>>> Get(Guid id)
        {
            if (IsUserKnown())
            {
                UnitTypeModel instance = await _dBcontext.UnitTypes
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .FirstAsync(o => o.Id == id);
                if (instance != null)
                {
                    
                    APIResultDTO<UnitTypeViewModel> result = new APIResultDTO<UnitTypeViewModel>();
                    result.IsOk = true;
                    result.Value = new UnitTypeViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<UnitTypeViewModel>>> Create(UnitTypeViewModel dtoInstance)
        {
            if (IsUserKnown())
            {

                UnitTypeModel instance = dtoInstance.Create(GetAppUser());

                _dBcontext.UnitTypes.Add(instance);
                _dBcontext.SaveChanges();
                _dBcontext.Entry<UnitTypeModel>(instance).Reference(o => o.UpdatedBy).Load();
                _dBcontext.Entry<UnitTypeModel>(instance).Reference(o => o.CreatedBy).Load();

                APIResultDTO<UnitTypeViewModel> result = new APIResultDTO<UnitTypeViewModel>();
                result.IsOk = true;
                result.Value = new UnitTypeViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<UnitTypeViewModel>>> Update(Guid id, UnitTypeViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                UnitTypeModel instance = _dBcontext.UnitTypes
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
                    _dBcontext.Entry<UnitTypeModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<UnitTypeModel>(instance).Reference(o => o.CreatedBy).Load();
                    APIResultDTO<UnitTypeViewModel> result = new APIResultDTO<UnitTypeViewModel>();
                    result.IsOk = true;
                    result.Value = new UnitTypeViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<UnitTypeViewModel>>> Delete(Guid id)
        {
            if (IsUserKnown())
            {
                UnitTypeModel instance = await _dBcontext.UnitTypes.FirstOrDefaultAsync(o => o.Id == id);
                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.UnitTypes.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<UnitTypeViewModel> result = new APIResultDTO<UnitTypeViewModel>();
                result.IsOk = true;
                result.Value = new UnitTypeViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }
    }


}
