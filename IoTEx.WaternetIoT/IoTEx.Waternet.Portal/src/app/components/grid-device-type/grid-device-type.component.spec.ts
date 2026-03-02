import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceTypeComponent } from './grid-device-type.component';

describe('GridDeviceTypeComponent', () => {
  let component: GridDeviceTypeComponent;
  let fixture: ComponentFixture<GridDeviceTypeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceTypeComponent]
    });
    fixture = TestBed.createComponent(GridDeviceTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
