import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceCalibrationComponent } from './grid-device-calibration.component';

describe('GridDeviceCalibrationComponent', () => {
  let component: GridDeviceCalibrationComponent;
  let fixture: ComponentFixture<GridDeviceCalibrationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceCalibrationComponent]
    });
    fixture = TestBed.createComponent(GridDeviceCalibrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
