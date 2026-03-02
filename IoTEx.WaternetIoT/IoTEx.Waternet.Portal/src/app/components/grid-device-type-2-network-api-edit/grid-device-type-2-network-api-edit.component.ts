import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as DTO from '../../models/_index';
import * as COMMON from '../../common/index';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'

@Component({
  selector: 'app-grid-device-type-2-network-api-edit',
  templateUrl: './grid-device-type-2-network-api-edit.component.html',
  styleUrls: ['./grid-device-type-2-network-api-edit.component.css']
})
export class GridDeviceType2NetworkAPIEditComponent extends BaseComponent {
 
  protected _deviceType2NetworkAPI: DTO.DeviceType2NetworkAPIDTO;
  public deviceType2NetworkAPIData: any[];
  public active = false;
  public editForm: FormGroup = new FormGroup({
    id: new FormControl({ disabled: true }),
    networkAPIId: new FormControl({}, Validators.required)
  });
 
  @Input() public isNew = false;
 
  @Input() public set model(deviceType2NetworkAPI: DTO.DeviceType2NetworkAPIDTO) {
    this._deviceType2NetworkAPI = deviceType2NetworkAPI;
    this.editForm.reset(deviceType2NetworkAPI);
    this.active = deviceType2NetworkAPI !== undefined;
  }
 
  @Output() cancel: EventEmitter<any> = new EventEmitter();
  @Output() save: EventEmitter<DTO.DeviceType2NetworkAPIDTO> = new EventEmitter();
  constructor(private service: IoTExService) {
    super();
    this.deviceType2NetworkAPIData = DATA.nameData;
  }

  public ngOnInit(): void {
    this.fillcombo();
  }

  public fillcombo():void{
    this.service.networkAPIService.gets(null).subscribe((result)=>{
      this.deviceType2NetworkAPIData =result.value;
     })
  }

  public onSave(e): void {
    e.preventDefault();
 
    this._deviceType2NetworkAPI.networkAPIId = this.editForm.value.networkAPIId;

    this.save.emit(this._deviceType2NetworkAPI);
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

