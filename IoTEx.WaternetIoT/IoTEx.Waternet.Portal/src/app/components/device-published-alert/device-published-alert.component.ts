import { Component, OnInit, Input, Output, ViewChild, EventEmitter, OnChanges,SimpleChanges } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Router, ActivatedRoute } from '@angular/router';
import { BaseComponent } from '../../base.component';
import * as DTO from '../../models/_index';
@Component({
  selector: 'app-device-published-alert',
  templateUrl: './device-published-alert.component.html',
  styleUrls: ['./device-published-alert.component.css']
})
export class DevicePublishedAlertComponent extends BaseComponent implements OnInit, OnChanges {
  @Input() public devicePublished: DTO.DeviceDefinitionDTO;

  public alerts: DTO.DeviceDefinitionAlertDTO[];

  constructor(private service: IoTExService, private _router: Router, private _activatedRoute: ActivatedRoute) {
    super();
  }

  public ngOnInit(): void {
    this.alerts = this.devicePublished.settings.alerts;
  }
  public ngOnChanges(changes: SimpleChanges): void {
    if (changes['devicePublished']) {
      this.alerts = this.devicePublished.settings.alerts;
    }
  }
}
