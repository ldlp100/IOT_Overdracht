import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as DTO from '../../models/_index';
import * as COMMON from '../../common/index';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'

@Component({
  selector: 'app-grid-device-type-firmware-edit',
  templateUrl: './grid-device-type-firmware-edit.component.html',
  styleUrls: ['./grid-device-type-firmware-edit.component.css']
})
export class GridDeviceTypeFirmwareEditComponent extends BaseComponent {
 
  protected _deviceTypeFirmware: DTO.DeviceTypeFirmwareDTO;
  private devicetypeFirmwareData: any[];
  public parserData:any[];
  public active = false;
  public editForm: FormGroup = new FormGroup({
    id: new FormControl({ disabled: true }),
    name: new FormControl({}, Validators.required),
    description: new FormControl(),
    isUsed: new FormControl(),
    parserId: new FormControl({}, Validators.required),
    isConfigurable: new FormControl()
  });
 
  @Input() public isNew = false;
 
  @Input() public set model(devicetypeFirmware: DTO.DeviceTypeFirmwareDTO) {
    this._deviceTypeFirmware = devicetypeFirmware;
    this.editForm.reset(devicetypeFirmware);
    this.active = devicetypeFirmware !== undefined;
  }
 
  @Output() cancel: EventEmitter<any> = new EventEmitter();
  @Output() save: EventEmitter<DTO.DeviceTypeFirmwareDTO> = new EventEmitter();
  constructor(private service: IoTExService) {
    super();
    this.devicetypeFirmwareData = DATA.nameData;
  }

  public ngOnInit(): void {
    this.fillcombo();
  }

  public fillcombo():void{
    this.service.parserService.gets(null).subscribe((result)=>{
      this.parserData =result.value;
     })
  }

  public onSave(e): void {
    e.preventDefault();
 
    this._deviceTypeFirmware.name = this.editForm.value.name;
    this._deviceTypeFirmware.description = this.editForm.value.description;
    this._deviceTypeFirmware.isUsed = this.editForm.value.isUsed;
    this._deviceTypeFirmware.parserId = this.editForm.value.parserId;
    this._deviceTypeFirmware.isConfigurable = this.editForm.value.isConfigurable;

    console.log(this._deviceTypeFirmware.parserId)

    this.save.emit(this._deviceTypeFirmware);
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

