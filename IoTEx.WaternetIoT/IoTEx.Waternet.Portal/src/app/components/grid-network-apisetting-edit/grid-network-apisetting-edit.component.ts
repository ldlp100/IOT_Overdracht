import { Component, OnInit, Input, Output, ViewChild, EventEmitter, AfterViewInit, ChangeDetectorRef } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as DTO from '../../models/_index';
import * as COMMON from '../../common/index';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'
import { TextBoxComponent } from '@progress/kendo-angular-inputs';

@Component({
  selector: 'app-grid-network-apisetting-edit',
  templateUrl: './grid-network-apisetting-edit.component.html',
  styleUrls: ['./grid-network-apisetting-edit.component.css']
})
export class GridNetworkAPISettingEditComponent  extends BaseComponent {
  @ViewChild("value_ctrl", {static: false}) public textbox?;
  
  protected _networkAPISetting: DTO.NetworkAPISettingDTO;
  private networkAPISettingData: any[];
  public active = false;
  public editForm: FormGroup = new FormGroup({
    id: new FormControl({ disabled: true }),
    name: new FormControl({}, Validators.required),
    description: new FormControl(),
    value: new FormControl({}, Validators.required),
    isSecret: new FormControl(),
    isDeviceInfo: new FormControl()
  });
 
  @Input() public isNew = false;
 
  @Input() public set model(networkAPISetting: DTO.NetworkAPISettingDTO) {
    this._networkAPISetting = networkAPISetting;
    this.editForm.reset(networkAPISetting);
    this.active = networkAPISetting !== undefined;
    if (networkAPISetting!=undefined)
    {
      this.changeDetector.detectChanges();
      
      if (this._networkAPISetting.isSecret)
        this.textbox.input.nativeElement.type = "password";
      else
        this.textbox.input.nativeElement.type = "text";
    }
  }
  
  @Output() cancel: EventEmitter<any> = new EventEmitter();
  @Output() save: EventEmitter<DTO.NetworkAPISettingDTO> = new EventEmitter();
  constructor(private changeDetector: ChangeDetectorRef) {
    super();
    this.networkAPISettingData = DATA.nameData;
  }
  public ngOnInit(): void {
    
    
  }
  public onSave(e): void {
    e.preventDefault();
 
    this._networkAPISetting.name = this.editForm.value.name;
    this._networkAPISetting.description = this.editForm.value.description;
    this._networkAPISetting.value = this.editForm.value.value;
    this._networkAPISetting.isSecret = this.editForm.value.isSecret;
    this._networkAPISetting.isDeviceInfo = this.editForm.value.isDeviceInfo;

    this.save.emit(this._networkAPISetting);
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

