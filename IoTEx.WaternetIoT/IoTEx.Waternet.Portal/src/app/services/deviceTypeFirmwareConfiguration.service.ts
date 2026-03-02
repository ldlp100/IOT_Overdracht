import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as DTO from '../models/_index';
import { BaseService } from "./base.service"
import { protectedResources } from '../auth-config';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';

import { GridDataResult } from '@progress/kendo-angular-grid';
import { State, FilterDescriptor, CompositeFilterDescriptor } from '@progress/kendo-data-query';
import { NotificationService } from '@progress/kendo-angular-notification';

@Injectable({
  providedIn: 'root'
})

export class DeviceTypeFirmwareConfigurationService extends BaseService {

  constructor(http: HttpClient, notificationService: NotificationService, propertyBag: DTO.ProjectPropertyBag) {

    super(http, notificationService, propertyBag);
    this.logON=true;
  }

  public getsGrid(state: State, deviceTypeId: string, firmwaresId: string): Observable<GridDataResult> {

    this.log(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/configurations/all/grid`);
    return this.http
      .post<GridDataResult>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/configurations/all/grid`, this.translateState(state))
      .pipe(
        map(response => (<GridDataResult>{
          data: response['value']['data'],
          total: response['value']['length']
        })
        ),
        tap(() => this.loading = false)
      );


  }
  public gets(state: any, deviceTypeId: string, firmwaresId: string): Observable<DTO.APIResultDTO<DTO.DeviceTypeFirmwareConfigurationDTO[]>> {

    this.log(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/configurations/all`);
    return this.http
      .post<DTO.APIResultDTO<DTO.DeviceTypeFirmwareConfigurationDTO[]>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/configurations/all`, {});
  }
  public save(deviceTypeFirmwareConfigurations: DTO.DeviceTypeFirmwareConfigurationDTO, isNew: boolean, deviceTypeId: string, firmwaresId: string): Observable<DTO.APIResultDTO<DTO.DeviceTypeFirmwareConfigurationDTO>> {

    if (isNew) {
      this.log(`POST ${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/configurations`);
      return this.http
        .post<DTO.APIResultDTO<DTO.DeviceTypeFirmwareConfigurationDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/configurations`, deviceTypeFirmwareConfigurations);

    }
    else {
      this.log(`PUT ${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/configurations/${deviceTypeFirmwareConfigurations.id}`);

      return this.http
        .put<DTO.APIResultDTO<DTO.DeviceTypeFirmwareConfigurationDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/configurations/${deviceTypeFirmwareConfigurations.id}`, deviceTypeFirmwareConfigurations);

    }
  }
  public delete(deviceTypeFirmwareConfigurations: DTO.DeviceTypeFirmwareConfigurationDTO, deviceTypeId: string, firmwaresId: string): Observable<DTO.APIResultDTO<DTO.DeviceTypeFirmwareConfigurationDTO>> {

    this.log(`DELETE ${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${deviceTypeFirmwareConfigurations.id}/`);
    return this.http
      .delete<DTO.APIResultDTO<DTO.DeviceTypeFirmwareConfigurationDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/configurations/${deviceTypeFirmwareConfigurations.id}/`);

  }
}
