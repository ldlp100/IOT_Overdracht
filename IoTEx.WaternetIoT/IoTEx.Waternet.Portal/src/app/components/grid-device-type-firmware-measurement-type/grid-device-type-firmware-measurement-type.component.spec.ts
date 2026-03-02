import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceTypeFirmwareMeasurementTypeComponent } from './grid-device-type-firmware-measurement-type.component';

describe('GridDeviceTypeFirmwareMeasurementTypeComponent', () => {
  let component: GridDeviceTypeFirmwareMeasurementTypeComponent;
  let fixture: ComponentFixture<GridDeviceTypeFirmwareMeasurementTypeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceTypeFirmwareMeasurementTypeComponent]
    });
    fixture = TestBed.createComponent(GridDeviceTypeFirmwareMeasurementTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
