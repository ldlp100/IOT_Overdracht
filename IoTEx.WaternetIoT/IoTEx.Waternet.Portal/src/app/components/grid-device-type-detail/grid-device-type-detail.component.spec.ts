import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceTypeDetailComponent } from './grid-device-type-detail.component';

describe('GridDeviceTypeDetailComponent', () => {
  let component: GridDeviceTypeDetailComponent;
  let fixture: ComponentFixture<GridDeviceTypeDetailComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceTypeDetailComponent]
    });
    fixture = TestBed.createComponent(GridDeviceTypeDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
