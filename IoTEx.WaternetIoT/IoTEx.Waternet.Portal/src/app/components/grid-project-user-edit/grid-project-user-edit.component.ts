import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as DTO from '../../models/_index';
import * as COMMON from '../../common/index';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'

@Component({
  selector: 'app-grid-project-user-edit',
  templateUrl: './grid-project-user-edit.component.html',
  styleUrls: ['./grid-project-user-edit.component.css']
})
export class GridProjectUserEditComponent extends BaseComponent {

  protected _user2project: DTO.User2ProjectDTO;
  public userRoleData: any[];
  public userData: any[];
  public userDataFilter: any[];
  public active = false;
  public editForm: FormGroup = new FormGroup({
    id: new FormControl({ disabled: true }),
    userId: new FormControl({}, Validators.required),
    role: new FormControl({}, Validators.required)
  });

  @Input() public isNew = false;

  @Input() public set model(user2project: DTO.User2ProjectDTO) {
    this._user2project = user2project;
    this.userRoleData = DATA.AppUserRole;
    this.editForm.reset(user2project);
    this.active = user2project !== undefined;
  }

  @Output() cancel: EventEmitter<any> = new EventEmitter();
  @Output() save: EventEmitter<DTO.User2ProjectDTO> = new EventEmitter();
  constructor(private service: IoTExService) {
    super();
    this.userRoleData = DATA.AppUserRole;
  }

  public ngOnInit(): void {
    this.fillcombo();
  }

  public fillcombo(): void {
    this.service.appUserService.gets(null).subscribe((result) => {
      this.userData = result.value;
      this.userDataFilter = result.value;
    })
  }
  public onFilterChange(filter: string): void {
    
    this.userDataFilter = this.userData.filter(item =>
      item.username.toLowerCase().includes(filter.toLowerCase())
    );
  }
  public onSave(e): void {
    e.preventDefault();

    this._user2project.userId = this.editForm.value.userId;
    this._user2project.role = this.editForm.value.role;

    this.save.emit(this._user2project);
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

