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

export class DeviceType2NetworkAPIService extends BaseService {

  constructor(http: HttpClient, notificationService: NotificationService, propertyBag: DTO.ProjectPropertyBag) {

    super(http, notificationService, propertyBag);
    this.logON=true;
  }

  public getsGrid(state: State, deviceTypeId: string): Observable<GridDataResult> {

    this.log(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/networkAPIs/all/grid`);
    return this.http
      .post<GridDataResult>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/networkAPIs/all/grid`, this.translateState(state))
      .pipe(
        map(response => (<GridDataResult>{
          data: response['value']['data'],
          total: response['value']['length']
        })
        ),
        tap(() => this.loading = false)
      );


  }
  public gets(state: any, deviceTypeId: string): Observable<DTO.APIResultDTO<DTO.DeviceType2NetworkAPIDTO[]>> {

    this.log(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/networkAPIs/all`);
    return this.http
      .post<DTO.APIResultDTO<DTO.DeviceType2NetworkAPIDTO[]>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/networkAPIs/all`, {});
  }
  public save(deviceType2NetworkAPI: DTO.DeviceType2NetworkAPIDTO, isNew: boolean, deviceTypeId: string): Observable<DTO.APIResultDTO<DTO.DeviceType2NetworkAPIDTO>> {

    if (isNew) {
      this.log(`POST ${this.BASE_URL}/deviceTypes/${deviceTypeId}/networkAPIs`);
      return this.http
        .post<DTO.APIResultDTO<DTO.DeviceType2NetworkAPIDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/networkAPIs`, deviceType2NetworkAPI);

    }
    else {
      this.log(`PUT ${this.BASE_URL}/deviceTypes/${deviceTypeId}/networkAPIs/${deviceType2NetworkAPI.id}`);

      return this.http
        .put<DTO.APIResultDTO<DTO.DeviceType2NetworkAPIDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/networkAPIs/${deviceType2NetworkAPI.id}`, deviceType2NetworkAPI);

    }
  }
  public delete(deviceType2NetworkAPI: DTO.DeviceType2NetworkAPIDTO, deviceTypeId: string): Observable<DTO.APIResultDTO<DTO.DeviceType2NetworkAPIDTO>> {

    this.log(`DELETE ${this.BASE_URL}/deviceTypes/${deviceTypeId}/networkAPIs/${deviceType2NetworkAPI.id}/`);
    return this.http
      .delete<DTO.APIResultDTO<DTO.DeviceType2NetworkAPIDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/networkAPIs/${deviceType2NetworkAPI.id}/`);

  }
}
