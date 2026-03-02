import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';
import 'hammerjs';
//KENDO MODULE
import { IconsModule } from "@progress/kendo-angular-icons";
import { LayoutModule } from '@progress/kendo-angular-layout';
import { ListViewModule } from '@progress/kendo-angular-listview';
import { ScrollViewModule } from '@progress/kendo-angular-scrollview';
import { NavigationModule } from "@progress/kendo-angular-navigation";
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { ChartsModule } from '@progress/kendo-angular-charts';
import { DialogModule, DialogsModule } from '@progress/kendo-angular-dialog';
import { GridModule, ExcelModule, PagerModule } from '@progress/kendo-angular-grid';
import { ExcelExportModule } from "@progress/kendo-angular-excel-export";
import { UploadsModule } from '@progress/kendo-angular-upload';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { NotificationModule } from '@progress/kendo-angular-notification';
import { TreeViewModule } from '@progress/kendo-angular-treeview';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { GanttModule } from '@progress/kendo-angular-gantt';

import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { IPublicClientApplication, PublicClientApplication, InteractionType, BrowserCacheLocation, LogLevel } from '@azure/msal-browser';
import { MsalGuard, MsalInterceptor, MsalBroadcastService, MsalInterceptorConfiguration, MsalModule, MsalService, MSAL_GUARD_CONFIG, MSAL_INSTANCE, MSAL_INTERCEPTOR_CONFIG, MsalGuardConfiguration, MsalRedirectComponent, ProtectedResourceScopes } from '@azure/msal-angular'; // Redirect component imported from msal-angular
 

import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { msalConfig, loginRequest, protectedResources } from './auth-config';
import { CookieService } from 'ngx-cookie-service';import { IoTExService } from './services/_index'

