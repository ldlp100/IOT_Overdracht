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

export class DeviceTypeFirmwareAlertService extends BaseService {

  constructor(http: HttpClient, notificationService: NotificationService, propertyBag: DTO.ProjectPropertyBag) {

    super(http, notificationService, propertyBag);
    this.logON=true;
  }

  public getsGrid(state: State, deviceTypeId: string, firmwaresId: string): Observable<GridDataResult> {

    this.log(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/alerts/all/grid`);
    return this.http
      .post<GridDataResult>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/alerts/all/grid`, this.translateState(state))
      .pipe(
        map(response => (<GridDataResult>{
          data: response['value']['data'],
          total: response['value']['length']
        })
        ),
        tap(() => this.loading = false)
      );


  }
  public gets(state: any, deviceTypeId: string, firmwaresId: string): Observable<DTO.APIResultDTO<DTO.DeviceTypeFirmwareAlertDTO[]>> {

    this.log(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/alerts/all`);
    return this.http
      .post<DTO.APIResultDTO<DTO.DeviceTypeFirmwareAlertDTO[]>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/alerts/all`, {});
  }
  public save(deviceTypeFirmwareAlert: DTO.DeviceTypeFirmwareAlertDTO, isNew: boolean, deviceTypeId: string, firmwaresId: string): Observable<DTO.APIResultDTO<DTO.DeviceTypeFirmwareAlertDTO>> {

    if (isNew) {
      this.log(`POST ${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/alerts`);
      return this.http
        .post<DTO.APIResultDTO<DTO.DeviceTypeFirmwareAlertDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/alerts`, deviceTypeFirmwareAlert);

    }
    else {
      this.log(`PUT ${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/alerts/${deviceTypeFirmwareAlert.id}`);

      return this.http
        .put<DTO.APIResultDTO<DTO.DeviceTypeFirmwareAlertDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/alerts/${deviceTypeFirmwareAlert.id}`, deviceTypeFirmwareAlert);

    }
  }
  public delete(deviceTypeFirmwareAlert: DTO.DeviceTypeFirmwareAlertDTO, deviceTypeId: string, firmwaresId: string): Observable<DTO.APIResultDTO<DTO.DeviceTypeFirmwareAlertDTO>> {

    this.log(`DELETE ${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/states/${deviceTypeFirmwareAlert.id}/`);
    return this.http
      .delete<DTO.APIResultDTO<DTO.DeviceTypeFirmwareAlertDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/alerts/${deviceTypeFirmwareAlert.id}/`);

  }
}
