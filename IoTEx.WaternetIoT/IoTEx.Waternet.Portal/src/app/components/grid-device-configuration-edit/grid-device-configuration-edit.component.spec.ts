import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceConfigurationEditComponent } from './grid-device-configuration-edit.component';

describe('GridDeviceConfigurationEditComponent', () => {
  let component: GridDeviceConfigurationEditComponent;
  let fixture: ComponentFixture<GridDeviceConfigurationEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceConfigurationEditComponent]
    });
    fixture = TestBed.createComponent(GridDeviceConfigurationEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
