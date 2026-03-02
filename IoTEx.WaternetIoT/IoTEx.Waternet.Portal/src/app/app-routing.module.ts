import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { MsalGuard, MsalRedirectComponent } from '@azure/msal-angular';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { UserProjectComponent } from './components/user-project/user-project.component';
import { CenterComponent } from './components/center/center.component';
import { AboutComponent } from './components/about/about.component';
import { ContactComponent } from './components/contact/contact.component';
import { DeviceProjectComponent } from './components/device-project/device-project.component'
import { DevicePublishedComponent } from './components/devicePublished/devicePublished.component'

const routes: Routes = [

  { path: 'auth', component: MsalRedirectComponent },
  { path: '', component: HomeComponent, pathMatch: 'full', canActivate: [MsalGuard] },
  { path: 'userproject', component: UserProjectComponent, pathMatch: 'full', canActivate: [MsalGuard] },
  { path: 'center', component: CenterComponent, pathMatch: 'full', canActivate: [MsalGuard] },
  { path: 'about', component: AboutComponent, pathMatch: 'full', canActivate: [MsalGuard] },
  { path: 'contact', component: ContactComponent, pathMatch: 'full', canActivate: [MsalGuard] },
  { path: 'projects/:projectId/devices', component: DeviceProjectComponent, pathMatch: 'full', canActivate: [MsalGuard] },
  { path: 'devices/:deviceId', component: DevicePublishedComponent, pathMatch: 'full', canActivate: [MsalGuard] },
  { path: 'login-failed', component: MsalRedirectComponent }
  //{ path: 'superadmin', component: SuperAdminComponent, canActivate: [MsalGuard] },
  //{ path: 'subscriptions/:subscriptionId', component: MyHomePageComponent, canActivate: [MsalGuard] },
  //{ path: 'subscriptions/:subscriptionId/sites/:siteId/config', component: SiteFormComponent, canActivate: [MsalGuard] },
  //{ path: 'subscriptions/:subscriptionId/sites/:siteId/intake/:siteName', component: SiteIntakeComponent, canActivate: [MsalGuard] },
  //{ path: 'subscriptions/:subscriptionId/sites/:siteId/realtime', component: Viewer3dComponent, canActivate: [MsalGuard] },
  //{ path: 'subscriptions/:subscriptionId/sites/:siteId/analytics', component: SiteAnalyticsComponent, canActivate: [MsalGuard] },
  //{ path: 'subscriptions/:subscriptionId/analytics', component: AnalyticsComponent, canActivate: [MsalGuard] },
  //{ path: 'subscriptions/:subscriptionId/liveData', component: AnalyticsComponent, canActivate: [MsalGuard] },
  //{ path: 'subscriptions/:subscriptionId/maps', component: MapsComponent, canActivate: [MsalGuard] },
  //{ path: 'subscriptions/:subscriptionId/configuration', component: TabConfigurationComponent, canActivate: [MsalGuard] },
  //{ path: 'subscriptions/:subscriptionId/bfadmin', component: BFAdminComponent, canActivate: [MsalGuard] },
  //{ path: 'subscriptions/:subscriptionId/projectMgmt', component: ProjectMgmtComponent, canActivate: [MsalGuard] }

];


@NgModule({
  declarations: [],
  imports: [ RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
