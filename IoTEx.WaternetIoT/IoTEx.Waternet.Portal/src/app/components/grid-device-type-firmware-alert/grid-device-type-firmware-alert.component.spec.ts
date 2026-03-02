import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceTypeFirmwareAlertComponent } from './grid-device-type-firmware-alert.component';

describe('GridDeviceTypeFirmwareAlertComponent', () => {
  let component: GridDeviceTypeFirmwareAlertComponent;
  let fixture: ComponentFixture<GridDeviceTypeFirmwareAlertComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceTypeFirmwareAlertComponent]
    });
    fixture = TestBed.createComponent(GridDeviceTypeFirmwareAlertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
