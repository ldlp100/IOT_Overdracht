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
    [Route("/api/suppliers/")]
    public class SupplierController : BaseController
    {
        public SupplierController(ILogger logger, IoTDBContext context, IConfiguration configuration)
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
        public async Task<ActionResult<APIResultDTO<List<SupplierViewModel>>>> GetAlls(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, SupplierViewModel.DefineMapper());
                IQueryable<SupplierModel> instances = _dBcontext.Suppliers
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy);

                APIResultDTO<List<SupplierViewModel>> result = new APIResultDTO<List<SupplierViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<SupplierModel, SupplierViewModel>
                    .DT(request, instances)
                    .Select(o => new SupplierViewModel(o))
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
        public async Task<ActionResult<APIResultDTO<GridResult<SupplierViewModel>>>> GetAllsGrid(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, SupplierViewModel.DefineMapper());
                IQueryable<SupplierModel> instances = _dBcontext.Suppliers
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy);

                APIResultDTO<GridResult<SupplierViewModel>> result = new APIResultDTO<GridResult<SupplierViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<SupplierModel, SupplierViewModel>
                    .DTGrid(request, instances, o => new SupplierViewModel(o));

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
        public async Task<ActionResult<APIResultDTO<SupplierViewModel>>> Get(Guid id)
        {
            if (IsUserKnown())
            {
                SupplierModel instance = await _dBcontext.Suppliers
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .FirstAsync(o => o.Id == id);

                if (instance != null)
                {
                    
                    APIResultDTO<SupplierViewModel> result = new APIResultDTO<SupplierViewModel>();
                    result.IsOk = true;
                    result.Value = new SupplierViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<SupplierViewModel>>> Create(SupplierViewModel dtoInstance)
        {
            if (IsUserKnown())
            {

                SupplierModel instance = dtoInstance.Create(GetAppUser());

                _dBcontext.Suppliers.Add(instance);
                _dBcontext.SaveChanges();
                _dBcontext.Entry<SupplierModel>(instance).Reference(o => o.UpdatedBy).Load();
                _dBcontext.Entry<SupplierModel>(instance).Reference(o => o.CreatedBy).Load();

                APIResultDTO<SupplierViewModel> result = new APIResultDTO<SupplierViewModel>();
                result.IsOk = true;
                result.Value = new SupplierViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<SupplierViewModel>>> Update(Guid id, SupplierViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                SupplierModel instance = _dBcontext.Suppliers
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
                    _dBcontext.Entry<SupplierModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<SupplierModel>(instance).Reference(o => o.CreatedBy).Load();
                    APIResultDTO<SupplierViewModel> result = new APIResultDTO<SupplierViewModel>();
                    result.IsOk = true;
                    result.Value = new SupplierViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<SupplierViewModel>>> Delete(Guid id)
        {
            if (IsUserKnown())
            {
                SupplierModel instance = await _dBcontext.Suppliers
                    .FirstOrDefaultAsync(o => o.Id == id);

                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.Suppliers.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<SupplierViewModel> result = new APIResultDTO<SupplierViewModel>();
                result.IsOk = true;
                result.Value = new SupplierViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }
    }


}
