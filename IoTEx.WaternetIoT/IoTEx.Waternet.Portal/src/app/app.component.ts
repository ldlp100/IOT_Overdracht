
import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { MsalService, MsalBroadcastService, MSAL_GUARD_CONFIG, MsalGuardConfiguration } from '@azure/msal-angular';
import { AuthenticationResult, InteractionStatus, PopupRequest, RedirectRequest, EventMessage, EventType } from '@azure/msal-browser';
import { Subject } from 'rxjs';
import { ActivatedRoute, Router,RouterModule } from '@angular/router';

import { filter, takeUntil } from 'rxjs/operators';
import { IoTExService } from './services/_index';
import { BaseComponent } from './base.component'
import { CookieService } from 'ngx-cookie-service';
import * as DTO from './models/_index'



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent extends BaseComponent implements OnInit, OnDestroy {

  public showSplash = true;


  title = 'IoT Portal';
  isIframe = false;
  loginDisplay = false;
  isLogged = true;
  private readonly _destroying$ = new Subject<void>();


  constructor(@Inject(MSAL_GUARD_CONFIG) private msalGuardConfig: MsalGuardConfiguration,
    private msalBroadcastService: MsalBroadcastService, authService: MsalService,
    private service: IoTExService, private router: Router, public propertyBag: DTO.ProjectPropertyBag,
    private cookieService: CookieService) {
    super();
    this.authService = authService;
  }

  ngOnInit(): void {
    this.logOn = true;


    this.authService.instance.enableAccountStorageEvents();
    this.msalBroadcastService.msalSubject$
      .pipe(
        // Optional filtering of events
        filter((msg: EventMessage) => msg.eventType === EventType.ACCOUNT_ADDED || msg.eventType === EventType.ACCOUNT_REMOVED),
        takeUntil(this._destroying$)
      )
      .subscribe((result: EventMessage) => {
        if (this.authService.instance.getAllAccounts().length === 0) {
          // Account logged out in a different tab, redirect to homepage
          window.location.pathname = "/";
        } else {
          // Update UI to show user is signed in. result.payload contains the account that was logged in
          this.log("MSDAL_ACCOUNT:", result.payload);
        }
      });
    this.msalBroadcastService.inProgress$
      .pipe(
        filter((status: InteractionStatus) => status === InteractionStatus.None),
        takeUntil(this._destroying$)
      )
      .subscribe(() => {
        this.log("LOGIN_INPROGRESS");
        this.setLoginDisplay();
        this.checkAndSetActiveAccount();

      })

    this.msalBroadcastService.msalSubject$
      .pipe(
        // Optional filtering of events.
        filter((msg: EventMessage) => msg.eventType === EventType.LOGIN_SUCCESS),
        takeUntil(this._destroying$)
      )
      .subscribe((result: EventMessage) => {
        // Do something with the result
        this.log("LOGIN_SUCCESS", result.eventType, result.payload);
        const payload = result.payload as AuthenticationResult;
        this.authService.instance.setActiveAccount(payload.account);
        this.isLogged = true;

      });

    this.msalBroadcastService.msalSubject$
      .pipe(
        // Optional filtering of events.
        filter((msg: EventMessage) => msg.eventType === EventType.ACQUIRE_TOKEN_BY_CODE_SUCCESS),
        takeUntil(this._destroying$)
      )
      .subscribe((result: EventMessage) => {
        // Do something with the result
        this.log("ACQUIRE_TOKEN_BY_CODE_SUCCESS", result.eventType, result.payload);


      });

    this.msalBroadcastService.msalSubject$
      .pipe(
        // Optional filtering of events.
        filter((msg: EventMessage) => msg.eventType === EventType.SSO_SILENT_SUCCESS),
        takeUntil(this._destroying$)
      )
      .subscribe((result: EventMessage) => {
        // Do something with the result
        this.log("SSO_SILENT_SUCCESS", result.eventType, result.payload);


      });

  }
  
  loginRedirect() {
    this.log("loginRedirect");
    if (this.msalGuardConfig.authRequest) {
      this.authService.loginRedirect({ ...this.msalGuardConfig.authRequest } as RedirectRequest);
    } else {
      this.authService.loginRedirect();
    }
  }
  loginPopup() {
    this.log("loginPopup");
    if (this.msalGuardConfig.authRequest) {
      this.authService.loginPopup({ ...this.msalGuardConfig.authRequest } as PopupRequest)
        .subscribe((response: AuthenticationResult) => {
          this.authService.instance.setActiveAccount(response.account);
          this.setupUser();
        });
    } else {
      this.authService.loginPopup()
        .subscribe((response: AuthenticationResult) => {
          this.authService.instance.setActiveAccount(response.account);
        });
    }
  }
  logout(popup?: boolean) {
    this.log("logout");
    if (popup) {
      this.authService.logoutPopup({
        mainWindowRedirectUri: "/"
      });
    } else {
      this.authService.logoutRedirect();
    }
  }
  checkAndSetActiveAccount() {
    /**
     * If no active account set but there are accounts signed in, sets first account to active account
     * To use active account set here, subscribe to inProgress$ first in your component
     * Note: Basic usage demonstrated. Your app may require more complicated account selection logic
     */
    let activeAccount = this.authService.instance.getActiveAccount();
    this.log("checkAndSetActiveAccount", activeAccount);
    if (!activeAccount && this.authService.instance.getAllAccounts().length > 0) {
      let accounts = this.authService.instance.getAllAccounts();
      this.authService.instance.setActiveAccount(accounts[0]);
      for (let account of this.authService.instance.getAllAccounts()) {
        this.log("ACCOUNT=", account.username);
      }
    }
    this.setupUser();
  }
  setLoginDisplay() {
    console.log(this.authService.instance.getAllAccounts());
    this.loginDisplay = this.authService.instance.getAllAccounts().length > 0;
  }
  public getUsername() {

    if (this.authService.instance.getAllAccounts().length > 0)
      return this.authService.instance.getActiveAccount().username;
    return '';
  }
  ngOnDestroy(): void {
    this._destroying$.next(null);
    this._destroying$.complete();
  }

  public setupUser() {

    this.isLogged = true;
    this.service.apiService.sayHello().subscribe(x => {
      console.log("SayHello:", x);
    });
    this.service.apiService.sayHelloUser().subscribe(x => {
      console.log("SayHelloUSer:", x);
    });
    console.log("User Roles", this.getRoles());
    

  }
  public async onActivate(event) {


  }

}
