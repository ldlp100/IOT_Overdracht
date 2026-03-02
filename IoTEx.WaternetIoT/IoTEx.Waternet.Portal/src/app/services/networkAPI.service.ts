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

export class NetworkAPIService extends BaseService {

  constructor(http: HttpClient, notificationService: NotificationService, propertyBag: DTO.ProjectPropertyBag) {

    super(http, notificationService, propertyBag);
    this.logON=true;
  }

  public getsGrid(state: State): Observable<GridDataResult> {

    this.log(`${this.BASE_URL}/networkAPIs/all/grid`);
    return this.http
      .post<GridDataResult>(`${this.BASE_URL}/networkAPIs/all/grid`, this.translateState(state))
      .pipe(
        map(response => (<GridDataResult>{
          data: response['value']['data'],
          total: response['value']['length']
        })
        ),
        tap(() => this.loading = false)
      );


  }
  public gets(state: any): Observable<DTO.APIResultDTO<DTO.NetworkAPIDTO[]>> {

    this.log(`${this.BASE_URL}/networkAPIs/all`);
    return this.http
      .post<DTO.APIResultDTO<DTO.NetworkAPIDTO[]>>(`${this.BASE_URL}/networkAPIs/all`, {});
  }
  public save(networkAPI: DTO.NetworkAPIDTO, isNew: boolean): Observable<DTO.APIResultDTO<DTO.NetworkAPIDTO>> {

    if (isNew) {
      this.log(`POST ${this.BASE_URL}/networkAPIs`);
      return this.http
        .post<DTO.APIResultDTO<DTO.NetworkAPIDTO>>(`${this.BASE_URL}/networkAPIs`, networkAPI);

    }
    else {
      this.log(`PUT ${this.BASE_URL}/networkAPIs/${networkAPI.id}`);

      return this.http
        .put<DTO.APIResultDTO<DTO.NetworkAPIDTO>>(`${this.BASE_URL}/networkAPIs/${networkAPI.id}`, networkAPI);

    }
  }
  public delete(networkAPI: DTO.NetworkAPIDTO): Observable<DTO.APIResultDTO<DTO.NetworkAPIDTO>> {

    this.log(`DELETE ${this.BASE_URL}/networkAPIs/${networkAPI.id}/`);
    return this.http
      .delete<DTO.APIResultDTO<DTO.NetworkAPIDTO>>(`${this.BASE_URL}/networkAPIs/${networkAPI.id}/`);

  }
}
