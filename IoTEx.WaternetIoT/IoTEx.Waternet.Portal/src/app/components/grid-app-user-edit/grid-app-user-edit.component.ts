import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as DTO from '../../models/_index';
import * as COMMON from '../../common/index';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'

@Component({
  selector: 'app-grid-app-user-edit',
  templateUrl: './grid-app-user-edit.component.html',
  styleUrls: ['./grid-app-user-edit.component.css']
})
export class GridAppUserEditComponent  extends BaseComponent {
 
  protected _appUser: DTO.AppUserDTO;
  public appUserData: any[];
  public active = false;
  public editForm: FormGroup = new FormGroup({
    id: new FormControl({ disabled: true }),
    username: new FormControl({}, Validators.required),
    role: new FormControl({}, Validators.required)
  });
 
  @Input() public isNew = false;
 
  @Input() public set model(appUser: DTO.AppUserDTO) {
    this._appUser = appUser;
    this.appUserData = DATA.AppUserRole;
    this.editForm.reset(appUser);
    this.active = appUser !== undefined;
  }
 
  @Output() cancel: EventEmitter<any> = new EventEmitter();
  @Output() save: EventEmitter<DTO.AppUserDTO> = new EventEmitter();
  constructor(private service: IoTExService) {
    super();
    this.appUserData = DATA.nameData;
  }

  public onSave(e): void {
    e.preventDefault();
 
    this._appUser.username = this.editForm.value.username;
    this._appUser.role = this.editForm.value.role;

    this.save.emit(this._appUser);
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

