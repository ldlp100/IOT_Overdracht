import { Component, OnInit, Input, Output, ViewChild, EventEmitter, OnChanges } from '@angular/core';
import { GridDataResult, DataStateChangeEvent, GridComponent, StringFilterComponent } from '@progress/kendo-angular-grid';
import { Observable, Subject } from 'rxjs';
import { IoTExService } from '../../services/_index';
import * as DTO from '../../models/_index';
import { State } from '@progress/kendo-data-query';
import { BaseComponent } from '../../base.component';
 
@Component({
  selector: 'app-grid-device-output',
  templateUrl: './grid-device-output.component.html',
  styleUrls: ['./grid-device-output.component.css']
})
export class GridDeviceOutputComponent extends BaseComponent implements OnInit, OnChanges {
 
  @Input() public deviceType: DTO.DeviceTypeDTO
  @Input() public deviceBatch: DTO.DeviceBatchDTO
  @Input() public device: DTO.DeviceDTO

  public gridView: GridDataResult;
  public editDataItem: DTO.DeviceOutputDTO;
  public isNew: boolean;
  public removeConfirmationSubject: Subject<boolean> = new Subject<boolean>();
  public itemToRemove: any;
 
  constructor(private service: IoTExService) {
    super();
  }
 
  public gridState: State = {
    sort: [],
    skip: 0,
    take: 10
  }

  public formatAlert(stateName: string, isAlert: boolean): string{
    if(!isAlert){
      return "";
    } else {
      return stateName
    }
  }

  public formatState(stateName: string, isAlert: boolean): string{
    if(isAlert){
      return "";
    } else {
      return stateName
    }
  }
  public ngOnChanges() {
    this.refreshGrid(null);
  }
  public ngOnInit(): void {

    this.refreshGrid(null);
  }

  public refreshGrid($event) {
    console.log(this.deviceType, this.deviceBatch ,this.device)
    if(this.deviceType != null && this.deviceBatch != null && this.device != null){
      this.service.deviceOutputService.getsGrid(this.gridState, this.deviceType.id, this.deviceBatch.id, this.device.id).subscribe((result) => {
      
      this.gridView = result;
    });
    }
  }

  public onStateChange(state: State) {
    this.gridState = state;
    console.log(this.gridState);
    this.refreshGrid(null);
  }
 
  public addHandler($event) {
    this.editDataItem = new DTO.DeviceOutputDTO();
    this.editDataItem.deviceId=this.device.id;
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
    this.service.deviceOutputService.save(objToSave, this.isNew, this.deviceType.id, this.deviceBatch.id, this.device.id).subscribe((data) => {
      this.updateGridData(data.value, false);
      this.editDataItem = undefined;
    });
 
  }
 
  public removeHandler({ dataItem }) {
    this.removeConfirmation(dataItem);
  }
  private updateGridData(updatedObj: DTO.DeviceOutputDTO, remove: boolean) {
 
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
      this.service.deviceOutputService.delete(this.itemToRemove, this.deviceType.id, this.deviceBatch.id, this.device.id).subscribe((data) => {
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
}
 
 

