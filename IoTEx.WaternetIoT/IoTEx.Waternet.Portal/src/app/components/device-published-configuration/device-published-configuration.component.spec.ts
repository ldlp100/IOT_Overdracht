import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DevicePublishedConfigurationComponent } from './device-published-configuration.component';

describe('DevicePublishedConfigurationComponent', () => {
  let component: DevicePublishedConfigurationComponent;
  let fixture: ComponentFixture<DevicePublishedConfigurationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DevicePublishedConfigurationComponent]
    });
    fixture = TestBed.createComponent(DevicePublishedConfigurationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
