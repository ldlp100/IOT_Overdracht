import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { GridDataResult, DataStateChangeEvent, GridComponent } from '@progress/kendo-angular-grid';
import { Observable, Subject } from 'rxjs';
import { IoTExService } from '../../services/_index';
import * as DTO from '../../models/_index';
import { State } from '@progress/kendo-data-query';
import { Router } from '@angular/router';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data';

@Component({
  selector: 'app-grid-project-user',
  templateUrl: './grid-project-user.component.html',
  styleUrls: ['./grid-project-user.component.css']
})
export class GridProjectUserComponent extends BaseComponent implements OnInit {

  @Input() public project: DTO.ProjectDTO

  public gridView: GridDataResult;
  public editDataItem: DTO.User2ProjectDTO;
  public isNew: boolean;
  public removeConfirmationSubject: Subject<boolean> = new Subject<boolean>();
  public itemToRemove: any;

  constructor(private service: IoTExService, private _router: Router) {
    super();
  }


  public gridState: State = {
    sort: [{ field: 'userName', dir: 'asc' }],
    skip: 0,
    take: 10
  }

  public ngOnInit(): void {
    this.refreshGrid(null);
  }

  public refreshGrid($event) {
    this.service.user2projectService.getsGrid(this.gridState, this.project.id).subscribe((result) => {
      console.log("RESULT", result);
      this.gridView = result;
    });
  }

  public onStateChange(state: State) {
    this.gridState = state;
    console.log(this.gridState);
    this.refreshGrid(null);
  }

  public addHandler($event) {
    this.editDataItem = new DTO.User2ProjectDTO();
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
    this.service.user2projectService.save(objToSave, this.isNew, this.project.id).subscribe((data) => {
      this.updateGridData(data.value, false);
      this.editDataItem = undefined;
    });

  }

  public removeHandler({ dataItem }) {
    this.removeConfirmation(dataItem);
  }

  private updateGridData(updatedObj: DTO.User2ProjectDTO, remove: boolean) {

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
      this.service.user2projectService.delete(this.itemToRemove, this.project.id).subscribe((data) => {
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

  public formatAppUserRole(id: number): string {
    for (const item of DATA.AppUserRole) {
      if (item.id == id)
        return item.text;
    }
    return "";
  }
}

