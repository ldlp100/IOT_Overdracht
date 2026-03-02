import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as DTO from '../../models/_index';
import * as COMMON from '../../common/index';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'

@Component({
  selector: 'app-grid-app-configuration-edit',
  templateUrl: './grid-app-configuration-edit.component.html',
  styleUrls: ['./grid-app-configuration-edit.component.css']
})
export class GridAppConfigurationEditComponent extends BaseComponent {
 
  protected _appConfiguration: DTO.AppConfigurationDTO;
  private appConfigurationData: any[];
  public active = false;
  public editForm: FormGroup = new FormGroup({
    id: new FormControl({disabled: true }),
    name: new FormControl({}, Validators.required),
    description: new FormControl(),
    value: new FormControl(),
    isDeletable: new FormControl({}),
    isModifiable: new FormControl({})
  });
 
  @Input() public isNew = false;
 
  @Input() public set model(appConfiguration: DTO.AppConfigurationDTO) {
    this._appConfiguration = appConfiguration;
    this.editForm.reset(appConfiguration);
    this.active = appConfiguration !== undefined;
  }
 
  @Output() cancel: EventEmitter<any> = new EventEmitter();
  @Output() save: EventEmitter<DTO.AppConfigurationDTO> = new EventEmitter();
  constructor() {
    super();
    this.appConfigurationData = DATA.nameData;
  }

  
  public onSave(e): void {
    e.preventDefault();
 
    this._appConfiguration.name = this.editForm.value.name;
    this._appConfiguration.description = this.editForm.value.description;
    this._appConfiguration.value = this.editForm.value.value;
    this._appConfiguration.isDeletable = this.editForm.value.isDeletable;
    this._appConfiguration.isModifiable = this.editForm.value.isModifiable;
    this.save.emit(this._appConfiguration);
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
