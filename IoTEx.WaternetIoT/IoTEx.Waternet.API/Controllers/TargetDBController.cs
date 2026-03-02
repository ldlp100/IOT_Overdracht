
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
    [Route("/api/targetDBs/")]
    public class TargetDBController : BaseController
    {
        public TargetDBController(ILogger logger, IoTDBContext context, IConfiguration configuration)
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
        public async Task<ActionResult<APIResultDTO<List<TargetDBViewModel>>>> GetAlls(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, TargetDBViewModel.DefineMapper());
                IQueryable<TargetDBModel> instances = _dBcontext.TargetDBs
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy);

                APIResultDTO<List<TargetDBViewModel>> result = new APIResultDTO<List<TargetDBViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<TargetDBModel, TargetDBViewModel>
                    .DT(request, instances)
                    .Select(o => new TargetDBViewModel(o))
                    .ToList();

                return result;
            }
            else
            {
                return Unauthorized();
            }
        }
        
        [HttpPost("all/grid")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<GridResult<TargetDBViewModel>>>> GetAllsGrid(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, TargetDBViewModel.DefineMapper());
                IQueryable<TargetDBModel> instances = _dBcontext.TargetDBs
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy);
                APIResultDTO<GridResult<TargetDBViewModel>> result = new APIResultDTO<GridResult<TargetDBViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<TargetDBModel, TargetDBViewModel>
                    .DTGrid(request, instances, o => new TargetDBViewModel(o));

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
        public async Task<ActionResult<APIResultDTO<TargetDBViewModel>>> Get(Guid id)
        {
            if (IsUserKnown())
            {
                TargetDBModel instance = await _dBcontext.TargetDBs
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .FirstAsync(o => o.Id == id);
                if (instance != null)
                {
                    
                    APIResultDTO<TargetDBViewModel> result = new APIResultDTO<TargetDBViewModel>();
                    result.IsOk = true;
                    result.Value = new TargetDBViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<TargetDBViewModel>>> Create(TargetDBViewModel dtoInstance)
        {
            if (IsUserKnown())
            {

                TargetDBModel instance = dtoInstance.Create(GetAppUser());

                _dBcontext.TargetDBs.Add(instance);
                _dBcontext.SaveChanges();
                _dBcontext.Entry<TargetDBModel>(instance).Reference(o => o.UpdatedBy).Load();
                _dBcontext.Entry<TargetDBModel>(instance).Reference(o => o.CreatedBy).Load();

                APIResultDTO<TargetDBViewModel> result = new APIResultDTO<TargetDBViewModel>();
                result.IsOk = true;
                result.Value = new TargetDBViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<TargetDBViewModel>>> Update(Guid id, TargetDBViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                TargetDBModel instance = _dBcontext.TargetDBs
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
                    _dBcontext.Entry<TargetDBModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<TargetDBModel>(instance).Reference(o => o.CreatedBy).Load();
                    APIResultDTO<TargetDBViewModel> result = new APIResultDTO<TargetDBViewModel>();
                    result.IsOk = true;
                    result.Value = new TargetDBViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<TargetDBViewModel>>> Delete(Guid id)
        {
            if (IsUserKnown())
            {
                TargetDBModel instance = await _dBcontext.TargetDBs.FirstOrDefaultAsync(o => o.Id == id);
                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.TargetDBs.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<TargetDBViewModel> result = new APIResultDTO<TargetDBViewModel>();
                result.IsOk = true;
                result.Value = new TargetDBViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }
    }


}