import { AppComponent } from './app.component';
import { environment } from './environments/environment';
import { ProjectPropertyBag } from './models/ProjectPropertyBag';
import { PDFExportModule } from '@progress/kendo-angular-pdf-export';
import { ProgressBarModule } from '@progress/kendo-angular-progressbar';
import { TreeListModule } from '@progress/kendo-angular-treelist';
import { PopupModule } from '@progress/kendo-angular-popup';
import { CenterComponent } from './components/center/center.component';
import { GridDeviceTypeComponent } from './components/grid-device-type/grid-device-type.component';
import { GridDeviceTypeEditComponent } from './components/grid-device-type-edit/grid-device-type-edit.component';
import { GridDeviceTypeDetailComponent } from './components/grid-device-type-detail/grid-device-type-detail.component';
import { GridParserComponent } from './components/grid-parser/grid-parser.component';
import { GridParserEditComponent } from './components/grid-parser-edit/grid-parser-edit.component';
import { GridSupplierComponent } from './components/grid-supplier/grid-supplier.component';
import { GridSupplierEditComponent } from './components/grid-supplier-edit/grid-supplier-edit.component';
import { GridUnitTypeComponent } from './components/grid-unit-type/grid-unit-type.component';
import { GridUnitTypeEditComponent } from './components/grid-unit-type-edit/grid-unit-type-edit.component';
import { GridAppConfigurationComponent } from './components/grid-app-configuration/grid-app-configuration.component';
import { GridAppConfigurationEditComponent } from './components/grid-app-configuration-edit/grid-app-configuration-edit.component';
import { GridNetworkAPIComponent } from './components/grid-network-api/grid-network-api.component';
import { GridNetworkAPIEditComponent } from './components/grid-network-api-edit/grid-network-api-edit.component';
import { GridNetworkAPIDetailComponent } from './components/grid-network-api-detail/grid-network-api-detail.component';
import { GridNetworkAPISettingComponent } from './components/grid-network-apisetting/grid-network-apisetting.component';
import { GridNetworkAPISettingEditComponent } from './components/grid-network-apisetting-edit/grid-network-apisetting-edit.component';
import { GridProjectComponent } from './components/grid-project/grid-project.component';
import { GridProjectEditComponent } from './components/grid-project-edit/grid-project-edit.component';
import { GridDeviceBatchComponent } from './components/grid-device-batch/grid-device-batch.component';
import { GridDeviceBatchEditComponent } from './components/grid-device-batch-edit/grid-device-batch-edit.component';
import { GridDeviceBatchDetailComponent } from './components/grid-device-batch-detail/grid-device-batch-detail.component';
import { GridDeviceComponent } from './components/grid-device/grid-device.component';
import { GridDeviceAllComponent } from './components/grid-device-all/grid-device-all.component';
import { GridDeviceProjectComponent } from './components/grid-device-project/grid-device-project.component';
import { GridDeviceEditComponent } from './components/grid-device-edit/grid-device-edit.component';
import { GridDeviceDetailComponent } from './components/grid-device-detail/grid-device-detail.component';
import { GridDeviceOutputComponent } from './components/grid-device-output/grid-device-output.component';
import { GridDeviceOutputEditComponent } from './components/grid-device-output-edit/grid-device-output-edit.component';
import { GridDeviceCalibrationComponent } from './components/grid-device-calibration/grid-device-calibration.component';
import { GridDeviceCalibrationEditComponent } from './components/grid-device-calibration-edit/grid-device-calibration-edit.component';
import { GridDeviceConfigurationComponent } from './components/grid-device-configuration/grid-device-configuration.component';
import { GridDeviceConfigurationEditComponent } from './components/grid-device-configuration-edit/grid-device-configuration-edit.component';
import { GridDeviceTypeFirmwareComponent } from './components/grid-device-type-firmware/grid-device-type-firmware.component';
import { GridDeviceTypeFirmwareEditComponent } from './components/grid-device-type-firmware-edit/grid-device-type-firmware-edit.component';
import { GridDeviceTypeFirmwareDetailComponent } from './components/grid-device-type-firmware-detail/grid-device-type-firmware-detail.component';
import { GridDeviceTypeFirmwareMeasurementTypeComponent } from './components/grid-device-type-firmware-measurement-type/grid-device-type-firmware-measurement-type.component';
import { GridDeviceTypeFirmwareConfigurationComponent } from './components/grid-device-type-firmware-configuration/grid-device-type-firmware-configuration.component';
import { GridDeviceTypeFirmwareMeasurementTypeEditComponent } from './components/grid-device-type-firmware-measurement-type-edit/grid-device-type-firmware-measurement-type-edit.component';
import { GridDeviceTypeFirmwareConfigurationEditComponent } from './components/grid-device-type-firmware-configuration-edit/grid-device-type-firmware-configuration-edit.component';
import { GridDeviceTypeFirmwareStateComponent } from './components/grid-device-type-firmware-state/grid-device-type-firmware-state.component';
import { GridDeviceTypeFirmwareStateEditComponent } from './components/grid-device-type-firmware-state-edit/grid-device-type-firmware-state-edit.component';
import { GridDeviceTypeFirmwareSubStateComponent} from './components/grid-device-type-firmware-substate/grid-device-type-firmware-substate.component';
import { GridDeviceTypeFirmwareSubStateEditComponent } from './components/grid-device-type-firmware-substate-edit/grid-device-type-firmware-substate-edit.component';
import { GridDeviceTypeFirmwareAlertComponent } from './components/grid-device-type-firmware-alert/grid-device-type-firmware-alert.component';
import { GridDeviceTypeFirmwareAlertEditComponent } from './components/grid-device-type-firmware-alert-edit/grid-device-type-firmware-alert-edit.component';
import { GridDeviceType2NetworkAPIComponent } from './components/grid-device-type-2-network-api/grid-device-type-2-network-api.component';
import { GridDeviceType2NetworkAPIEditComponent } from './components/grid-device-type-2-network-api-edit/grid-device-type-2-network-api-edit.component';
import { GridSettingDetailComponent } from './components/grid-setting-detail/grid-setting-detail.component';
import { GridAppUserComponent } from './components/grid-app-user/grid-app-user.component';
import { GridAppUserEditComponent } from './components/grid-app-user-edit/grid-app-user-edit.component';
import { GridTargetDBComponent } from './components/grid-target-db/grid-target-db.component';
import { GridTargetDBEditComponent } from './components/grid-target-db-edit/grid-target-db-edit.component';
import { GridDeviceMessageComponent } from './components/grid-device-message/grid-device-message.component';
import { GridDeviceMessageContentComponent } from './components/grid-device-message-content/grid-device-message-content.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { GridUserProjectComponent } from './components/grid-user-project/grid-user-project.component';
import { HomeComponent } from './components/home/home.component';
import { AboutComponent } from './components/about/about.component';
import { ContactComponent } from './components/contact/contact.component';

