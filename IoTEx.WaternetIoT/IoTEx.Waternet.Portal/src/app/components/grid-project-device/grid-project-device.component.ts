import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { GridDataResult, DataStateChangeEvent, GridComponent } from '@progress/kendo-angular-grid';
import { Observable, Subject } from 'rxjs';
import { IoTExService } from '../../services/_index';
import * as DTO from '../../models/_index';
import { State } from '@progress/kendo-data-query';
import { Router, ActivatedRoute } from '@angular/router';
import { BaseComponent } from '../../base.component';
import { NotificationService } from "@progress/kendo-angular-notification";
import { FilterableSettings } from "@progress/kendo-angular-grid";
import {
  SVGIcon,
  jsIcon
} from "@progress/kendo-svg-icons";

@Component({
  selector: 'app-grid-project-device',
  templateUrl: './grid-project-device.component.html',
  styleUrls: ['./grid-project-device.component.css']
})
export class GridProjectDeviceComponent extends BaseComponent implements OnInit {
  @Input() public projectId:string;
  public gridView: GridDataResult;
  public data:any;
  public svgPublishDoc: SVGIcon = jsIcon;
  public filterMode: FilterableSettings = "row";
  constructor(private service: IoTExService, private _router: Router, private _activatedRoute: ActivatedRoute, private notificationService: NotificationService) {
    super();
  }


  public gridState: State = {
    sort: [{ field:'assetUID', dir: 'asc' }],
    skip: 0,
    take: 10
  }

  public ngOnInit(): void {
    this.refreshGrid(null);
  }

  public refreshGrid($event) {
    
    if (this.projectId != null) {
      this.service.device2projectService.getsDeviceForProjectGrid(this.gridState, this.projectId).subscribe((result) => {
        this.gridView = result;
        this.data=result.data;
      });
  
   }  
  }

  public onStateChange(state: State) {
    this.gridState = state;
    console.log(this.gridState);
    this.refreshGrid(null);
  }

  public extractCSV() {
    console.log("extract CSV");
  }

  public device(deviceId: string) {
    this._router.navigate([`devices/${deviceId}`]);
  }

  public startPublish(dataItem) {
    console.log("Publish Device", dataItem);
    this.service.deviceService.publish(dataItem.deviceId , dataItem.deviceTypeId, dataItem.deviceBatchId).subscribe((result) => {
      this.notificationService.show({
        content: (result.isOk)? "Device is published successfully!" : "Error while publishing device!\n" + result.error,
        cssClass: "button-notification",
        animation: { type: "slide", duration: 400 },
        position: { horizontal: "center", vertical: "bottom" },
        type: { style: (result.isOk)?"success":"error", icon: true },
        closable: false,
      });
      console.log("RESULT",result);
    });
  }
}
