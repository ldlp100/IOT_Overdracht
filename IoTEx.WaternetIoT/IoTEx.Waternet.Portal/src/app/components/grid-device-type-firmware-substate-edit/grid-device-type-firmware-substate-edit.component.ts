import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as DTO from '../../models/_index';
import * as COMMON from '../../common/index';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'

@Component({
  selector: 'app-grid-device-type-firmware-substate-edit',
  templateUrl: './grid-device-type-firmware-substate-edit.component.html',
  styleUrl: './grid-device-type-firmware-substate-edit.component.css'
})

export class GridDeviceTypeFirmwareSubStateEditComponent extends BaseComponent {
 
  protected _deviceTypeFirmwareSubState: DTO.DeviceTypeFirmwareSubStateDTO;
  private devicetypeFirmwareSubStateData: any[];
  public active = false;
  public editForm: FormGroup = new FormGroup({
    id: new FormControl({ disabled: true }),
    name: new FormControl({}, Validators.required),
    value: new FormControl(0),
    description: new FormControl()
  });
 
  @Input() public isNew = false;
 
  @Input() public set model(devicetypeFirmwareSubState: DTO.DeviceTypeFirmwareSubStateDTO) {
    this._deviceTypeFirmwareSubState = devicetypeFirmwareSubState;
    this.editForm.reset(devicetypeFirmwareSubState);
    this.active = devicetypeFirmwareSubState !== undefined;
  }
 
  @Output() cancel: EventEmitter<any> = new EventEmitter();
  @Output() save: EventEmitter<DTO.DeviceTypeFirmwareSubStateDTO> = new EventEmitter();
  constructor(private service: IoTExService) {
    super();
    //this.devicetypeFirmwareSubStateData = DATA.nameData;
  }

  public onSave(e): void {
    e.preventDefault();
 
    this._deviceTypeFirmwareSubState.name = this.editForm.value.name;
    this._deviceTypeFirmwareSubState.value = this.editForm.value.value;
    this._deviceTypeFirmwareSubState.description = this.editForm.value.description;

    this.save.emit(this._deviceTypeFirmwareSubState);
    console.log("SAVE", this._deviceTypeFirmwareSubState);
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

