import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { GridDataResult, DataStateChangeEvent, GridComponent } from '@progress/kendo-angular-grid';
import { Observable, Subject } from 'rxjs';
import { IoTExService } from '../../services/_index';
import * as DTO from '../../models/_index';
import { State } from '@progress/kendo-data-query';
import { Router } from '@angular/router';
import { BaseComponent } from '../../base.component';
import { FilterableSettings } from "@progress/kendo-angular-grid";

@Component({
  selector: 'app-grid-user-project',
  templateUrl: './grid-user-project.component.html',
  styleUrls: ['./grid-user-project.component.css']
})
export class GridUserProjectComponent extends BaseComponent implements OnInit {

  public gridView: GridDataResult;
  public filterMode: FilterableSettings = "row";
  constructor(private service: IoTExService, private _router: Router) {
    super();
  }


  public gridState: State = {
    sort: [{ field:'projectName', dir: 'asc' }],
    skip: 0,
    take: 15
  }

  public ngOnInit(): void {
    this.refreshGrid(null);
  }

  public refreshGrid($event) {
    this.service.user2projectService.getsGridMyProject(this.gridState).subscribe((result) => {
      console.log("RESULT", result);
      this.gridView = result;
    });
  }
  public onStateChange(state: State) {
    this.gridState = state;
    console.log(this.gridState);
    this.refreshGrid(null);
  }
  public deviceProject(projectId: string) {
    this._router.navigate([`projects/${projectId}/devices`]);
  }
}

