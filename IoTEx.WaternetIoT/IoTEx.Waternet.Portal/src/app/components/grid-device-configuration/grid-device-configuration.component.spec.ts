import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceConfigurationComponent } from './grid-device-configuration.component';

describe('GridDeviceConfigurationComponent', () => {
  let component: GridDeviceConfigurationComponent;
  let fixture: ComponentFixture<GridDeviceConfigurationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceConfigurationComponent]
    });
    fixture = TestBed.createComponent(GridDeviceConfigurationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