import { DevicePublishedComponent } from './components/devicePublished/devicePublished.component';
import { GridProjectDetailComponent } from './components/grid-project-detail/grid-project-detail.component';
import { GridProjectDeviceComponent } from './components/grid-project-device/grid-project-device.component';
import { DeviceProjectComponent } from './components/device-project/device-project.component';
import { UserProjectComponent } from './components/user-project/user-project.component';
import { GridProjectUserComponent } from './components/grid-project-user/grid-project-user.component';
import { GridProjectUserEditComponent } from './components/grid-project-user-edit/grid-project-user-edit.component';
import { DevicePublishedConfigurationComponent } from './components/device-published-configuration/device-published-configuration.component';
import { DevicePublishedDocumentationComponent } from './components/device-published-documentation/device-published-documentation.component';
import { DevicePublishedMeasurementComponent } from './components/device-published-measurement/device-published-measurement.component';
import { DevicePublishedAlertComponent } from './components/device-published-alert/device-published-alert.component';
import { DevicePublishedStateComponent } from './components/device-published-state/device-published-state.component';
import {ProjectMapComponent} from './components/project-map/project-map.component';
import { GridDeviceProjectEditComponent } from './components/grid-device-project-edit/grid-device-project-edit.component';
import {DeviceChartComponent} from './components/device-chart/device-chart.component';
import {DevicePublishedBasicComponent} from './components/device-published-basic/device-published-basic.component';
const isIE = window.navigator.userAgent.indexOf("MSIE ") > -1 || window.navigator.userAgent.indexOf("Trident/") > -1;

