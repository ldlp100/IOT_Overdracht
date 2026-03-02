import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceTypeFirmwareAlertEditComponent } from './grid-device-type-firmware-alert-edit.component';

describe('GridDeviceTypeFirmwareAlertEditComponent', () => {
  let component: GridDeviceTypeFirmwareAlertEditComponent;
  let fixture: ComponentFixture<GridDeviceTypeFirmwareAlertEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceTypeFirmwareAlertEditComponent]
    });
    fixture = TestBed.createComponent(GridDeviceTypeFirmwareAlertEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
