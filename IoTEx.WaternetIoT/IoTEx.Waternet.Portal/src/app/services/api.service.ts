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

export class APIService extends BaseService {

  constructor(http: HttpClient, notificationService: NotificationService, propertyBag: DTO.ProjectPropertyBag) {

    super(http, notificationService, propertyBag);

  }

  public sayHello(): Observable<string> {
    this.log(`${this.BASE_URL}/sayHello`);
    return this.http
      .get<string>(`${this.BASE_URL}/sayHello`);
  }
  public sayHelloUser(): Observable<string> {
    this.log(`${this.BASE_URL}/sayHelloUser`);
    return this.http
      .get<string>(`${this.BASE_URL}/sayHelloUser`);

  }
 


}
