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

export class DeviceBatchService extends BaseService {

  constructor(http: HttpClient, notificationService: NotificationService, propertyBag: DTO.ProjectPropertyBag) {

    super(http, notificationService, propertyBag);
    this.logON=true;
  }

  public getsGrid(state: State, deviceTypeId: string): Observable<GridDataResult> {

    this.log(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/all/grid`);
    return this.http
      .post<GridDataResult>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/all/grid`, this.translateState(state))
      .pipe(
        map(response => (<GridDataResult>{
          data: response['value']['data'],
          total: response['value']['length']
        })
        ),
        tap(() => this.loading = false)
      );


  }
  public gets(state: any, deviceTypeId: string): Observable<DTO.APIResultDTO<DTO.DeviceBatchDTO[]>> {

    this.log(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/all`);
    return this.http
      .post<DTO.APIResultDTO<DTO.DeviceBatchDTO[]>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/all`, {});
  }
  public get( state: any,deviceTypeId:string,id:string): Observable<DTO.APIResultDTO<DTO.DeviceBatchDTO>> {

    this.log(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${id}`);
    return this.http
      .get<DTO.APIResultDTO<DTO.DeviceBatchDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${id}`, {});
  }
  public save(deviceBatch: DTO.DeviceBatchDTO, isNew: boolean, deviceTypeId: string): Observable<DTO.APIResultDTO<DTO.DeviceBatchDTO>> {

    if (isNew) {
      this.log(`POST ${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs`);
      return this.http
        .post<DTO.APIResultDTO<DTO.DeviceBatchDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs`, deviceBatch);

    }
    else {
      this.log(`PUT ${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatch.id}`);

      return this.http
        .put<DTO.APIResultDTO<DTO.DeviceBatchDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatch.id}`, deviceBatch);

    }
  }
  public delete(deviceBatch: DTO.DeviceBatchDTO, deviceTypeId: string): Observable<DTO.APIResultDTO<DTO.DeviceBatchDTO>> {

    this.log(`DELETE ${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatch.id}/`);
    return this.http
      .delete<DTO.APIResultDTO<DTO.DeviceBatchDTO>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatch.id}/`);

  }
  public publish(deviceTypeId: string, deviceBatch: DTO.DeviceBatchDTO): Observable<DTO.APIResultDTO<string>> {
    
    this.log(`POST ${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatch.id}/publish`);
      return this.http
        .post<DTO.APIResultDTO<string>>(`${this.BASE_URL}/deviceTypes/${deviceTypeId}/deviceBatchs/${deviceBatch.id}/publish`, deviceBatch);
  }
}
