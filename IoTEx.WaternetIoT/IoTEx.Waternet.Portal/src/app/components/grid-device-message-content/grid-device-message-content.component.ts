import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as DTO from '../../models/_index';
import * as COMMON from '../../common/index';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'

@Component({
  selector: 'app-grid-device-message-content',
  templateUrl: './grid-device-message-content.component.html',
  styleUrls: ['./grid-device-message-content.component.css']
})
export class GridDeviceMessageContentComponent extends BaseComponent {

  @Input() public deviceType: DTO.DeviceTypeDTO

  public _document: DTO.DeviceMessageDTO;
  public active = false;
  public content: string;

  @Input() public set document(value: DTO.DeviceMessageDTO) {
    if (value != undefined && value != null) {
      this._document = value;
      this.content = JSON.stringify(this._document, null, "    ");
      this.active = true;
    }    
  }

  constructor(private service: IoTExService) {
    super();
  }

  public onCancel(e): void {
    
    e.preventDefault();
    this.closeForm();
  }

  public closeForm(): void {
    this.active = false;
  }
}


