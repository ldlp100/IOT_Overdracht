import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { GridDataResult, DataStateChangeEvent, GridComponent } from '@progress/kendo-angular-grid';
import { Observable, Subject } from 'rxjs';
import { IoTExService } from '../../services/_index';
import * as DTO from '../../models/_index';
import { State } from '@progress/kendo-data-query';
import { Router, ActivatedRoute } from '@angular/router';
import { BaseComponent } from '../../base.component';

@Component({
  selector: 'app-grid-device-project',
  templateUrl: './grid-device-project.component.html',
  styleUrls: ['./grid-device-project.component.css']
})
export class GridDeviceProjectComponent extends BaseComponent implements OnInit {

  @Input() public device: DTO.DeviceDTO
  
  public gridView: GridDataResult;
  public editDataItem: DTO.Device2ProjectDTO;
  public isNew: boolean;
  public removeConfirmationSubject: Subject<boolean> = new Subject<boolean>();
  public itemToRemove: any;
  
  public id: string;

  constructor(private service: IoTExService, private _router: Router, private _activatedRoute: ActivatedRoute) {
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
    if (this.device != null) {
      this.service.device2projectService.getsProjectForDeviceGrid(this.gridState, this.device.id).subscribe((result) => {
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
    this.isNew = true;
    this.editDataItem = new DTO.Device2ProjectDTO();
    this.editDataItem.deviceId = this.device.id;
    //Set Defayult Value
    //this.editDataItem.communicationType = DTO.CommunicationTypeEnum.Unknown;
    
  }
 
  public editHandler({ dataItem }) {
    this.isNew = false;
    this.editDataItem = dataItem;
    
  }
 
  public cancelHandler($event) {
    this.editDataItem = undefined;
  }
 
  public saveHandler(objToSave: any) {
    this.service.device2projectService.save(objToSave, this.isNew).subscribe((data) => {
      this.updateGridData(data.value, false);
      this.editDataItem = undefined;
    });
 
  }
 
  public removeHandler({ dataItem }) {
    this.removeConfirmation(dataItem);
  }
  private updateGridData(updatedObj: DTO.Device2ProjectDTO, remove: boolean) {
 
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
      this.service.device2projectService.delete(this.itemToRemove).subscribe((data) => {
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