export function loggerCallback(logLevel: LogLevel, message: string) {
  //console.log("MSAL:", message);
}
export function MSALInstanceFactory(): IPublicClientApplication {
  return new PublicClientApplication({
    auth: environment.IoTExAuthorization,
    cache: {
      cacheLocation: BrowserCacheLocation.LocalStorage,
      storeAuthStateInCookie: isIE, // set to true for IE 11
    },
    system: {
      loggerOptions: {
        loggerCallback,
        logLevel: LogLevel.Info,
        piiLoggingEnabled: false
      }
    }
  });
}
export function MSALInterceptorConfigFactory(): MsalInterceptorConfiguration {
  const protectedResourceMap = new Map<string, Array<string | ProtectedResourceScopes> | null>();
  protectedResourceMap.set('https://graph.microsoft.com/v1.0/me', ['user.read']);
  //protectedResourceMap.set(protectedResources.apiList.endpoint, [...protectedResources.apiList.scopes.read]);
  protectedResourceMap.set(protectedResources.apiList.endpoint, [...protectedResources.apiList.scopes.read]);

  return {
    interactionType: InteractionType.Redirect,//.Popup,
    protectedResourceMap,
    //MULTITENANT
    //authRequest: (msalService, httpReq, originalAuthRequest) => {
    //  //console.log("originalAuthRequest.account", originalAuthRequest.account);
    //  //console.log("authority", `https://login.microsoftonline.com/${ originalAuthRequest.account?.tenantId ?? 'organizations' }`);
    //  return {
    //    ...originalAuthRequest,
    //    authority: `https://login.microsoftonline.com/${originalAuthRequest.account?.tenantId ?? 'organizations'}`
    //  };
    //}
  };
}
export function MSALGuardConfigFactory(): MsalGuardConfiguration {
  return { interactionType: InteractionType.Redirect, loginFailedRoute: '/login-failed' };
}
@NgModule({
  declarations: [
    AppComponent,
    CenterComponent,
    GridDeviceTypeComponent,
    GridDeviceTypeEditComponent,
    GridDeviceTypeDetailComponent,
    GridParserComponent,
    GridParserEditComponent,
    GridSupplierComponent,
    GridSupplierEditComponent,
    GridUnitTypeComponent,
    GridUnitTypeEditComponent,
    GridAppConfigurationComponent,
    GridAppConfigurationEditComponent,
    GridNetworkAPIComponent,
    GridNetworkAPIEditComponent,
    GridNetworkAPIDetailComponent,
    GridNetworkAPISettingComponent,
    GridNetworkAPISettingEditComponent,
    GridProjectComponent,
    GridProjectEditComponent,
    GridDeviceBatchComponent,
    GridDeviceBatchEditComponent,
    GridDeviceBatchDetailComponent,
    GridDeviceComponent,
    GridDeviceAllComponent,
    GridDeviceEditComponent,
    GridDeviceDetailComponent,
    GridDeviceOutputComponent,
    GridDeviceOutputEditComponent,
    GridDeviceCalibrationComponent,
    GridDeviceCalibrationEditComponent,
    GridDeviceConfigurationComponent,
    GridDeviceConfigurationEditComponent,
    GridProjectDeviceComponent,
    GridDeviceTypeFirmwareComponent,
    GridDeviceTypeFirmwareEditComponent,
    GridDeviceTypeFirmwareDetailComponent,
    GridDeviceTypeFirmwareMeasurementTypeComponent,
    GridDeviceTypeFirmwareConfigurationComponent,
    GridDeviceTypeFirmwareMeasurementTypeEditComponent,
    GridDeviceTypeFirmwareConfigurationEditComponent,
    GridDeviceTypeFirmwareStateComponent,
    GridDeviceTypeFirmwareStateEditComponent,
    GridDeviceTypeFirmwareSubStateComponent,
    GridDeviceTypeFirmwareSubStateEditComponent,    
    GridDeviceTypeFirmwareAlertComponent,
    GridDeviceTypeFirmwareAlertEditComponent,
    GridDeviceType2NetworkAPIComponent,
    GridDeviceType2NetworkAPIEditComponent,
    GridSettingDetailComponent,
    GridAppUserComponent,
    GridAppUserEditComponent,
    GridTargetDBComponent,
    GridTargetDBEditComponent,
    GridDeviceMessageComponent,
    GridDeviceMessageContentComponent,
    NavMenuComponent,
    GridUserProjectComponent,
    HomeComponent,
    AboutComponent,
    ContactComponent,
    GridDeviceProjectComponent,
    GridDeviceProjectEditComponent,
    DevicePublishedComponent,
    GridProjectDetailComponent,
    DeviceProjectComponent,
    UserProjectComponent,
    GridProjectUserComponent,
    GridProjectUserEditComponent,
    DevicePublishedConfigurationComponent,
    DevicePublishedDocumentationComponent,
    DevicePublishedMeasurementComponent,
    DevicePublishedAlertComponent,
    DevicePublishedStateComponent,
    DevicePublishedBasicComponent,
    ProjectMapComponent,
    DeviceChartComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    MsalModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ListViewModule,
    GridModule,
    ExcelModule,
    ExcelExportModule,
    InputsModule,
    LabelModule,
    UploadsModule,
    DropDownsModule,
    DialogModule,
    IconsModule,
    ScrollViewModule,
    LayoutModule,
    ButtonsModule,
    ChartsModule,
    NotificationModule,
    TreeViewModule,
    DateInputsModule,
    GanttModule,
    DialogsModule,
    PagerModule,
    PDFExportModule,
    PopupModule,
    NavigationModule,
    ProgressBarModule,
    TreeListModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: MsalInterceptor,
    multi: true
  },
    {
      provide: MSAL_INSTANCE,
      useFactory: MSALInstanceFactory
    },
    {
      provide: MSAL_GUARD_CONFIG,
      useFactory: MSALGuardConfigFactory
    },
    {
      provide: MSAL_INTERCEPTOR_CONFIG,
      useFactory: MSALInterceptorConfigFactory
    },
    IoTExService,
    CookieService,
    MsalService,
    MsalGuard,
    MsalBroadcastService,
    DatePipe, ProjectPropertyBag],
  bootstrap: [AppComponent, MsalRedirectComponent]
})
export class AppModule { }
