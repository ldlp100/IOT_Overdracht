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

export class DeviceMessageService extends BaseService {

  constructor(http: HttpClient, notificationService: NotificationService, propertyBag: DTO.ProjectPropertyBag) {

    super(http, notificationService, propertyBag);
    this.logON=true;
  }

  public getsGrid(state: State, deviceTypeId: string, deviceBatchId: string, deviceId: string): Observable<GridDataResult> {

    this.log(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/messages/all/grid`);
    return this.http
      .post<GridDataResult>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/messages/all/grid`, this.translateState(state))
      .pipe(
        map(response => (<GridDataResult>{
          data: response['value']['data'],
          total: response['value']['length']
        })
        ),
        tap(() => this.loading = false)
      );


  }
  public gets(state: any, deviceTypeId: string, deviceBatchId: string, deviceId: string): Observable<DTO.APIResultDTO<DTO.DeviceMessageDTO[]>> {

    this.log(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/messages/all`);
    return this.http
      .post<DTO.APIResultDTO<DTO.DeviceMessageDTO[]>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/messages/all`, {});
  }
  public get(deviceTypeId: string, deviceBatchId: string, deviceId: string, deviceMessage: DTO.DeviceMessageDTO, path: string): Observable<DTO.APIResultDTO<DTO.DeviceMessageDTO>> {

    this.log(`GET ${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/messages/${deviceMessage.id}`);
    return this.http
      .get<DTO.APIResultDTO<DTO.DeviceMessageDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/messages/${deviceMessage.id}`);
  }

  public getLastMessage(deviceTypeId: string, deviceBatchId: string, deviceId: string): Observable<DTO.APIResultDTO<DTO.DeviceMessageContentDTO>> {

    this.log(`GET ${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/messages/last`);
    return this.http
      .get<DTO.APIResultDTO<DTO.DeviceMessageContentDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/messages/last`);
  }

  public getContent(deviceTypeId: string, deviceBatchId: string, deviceId: string, deviceMessage: DTO.DeviceMessageDTO, path: string): Observable<DTO.APIResultDTO<DTO.DeviceMessageDTO>> {

    this.log(`GET ${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/messages/${deviceMessage.id}/content`);
    return this.http
      .get<DTO.APIResultDTO<DTO.DeviceMessageDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/messages/${deviceMessage.id}/content`);
  }
  

}
