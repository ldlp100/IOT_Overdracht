import { Component, OnInit, Input, Output, ViewChild, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { GridDataResult, DataStateChangeEvent, GridComponent } from '@progress/kendo-angular-grid';
import { Observable, Subject } from 'rxjs';
import { IoTExService } from '../../services/_index';
import * as DTO from '../../models/_index';
import * as allIcons from "@progress/kendo-svg-icons";
import { State } from '@progress/kendo-data-query';
import { Router, ActivatedRoute } from '@angular/router';
import { BaseComponent } from '../../base.component';
import { Stream } from 'stream';
import { CONDITIONAL_TYPES } from '@babel/types';
import { NotificationService } from "@progress/kendo-angular-notification";

@Component({
  selector: 'app-device-published-configuration',
  templateUrl: './device-published-configuration.component.html',
  styleUrls: ['./device-published-configuration.component.css']
})
export class DevicePublishedConfigurationComponent extends BaseComponent implements OnInit, OnChanges {

  @Input() public devicePublished: DTO.DeviceDefinitionDTO;

  public gridView: GridDataResult;
  public editDataItem: DTO.DeviceConfigurationDTO;
  public isNew: boolean;
  public device: DTO.DeviceDTO;
  constructor(private service: IoTExService, private _router: Router, private _activatedRoute: ActivatedRoute,private notificationService: NotificationService) {
    super();
  }

  public gridState: State = {
    sort: [],
    skip: 0,
    take: 10
  }
  public ngOnChanges(changes: SimpleChanges): void {
    if (changes['devicePublished']) {
      this.refreshGrid(null);
    }
    
  }
  public ngOnInit(): void {
    
    this.refreshGrid(null);
  }

  public refreshGrid($event): void {
    if (this.devicePublished == null) {
      return;
    }
    if (this.devicePublished.settings == null) {
      return;
    }
    this.gridView = <GridDataResult>{
       data: this.devicePublished.settings.configurations,
       total: this.devicePublished.settings.configurations.length
    }
  }
  public publish(){
    this.service.deviceService.publish(this.devicePublished.deviceId, this.devicePublished.info.deviceTypeId, 
                          this.devicePublished.info.deviceBatchId).subscribe((result) => {
      console.log("RESULT",result);
      this.notificationService.show({
        content: (result.isOk)? "Device is published successfully!" : "Error while publishing device!\n" + result.error,
        cssClass: "button-notification",
        animation: { type: "slide", duration: 400 },
        position: { horizontal: "center", vertical: "bottom" },
        type: { style: (result.isOk)?"success":"error", icon: true },
        closable: false,
      });
    });
  }
  public onStateChange(state: State) {
    this.gridState = state;
    console.log(this.gridState);
    this.refreshGrid(null);
  }

  public editHandler({ dataItem }) {
    var device = new DTO.DeviceDTO();
    
    device.deviceTypeId = this.devicePublished.info.deviceTypeId;
    device.deviceTypeFirmwareId = this.devicePublished.info.deviceFirmwareId;
    device.id = this.devicePublished.deviceId;
    this.device = device;
    this.editDataItem = dataItem;
    console.log("Edit Handler", this.editDataItem);
    
    this.isNew = false;
  }

  public cancelHandler($event) {
    this.editDataItem = undefined;
  }

  public saveHandler(objToSave: any) {
    this.service.deviceConfigurationService.save(objToSave, this.isNew, this.device.deviceTypeId, 
                                    this.device.deviceBatchId, this.device.id).subscribe((result) => {
      this.updateGridData(result.value, false);
      this.editDataItem = undefined;
    });
  } 

  private updateGridData(updatedObj: DTO.DeviceDefinitionConfigurationDTO, remove: boolean) {
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
}
