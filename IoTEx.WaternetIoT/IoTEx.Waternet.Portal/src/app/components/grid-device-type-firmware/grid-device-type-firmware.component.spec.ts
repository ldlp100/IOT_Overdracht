import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceTypeFirmwareComponent } from './grid-device-type-firmware.component';

describe('GridDeviceTypeFirmwareComponent', () => {
  let component: GridDeviceTypeFirmwareComponent;
  let fixture: ComponentFixture<GridDeviceTypeFirmwareComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceTypeFirmwareComponent]
    });
    fixture = TestBed.createComponent(GridDeviceTypeFirmwareComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
