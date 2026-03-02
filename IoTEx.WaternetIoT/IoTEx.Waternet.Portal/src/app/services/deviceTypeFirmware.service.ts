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

export class DeviceTypeFirmwareService extends BaseService {

  constructor(http: HttpClient, notificationService: NotificationService, propertyBag: DTO.ProjectPropertyBag) {

    super(http, notificationService, propertyBag);
    this.logON=true;
  }

  public getsGrid(state: State, deviceTypeId: string): Observable<GridDataResult> {

    this.log(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/all/grid`);
    return this.http
      .post<GridDataResult>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/all/grid`, this.translateState(state))
      .pipe(
        map(response => (<GridDataResult>{
          data: response['value']['data'],
          total: response['value']['length']
        })
        ),
        tap(() => this.loading = false)
      );


  }
  public gets(state: any, deviceTypeId: string): Observable<DTO.APIResultDTO<DTO.DeviceTypeFirmwareDTO[]>> {

    this.log(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/all`);
    return this.http
      .post<DTO.APIResultDTO<DTO.DeviceTypeFirmwareDTO[]>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/all`, {});
  }
  public save(deviceTypeFirmware: DTO.DeviceTypeFirmwareDTO, isNew: boolean, deviceTypeId: string): Observable<DTO.APIResultDTO<DTO.DeviceTypeFirmwareDTO>> {

    if (isNew) {
      this.log(`POST ${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares`);
      return this.http
        .post<DTO.APIResultDTO<DTO.DeviceTypeFirmwareDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares`, deviceTypeFirmware);

    }
    else {
      this.log(`PUT ${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${deviceTypeFirmware.id}`);

      return this.http
        .put<DTO.APIResultDTO<DTO.DeviceTypeFirmwareDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${deviceTypeFirmware.id}`, deviceTypeFirmware);

    }
  }
  public delete(deviceTypeFirmware: DTO.DeviceTypeFirmwareDTO, deviceTypeId: string): Observable<DTO.APIResultDTO<DTO.DeviceTypeFirmwareDTO>> {

    this.log(`DELETE ${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${deviceTypeFirmware.id}/`);
    return this.http
      .delete<DTO.APIResultDTO<DTO.DeviceTypeFirmwareDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${deviceTypeFirmware.id}/`);

  }

  public getMetadata(deviceTypeFirmware: DTO.DeviceTypeFirmwareDTO, deviceTypeId: string): Observable<DTO.APIResultDTO<string>> {

    this.log(`POST ${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${deviceTypeFirmware.id}/getMetadata`);
    return this.http
      .post<DTO.APIResultDTO<string>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${deviceTypeFirmware.id}/getMetadata`, deviceTypeFirmware);
  }
}
