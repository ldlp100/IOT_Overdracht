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

export class AppUserService extends BaseService {

  constructor(http: HttpClient, notificationService: NotificationService, propertyBag: DTO.ProjectPropertyBag) {

    super(http, notificationService, propertyBag);
    this.logON=true;
  }

  public getsGrid(state: State): Observable<GridDataResult> {

    this.log(`${this.BASE_URL}/users/all/grid`);
    return this.http
      .post<GridDataResult>(`${this.BASE_URL}/users/all/grid`, this.translateState(state))
      .pipe(
        map(response => (<GridDataResult>{
          data: response['value']['data'],
          total: response['value']['length']
        })
        ),
        tap(() => this.loading = false)
      );


  }
  public gets(state: any): Observable<DTO.APIResultDTO<DTO.AppUserDTO[]>> {

    this.log(`${this.BASE_URL}/users/all`);
    return this.http
      .post<DTO.APIResultDTO<DTO.AppUserDTO[]>>(`${this.BASE_URL}/users/all`, {});
  }
  public save(appUser: DTO.AppUserDTO, isNew: boolean): Observable<DTO.APIResultDTO<DTO.AppUserDTO>> {

    if (isNew) {
      this.log(`POST ${this.BASE_URL}/users`);
      return this.http
        .post<DTO.APIResultDTO<DTO.AppUserDTO>>(`${this.BASE_URL}/users`, appUser);

    }
    else {
      this.log(`PUT ${this.BASE_URL}/users/${appUser.id}`);

      return this.http
        .put<DTO.APIResultDTO<DTO.AppUserDTO>>(`${this.BASE_URL}/users/${appUser.id}`, appUser);

    }
  }
  public delete(appUser: DTO.AppUserDTO): Observable<DTO.APIResultDTO<DTO.AppUserDTO>> {

    this.log(`DELETE ${this.BASE_URL}/users/${appUser.id}/`);
    return this.http
      .delete<DTO.APIResultDTO<DTO.AppUserDTO>>(`${this.BASE_URL}/users/${appUser.id}/`);

  }




}
