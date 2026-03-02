import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeviceProjectComponent } from './device-project.component';

describe('DeviceProjectComponent', () => {
  let component: DeviceProjectComponent;
  let fixture: ComponentFixture<DeviceProjectComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeviceProjectComponent]
    });
    fixture = TestBed.createComponent(DeviceProjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
