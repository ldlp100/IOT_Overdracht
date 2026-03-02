import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as DTO  from '../models/_index';
import { NotificationService } from '@progress/kendo-angular-notification';

import { BehaviorSubject, empty, Observable } from 'rxjs';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { State, FilterDescriptor, CompositeFilterDescriptor } from '@progress/kendo-data-query';
import { isCompositeFilterDescriptor } from '@progress/kendo-data-query';
import { protectedResources } from '../auth-config';

@Injectable({
  providedIn: 'root'
})

export class BaseService extends BehaviorSubject<GridDataResult>{
  protected logON = false;
  constructor(
    protected http: HttpClient, protected notificationService: NotificationService, 
    protected propertyBag: DTO.ProjectPropertyBag) {
    var s: GridDataResult = { data:[], total:1 }
    super( s);

  }
  public get BASE_URL(): string {
    return this.propertyBag.BASE_URL+'/api';
  }  
 
  public get splashScreenLoaded(): boolean {
    return this.propertyBag.splashScreenLoaded;
  } 
  public get loading(): boolean {
    return this.propertyBag.loading;
  }
  public set loading(value) {
    this.propertyBag.loading = value;
  }

  protected log(message:string) {
    if (this.logON) console.log(message);
  }
  public showNotificationError(message: string) {
    this.showNotification(message, "error");
  }
  public showNotificationInfo(message: string) {
    this.showNotification(message, "info");
  }
  public showNotificationSucces(message: string) {
    this.showNotification(message, "success");
  }
  public showNotification(message: string, style: any) {
    this.notificationService.show({
      cssClass:'af-notification',
      content: message,
      animation: { type: 'fade', duration: 1000 },
      position: { horizontal: 'right', vertical: 'top' },
      type: { style: style, icon: true },
      closable: false
    });
  }

  protected translateState(state: State): DTO.APIRequestDTO {
    const request = new DTO.APIRequestDTO();
    if (state !== null && state != undefined) {
      if (state.skip !== undefined && state.take !== undefined) {
        request.page = state.skip / state.take;
        request.pageSize = state.take;
      }

      if (state.sort !== null && state.sort != undefined) {
        request.sorts = [];
        for (const stateSort of state.sort) {
          const sort = new DTO.SortDesc();
          sort.member = stateSort.field;
          sort.direction = (stateSort.dir === "asc") ? DTO.SortDirection.ASC : DTO.SortDirection.DESC;
          request.sorts.push(sort);
        }
      }
      if (state.filter != null && state.filter != undefined) {

        request.filters = [];
        for (const stateFilter of state.filter.filters) {

          const kendofilter = ((isCompositeFilterDescriptor(stateFilter)) ? stateFilter.filters : [stateFilter]) as FilterDescriptor[];

          for (var i = 0; i < kendofilter.length; i++) {
            const filter = this.createFilter(kendofilter[i].field + '', kendofilter[i].value, kendofilter[i].operator);
            request.filters.push(filter);
          }

        }
      }

    }
    //console.log(request);
    return request;
  }
  protected createFilter(fieldname: string, fieldvalue: any, fieldoperator: any): DTO.FilterDesc {

    const filter = new DTO.FilterDesc();
    filter.member = fieldname;
    filter.value = fieldvalue;

    switch (fieldoperator) {
      case "eq":
        filter.operator = DTO.FilterOperator.Eq;
        break;
      case "neq":
        filter.operator = DTO.FilterOperator.Eq;
        break;
      case "isnull":
        filter.operator = DTO.FilterOperator.IsNull;
        break;
      case "isnotnull":
        filter.operator = DTO.FilterOperator.IsNotNull;
        break;
      case "lt":
        filter.operator = DTO.FilterOperator.Lower;
        break;
      case "lte":
        filter.operator = DTO.FilterOperator.LowerEqual;
        break;
      case "gt":
        filter.operator = DTO.FilterOperator.Greater;
        break;
      case "gte":
        filter.operator = DTO.FilterOperator.GreaterEqual;
        break
      case "startswith":
        filter.operator = DTO.FilterOperator.StartWith;
        break;
      case "endswith":
        filter.operator = DTO.FilterOperator.EndWith;
        break;
      case "contains":
        filter.operator = DTO.FilterOperator.Contains;
        break
      case "doesnotcontains":
        filter.operator = DTO.FilterOperator.DoesNotContain;
        break;
      case "isempty":
        break;
      case "isnotempty":
        break;
    }
    return filter;
  }

}
