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

export class DeviceConfigurationService extends BaseService {

  constructor(http: HttpClient, notificationService: NotificationService, propertyBag: DTO.ProjectPropertyBag) {

    super(http, notificationService, propertyBag);
    this.logON=true;
  }

  public getsGrid(state: State, deviceTypeId: string, deviceBatchId: string, deviceId: string): Observable<GridDataResult> {

    this.log(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/configurations/all/grid`);
    return this.http
      .post<GridDataResult>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/configurations/all/grid`, this.translateState(state))
      .pipe(
        map(response => (<GridDataResult>{
          data: response['value']['data'],
          total: response['value']['length']
        })
        ),
        tap(() => this.loading = false)
      );


  }
  public gets(state: any, deviceTypeId: string, deviceBatchId: string, deviceId: string): Observable<DTO.APIResultDTO<DTO.DeviceConfigurationDTO[]>> {

    this.log(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/configurations/all`);
    return this.http
      .post<DTO.APIResultDTO<DTO.DeviceConfigurationDTO[]>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/configurations/all`, {});
  }
  public save(deviceConfiguration: DTO.DeviceConfigurationDTO, isNew: boolean, deviceTypeId: string, deviceBatchId: string, deviceId: string): Observable<DTO.APIResultDTO<DTO.DeviceConfigurationDTO>> {

    if (isNew) {
      this.log(`POST ${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/configurations`);
      return this.http
        .post<DTO.APIResultDTO<DTO.DeviceConfigurationDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/configurations`, deviceConfiguration);

    }
    else {
      this.log(`PUT ${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/configurations/${deviceConfiguration.id}`);

      return this.http
        .put<DTO.APIResultDTO<DTO.DeviceConfigurationDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/configurations/${deviceConfiguration.id}`, deviceConfiguration);

    }
  }
  public delete(deviceConfiguration: DTO.DeviceConfigurationDTO, deviceTypeId: string, deviceBatchId: string , deviceId: string): Observable<DTO.APIResultDTO<DTO.DeviceConfigurationDTO>> {

    this.log(`DELETE ${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/configurations/${deviceConfiguration.id}/`);
    return this.http
      .delete<DTO.APIResultDTO<DTO.DeviceConfigurationDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/configurations/${deviceConfiguration.id}/`);

  }
}
