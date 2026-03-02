import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as DTO from '../../models/_index';
import * as COMMON from '../../common/index';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'

@Component({
  selector: 'app-grid-device-type-firmware-alert-edit',
  templateUrl: './grid-device-type-firmware-alert-edit.component.html',
  styleUrls: ['./grid-device-type-firmware-alert-edit.component.css']
})
export class GridDeviceTypeFirmwareAlertEditComponent extends BaseComponent {
 
  protected _deviceTypeFirmwareAlert: DTO.DeviceTypeFirmwareAlertDTO;
  private devicetypeFirmwareAlertData: any[];
  public active = false;
  public editForm: FormGroup = new FormGroup({
    id: new FormControl({ disabled: true }),
    name: new FormControl({}, Validators.required),
    description: new FormControl()
  });
 
  @Input() public isNew = false;
 
  @Input() public set model(devicetypeFirmwareAlert: DTO.DeviceTypeFirmwareAlertDTO) {
    this._deviceTypeFirmwareAlert = devicetypeFirmwareAlert;
    this.editForm.reset(devicetypeFirmwareAlert);
    this.active = devicetypeFirmwareAlert !== undefined;
  }
 
  @Output() cancel: EventEmitter<any> = new EventEmitter();
  @Output() save: EventEmitter<DTO.DeviceTypeFirmwareAlertDTO> = new EventEmitter();
  constructor(private service: IoTExService) {
    super();
    this.devicetypeFirmwareAlertData = DATA.nameData;
  }

  public onSave(e): void {
    e.preventDefault();
 
    this._deviceTypeFirmwareAlert.name = this.editForm.value.name;
    this._deviceTypeFirmwareAlert.description = this.editForm.value.description;

    this.save.emit(this._deviceTypeFirmwareAlert);
    this.active = false;
  }
 
  public onCancel(e): void {
    e.preventDefault();
    this.closeForm();
  }
 
  public closeForm(): void {
    this.active = false;
    this.cancel.emit();
  }
}

