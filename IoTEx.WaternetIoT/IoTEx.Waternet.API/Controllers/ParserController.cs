
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
    [Route("/api/parsers/")]
    public class ParserController : BaseController
    {
        public ParserController(ILogger logger, IoTDBContext context, IConfiguration configuration)
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
        public async Task<ActionResult<APIResultDTO<List<ParserViewModel>>>> GetAlls(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, ParserViewModel.DefineMapper());
                IQueryable<ParserModel> instances = _dBcontext.Parsers
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy);

                APIResultDTO<List<ParserViewModel>> result = new APIResultDTO<List<ParserViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<ParserModel, ParserViewModel>
                    .DT(request, instances)
                    .Select(o => new ParserViewModel(o))
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
        public async Task<ActionResult<APIResultDTO<GridResult<ParserViewModel>>>> GetAllsGrid(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, ParserViewModel.DefineMapper());
                IQueryable<ParserModel> instances = _dBcontext.Parsers
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy);
                APIResultDTO<GridResult<ParserViewModel>> result = new APIResultDTO<GridResult<ParserViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<ParserModel, ParserViewModel>
                    .DTGrid(request, instances, o => new ParserViewModel(o));

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
        public async Task<ActionResult<APIResultDTO<ParserViewModel>>> Get(Guid id)
        {
            if (IsUserKnown())
            {
                ParserModel instance = await _dBcontext.Parsers
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .FirstAsync(o => o.Id == id);
                if (instance != null)
                {
                    
                    APIResultDTO<ParserViewModel> result = new APIResultDTO<ParserViewModel>();
                    result.IsOk = true;
                    result.Value = new ParserViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<ParserViewModel>>> Create(ParserViewModel dtoInstance)
        {
            if (IsUserKnown())
            {

                ParserModel instance = dtoInstance.Create(GetAppUser());

                _dBcontext.Parsers.Add(instance);
                _dBcontext.SaveChanges();
                _dBcontext.Entry<ParserModel>(instance).Reference(o => o.UpdatedBy).Load();
                _dBcontext.Entry<ParserModel>(instance).Reference(o => o.CreatedBy).Load();

                APIResultDTO<ParserViewModel> result = new APIResultDTO<ParserViewModel>();
                result.IsOk = true;
                result.Value = new ParserViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<ParserViewModel>>> Update(Guid id, ParserViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                ParserModel instance = _dBcontext.Parsers
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
                    _dBcontext.Entry<ParserModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<ParserModel>(instance).Reference(o => o.CreatedBy).Load();
                    APIResultDTO<ParserViewModel> result = new APIResultDTO<ParserViewModel>();
                    result.IsOk = true;
                    result.Value = new ParserViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<ParserViewModel>>> Delete(Guid id)
        {
            if (IsUserKnown())
            {
                ParserModel instance = await _dBcontext.Parsers.FirstOrDefaultAsync(o => o.Id == id);
                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.Parsers.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<ParserViewModel> result = new APIResultDTO<ParserViewModel>();
                result.IsOk = true;
                result.Value = new ParserViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }
    }


}
