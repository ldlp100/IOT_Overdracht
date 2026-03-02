import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
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
  selector: 'app-device-published-documentation',
  templateUrl: './device-published-documentation.component.html',
  styleUrls: ['./device-published-documentation.component.css']
})
export class DevicePublishedDocumentationComponent extends BaseComponent implements OnInit {

  @Input() public deviceInfos: DTO.DeviceInfoDTO;

  public attachments: DTO.DeviceAttachmentDTO[];

  constructor(private service: IoTExService, private _router: Router, private _activatedRoute: ActivatedRoute) {
    super();
  }

  public ngOnInit(): void {
    this.attachments = this.deviceInfos.attachments;
  }

}
