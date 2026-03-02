export { Injectable } from '@angular/core'
import { Injectable } from '@angular/core'
import { BaseService } from './base.service'
import { HttpClient } from '@angular/common/http'
import { NotificationService } from '@progress/kendo-angular-notification'
import { ProjectPropertyBag } from '../models/_index'
import { APIService } from './api.service'
import { ParserService } from './parser.service'
import { SupplierService } from './supplier.service'
import { UnitTypeService } from './unitType.service'
import { AppConfigurationService } from './appConfiguration.service'
import { NetworkAPIService } from './networkAPI.service'
import { NetworkAPISettingService } from './networkAPISetting.service'
import { ProjectService } from './project.service'
import { DeviceTypeService } from './deviceType.service'
import { DeviceBatchService } from './deviceBatch.service'
import { DeviceService } from './device.service'
import { DeviceTypeFirmwareService } from './deviceTypeFirmware.service'
import { DeviceOutputService } from './deviceOutput.service'
import { DeviceCalibrationService } from './deviceCalibration.service'
import { DeviceConfigurationService } from './deviceConfiguration.service'
import { DeviceTypeFirmwareStateService } from './deviceTypeFirmwareState.service'
import { DeviceTypeFirmwareAlertService } from './deviceTypeFirmwareAlert.service'
import { DeviceTypeFirmwareMeasurementTypeService } from './deviceTypeFirmwareMeasurementType.service'
import { DeviceTypeFirmwareConfigurationService } from './deviceTypeFirmwareConfiguration.service'
import { DeviceType2NetworkAPIService } from './deviceType2NetworkAPI.service'
import { AppUserService } from './appUser.service'
import { TargetDBService } from './targetDB.service'
import { DeviceMessageService} from './deviceMessage.service'
import { User2projectService } from './user2project.service'
import { Device2projectService } from './device2project.service'
import { DeviceTypeFirmwareSubStateService } from './deviceTypeFirmwareSubState.service'
import {DeviceTelemetryService} from './deviceTelemetry.service'
@Injectable()
export class IoTExService extends BaseService {

  constructor(protected override http: HttpClient, protected override notificationService: NotificationService, protected override propertyBag: ProjectPropertyBag) {
    super(http, notificationService, propertyBag);
  }
  public apiService = new APIService(this.http, this.notificationService, this.propertyBag);
  
  public supplierService = new SupplierService(this.http, this.notificationService, this.propertyBag);
  public parserService = new ParserService(this.http, this.notificationService, this.propertyBag);
  public unitTypeService = new UnitTypeService(this.http, this.notificationService, this.propertyBag);
  public appConfigurationService = new AppConfigurationService(this.http, this.notificationService, this.propertyBag);
  public networkAPIService = new NetworkAPIService(this.http, this.notificationService, this.propertyBag);
  public networkAPISettingService = new NetworkAPISettingService(this.http, this.notificationService, this.propertyBag);
  public projectService = new ProjectService(this.http, this.notificationService, this.propertyBag);
  public deviceTypeService = new DeviceTypeService(this.http, this.notificationService, this.propertyBag);
  public deviceBatchService = new DeviceBatchService(this.http, this.notificationService, this.propertyBag);
  public deviceService = new DeviceService(this.http, this.notificationService, this.propertyBag);
  public deviceTypeFirmwareService = new DeviceTypeFirmwareService(this.http, this.notificationService, this.propertyBag);
  public deviceOutputService = new DeviceOutputService(this.http, this.notificationService, this.propertyBag);
  public deviceCalibrationService = new DeviceCalibrationService(this.http, this.notificationService, this.propertyBag);
  public deviceConfigurationService = new DeviceConfigurationService(this.http, this.notificationService, this.propertyBag);
  public deviceTypeFirmwareStateService = new DeviceTypeFirmwareStateService(this.http, this.notificationService, this.propertyBag);
  public deviceTypeFirmwareAlertService = new DeviceTypeFirmwareAlertService(this.http, this.notificationService, this.propertyBag);
  public deviceTypeFirmwareMeasurementTypeService = new DeviceTypeFirmwareMeasurementTypeService(this.http, this.notificationService, this.propertyBag);
  public deviceTypeFirmwareConfigurationService = new DeviceTypeFirmwareConfigurationService(this.http, this.notificationService, this.propertyBag);
  public deviceType2NetworkAPIService = new DeviceType2NetworkAPIService(this.http, this.notificationService, this.propertyBag);
  public appUserService = new AppUserService(this.http, this.notificationService, this.propertyBag);
  public targetDBService = new TargetDBService(this.http, this.notificationService, this.propertyBag);
  public deviceMessageService = new DeviceMessageService(this.http, this.notificationService, this.propertyBag);
  public user2projectService = new User2projectService(this.http, this.notificationService, this.propertyBag);
  public device2projectService = new Device2projectService(this.http, this.notificationService, this.propertyBag);
  public deviceTypeFirmwareSubStateService = new DeviceTypeFirmwareSubStateService(this.http, this.notificationService, this.propertyBag);
  public DeviceTelemetryService = new DeviceTelemetryService(this.http, this.notificationService, this.propertyBag);
}

