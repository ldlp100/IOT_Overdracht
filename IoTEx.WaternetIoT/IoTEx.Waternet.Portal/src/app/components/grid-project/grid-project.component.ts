import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { GridDataResult, DataStateChangeEvent, GridComponent } from '@progress/kendo-angular-grid';
import { Observable, Subject } from 'rxjs';
import { IoTExService } from '../../services/_index';
import * as DTO from '../../models/_index';
import { State } from '@progress/kendo-data-query';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'
import { FilterableSettings } from "@progress/kendo-angular-grid";

@Component({
  selector: 'app-grid-project',
  templateUrl: './grid-project.component.html',
  styleUrls: ['./grid-project.component.css']
})
export class GridProjectComponent extends BaseComponent implements OnInit {
 
  public gridView: GridDataResult;
  public editDataItem: DTO.ProjectDTO;
  public isNew: boolean;
  public removeConfirmationSubject: Subject<boolean> = new Subject<boolean>();
  public itemToRemove: any;
  public filterMode: FilterableSettings = "row";

  public onModeChange(mode: FilterableSettings): void {
    this.filterMode = mode;
  }
  constructor(private service: IoTExService) {
    super();
  }
 
  public gridState: State = {
    
    sort: [{ field:'name', dir: 'asc' }],
    skip: 0,
    take: 10
  }
 
  public ngOnInit(): void {
    this.refreshGrid(null);
  }
  public refreshGrid($event) {
    this.service.projectService.getsGrid(this.gridState).subscribe((result) => {
      console.log("RESULT",result);
      this.gridView = result;
    });
  }
  public onStateChange(state: State) {
    
    this.gridState = state;
    console.log("state", this.gridState);
    this.refreshGrid(null);
  }
 
  public addHandler($event) {
    this.editDataItem = new DTO.ProjectDTO();
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
    this.service.projectService.save(objToSave, this.isNew).subscribe((data) => {
      this.updateGridData(data.value, false);
      this.editDataItem = undefined;
    });
 
  }
 
  public removeHandler({ dataItem }) {
    this.removeConfirmation(dataItem);
  }

  private updateGridData(updatedObj: DTO.ProjectDTO, remove: boolean) {
 
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
      this.service.projectService.delete(this.itemToRemove).subscribe((data) => {
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


  public formatAccessLevel(id:number):string {
    for (const item of DATA.accessEnumData) {
        if (item.id==id)
          return item.text;
    }
    return "";
  }
}
 
 