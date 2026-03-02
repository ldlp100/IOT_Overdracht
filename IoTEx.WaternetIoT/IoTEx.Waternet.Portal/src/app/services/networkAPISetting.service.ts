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

export class NetworkAPISettingService extends BaseService {

  constructor(http: HttpClient, notificationService: NotificationService, propertyBag: DTO.ProjectPropertyBag) {

    super(http, notificationService, propertyBag);
    this.logON=true;
  }

  public getsGrid(state: State, networkAPIId: string): Observable<GridDataResult> {

    this.log(`${this.BASE_URL}/networkAPIs/${networkAPIId}/settings/all/grid`);
    return this.http
      .post<GridDataResult>(`${this.BASE_URL}/networkAPIs/${networkAPIId}/settings/all/grid`, this.translateState(state))
      .pipe(
        map(response => (<GridDataResult>{
          data: response['value']['data'],
          total: response['value']['length']
        })
        ),
        tap(() => this.loading = false)
      );


  }
  public gets(state: any, networkAPIId: string): Observable<DTO.APIResultDTO<DTO.NetworkAPISettingDTO[]>> {

    this.log(`${this.BASE_URL}/networkAPIs/${networkAPIId}/settings/all`);
    return this.http
      .post<DTO.APIResultDTO<DTO.NetworkAPISettingDTO[]>>(`${this.BASE_URL}/networkAPIs/${networkAPIId}/settings/all`, {});
  }

  public save(networkAPISetting: DTO.NetworkAPISettingDTO, isNew: boolean, networkAPIId: string): Observable<DTO.APIResultDTO<DTO.NetworkAPISettingDTO>> {

    if (isNew) {
      this.log(`POST ${this.BASE_URL}/networkAPIs/${networkAPIId}/settings`);
      return this.http
        .post<DTO.APIResultDTO<DTO.NetworkAPISettingDTO>>(`${this.BASE_URL}/networkAPIs/${networkAPIId}/settings`, networkAPISetting);

    }
    else {
      this.log(`PUT ${this.BASE_URL}/networkAPIs/${networkAPIId}/settings/${networkAPISetting.id}`);

      return this.http
        .put<DTO.APIResultDTO<DTO.NetworkAPISettingDTO>>(`${this.BASE_URL}/networkAPIs/${networkAPIId}/settings/${networkAPISetting.id}`, networkAPISetting);

    }
  }
  public delete(networkAPISetting: DTO.NetworkAPIDTO, networkAPIId: string): Observable<DTO.APIResultDTO<DTO.NetworkAPISettingDTO>> {

    this.log(`DELETE ${this.BASE_URL}/networkAPIs/${networkAPIId}/settings/${networkAPISetting.id}/`);
    return this.http
      .delete<DTO.APIResultDTO<DTO.NetworkAPISettingDTO>>(`${this.BASE_URL}/networkAPIs/${networkAPIId}/settings/${networkAPISetting.id}/`);

  }
}
