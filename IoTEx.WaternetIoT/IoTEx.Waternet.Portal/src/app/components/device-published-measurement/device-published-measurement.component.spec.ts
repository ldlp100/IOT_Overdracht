import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DevicePublishedMeasurementComponent } from './device-published-measurement.component';

describe('DevicePublishedMeasurementComponent', () => {
  let component: DevicePublishedMeasurementComponent;
  let fixture: ComponentFixture<DevicePublishedMeasurementComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DevicePublishedMeasurementComponent]
    });
    fixture = TestBed.createComponent(DevicePublishedMeasurementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
