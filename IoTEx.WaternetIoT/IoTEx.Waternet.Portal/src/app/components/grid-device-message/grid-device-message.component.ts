import { EventMessage } from '@azure/msal-browser';
import { Component, OnInit, Input, Output, ViewChild, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { GridDataResult, DataStateChangeEvent, GridComponent, StringFilterComponent } from '@progress/kendo-angular-grid';
import { Observable, Subject } from 'rxjs';
import { IoTExService } from '../../services/_index';
import * as DTO from '../../models/_index';
import { State } from '@progress/kendo-data-query';
import { BaseComponent } from '../../base.component';
import { NotificationService } from "@progress/kendo-angular-notification";

@Component({
  selector: 'app-grid-device-message',
  templateUrl: './grid-device-message.component.html',
  styleUrls: ['./grid-device-message.component.css']
})
export class GridDeviceMessageComponent extends BaseComponent implements OnInit, OnChanges {

  @Input() public deviceType: DTO.DeviceTypeDTO
  @Input() public deviceBatch: DTO.DeviceBatchDTO
  @Input() public device: DTO.DeviceDTO

  public document: DTO.DeviceMessageDTO;
  public gridView: GridDataResult;

  constructor(private service: IoTExService) {
    super();
  }

  public gridState: State = {
    sort: [],
    skip: 0,
    take: 10
  }

  
  public ngOnChanges(changes: SimpleChanges): void {
    this.refreshGrid(null);
  }
  public ngOnInit(): void {
    this.refreshGrid(null);
  }

  public refreshGrid($event) {
    if (this.deviceType != null && this.deviceBatch != null && this.device != null) {
      this.service.deviceMessageService.getsGrid(this.gridState, this.deviceType.id, this.deviceBatch.id, this.device.id).subscribe((result) => {
        console.log("RESULT", result);
        this.gridView = result;
      });
    }
  }

  public showdata(dataItem) {
    this.service.deviceMessageService.getContent(this.deviceType.id, this.deviceBatch.id, dataItem.deviceId, dataItem, dataItem.path).subscribe((result) => {
      console.log("RESULT", result);
      
      this.document = result.value;

    });
  }

  public onStateChange(state: State) {
    this.gridState = state;
    console.log(this.gridState);
    this.refreshGrid(null);
  }

}
