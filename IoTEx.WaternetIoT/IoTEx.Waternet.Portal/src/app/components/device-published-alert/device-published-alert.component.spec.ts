import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DevicePublishedAlertComponent } from './device-published-alert.component';

describe('DevicePublishedAlertComponent', () => {
  let component: DevicePublishedAlertComponent;
  let fixture: ComponentFixture<DevicePublishedAlertComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DevicePublishedAlertComponent]
    });
    fixture = TestBed.createComponent(DevicePublishedAlertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
