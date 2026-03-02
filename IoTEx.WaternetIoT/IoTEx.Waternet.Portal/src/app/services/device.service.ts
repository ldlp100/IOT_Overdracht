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

export class DeviceService extends BaseService {

  constructor(http: HttpClient, notificationService: NotificationService, propertyBag: DTO.ProjectPropertyBag) {

    super(http, notificationService, propertyBag);
    this.logON=true;
  }

  public getsAllDevicesGrid(state: State): Observable<GridDataResult> {

    this.log(`${this.BASE_URL}/devices/all/grid`);
    return this.http
      .post<GridDataResult>(`${this.BASE_URL}/devices/all/grid`, this.translateState(state))
      .pipe(
        map(response => (<GridDataResult>{
          data: response['value']['data'],
          total: response['value']['length']
        })
        ),
        tap(() => this.loading = false)
      );


  }
  public getsGrid(state: State, deviceTypeId: string, deviceBatchId: string): Observable<GridDataResult> {

    this.log(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/all/grid`);
    return this.http
      .post<GridDataResult>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/all/grid`, this.translateState(state))
      .pipe(
        map(response => (<GridDataResult>{
          data: response['value']['data'],
          total: response['value']['length']
        })
        ),
        tap(() => this.loading = false)
      );


  }

  public gets(state: any, deviceTypeId: string, deviceBatchId: string): Observable<DTO.APIResultDTO<DTO.DeviceDTO[]>> {

    this.log(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/all`);
    return this.http
      .post<DTO.APIResultDTO<DTO.DeviceDTO[]>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/all`, {});
  }

  public getDevice(deviceId: string): Observable<DTO.APIResultDTO<DTO.DeviceDTO>> {
    return this.http
      .get<DTO.APIResultDTO<DTO.DeviceDTO>>(`${this.BASE_URL}/devices/${deviceId}`);
  }
  public get( state: any,deviceTypeId:string,deviceBatchId:string,id:string): Observable<DTO.APIResultDTO<DTO.DeviceDTO>> {

    this.log(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${id}`);
    return this.http
      .get<DTO.APIResultDTO<DTO.DeviceDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${id}`, {});
  }
  public save(device: DTO.DeviceDTO, isNew: boolean, deviceTypeId: string, deviceBatchId: string): Observable<DTO.APIResultDTO<DTO.DeviceDTO>> {

    if (isNew) {
      this.log(`POST ${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices`);
      return this.http
        .post<DTO.APIResultDTO<DTO.DeviceDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices`, device);

    }
    else {
      this.log(`PUT ${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${device.id}`);

      return this.http
        .put<DTO.APIResultDTO<DTO.DeviceDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${device.id}`, device);

    }
  }
  public saveMinimal(device: DTO.DeviceDTO): Observable<DTO.APIResultDTO<DTO.DeviceDTO>> {
    this.log(`PUT ${this.BASE_URL}/devices/${device.id}/updateUser`);
    return this.http
      .put<DTO.APIResultDTO<DTO.DeviceDTO>>(`${this.BASE_URL}/devices/${device.id}/updateUser`, device);

  }
  public delete(device: DTO.DeviceDTO, deviceTypeId: string, deviceBatchId: string): Observable<DTO.APIResultDTO<DTO.DeviceDTO>> {

    this.log(`DELETE ${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${device.id}/`);
    return this.http
      .delete<DTO.APIResultDTO<DTO.DeviceDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${device.id}/`);

  }

  public publish(deviceId: string, deviceTypeId: string, deviceBatchId: string): Observable<DTO.APIResultDTO<string>> {

    this.log(`POST ${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/publish`);
      return this.http
        .post<DTO.APIResultDTO<string>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/publish`, {});
  }

  public getPublishDevice(deviceTypeId: string, deviceBatchId: string, deviceId: string): Observable<DTO.APIResultDTO<DTO.DeviceDefinitionDTO>> {
    return this.http
      .get<DTO.APIResultDTO<DTO.DeviceDefinitionDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${deviceId}/getPublish`);
  }

  public genConfig(device: DTO.DeviceDTO,deviceTypeId: string, deviceBatchId: string): Observable<DTO.APIResultDTO<boolean>> {

    this.log(`POST ${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${device.id}/genConfig`);
      return this.http
        .post<DTO.APIResultDTO<boolean>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${device.id}/genConfig`, device);
  }

  public pushConfig(device: DTO.DeviceDTO, deviceTypeId: string, deviceBatchId: string): Observable<DTO.APIResultDTO<boolean>> {

    this.log(`POST ${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${device.id}/pushConfig`);
      return this.http
        .post<DTO.APIResultDTO<boolean>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatchId}/devices/${device.id}/pushConfig`, device);
  }
}
