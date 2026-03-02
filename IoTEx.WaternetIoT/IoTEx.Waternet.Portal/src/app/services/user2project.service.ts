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

export class User2projectService extends BaseService {

  constructor(http: HttpClient, notificationService: NotificationService, propertyBag: DTO.ProjectPropertyBag) {

    super(http, notificationService, propertyBag);
    this.logON=true;
  }

  public getsGrid(state: State, projectId: string): Observable<GridDataResult> {

    this.log(`${this.BASE_URL}/projects/${projectId}/users/all/grid`);
    return this.http
      .post<GridDataResult>(`${this.BASE_URL}/projects/${projectId}/users/all/grid`, this.translateState(state))
      .pipe(
        map(response => (<GridDataResult>{
          data: response['value']['data'],
          total: response['value']['length']
        })
        ),
        tap(() => this.loading = false)
      );
  }

  public gets(state: any, projectId: string): Observable<DTO.APIResultDTO<DTO.User2ProjectDTO[]>> {

    this.log(`${this.BASE_URL}/projects/${projectId}/users/all`);
    return this.http
      .post<DTO.APIResultDTO<DTO.User2ProjectDTO[]>>(`${this.BASE_URL}/projects/${projectId}/users/all`, {});
  }

  public save(deviceType2NetworkAPI: DTO.User2ProjectDTO, isNew: boolean, projectId: string): Observable<DTO.APIResultDTO<DTO.User2ProjectDTO>> {

    if (isNew) {
      this.log(`POST ${this.BASE_URL}/projects/${projectId}/users`);
      return this.http
        .post<DTO.APIResultDTO<DTO.User2ProjectDTO>>(`${this.BASE_URL}/projects/${projectId}/users`, deviceType2NetworkAPI);

    }
    else {
      this.log(`PUT ${this.BASE_URL}/projects/${projectId}/users/${deviceType2NetworkAPI.id}`);

      return this.http
        .put<DTO.APIResultDTO<DTO.User2ProjectDTO>>(`${this.BASE_URL}/projects/${projectId}/users/${deviceType2NetworkAPI.id}`, deviceType2NetworkAPI);

    }
  }
  public delete(user2project: DTO.User2ProjectDTO, projectId: string): Observable<DTO.APIResultDTO<DTO.User2ProjectDTO>> {

    this.log(`DELETE ${this.BASE_URL}/projects/${projectId}/users/${user2project.id}/`);
    return this.http
      .delete<DTO.APIResultDTO<DTO.User2ProjectDTO>>(`${this.BASE_URL}/projects/${projectId}/users/${user2project.id}/`);

  }

  public getsGridMyProject(state: State): Observable<GridDataResult> {

    this.log(`${this.BASE_URL}/users/myProjects/all/grid`);
    return this.http
      .post<GridDataResult>(`${this.BASE_URL}/users/myProjects/all/grid`, this.translateState(state))
      .pipe(
        map(response => (<GridDataResult>{
          data: response['value']['data'],
          total: response['value']['length']
        })
        ),
        tap(() => this.loading = false)
      );
  }

  public getsMyProject(state: any): Observable<DTO.APIResultDTO<DTO.User2ProjectDTO[]>> {

    this.log(`${this.BASE_URL}/users/myProjects/all`);
    return this.http
      .post<DTO.APIResultDTO<DTO.User2ProjectDTO[]>>(`${this.BASE_URL}/users/myProjects/all`, {});
  }
}
