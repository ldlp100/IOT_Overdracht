import { environment } from '../environments/environment'


export class ProjectPropertyBag {
  public loading: boolean = false;
  public BASE_URL = environment.IoTExServiceAPIUri;
  public splashScreenLoaded: boolean = false;
}
