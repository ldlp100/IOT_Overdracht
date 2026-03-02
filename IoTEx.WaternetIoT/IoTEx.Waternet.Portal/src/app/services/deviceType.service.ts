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

export class DeviceTypeService extends BaseService {

  constructor(http: HttpClient, notificationService: NotificationService, propertyBag: DTO.ProjectPropertyBag) {

    super(http, notificationService, propertyBag);
    this.logON=true;
  }

  public getsGrid(state: State): Observable<GridDataResult> {

    this.log(`${this.BASE_URL}/deviceTypes/all/grid`);
    return this.http
      .post<GridDataResult>(`${this.BASE_URL}/deviceTypes/all/grid`, this.translateState(state))
      .pipe(
        map(response => (<GridDataResult>{
          data: response['value']['data'],
          total: response['value']['length']
        })
        ),
        tap(() => this.loading = false)
      );


  }
  public gets(state: any): Observable<DTO.APIResultDTO<DTO.DeviceTypeDTO[]>> {

    this.log(`${this.BASE_URL}/deviceTypes/all`);
    return this.http
      .post<DTO.APIResultDTO<DTO.DeviceTypeDTO[]>>(`${this.BASE_URL}/deviceTypes/all`, {});
  }
  public get( state: any,id:string): Observable<DTO.APIResultDTO<DTO.DeviceTypeDTO>> {

    this.log(`${this.BASE_URL}/deviceTypes/${id}`);
    return this.http
      .get<DTO.APIResultDTO<DTO.DeviceTypeDTO>>(`${this.BASE_URL}/deviceTypes/${id}`, {});
  }
  public save(deviceType: DTO.DeviceTypeDTO, isNew: boolean): Observable<DTO.APIResultDTO<DTO.DeviceTypeDTO>> {

    if (isNew) {
      this.log(`POST ${this.BASE_URL}/deviceTypes`);
      return this.http
        .post<DTO.APIResultDTO<DTO.DeviceTypeDTO>>(`${this.BASE_URL}/deviceTypes`, deviceType);

    }
    else {
      this.log(`PUT ${this.BASE_URL}/deviceTypes/${deviceType.id}`);

      return this.http
        .put<DTO.APIResultDTO<DTO.DeviceTypeDTO>>(`${this.BASE_URL}/deviceTypes/${deviceType.id}`, deviceType);

    }
  }
  public delete(deviceType: DTO.DeviceTypeDTO): Observable<DTO.APIResultDTO<DTO.DeviceTypeDTO>> {

    this.log(`DELETE ${this.BASE_URL}/deviceTypes/${deviceType.id}/`);
    return this.http
      .delete<DTO.APIResultDTO<DTO.DeviceTypeDTO>>(`${this.BASE_URL}/deviceTypes/${deviceType.id}/`);

  }
}
