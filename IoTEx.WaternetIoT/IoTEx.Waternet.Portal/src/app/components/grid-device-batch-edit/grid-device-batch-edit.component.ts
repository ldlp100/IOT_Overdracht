import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as DTO from '../../models/_index';
import * as COMMON from '../../common/index';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'

@Component({
  selector: 'app-grid-device-batch-edit',
  templateUrl: './grid-device-batch-edit.component.html',
  styleUrls: ['./grid-device-batch-edit.component.css']
})
export class GridDeviceBatchEditComponent extends BaseComponent {
 
  protected _deviceBatch: DTO.DeviceBatchDTO;
  private deviceBatchData: any[];
  public active = false;
  public editForm: FormGroup = new FormGroup({
    id: new FormControl({ disabled: true }),
    name: new FormControl({}, Validators.required)
  });
 
  @Input() public isNew = false;
 
  @Input() public set model(deviceBatch: DTO.DeviceBatchDTO) {
    this._deviceBatch = deviceBatch;
    this.editForm.reset(deviceBatch);
    this.active = deviceBatch !== undefined;
  }
 
  @Output() cancel: EventEmitter<any> = new EventEmitter();
  @Output() save: EventEmitter<DTO.DeviceBatchDTO> = new EventEmitter();
  constructor(private service: IoTExService) {
    super();
    this.deviceBatchData = DATA.nameData;
  }

  public onSave(e): void {
    e.preventDefault();
 
    this._deviceBatch.name = this.editForm.value.name;

    this.save.emit(this._deviceBatch);
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

