import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DevicePublishedBasicComponent } from './device-published-basic.component';

describe('DevicePublishedBasicComponent', () => {
  let component: DevicePublishedBasicComponent;
  let fixture: ComponentFixture<DevicePublishedBasicComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DevicePublishedBasicComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DevicePublishedBasicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
