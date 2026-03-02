import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as DTO from '../../models/_index';
import * as COMMON from '../../common/index';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'

@Component({
  selector: 'app-grid-network-api-edit',
  templateUrl: './grid-network-api-edit.component.html',
  styleUrls: ['./grid-network-api-edit.component.css']
})
export class GridNetworkAPIEditComponent extends BaseComponent {
 
  protected _networkAPI: DTO.NetworkAPIDTO;
  private networkAPIData: any[];
  public active = false;
  public editForm: FormGroup = new FormGroup({
    id: new FormControl({ disabled: true }),
    name: new FormControl({}, Validators.required),
    description: new FormControl(),
    isLORA: new FormControl(),
    isSigFox: new FormControl(),
    isLTM: new FormControl(),
    isNBIoT: new FormControl()
  });
 
  @Input() public isNew = false;
 
  @Input() public set model(networkAPI: DTO.NetworkAPIDTO) {
    this._networkAPI = networkAPI;
    this.editForm.reset(this._networkAPI);
    this.active = networkAPI !== undefined;
  }
 
  @Output() cancel: EventEmitter<any> = new EventEmitter();
  @Output() save: EventEmitter<DTO.NetworkAPIDTO> = new EventEmitter();
  constructor() {
    super();
    this.networkAPIData = DATA.nameData;
  }

  
  public onSave(e): void {
    e.preventDefault();
 
    this._networkAPI.name = this.editForm.value.name;
    this._networkAPI.description = this.editForm.value.description;
    this._networkAPI.isLORA = this.editForm.value.isLORA;
    this._networkAPI.isSigFox = this.editForm.value.isSigFox;
    this._networkAPI.isLTM = this.editForm.value.isLTM;
    this._networkAPI.isNBIoT = this.editForm.value.isNBIoT;
    
    this.save.emit(this._networkAPI);
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
