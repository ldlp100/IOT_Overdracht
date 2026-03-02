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
  selector: 'app-user-project',
  templateUrl: './user-project.component.html',
  styleUrls: ['./user-project.component.css']
})
export class UserProjectComponent extends BaseComponent implements OnInit {

  constructor(private service: IoTExService, private _router: Router) {
    super();
  }
  
  public ngOnInit(): void {
    
  }

}

