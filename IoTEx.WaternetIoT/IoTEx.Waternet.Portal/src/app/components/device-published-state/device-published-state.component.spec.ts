import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DevicePublishedStateComponent } from './device-published-state.component';

describe('DevicePublishedStateComponent', () => {
  let component: DevicePublishedStateComponent;
  let fixture: ComponentFixture<DevicePublishedStateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DevicePublishedStateComponent]
    });
    fixture = TestBed.createComponent(DevicePublishedStateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
