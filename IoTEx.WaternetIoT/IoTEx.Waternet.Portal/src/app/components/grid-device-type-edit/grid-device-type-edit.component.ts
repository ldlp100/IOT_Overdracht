import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as DTO from '../../models/_index';
import * as COMMON from '../../common/index';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'

@Component({
  selector: 'app-grid-device-type-edit',
  templateUrl: './grid-device-type-edit.component.html',
  styleUrls: ['./grid-device-type-edit.component.css']
})
export class GridDeviceTypeEditComponent extends BaseComponent implements OnInit {
 
  protected _deviceType: DTO.DeviceTypeDTO;
  private deviceTypeData: any[];
  public supplierData:any[];
  public active = false;
  public editForm: FormGroup = new FormGroup({
    id: new FormControl({ disabled: true }),
    name: new FormControl({}, Validators.required),
    description: new FormControl(),
    supplierId: new FormControl({}, Validators.required)
  });
 
  @Input() public isNew = false;
 
  @Input() public set model(deviceType: DTO.DeviceTypeDTO) {
    this._deviceType = deviceType;
    this.editForm.reset(this._deviceType);
    this.active = deviceType !== undefined;
  }
 
  @Output() cancel: EventEmitter<any> = new EventEmitter();
  @Output() save: EventEmitter<DTO.DeviceTypeDTO> = new EventEmitter();
  constructor(private service: IoTExService) {
    super();
    this.deviceTypeData = DATA.nameData;
  }
  
  public ngOnInit(): void {
    this.fillcombo();
  }

  public fillcombo():void{
    this.service.supplierService.gets(null).subscribe((result)=>{
      this.supplierData =result.value;
     })
  }

  public onSave(e): void {
    e.preventDefault();
 
    this._deviceType.name = this.editForm.value.name;
    this._deviceType.description = this.editForm.value.description;
    this._deviceType.supplierId = this.editForm.value.supplierId;
    
    this.save.emit(this._deviceType);
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
