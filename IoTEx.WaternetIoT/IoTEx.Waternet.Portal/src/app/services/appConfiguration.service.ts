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

export class AppConfigurationService extends BaseService {

  constructor(http: HttpClient, notificationService: NotificationService, propertyBag: DTO.ProjectPropertyBag) {

    super(http, notificationService, propertyBag);
    this.logON=true;
  }

  public getsGrid(state: State): Observable<GridDataResult> {

    this.log(`${this.BASE_URL}/appConfigurations/all/grid`);
    return this.http
      .post<GridDataResult>(`${this.BASE_URL}/appConfigurations/all/grid`, this.translateState(state))
      .pipe(
        map(response => (<GridDataResult>{
          data: response['value']['data'],
          total: response['value']['length']
        })
        ),
        tap(() => this.loading = false)
      );


  }
  public gets(state: any): Observable<DTO.APIResultDTO<DTO.AppConfigurationDTO[]>> {

    this.log(`${this.BASE_URL}/appConfigurations/all`);
    return this.http
      .post<DTO.APIResultDTO<DTO.AppConfigurationDTO[]>>(`${this.BASE_URL}/appConfigurations/all`, {});
  }
  public save(appConfiguration: DTO.AppConfigurationDTO, isNew: boolean): Observable<DTO.APIResultDTO<DTO.AppConfigurationDTO>> {

    if (isNew) {
      this.log(`POST ${this.BASE_URL}/appConfigurations`);
      return this.http
        .post<DTO.APIResultDTO<DTO.AppConfigurationDTO>>(`${this.BASE_URL}/appConfigurations`, appConfiguration);

    }
    else {
      this.log(`PUT ${this.BASE_URL}/appConfigurations/${appConfiguration.id}`);

      return this.http
        .put<DTO.APIResultDTO<DTO.AppConfigurationDTO>>(`${this.BASE_URL}/appConfigurations/${appConfiguration.id}`, appConfiguration);

    }
  }
  public delete(appConfiguration: DTO.AppConfigurationDTO): Observable<DTO.APIResultDTO<DTO.AppConfigurationDTO>> {

    this.log(`DELETE ${this.BASE_URL}/appConfigurations/${appConfiguration.id}/`);
    return this.http
      .delete<DTO.APIResultDTO<DTO.AppConfigurationDTO>>(`${this.BASE_URL}/appConfigurations/${appConfiguration.id}/`);

  }




}
