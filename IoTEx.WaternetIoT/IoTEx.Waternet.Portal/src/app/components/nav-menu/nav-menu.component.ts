import { ProjectPropertyBag } from '../../models/ProjectPropertyBag';
import {
  Component, OnInit, Input, Output, ViewChild, ViewEncapsulation, NgZone, EventEmitter, AfterViewInit, ElementRef } from '@angular/core';
import { MsalService, MsalBroadcastService, MSAL_GUARD_CONFIG, MsalGuardConfiguration } from '@azure/msal-angular';
import { Router } from '@angular/router';
import { BaseComponent } from '../../base.component';
import * as DTO from "../../models/_index";
import * as allIcons from "@progress/kendo-svg-icons";
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  encapsulation: ViewEncapsulation.None,
  styleUrls: ['./nav-menu.component.css']
})

export class NavMenuComponent extends BaseComponent {
  public icon = allIcons;
  public icons = { menu: this.icon.menuIcon, inbox: this.icon.inboxIcon, user: this.icon.userIcon, close: this.icon.xIcon };


  public user: DTO.AppUserDTO;

  @ViewChild("anchor", { static: false })
  public anchor: ElementRef<HTMLElement>;

  @ViewChild("anchorUser", { static: false })
  public anchorUser: ElementRef<HTMLElement>;

  public margin = { horizontal: -46, vertical: 7 };
  public marginUser = { horizontal: 0, vertical: 7};
  public showNavbar = false;
  public showUser = false;

  constructor(private _router: Router, authService: MsalService) {
    super();
    this.authService = authService;
  }

  public onToggle(): void {
    this.showNavbar = !this.showNavbar;
  }

  public routerlink(link: string): void {
    this._router.navigate([link]);
    this.showNavbar = !this.showNavbar;
  }
  public isAdmin(): boolean {
    if (this.authService.instance.getActiveAccount() !== null) {
      let roles = this.authService.instance.getActiveAccount().idTokenClaims.roles;
      return roles.find(o => o == "IoTEx.Admin") != null;
    }
    return false;
  }
  public onToggleUser(): void {
    this.showUser = !this.showUser;
  }

  public closeToggleUser(): void {
    this.showUser = !this.showUser;
  }

  public logout(): void {
    this.showUser = false;
    this.authService.logoutRedirect();
  }

  public getUsername() {
    if (this.authService.instance.getActiveAccount() !== null)
      return this.authService.instance.getActiveAccount().name;
    return ""
  }
  public getLogin() {
    if (this.authService.instance.getActiveAccount() !== null)
      return this.authService.instance.getActiveAccount().username;
    return ""
  }
}
