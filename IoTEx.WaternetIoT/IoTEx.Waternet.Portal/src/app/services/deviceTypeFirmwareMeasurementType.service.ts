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

export class DeviceTypeFirmwareMeasurementTypeService extends BaseService {

  constructor(http: HttpClient, notificationService: NotificationService, propertyBag: DTO.ProjectPropertyBag) {

    super(http, notificationService, propertyBag);
    this.logON=true;
  }

  public getsGrid(state: State, deviceTypeId: string, firmwaresId: string): Observable<GridDataResult> {

    this.log(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/measurements/all/grid`);
    return this.http
      .post<GridDataResult>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/measurements/all/grid`, this.translateState(state))
      .pipe(
        map(response => (<GridDataResult>{
          data: response['value']['data'],
          total: response['value']['length']
        })
        ),
        tap(() => this.loading = false)
      );


  }
  public gets(state: any, deviceTypeId: string, firmwaresId: string): Observable<DTO.APIResultDTO<DTO.DeviceTypeFirmwareMeasurementTypeDTO[]>> {

    this.log(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/measurements/all`);
    return this.http
      .post<DTO.APIResultDTO<DTO.DeviceTypeFirmwareMeasurementTypeDTO[]>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/measurements/all`, {});
  }
  public save(deviceTypeFirmwareMeasurementType: DTO.DeviceTypeFirmwareMeasurementTypeDTO, isNew: boolean, deviceTypeId: string, firmwaresId: string): Observable<DTO.APIResultDTO<DTO.DeviceTypeFirmwareMeasurementTypeDTO>> {

    if (isNew) {
      this.log(`POST ${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/measurements`);
      return this.http
        .post<DTO.APIResultDTO<DTO.DeviceTypeFirmwareMeasurementTypeDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/measurements`, deviceTypeFirmwareMeasurementType);

    }
    else {
      this.log(`PUT ${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/measurements/${deviceTypeFirmwareMeasurementType.id}`);

      return this.http
        .put<DTO.APIResultDTO<DTO.DeviceTypeFirmwareMeasurementTypeDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/measurements/${deviceTypeFirmwareMeasurementType.id}`, deviceTypeFirmwareMeasurementType);

    }
  }
  public delete(deviceTypeFirmwareMeasurementType: DTO.DeviceTypeFirmwareMeasurementTypeDTO, deviceTypeId: string, firmwaresId: string): Observable<DTO.APIResultDTO<DTO.DeviceTypeFirmwareMeasurementTypeDTO>> {

    this.log(`DELETE ${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${deviceTypeFirmwareMeasurementType.id}/`);
    return this.http
      .delete<DTO.APIResultDTO<DTO.DeviceTypeFirmwareMeasurementTypeDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/firmwares/${firmwaresId}/measurements/${deviceTypeFirmwareMeasurementType.id}/`);

  }
}
