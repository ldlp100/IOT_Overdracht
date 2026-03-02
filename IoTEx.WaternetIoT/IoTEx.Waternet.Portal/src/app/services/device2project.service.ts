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

export class Device2projectService extends BaseService {

  constructor(http: HttpClient, notificationService: NotificationService, propertyBag: DTO.ProjectPropertyBag) {

    super(http, notificationService, propertyBag);
    this.logON=true;
  }

  public getsDeviceForProjectGrid(state: State, projectId: string): Observable<GridDataResult> {

    this.log(`${this.BASE_URL}/projects/${projectId}/devices/all/grid`);
    return this.http
      .post<GridDataResult>(`${this.BASE_URL}/projects/${projectId}/devices/all/grid`, this.translateState(state))
      .pipe(
        map(response => (<GridDataResult>{
          data: response['value']['data'],
          total: response['value']['length']
        })
        ),
        tap(() => this.loading = false)
      );
  }
  public getsProjectForDeviceGrid(state: State, deviceId: string): Observable<GridDataResult> {

    this.log(`${this.BASE_URL}/devices/${deviceId}/projects/all/grid`);
    return this.http
      .post<GridDataResult>(`${this.BASE_URL}/devices/${deviceId}/projects/all/grid`, this.translateState(state))
      .pipe(
        map(response => (<GridDataResult>{
          data: response['value']['data'],
          total: response['value']['length']
        })
        ),
        tap(() => this.loading = false)
      );
  }

  public getsDeviceForProject(state: any, deviceId: string): Observable<DTO.APIResultDTO<DTO.User2ProjectDTO[]>> {

    this.log(`${this.BASE_URL}/devices/${deviceId}/projects/all`);
    return this.http
      .post<DTO.APIResultDTO<DTO.User2ProjectDTO[]>>(`${this.BASE_URL}/projects/${deviceId}/devices/all`, {});
  }
  public getsProjectForDevice(state: any, projectId: string): Observable<DTO.APIResultDTO<DTO.User2ProjectDTO[]>> {

    this.log(`${this.BASE_URL}/projects/${projectId}/devices/all`);
    return this.http
      .post<DTO.APIResultDTO<DTO.User2ProjectDTO[]>>(`${this.BASE_URL}/projects/${projectId}/devices/all`, {});
  }
  public get(state: any, deviceId: string, projectId: string): Observable<DTO.APIResultDTO<DTO.Device2ProjectDTO>> {

    this.log(`${this.BASE_URL}/devices/${deviceId}/projects/${projectId}/`);
    return this.http
      .get<DTO.APIResultDTO<DTO.Device2ProjectDTO>>(`${this.BASE_URL}/devices/${deviceId}/projects/${projectId}`, {});
  }
  public save(device2project: DTO.Device2ProjectDTO, isNew: boolean): Observable<DTO.APIResultDTO<DTO.Device2ProjectDTO>> {

    if (isNew) {
      this.log(`POST ${this.BASE_URL}/devices/${device2project.deviceId}/projects/${device2project.projectId}/`);
      return this.http
        .post<DTO.APIResultDTO<DTO.Device2ProjectDTO>>(`${this.BASE_URL}/devices/${device2project.deviceId}/projects/`, device2project);

    }
    else {
      this.log(`PUT ${this.BASE_URL}/devices/${device2project.deviceId}/projects/${device2project.projectId}/`);

      return this.http
        .put<DTO.APIResultDTO<DTO.Device2ProjectDTO>>(`${this.BASE_URL}/devices/${device2project.deviceId}/projects/${device2project.projectId}`, device2project);

    }
  }

  public delete(device2Project: DTO.Device2ProjectDTO): Observable<DTO.APIResultDTO<DTO.Device2ProjectDTO>> {

    this.log(`DELETE ${this.BASE_URL}/devices/${device2Project.deviceId}/projects/${device2Project.id}/`);
    return this.http
      .delete<DTO.APIResultDTO<DTO.Device2ProjectDTO>>(`${this.BASE_URL}/devices/${device2Project.deviceId}/projects/${device2Project.id}/`);

  }
}
