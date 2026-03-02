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

export class DeviceOutputService extends BaseService {

  constructor(http: HttpClient, notificationService: NotificationService, propertyBag: DTO.ProjectPropertyBag) {

    super(http, notificationService, propertyBag);
    this.logON=true;
  }

  public getsGrid(state: State, deviceTypeId: string, deviceBatchId: string, deviceId: string): Observable<GridDataResult> {

    this.log(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/outputs/all/grid`);
    return this.http
      .post<GridDataResult>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/outputs/all/grid`, this.translateState(state))
      .pipe(
        map(response => (<GridDataResult>{
          data: response['value']['data'],
          total: response['value']['length']
        })
        ),
        tap(() => this.loading = false)
      );


  }
  public gets(state: any, deviceTypeId: string, deviceBatchId: string, deviceId: string): Observable<DTO.APIResultDTO<DTO.DeviceOutputDTO[]>> {

    this.log(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/outputs/all`);
    return this.http
      .post<DTO.APIResultDTO<DTO.DeviceOutputDTO[]>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/outputs/all`, {});
  }
  public save(deviceOutput: DTO.DeviceOutputDTO, isNew: boolean, deviceTypeId: string, deviceBatchId: string, deviceId: string): Observable<DTO.APIResultDTO<DTO.DeviceOutputDTO>> {

    if (isNew) {
      this.log(`POST ${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/outputs`);
      return this.http
        .post<DTO.APIResultDTO<DTO.DeviceOutputDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/outputs`, deviceOutput);

    }
    else {
      this.log(`PUT ${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/outputs/${deviceOutput.id}`);

      return this.http
        .put<DTO.APIResultDTO<DTO.DeviceOutputDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/outputs/${deviceOutput.id}`, deviceOutput);

    }
  }
  public delete(deviceOutput: DTO.DeviceOutputDTO, deviceTypeId: string, deviceBatchId: string , deviceId: string): Observable<DTO.APIResultDTO<DTO.DeviceOutputDTO>> {

    this.log(`DELETE ${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/outputs/${deviceOutput.id}/`);
    return this.http
      .delete<DTO.APIResultDTO<DTO.DeviceOutputDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/outputs/${deviceOutput.id}/`);

  }
}
