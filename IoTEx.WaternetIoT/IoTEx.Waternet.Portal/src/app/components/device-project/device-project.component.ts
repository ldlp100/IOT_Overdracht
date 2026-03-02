import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { GridDataResult, DataStateChangeEvent, GridComponent } from '@progress/kendo-angular-grid';
import { Observable, Subject } from 'rxjs';
import { IoTExService } from '../../services/_index';
import * as DTO from '../../models/_index';
import { State } from '@progress/kendo-data-query';
import { Router, ActivatedRoute } from '@angular/router';
import { BaseComponent } from '../../base.component';

@Component({
  selector: 'app-device-project',
  templateUrl: './device-project.component.html',
  styleUrls: ['./device-project.component.css']
})
export class DeviceProjectComponent extends BaseComponent implements OnInit {

  public project: DTO.ProjectDTO;
  public id: string;

  constructor(private service: IoTExService, private _router: Router, private _activatedRoute: ActivatedRoute) {
    super();
  }

  public ngOnInit(): void {
    this.id = this._activatedRoute.snapshot.paramMap.get('projectId');
    
    this.service.projectService.get(this.id).subscribe((result) => {
      this.project = result.value;
      
    });
  }
}
