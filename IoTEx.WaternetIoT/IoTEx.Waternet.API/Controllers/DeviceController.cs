
using IoTEx.WaternetIoT.DAL;
using IoTEx.WaternetIoT.Model.DTOs.API;
using IoTEx.WaternetIoT.Model.PortalModels;
using IoTEx.WaternetIoT.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web.Resource;
using Azure.Storage.Blobs;
using Newtonsoft.Json;
using IoTEx.WaternetIoT.Model.DTOs;

namespace IoTEx.Waternet.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/deviceTypes/{deviceTypeId}/deviceBatchs/{deviceBatchId}/devices/")]

    public class DeviceController : BaseController
    {
        private BlobServiceClient _blobServiceClient;
        private IKustoService _kustoService;
        string containerName = "iotdevices";
        public DeviceController(ILogger logger, IoTDBContext context, IConfiguration configuration, 
            BlobServiceClient blobserviceClient, IKustoService kustoService)
        {

            _dBcontext = context;
            _logger = logger;
            _configuration = configuration;
            _blobServiceClient = blobserviceClient;
            _kustoService = kustoService;
        }

        [HttpPost("all")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<List<DeviceViewModel>>>> GetAlls(
            APIRequestDTO request, Guid deviceTypeId, Guid deviceBatchId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceViewModel.DefineMapper());
                IQueryable<DeviceModel> instances = _dBcontext.Devices
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.DeviceBatch.DeviceType)
                    .Include(o => o.DeviceBatch)
                    .Include(o => o.DeviceTypeFirmware)
                    .Where(o => o.DeviceBatchId == deviceBatchId && o.DeviceBatch.DeviceTypeId == deviceTypeId);

                APIResultDTO<List<DeviceViewModel>> result = new APIResultDTO<List<DeviceViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<DeviceModel, DeviceViewModel>
                    .DT(request, instances)
                    .Select(o => new DeviceViewModel(o))
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
        public async Task<ActionResult<APIResultDTO<GridResult<DeviceViewModel>>>> GetAllsGrid(
            APIRequestDTO request, Guid deviceTypeId, Guid deviceBatchId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceViewModel.DefineMapper());
                IQueryable<DeviceModel> instances = _dBcontext.Devices
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.DeviceBatch.DeviceType)
                    .Include(o => o.DeviceBatch)
                    .Include(o => o.DeviceTypeFirmware)
                    .Where(o => o.DeviceBatchId == deviceBatchId && o.DeviceBatch.DeviceTypeId == deviceTypeId);

                APIResultDTO<GridResult<DeviceViewModel>> result = new APIResultDTO<GridResult<DeviceViewModel>>();
                result.IsOk = true;

                result.Value = APIRequester<DeviceModel, DeviceViewModel>
                    .DTGrid(request, instances, o => new DeviceViewModel(o));

                return result;
            }
            else
                return Unauthorized();
        }
        [HttpPost("/api/devices/all/grid")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<GridResult<DeviceViewModel>>>> GetDevicesAllsGrid(
            APIRequestDTO request)
        {
            APIResultDTO<GridResult<DeviceViewModel>> result = new APIResultDTO<GridResult<DeviceViewModel>>();
            try {
                if (IsUserKnown())
                {
                    ManageMapper(request, DeviceViewModel.DefineMapper());
                    IQueryable<DeviceModel> instances = _dBcontext.Devices
                        .Include(o => o.CreatedBy)
                        .Include(o => o.UpdatedBy)
                        .Include(o => o.DeviceBatch.DeviceType)
                        .Include(o => o.DeviceBatch)
                        .Include(o => o.DeviceTypeFirmware);

                    
                    result.IsOk = true;

                    result.Value = APIRequester<DeviceModel, DeviceViewModel>
                        .DTGrid(request, instances, o => new DeviceViewModel(o));

                    
                }
                else
                    return Unauthorized();
            }
            catch (Exception ex)
            {
                result.IsOk = false;
                result.Error = ex.Message;
                
            }
            return result;
        }
        [HttpGet("/api/devices/{deviceId}")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] {_RoleIoTExAdmin, _RoleProjectAdmin, _RoleProjectGuest, _RoleProjectReader }
        )]
        public async Task<ActionResult<APIResultDTO<DeviceViewModel>>> GetDevice(Guid deviceId)
        {
            if (IsUserKnown())
            {
                DeviceModel instance = await _dBcontext.Devices
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.DeviceBatch.DeviceType)
                    .Include(o => o.DeviceBatch)
                    .Include(o => o.DeviceTypeFirmware)
                    .FirstAsync(o => o.Id == deviceId);

                if (instance != null)
                {

                    APIResultDTO<DeviceViewModel> result = new APIResultDTO<DeviceViewModel>();
                    result.IsOk = true;
                    result.Value = new DeviceViewModel(instance);
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

        [HttpGet("{id}")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<DeviceViewModel>>> Get(Guid id, Guid deviceTypeId,
            Guid deviceBatchId)
        {
            if (IsUserKnown())
            {
                DeviceModel instance = await _dBcontext.Devices
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.DeviceBatch.DeviceType)
                    .Include(o => o.DeviceBatch)
                    .Include(o => o.DeviceTypeFirmware)
                    .FirstOrDefaultAsync(o => o.Id == id && o.DeviceBatchId == deviceBatchId && o.DeviceBatch.DeviceTypeId == deviceTypeId);

                if (instance != null)
                {

                    APIResultDTO<DeviceViewModel> result = new APIResultDTO<DeviceViewModel>();
                    result.IsOk = true;
                    result.Value = new DeviceViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceViewModel>>> Create(
            Guid deviceBatchId, DeviceViewModel dtoInstance)
        {
            APIResultDTO<DeviceViewModel> result = new APIResultDTO<DeviceViewModel>();
            if (IsUserKnown())
            {
                try
                {
                    DeviceModel instance = dtoInstance.Create(GetAppUser());
                    instance.DeviceBatchId = deviceBatchId;
                    
                    
                    _dBcontext.Devices.Add(instance);
                    _dBcontext.SaveChanges();
                    _dBcontext.Entry<DeviceModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<DeviceModel>(instance).Reference(o => o.CreatedBy).Load();
                    _dBcontext.Entry<DeviceModel>(instance).Reference(o => o.DeviceBatch).Load();
                    _dBcontext.Entry<DeviceBatchModel>(instance.DeviceBatch).Reference(o => o.DeviceType).Load();
                    
                    result.IsOk = true;
                    result.Value = new DeviceViewModel(instance);
                }
                catch (Exception ex)
                {
                    result.IsOk = false;
                    result.Error = ex.Message + ex.InnerException.Message;
                }
                return result;
            }
            else
                return Unauthorized();
        }

        [HttpPut("/api/devices/{id}/updateUser")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin, _RoleProjectAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<DeviceViewModel>>> UpdateUser(
            Guid id, DeviceViewModel dtoInstance)
        {
            APIResultDTO<DeviceViewModel> result = new APIResultDTO<DeviceViewModel>();
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }
                //CheckProject
                if (!MayChangeDeviceData(id))
                {
                    result.IsOk = false;
                    result.Error = "User is not allowed to change this device data";
                    return result;
                }
                DeviceModel instance = _dBcontext.Devices
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.DeviceBatch.DeviceType)
                    .Include(o => o.DeviceBatch)
                    .Include(o => o.DeviceTypeFirmware)
                    .FirstOrDefault(o => o.Id == id);

                if (instance == null)
                {
                    return NotFound();
                }
                DeviceViewModel view = new DeviceViewModel(instance);
                view.Name = dtoInstance.Name;
                view.AssetUID = dtoInstance.AssetUID;
                view.Long = dtoInstance.Long;
                view.Lat = dtoInstance.Lat;
                view.InstalledDate = dtoInstance.InstalledDate;                
                instance = view.Update(instance, GetAppUser());
                _dBcontext.Entry(instance).State = EntityState.Modified;

                try
                {
                    await _dBcontext.SaveChangesAsync();
                    _dBcontext.Entry<DeviceModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<DeviceModel>(instance).Reference(o => o.CreatedBy).Load();
                    _dBcontext.Entry<DeviceModel>(instance).Reference(o => o.DeviceBatch).Load();
                    _dBcontext.Entry<DeviceBatchModel>(instance.DeviceBatch).Reference(o => o.DeviceType).Load();

                    
                    result.IsOk = true;
                    result.Value = new DeviceViewModel(instance);
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

        [HttpPut("{id}")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<DeviceViewModel>>> Update(
            Guid deviceBatchId, Guid id, DeviceViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                DeviceModel instance = _dBcontext.Devices
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.DeviceBatch.DeviceType)
                    .Include(o => o.DeviceBatch)
                    .Include(o => o.DeviceTypeFirmware)
                    .FirstOrDefault(o => o.Id == id);

                if (instance == null)
                {
                    return NotFound();
                }

                instance = dtoInstance.Update(instance, GetAppUser());
                instance.DeviceBatchId = deviceBatchId;
                _dBcontext.Entry(instance).State = EntityState.Modified;

                try
                {
                    await _dBcontext.SaveChangesAsync();
                    _dBcontext.Entry<DeviceModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<DeviceModel>(instance).Reference(o => o.CreatedBy).Load();
                    _dBcontext.Entry<DeviceModel>(instance).Reference(o => o.DeviceBatch).Load();
                    _dBcontext.Entry<DeviceBatchModel>(instance.DeviceBatch).Reference(o => o.DeviceType).Load();
                    
                    APIResultDTO<DeviceViewModel> result = new APIResultDTO<DeviceViewModel>();
                    result.IsOk = true;
                    result.Value = new DeviceViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceViewModel>>> Delete(Guid deviceTypeId,
            Guid deviceBatchId, Guid id)
        {
            if (IsUserKnown())
            {
                DeviceModel instance = await _dBcontext.Devices
                    .FirstOrDefaultAsync(o => o.Id == id && o.DeviceBatchId == deviceBatchId && o.DeviceBatch.DeviceTypeId == deviceTypeId);
                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.Devices.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<DeviceViewModel> result = new APIResultDTO<DeviceViewModel>();
                result.IsOk = true;
                result.Value = new DeviceViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<string>>> PublishDevice(
             Guid deviceTypeId, Guid deviceBatchId, Guid id)
        {
            if (IsUserKnown())
            {
                return await PublishDeviceInternal(deviceTypeId, deviceBatchId, id, GetAppUser());
            }
            else
                return Unauthorized();
        }


        [HttpGet("{id}/getPublish")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] {_RoleIoTExAdmin, _RoleProjectAdmin, _RoleProjectGuest, _RoleProjectReader , }
        )]
        public async Task<ActionResult<APIResultDTO<DeviceDefinitionDTO>>> GetPublishDevice(Guid deviceTypeId,
            Guid deviceBatchId, Guid id)
        {
            APIResultDTO<DeviceDefinitionDTO?> result = new APIResultDTO<DeviceDefinitionDTO>();

            if (IsUserKnown())
            {
                DeviceDefinitionPublishedDTO publishDevice = _kustoService.GetDevice(id);
                if (publishDevice != null)
                {
                    string json = publishDevice.JSON;
                    if (json != null)
                    {
                        result.IsOk = true;
                        result.Value = JsonConvert.DeserializeObject<DeviceDefinitionDTO>(json);
                    }
                    else
                    {
                        result.IsOk = true;
                        result.Value = null;
                        
                    }
                }
                return result;
            }
            else
                return Unauthorized();
        }


        [NonAction]
        public async Task<APIResultDTO<string>> PublishDeviceInternal(
             Guid deviceTypeId, Guid deviceBatchId, Guid id, AppUserModel user)
        {
            APIResultDTO<string> result = new APIResultDTO<string>();

            DeviceModel instance = await _dBcontext.Devices
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.DeviceBatch.DeviceType)
                    .Include(o => o.DeviceBatch)
                    .Include(o => o.DeviceTypeFirmware)
                    .FirstOrDefaultAsync(o => o.Id == id && 
                            o.DeviceBatchId == deviceBatchId && 
                            o.DeviceBatch.DeviceTypeId == deviceTypeId);

            
            if (instance != null)
            {
                DeviceDefinitionDTO doc = GenerateDocumentDevice(instance, user);
                DeviceDefinitionPublishedDTO docJson = new DeviceDefinitionPublishedDTO();
                docJson.DeviceId = doc.deviceId;
                docJson.JSON = JsonConvert.SerializeObject(doc);
                docJson.IsActive = (doc.isActive)?(sbyte)1: (sbyte)0;

                docJson.NetworkId = (!string.IsNullOrEmpty(instance.IMEI)) ? instance.IMEI : instance.LORA_DEVEUI;
                docJson.Published = DateTime.UtcNow;

                _kustoService.CreateTableDevice();
                result.IsOk = await _kustoService.InsertDevice(docJson);

                if (result.IsOk)
                {
                    result.Value = docJson.JSON;
                    instance.PublishedDocId = result.Value;
                    instance.PublishedDocDate = DateTime.UtcNow;
                    _dBcontext.SaveChanges();
                }
            }

            return result;

        }

        [HttpPost("{id}/genConfig")]
        [RequiredScopeOrAppPermission(
             AcceptedScope = new string[] { },
             AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
         )]
        public async Task<ActionResult<APIResultDTO<string>>> GenConfig(
             Guid deviceTypeId, Guid deviceBatchId, Guid id)
        {
            if (IsUserKnown())
            {
                APIResultDTO<string> result = new APIResultDTO<string>();
                result.IsOk = true;
                result.Value = "Genconfig";
                return result;
            }
            else
                return Unauthorized();
        }

        [HttpPost("{id}/pushConfig")]
        [RequiredScopeOrAppPermission(
             AcceptedScope = new string[] { },
             AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
         )]
        public async Task<ActionResult<APIResultDTO<string>>> PushConfig(
             Guid deviceTypeId, Guid deviceBatchId, Guid id)
        {
            if (IsUserKnown())
            {
                APIResultDTO<string> result = new APIResultDTO<string>();
                result.IsOk = true;
                result.Value = "PushConfig";
                return result;
            }
            else
                return Unauthorized();
        }

        private DeviceDefinitionDTO GenerateDocumentDevice(DeviceModel device, AppUserModel user)
        {
            if (device != null)
            {
                DeviceTypeFirmwareModel firmware = _dBcontext.DeviceTypeFirmwares
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Parser)
                    .FirstOrDefault(o => o.Id == device.DeviceTypeFirmwareId);


                //Search for documents

                DeviceDefinitionDTO doc = new DeviceDefinitionDTO()
                {
                    deviceId = device.Id.ToString(),
                    deviceName = device.Name,
                    isActive = device.IsActive,
                    isTraced = device.IsTraced,
                    info = new DeviceDefinitionInfoDTO()
                    {

                        serialNr = device.SerialNr,
                        
                        harwareVersion = device.HarwareVersion,
                        deviceBatchId = (device.DeviceBatch != null) ? device.DeviceBatchId.ToString() : null,
                        deviceBatchName = (device.DeviceBatch != null) ? device.DeviceBatch.Name : null,
                        deviceTypeId = device.DeviceBatch.DeviceType.Id.ToString(),
                        deviceTypeName = device.DeviceBatch.DeviceType.Name,

                        deviceParserId = (device.DeviceTypeFirmware != null) ? device.DeviceTypeFirmware.Parser.Id.ToString() : null,
                        deviceParserName = (device.DeviceTypeFirmware != null) ? device.DeviceTypeFirmware.Parser.Name : null,
                        deviceParserClassName = (device.DeviceTypeFirmware != null) ? device.DeviceTypeFirmware.Parser.ClassName : null,
                        deviceFirmwareName = (device.DeviceTypeFirmware != null) ? device.DeviceTypeFirmware.Name : null,
                        deviceFirmwareId = (device.DeviceTypeFirmware != null) ? device.DeviceTypeFirmware.Id.ToString() : null,

                    },
                    location = new DeviceDefinitionLocationDTO()
                    {
                        //Geographical
                        latitude = device.Lat,
                        longitude = device.Long,
                        altitude = device.Altitude,
                    },
                    assetUID = device.AssetUID,
                    network = new DeviceDefinitionNetworkInfoDTO()
                    {
                        //Connectivity Info
                        iccid = device.ICCID,
                        imei = device.IMEI,
                        lora_deveui = device.LORA_DEVEUI,
                        sigFoxId = device.SigFoxId
                    },

                    //TelemetryConfiguration
                    settings = new DeviceDefinitionSettingsDTO()
                    {
                       
                        configurations = new List<DeviceDefinitionConfigurationDTO>(),
                        
                    },
                    //Publish info
                    publishedDate = DateTime.UtcNow,
                    publishedByUserId = user.Id.ToString(),
                    publishedByUsername = user.Username,
                    installedDate = device.InstalledDate

                };
                //Add Measuremenent Definition from firmware
                IQueryable<DeviceTypeFirmwareMeasurementTypeModel> measurements = _dBcontext.DeviceTypeFirmware2MeasurementTypes
                                                                    .Include(o=>o.UnitType)
                                                                    .Where(o => o.DeviceTypeFirmwareId == device.DeviceTypeFirmwareId);
                doc.settings.measurements = new List<DeviceDefinitionMeasurementDTO>();
                foreach (DeviceTypeFirmwareMeasurementTypeModel measurement in measurements)
                {
                    doc.settings.measurements.Add(new DeviceDefinitionMeasurementDTO()
                    {
                        id = measurement.Id.ToString(),
                        name = measurement.Name,
                        unit = measurement.UnitType.Name,    
                        maxMeasurement = measurement.MaxMeas,
                        minMeasurement = measurement.MinMeas,
                        maxSensor = measurement.MaxSensor,
                        minSensor = measurement.MinSensor,
                        offsetValue = measurement.OffsetValue,
                        unitLabel = measurement.UnitType.Label,
                        description = measurement.Description,
                        updatedById = measurement.UpdatedBy.Id.ToString(),
                        updatedByName = measurement.UpdatedBy.Username
                    });
                }
                //correct with the Calibrations at device level
                IQueryable<DeviceCalibrationModel> calibrations = _dBcontext.Device2Calibrations
                                                                    .Include(o => o.UpdatedBy)
                                                                    .Include(o=>o.DeviceTypeFirmware2MeasurementType)
                                                                    .Where(o => o.DeviceId == device.Id);
                foreach (DeviceCalibrationModel calibration in calibrations)
                {
                    var meas = doc.settings.measurements.FirstOrDefault(o => o.id == calibration.DeviceTypeFirmware2MeasurementTypeId.ToString());
                    if (meas != null)
                    {
                        meas.minMeasurement = calibration.MinMeas;
                        meas.maxMeasurement = calibration.MaxMeas;
                        meas.minSensor = calibration.MinReal;
                        meas.maxSensor = calibration.MaxReal;
                        meas.offsetValue = calibration.OffsetValue;
                    }
                }

                //Add States and Alerts Definition
                IQueryable<DeviceTypeFirmwareEventStateTypeModel> states = _dBcontext.DeviceTypeFirmware2EventStateTypes
                                                                    .Include(o=>o.SubStates)
                                                                    .Where(o => o.DeviceTypeFirmwareId == device.DeviceTypeFirmwareId);
                doc.settings.states = new List<DeviceDefinitionStateDTO>();
                foreach (DeviceTypeFirmwareEventStateTypeModel state in states)
                {
                    if (!state.IsAlert)
                    {
                        doc.settings.states.Add(new DeviceDefinitionStateDTO()
                        {
                            id = state.Id.ToString(),
                            name = state.Name,
                            description = state.Description,
                            values = state.SubStates.Select(o => new DeviceDefinitionSubStateDTO()
                            {
                                name = o.Name,
                                value = o.Value,
                                updatedById = o.UpdatedBy.Id.ToString(),
                                updatedByName = o.UpdatedBy.Username,
                                description = o.Description
                            }).ToList()
                        });
                    }
                    else
                    {
                        doc.settings.alerts.Add(new DeviceDefinitionAlertDTO()
                        {
                            id = state.Id.ToString(),
                            name = state.Name,
                            description = state.Description,
                            values = state.SubStates.Select(o => new DeviceDefinitionSubStateDTO()
                            {
                                name = o.Name,
                                value = o.Value,
                                updatedById = o.UpdatedBy.Id.ToString(),
                                updatedByName = o.UpdatedBy.Username,
                                description = o.Description
                            }).ToList()
                        });
                    }
                }

                //Add Process Codes
                IQueryable<DeviceOutputModel> outputs = _dBcontext.Device2Outputs
                                                            .Include(o=>o.UnitType)
                                                            .Include(o => o.UpdatedBy)
                                                            .Include(o=>o.EventStateType)
                                                            .Include(o=>o.MeasurementType)
                                                            .Where(o => o.DeviceId == device.Id);
                foreach (DeviceOutputModel output in outputs)
                {
                    doc.settings.processCodes.Add(new DeviceDefinitionProcessCodeDTO()
                    {
                        updatedByName = output.UpdatedBy.Username,
                        updatedById = output.UpdatedById.ToString(),
                        alertName = (output.IsAlert) ? output.EventStateType.Name : null,
                        stateAlertId = (output.EventStateType!=null) ?output.EventStateType.Id.ToString():null,
                        stateName = (!output.IsAlert && output.EventStateType!=null) ? output.EventStateType.Name : null,
                        measurementId = (output.MeasurementType != null) ? output.MeasurementTypeId.ToString():null,
                        measurementName = (output.MeasurementType != null) ? output.MeasurementType.Name : null,
                        name = output.PC,
                        unitTypeId = (output.UnitType!=null) ? output.UnitTypeId.ToString() : null,
                        unitTypeLabel = (output.UnitType != null) ? output.UnitType.Label.ToString() : null,
                        unitTypeName = (output.UnitType != null) ? output.UnitType.Name : null,

                    });
                }

                IQueryable<DeviceConfigurationModel> configurations = _dBcontext.Device2Configurations                                                            
                                                            .Include(o => o.UpdatedBy)
                                                            .Include(o => o.DeviceTypeFirmwareConfiguration)
                                                            .Where(o => o.DeviceId == device.Id);
                
                foreach (DeviceConfigurationModel config in configurations)
                {
                    doc.settings.configurations.Add(new DeviceDefinitionConfigurationDTO()
                    {
                        updatedByName = config.UpdatedBy.Username,
                        updatedById = config.UpdatedById.ToString(),
                        value = config.Value,
                        //config.DeviceTypeFirmwareConfiguration.DefaultValue,
                        name = config.DeviceTypeFirmwareConfiguration.Name,
                        description = config.DeviceTypeFirmwareConfiguration.Description,
                        MaxLength = config.DeviceTypeFirmwareConfiguration.MaxLength,
                        MaxValue = config.DeviceTypeFirmwareConfiguration.MaxValue,
                        MinLength = config.DeviceTypeFirmwareConfiguration.MinLength,
                        MinValue = config.DeviceTypeFirmwareConfiguration.MinValue,
                        role = config.DeviceTypeFirmwareConfiguration.Role.ToString(),                        
                        type = Enum.Parse< DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum>(config.DeviceTypeFirmwareConfiguration.TypeName),
                        id = config.Id.ToString()
                    });
                }

                IQueryable<AttachmentModel> attachments = _dBcontext.Attachments.Where(o => o.ObjectId == device.DeviceTypeFirmwareId &&
                                            o.ObjectType == AttachmentModel.ObjectTypeEnum.FIRMWARE || o.ObjectId == device.DeviceBatch.DeviceTypeId &&
                                            o.ObjectType == AttachmentModel.ObjectTypeEnum.DEVICETYPE || o.ObjectId == device.Id &&
                                            o.ObjectType == AttachmentModel.ObjectTypeEnum.DEVICE);
                doc.info.attachments = new List<DeviceDefinitionAttachmentDTO>();
                foreach (AttachmentModel attach in attachments)
                {
                    doc.info.attachments.Add(new DeviceDefinitionAttachmentDTO()
                    {
                        url = attach.URL,
                        name = attach.Name,
                        objectType = attach.ObjectType.ToString(),
                        attachType = attach.AttachmentType.ToString(),
                    });
                }

                IQueryable<Device2ProjectModel> deviceProjects = _dBcontext.Device2Projects.Include(o=>o.Project).Where(o => o.DeviceId == device.Id);
                doc.projects = new List<DeviceDefinitionProjectDTO>();
                foreach (Device2ProjectModel deviceProject in deviceProjects)
                {
                    doc.projects.Add(new DeviceDefinitionProjectDTO()
                    {
                        id = deviceProject.Project.Id.ToString(),
                        startDate = deviceProject.Project.BeginDate,
                        endDate = deviceProject.Project.EndDate,
                        name = deviceProject.Project.Name,
                        targetDB = deviceProject.Project.TargetDBString
                    });
                }
                return doc;
            }
            return null;
        }

    }
}
