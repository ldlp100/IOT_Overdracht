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

export class ProjectService extends BaseService {

  constructor(http: HttpClient, notificationService: NotificationService, propertyBag: DTO.ProjectPropertyBag) {

    super(http, notificationService, propertyBag);
    this.logON=true;
  }

  public getsGrid(state: State): Observable<GridDataResult> {

    this.log(`${this.BASE_URL}/projects/all/grid`);
    return this.http
      .post<GridDataResult>(`${this.BASE_URL}/projects/all/grid`, this.translateState(state))
      .pipe(
        map(response => (<GridDataResult>{
          data: response['value']['data'],
          total: response['value']['length']
        })
        ),
        tap(() => this.loading = false)
      );


  }
  public gets(state: any): Observable<DTO.APIResultDTO<DTO.ProjectDTO[]>> {

    this.log(`${this.BASE_URL}/projects/all`);
    return this.http
      .post<DTO.APIResultDTO<DTO.ProjectDTO[]>>(`${this.BASE_URL}/projects/all`, this.translateState(state));

  }
  public get(id): Observable<DTO.APIResultDTO<DTO.ProjectDTO>> {
    this.log(`${this.BASE_URL}/projects/${id}`);
    return this.http
      .get<DTO.APIResultDTO<DTO.ProjectDTO>>(`${this.BASE_URL}/projects/${id}`);
  }
  public save(project: DTO.ProjectDTO, isNew: boolean): Observable<DTO.APIResultDTO<DTO.ProjectDTO>> {

    if (isNew) {
      this.log(`POST ${this.BASE_URL}/projects`);
      return this.http
        .post<DTO.APIResultDTO<DTO.ProjectDTO>>(`${this.BASE_URL}/projects`, project);

    }
    else {
      this.log(`PUT ${this.BASE_URL}/projects/${project.id}`);

      return this.http
        .put<DTO.APIResultDTO<DTO.ProjectDTO>>(`${this.BASE_URL}/projects/${project.id}`, project);

    }
  }
  public delete(project: DTO.ProjectDTO): Observable<DTO.APIResultDTO<DTO.ProjectDTO>> {

    this.log(`DELETE ${this.BASE_URL}/projects/${project.id}/`);
    return this.http
      .delete<DTO.APIResultDTO<DTO.ProjectDTO>>(`${this.BASE_URL}/projects/${project.id}/`);

  }
  public createMap(project: DTO.ProjectDTO): Observable<DTO.APIResultDTO<boolean>> {

    this.log(`POST ${this.BASE_URL}/projects/${project.id}`);
      return this.http
        .post<DTO.APIResultDTO<boolean>>(`${this.BASE_URL}/projects/${project.id}/createmap`, project);
  }
}
