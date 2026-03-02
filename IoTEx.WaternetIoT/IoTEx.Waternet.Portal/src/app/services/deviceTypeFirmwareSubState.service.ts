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

export class DeviceTypeFirmwareSubStateService extends BaseService {

  constructor(http: HttpClient, notificationService: NotificationService, propertyBag: DTO.ProjectPropertyBag) {

    super(http, notificationService, propertyBag);
    this.logON=true;
  }

  public getsGrid(state: State, deviceTypeId: string, firmwareId: string, stateId:string): Observable<GridDataResult> {

    this.log(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwareId}/states/${stateId}/subs/all/grid`);
    return this.http
      .post<GridDataResult>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwareId}/states/${stateId}/subs/all/grid`, this.translateState(state))
      .pipe(
        map(response => (<GridDataResult>{
          data: response['value']['data'],
          total: response['value']['length']
        })
        ),
        tap(() => this.loading = false)
      );
  }

  public gets(state: any, deviceTypeId: string, firmwareId: string, stateId:string): Observable<DTO.APIResultDTO<DTO.DeviceTypeFirmwareSubStateDTO[]>> {

    this.log(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwareId}/states/${stateId}/subs/all`);
    return this.http
      .post<DTO.APIResultDTO<DTO.DeviceTypeFirmwareSubStateDTO[]>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwareId}/states/${stateId}/subs/all`, {});
  }

  public save(deviceTypeFirmwareSubState: DTO.DeviceTypeFirmwareSubStateDTO, isNew: boolean, deviceTypeId: string, firmwareId: string, stateId: string): Observable<DTO.APIResultDTO<DTO.DeviceTypeFirmwareSubStateDTO>> {

    if (isNew) {
      this.log(`POST ${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwareId}/states/${stateId}/subs/`);
      return this.http
        .post<DTO.APIResultDTO<DTO.DeviceTypeFirmwareSubStateDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwareId}/states/${stateId}/subs/`, deviceTypeFirmwareSubState);

    }
    else {
      this.log(`PUT ${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwareId}/states/${stateId}/subs/subs/${deviceTypeFirmwareSubState.id}`);

      return this.http
        .put<DTO.APIResultDTO<DTO.DeviceTypeFirmwareSubStateDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwareId}/states/${stateId}/subs/${deviceTypeFirmwareSubState.id}`, deviceTypeFirmwareSubState);

    }
  }
  public delete(deviceTypeFirmwareState: DTO.DeviceTypeFirmwareSubStateDTO, deviceTypeId: string, firmwaresId: string, stateId: string): Observable<DTO.APIResultDTO<DTO.DeviceTypeFirmwareSubStateDTO>> {

    this.log(`DELETE ${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/states/${stateId}/subs/states/${stateId}/subs/${deviceTypeFirmwareState.id}`);
    return this.http
      .delete<DTO.APIResultDTO<DTO.DeviceTypeFirmwareSubStateDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/states/${stateId}/subs/${deviceTypeFirmwareState.id}`);

  }
}
