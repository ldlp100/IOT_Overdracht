
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
    [Route("/api/measurementTypes/")]
    public class MeasurementTypeController : BaseController
    {
        public MeasurementTypeController(ILogger logger, IoTDBContext context, IConfiguration configuration)
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
        public async Task<ActionResult<APIResultDTO<List<MeasurementTypeViewModel>>>> GetAlls(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, MeasurementTypeViewModel.DefineMapper());
                IQueryable<MeasurementTypeModel> instances = _dBcontext.MeasurementTypes
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy);

                APIResultDTO<List<MeasurementTypeViewModel>> result = new APIResultDTO<List<MeasurementTypeViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<MeasurementTypeModel, MeasurementTypeViewModel>
                    .DT(request, instances)
                    .Select(o => new MeasurementTypeViewModel(o))
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
        public async Task<ActionResult<APIResultDTO<GridResult<MeasurementTypeViewModel>>>> GetAllsGrid(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, MeasurementTypeViewModel.DefineMapper());
                IQueryable<MeasurementTypeModel> instances = _dBcontext.MeasurementTypes
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy);
                APIResultDTO<GridResult<MeasurementTypeViewModel>> result = new APIResultDTO<GridResult<MeasurementTypeViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<MeasurementTypeModel, MeasurementTypeViewModel>
                    .DTGrid(request, instances, o => new MeasurementTypeViewModel(o));

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
        public async Task<ActionResult<APIResultDTO<MeasurementTypeViewModel>>> Get(Guid id)
        {
            if (IsUserKnown())
            {
                MeasurementTypeModel instance = await _dBcontext.MeasurementTypes
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .FirstAsync(o => o.Id == id);
                if (instance != null)
                {
                    
                    APIResultDTO<MeasurementTypeViewModel> result = new APIResultDTO<MeasurementTypeViewModel>();
                    result.IsOk = true;
                    result.Value = new MeasurementTypeViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<MeasurementTypeViewModel>>> Create(MeasurementTypeViewModel dtoInstance)
        {
            if (IsUserKnown())
            {

                MeasurementTypeModel instance = dtoInstance.Create(GetAppUser());

                _dBcontext.MeasurementTypes.Add(instance);
                _dBcontext.SaveChanges();
                _dBcontext.Entry<MeasurementTypeModel>(instance).Reference(o => o.UpdatedBy).Load();
                _dBcontext.Entry<MeasurementTypeModel>(instance).Reference(o => o.CreatedBy).Load();

                APIResultDTO<MeasurementTypeViewModel> result = new APIResultDTO<MeasurementTypeViewModel>();
                result.IsOk = true;
                result.Value = new MeasurementTypeViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<MeasurementTypeViewModel>>> Update(Guid id, MeasurementTypeViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                MeasurementTypeModel instance = _dBcontext.MeasurementTypes
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
                    _dBcontext.Entry<MeasurementTypeModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<MeasurementTypeModel>(instance).Reference(o => o.CreatedBy).Load();
                    APIResultDTO<MeasurementTypeViewModel> result = new APIResultDTO<MeasurementTypeViewModel>();
                    result.IsOk = true;
                    result.Value = new MeasurementTypeViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<MeasurementTypeViewModel>>> Delete(Guid id)
        {
            if (IsUserKnown())
            {
                MeasurementTypeModel instance = await _dBcontext.MeasurementTypes.FirstOrDefaultAsync(o => o.Id == id);
                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.MeasurementTypes.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<MeasurementTypeViewModel> result = new APIResultDTO<MeasurementTypeViewModel>();
                result.IsOk = true;
                result.Value = new MeasurementTypeViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }
    }


}
