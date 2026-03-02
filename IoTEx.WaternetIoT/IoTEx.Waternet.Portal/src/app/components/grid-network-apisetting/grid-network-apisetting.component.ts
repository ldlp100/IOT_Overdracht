import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { GridDataResult, DataStateChangeEvent, GridComponent } from '@progress/kendo-angular-grid';
import { Observable, Subject } from 'rxjs';
import { IoTExService } from '../../services/_index';
import * as DTO from '../../models/_index';
import { State } from '@progress/kendo-data-query';
import { BaseComponent } from '../../base.component';
 
@Component({
  selector: 'app-grid-network-apisetting',
  templateUrl: './grid-network-apisetting.component.html',
  styleUrls: ['./grid-network-apisetting.component.css']
})
export class GridNetworkAPISettingComponent extends BaseComponent implements OnInit {
 
  @Input() public networkAPI: DTO.NetworkAPIDTO

  public gridView: GridDataResult;
  public editDataItem: DTO.NetworkAPISettingDTO;
  public isNew: boolean;
  public removeConfirmationSubject: Subject<boolean> = new Subject<boolean>();
  public itemToRemove: any;
  public isSecret: boolean = false;
 
  constructor(private service: IoTExService) {
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
    this.service.networkAPISettingService.getsGrid(this.gridState, this.networkAPI.id).subscribe((result) => {
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
    this.editDataItem = new DTO.NetworkAPISettingDTO();
    this.editDataItem.networkAPIId=this.networkAPI.id;
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
    this.service.networkAPISettingService.save(objToSave, this.isNew, this.networkAPI.id).subscribe((data) => {
      this.updateGridData(data.value, false);
      this.editDataItem = undefined;
    });
 
  }
 
  public removeHandler({ dataItem }) {
    this.removeConfirmation(dataItem);
  }

  private updateGridData(updatedObj: DTO.NetworkAPISettingDTO, remove: boolean) {
 
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
      this.service.networkAPISettingService.delete(this.itemToRemove, this.networkAPI.id).subscribe((data) => {
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

  public isSecretValue(value: string, isSecret: boolean){
    if(isSecret)
      return value="********"
    else
      return value
  }
}
 
 