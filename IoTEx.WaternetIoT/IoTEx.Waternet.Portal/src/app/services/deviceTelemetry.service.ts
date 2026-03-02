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

export class DeviceTelemetryService extends BaseService {

  constructor(http: HttpClient, notificationService: NotificationService, propertyBag: DTO.ProjectPropertyBag) {

    super(http, notificationService, propertyBag);
    this.logON=true;
  }

  public gets( deviceId: string, startDate:Date, endDate:Date, window:string ): Observable<DTO.APIResultDTO<DTO.DeviceTelemetryAggregateDTO[]>> {

    this.log(`${this.BASE_URL}/devices/${deviceId}/telemetries/${window}/${startDate.toISOString()}/${endDate.toISOString()}`);
    return this.http
      .get<DTO.APIResultDTO<DTO.DeviceTelemetryAggregateDTO[]>>(`${this.BASE_URL}/devices/${deviceId}/telemetries/${window}/${startDate.toISOString()}/${endDate.toISOString()}`);
  }
  

}
