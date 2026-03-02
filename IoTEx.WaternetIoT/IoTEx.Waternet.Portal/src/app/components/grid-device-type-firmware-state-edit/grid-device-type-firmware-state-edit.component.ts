import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as DTO from '../../models/_index';
import * as COMMON from '../../common/index';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'

@Component({
  selector: 'app-grid-device-type-firmware-state-edit',
  templateUrl: './grid-device-type-firmware-state-edit.component.html',
  styleUrls: ['./grid-device-type-firmware-state-edit.component.css']
})
export class GridDeviceTypeFirmwareStateEditComponent extends BaseComponent {
 
  protected _deviceTypeFirmwareState: DTO.DeviceTypeFirmwareStateDTO;
  private devicetypeFirmwareStateData: any[];
  public active = false;
  public editForm: FormGroup = new FormGroup({
    id: new FormControl({ disabled: true }),
    name: new FormControl({}, Validators.required),
    description: new FormControl()
  });
 
  @Input() public isNew = false;
 
  @Input() public set model(devicetypeFirmwareState: DTO.DeviceTypeFirmwareStateDTO) {
    this._deviceTypeFirmwareState = devicetypeFirmwareState;
    this.editForm.reset(devicetypeFirmwareState);
    this.active = devicetypeFirmwareState !== undefined;
  }
 
  @Output() cancel: EventEmitter<any> = new EventEmitter();
  @Output() save: EventEmitter<DTO.DeviceTypeFirmwareStateDTO> = new EventEmitter();
  constructor(private service: IoTExService) {
    super();
    this.devicetypeFirmwareStateData = DATA.nameData;
  }

  public onSave(e): void {
    e.preventDefault();
 
    this._deviceTypeFirmwareState.name = this.editForm.value.name;
    this._deviceTypeFirmwareState.description = this.editForm.value.description;

    this.save.emit(this._deviceTypeFirmwareState);
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

