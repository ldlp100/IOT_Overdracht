import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { GridDataResult, DataStateChangeEvent, GridComponent } from '@progress/kendo-angular-grid';
import { Observable, Subject } from 'rxjs';
import { IoTExService } from '../../services/_index';
import * as DTO from '../../models/_index';
import { State } from '@progress/kendo-data-query';
import { BaseComponent } from '../../base.component';
import { Router, ActivatedRoute } from '@angular/router';
import { NotificationService } from "@progress/kendo-angular-notification";
import {
  SVGIcon,
  jsIcon
} from "@progress/kendo-svg-icons";

@Component({
  selector: 'app-grid-device',
  templateUrl: './grid-device.component.html',
  styleUrls: ['./grid-device.component.css']
})
export class GridDeviceComponent extends BaseComponent implements OnInit {
 
  @Input() public deviceTypeId: string
  @Input() public deviceBatchId: string
  
  public gridView: GridDataResult;
  public editDataItem: DTO.DeviceDTO;
  public isNew: boolean;
  public removeConfirmationSubject: Subject<boolean> = new Subject<boolean>();
  public itemToRemove: any;
  public showPublished:boolean=false;
  public publishedContent="";
  public svgPublishDoc: SVGIcon = jsIcon;
  constructor(private service: IoTExService,private _router: Router, private _activatedRoute: ActivatedRoute,private notificationService: NotificationService) {
    super();
  }
 
  public gridState: State = {
    sort: [],
    skip: 0,
    take: 10
  }
 
  public ngOnInit(): void {
    this.refreshGrid(null);
  }
  public refreshGrid($event) {
    
    if(this.deviceTypeId != null && this.deviceBatchId != null){
      this.service.deviceService.getsGrid(this.gridState, this.deviceTypeId, this.deviceBatchId).subscribe((result) => {
      console.log("RESULT",result);
      this.gridView = result;
      });
    }
  }
  public showDevice(deviceId: string) {
    console.log(deviceId);
    const url = this._router.serializeUrl(this._router.createUrlTree([`devices/${deviceId}`])); // Use your route here
    window.open(url, `_device${deviceId}`);
  }
  public onStateChange(state: State) {
    this.gridState = state;
    console.log(this.gridState);
    this.refreshGrid(null);
  }
 
  public addHandler($event) {
    this.editDataItem = new DTO.DeviceDTO();
    this.editDataItem.deviceTypeId=this.deviceTypeId;
    this.editDataItem.deviceBatchId=this.deviceBatchId;
    //Set Defayult Value
    //this.editDataItem.communicationType = DTO.CommunicationTypeEnum.Unknown;
    this.isNew = true;
  }
 
  public editHandler({ dataItem }) {
 
    this.editDataItem = dataItem;    
    this.isNew = false;
  }
 
  public cancelHandler($event) {
    this.editDataItem = undefined;
  }
 
  public saveHandler(objToSave: any) {
    
    this.service.deviceService.save(objToSave, this.isNew, objToSave.deviceTypeId, objToSave.deviceBatchId).subscribe((data) => {
      this.updateGridData(data.value, false);
      this.editDataItem = undefined;
    });
 
  }
 
  public removeHandler({ dataItem }) {
    this.removeConfirmation(dataItem);
  }
  private updateGridData(updatedObj: DTO.DeviceDTO, remove: boolean) {
 
    let i = 0;
    for (const site of this.gridView.data) {
 
      if (site.id == updatedObj.id) {
        if (!remove)
          this.gridView.data.splice(i, 1, updatedObj);
        else
          this.gridView.data.splice(i, 1);
        return;
      }
      i++;
    }
    this.gridView.data.push(updatedObj);
  }
  public confirmRemove(shouldRemove: boolean): void {
    this.removeConfirmationSubject.next(shouldRemove);
    if (shouldRemove) {
      this.service.deviceService.delete(this.itemToRemove, this.deviceTypeId, this.deviceBatchId).subscribe((data) => {
        if (data.isOk) {
          this.updateGridData(data.value, true);
          this.editDataItem = undefined;
        }
        else {
          this.service.showNotificationError("The record cannot be deleted! Check that there is no children relationship to this record!");
        }
      });
    }
    this.itemToRemove = null;
  }
 
  public removeConfirmation(dataItem): Subject<boolean> {
    this.itemToRemove = dataItem;
 
    return this.removeConfirmationSubject;
  }

  public startPublish(dataItem) {
    console.log("Publish Device", dataItem);
    this.service.deviceService.publish(dataItem.id, dataItem.deviceTypeId, dataItem.deviceBatchId).subscribe((result) => {
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

  public startGenConfig(dataItem) {
    this.service.deviceService.genConfig(dataItem, dataItem.deviceTypeId, dataItem.deviceBatchId).subscribe((result) => {
      console.log("RESULT",result);
    });
  }

  public startPushConfig(dataItem) {
    this.service.deviceService.pushConfig(dataItem, dataItem.deviceTypeId, dataItem.deviceBatchId).subscribe((result) => {
      console.log("RESULT",result);
    });
  }
  public getPublish(dataItem) {
    
    this.service.deviceService.getPublishDevice(dataItem.deviceTypeId, dataItem.deviceBatchId,dataItem.id).subscribe((result) => {
      this.showPublished=true;
      console.log("RESULT",result);
      if (result.isOk){
        this.publishedContent=JSON.stringify(result.value, null, 2);
      }
      else
        this.publishedContent="Content NoT Existing for Device!";

      
    });
  }
  public closePublishedWindow(){
    this.showPublished=false;
  }
}
