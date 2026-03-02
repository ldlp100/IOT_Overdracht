import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { GridDataResult, DataStateChangeEvent, GridComponent } from '@progress/kendo-angular-grid';
import { Observable, Subject } from 'rxjs';
import { IoTExService } from '../../services/_index';
import * as DTO from '../../models/_index';
import { State } from '@progress/kendo-data-query';
import { BaseComponent } from '../../base.component';
import { NotificationService } from "@progress/kendo-angular-notification";
import {
  SVGIcon,
  jsIcon
} from "@progress/kendo-svg-icons";

@Component({
  selector: 'app-grid-device-batch',
  templateUrl: './grid-device-batch.component.html',
  styleUrls: ['./grid-device-batch.component.css']
})
export class GridDeviceBatchComponent extends BaseComponent implements OnInit {
 
  @Input() public deviceType: DTO.DeviceTypeDTO

  public gridView: GridDataResult;
  public editDataItem: DTO.DeviceBatchDTO;
  public isNew: boolean;
  public removeConfirmationSubject: Subject<boolean> = new Subject<boolean>();
  public itemToRemove: any;
  public svgPublishDoc: SVGIcon = jsIcon;

  constructor(private service: IoTExService,private notificationService: NotificationService) {
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
    this.service.deviceBatchService.getsGrid(this.gridState, this.deviceType.id).subscribe((result) => {
      console.log("RESULT",result);
      this.gridView = result;
    });
  }
  public onStateChange(state: State) {
    this.gridState = state;
    console.log(this.gridState);
    this.refreshGrid(null);
  }
 
  public addHandler($event) {
    this.editDataItem = new DTO.DeviceBatchDTO();
    this.editDataItem.deviceTypeId=this.deviceType.id;
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
    this.service.deviceBatchService.save(objToSave, this.isNew, this.deviceType.id).subscribe((data) => {
      this.updateGridData(data.value, false);
      this.editDataItem = undefined;
    });
 
  }
 
  public removeHandler({ dataItem }) {
    this.removeConfirmation(dataItem);
  }
  private updateGridData(updatedObj: DTO.DeviceBatchDTO, remove: boolean) {
 
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
      this.service.deviceBatchService.delete(this.itemToRemove, this.deviceType.id).subscribe((data) => {
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
    this.service.deviceBatchService.publish(dataItem.deviceTypeId, dataItem).subscribe((result) => {
      this.notificationService.show({
        content: (result.isOk)? result.value : result.error,
        cssClass: "button-notification",
        animation: { type: "slide", duration: 400 },
        position: { horizontal: "center", vertical: "bottom" },
        type: { style: (result.isOk)?"success":"error", icon: true },
        closable: true,
      });
      console.log("RESULT",result);
    });
  }
}