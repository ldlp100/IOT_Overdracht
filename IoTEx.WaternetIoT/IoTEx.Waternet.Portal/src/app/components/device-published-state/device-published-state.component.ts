import { Component, OnInit, Input, Output, ViewChild, EventEmitter, OnChanges,SimpleChanges } from '@angular/core';
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

@Component({
  selector: 'app-device-published-state',
  templateUrl: './device-published-state.component.html',
  styleUrls: ['./device-published-state.component.css']
})
export class DevicePublishedStateComponent extends BaseComponent implements OnInit, OnChanges {

  @Input() public devicePublished: DTO.DeviceDefinitionDTO;

  public states: DTO.DeviceDefinitionStateDTO[];

  constructor(private service: IoTExService, private _router: Router, private _activatedRoute: ActivatedRoute) {
    super();
  }

  public ngOnInit(): void {
    this.states = this.devicePublished.settings.states;
  }
  public ngOnChanges(changes: SimpleChanges): void {
    if (changes['devicePublished']) {
      this.states = this.devicePublished.settings.states;
    }
  }
}
