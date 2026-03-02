import { ProjectPropertyBag } from './models/ProjectPropertyBag';

import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { MsalService, MsalBroadcastService, MSAL_GUARD_CONFIG, MsalGuardConfiguration } from '@azure/msal-angular';
import { AuthenticationResult, InteractionStatus, PopupRequest, RedirectRequest, EventMessage, EventType } from '@azure/msal-browser';
import { Subject } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { filter, takeUntil } from 'rxjs/operators';
import { IoTExService } from './services/_index';

export class BaseComponent {
  protected authService: MsalService
  protected logOn = false;
  constructor() {
    //if (this.route.snapshot.queryParamMap.get("Log") != undefined) {
    //  this.logOn = true;
    //}
  }

  public log(...args: any[]) {
    if (document.location.href.indexOf('log=true') > 1) {
      console.log(args);
      return;
    }
    if (this.logOn) console.log(args);
  }
  
  public hasRole(roleName: string): boolean {
    if (this.authService != null)
      return false;
    let roles = this.authService.instance.getActiveAccount().idTokenClaims.roles;

    return roles.find(o => o == roleName).length > 0;
  }
  
  public getRoles(): string[] {
    var account = this.authService.instance.getActiveAccount();
    if (account == null)
      return [];
    if (account.idTokenClaims == null)
      return [];
    return this.authService.instance.getActiveAccount().idTokenClaims.roles
  }
  public hasAdminRoles():boolean{
    let roles = this.getRoles();
    return (roles.find(o=> o === "IoTEx.Admin") !=null);
  }
  public formatDateTime(dt){
    
    if (dt==null){
      //console.log("dt is a leeg",dt);
      return "";
    }
    if (dt instanceof Date){
      //console.log("dt is a Date",dt);
      return dt.toLocaleString();
    }
    else
    {
      //console.log("dt is a string",dt);
      return dt.substring(8,10) + "-" + dt.substring(5,7) + "-" + dt.substring(0,4)
      + " " + dt.substring(11,13) + ":" + dt.substring(14, 16) + ":" + dt.substring(17, 19);
    }
  }
  
  public getModalWidth() {
 
    if (screen.availWidth <= 400) {
      return 375;
    }
    else if (screen.availWidth <= 768) {
      return 600;
    }
    return 700;
  }
}
