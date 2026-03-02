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
    [Route("/api/eventStateTypes/")]
    public class _EventStateTypeController : BaseController
    {
        public _EventStateTypeController(ILogger logger, IoTDBContext context, IConfiguration configuration)
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
        public async Task<ActionResult<APIResultDTO<List<EventStateTypeViewModel>>>> GetAlls(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, EventStateTypeViewModel.DefineMapper());
                IQueryable<EventStateTypeModel> instances = _dBcontext.EventStateTypes
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy);

                APIResultDTO<List<EventStateTypeViewModel>> result = new APIResultDTO<List<EventStateTypeViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<EventStateTypeModel, EventStateTypeViewModel>
                    .DT(request, instances)
                    .Select(o => new EventStateTypeViewModel(o))
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
        public async Task<ActionResult<APIResultDTO<GridResult<EventStateTypeViewModel>>>> GetAllsGrid(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, EventStateTypeViewModel.DefineMapper());
                IQueryable<EventStateTypeModel> instances = _dBcontext.EventStateTypes
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy);
                APIResultDTO<GridResult<EventStateTypeViewModel>> result = new APIResultDTO<GridResult<EventStateTypeViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<EventStateTypeModel, EventStateTypeViewModel>
                    .DTGrid(request, instances, o => new EventStateTypeViewModel(o));

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
        public async Task<ActionResult<APIResultDTO<EventStateTypeViewModel>>> Get(Guid id)
        {
            if (IsUserKnown())
            {
                EventStateTypeModel instance = await _dBcontext.EventStateTypes
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .FirstAsync(o => o.Id == id);
                if (instance != null)
                {
                    
                    APIResultDTO<EventStateTypeViewModel> result = new APIResultDTO<EventStateTypeViewModel>();
                    result.IsOk = true;
                    result.Value = new EventStateTypeViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<EventStateTypeViewModel>>> Create(EventStateTypeViewModel dtoInstance)
        {
            if (IsUserKnown())
            {

                EventStateTypeModel instance = dtoInstance.Create(GetAppUser());

                _dBcontext.EventStateTypes.Add(instance);
                _dBcontext.SaveChanges();
                _dBcontext.Entry<EventStateTypeModel>(instance).Reference(o => o.UpdatedBy).Load();
                _dBcontext.Entry<EventStateTypeModel>(instance).Reference(o => o.CreatedBy).Load();

                APIResultDTO<EventStateTypeViewModel> result = new APIResultDTO<EventStateTypeViewModel>();
                result.IsOk = true;
                result.Value = new EventStateTypeViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<EventStateTypeViewModel>>> Update(Guid id, EventStateTypeViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                EventStateTypeModel instance = _dBcontext.EventStateTypes
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
                    _dBcontext.Entry<EventStateTypeModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<EventStateTypeModel>(instance).Reference(o => o.CreatedBy).Load();
                    APIResultDTO<EventStateTypeViewModel> result = new APIResultDTO<EventStateTypeViewModel>();
                    result.IsOk = true;
                    result.Value = new EventStateTypeViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<EventStateTypeViewModel>>> Delete(Guid id)
        {
            if (IsUserKnown())
            {
                EventStateTypeModel instance = await _dBcontext.EventStateTypes.FirstOrDefaultAsync(o => o.Id == id);
                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.EventStateTypes.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<EventStateTypeViewModel> result = new APIResultDTO<EventStateTypeViewModel>();
                result.IsOk = true;
                result.Value = new EventStateTypeViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }
    }


}
