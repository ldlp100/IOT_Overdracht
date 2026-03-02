import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceDetailComponent } from './grid-device-detail.component';

describe('GridDeviceDetailComponent', () => {
  let component: GridDeviceDetailComponent;
  let fixture: ComponentFixture<GridDeviceDetailComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceDetailComponent]
    });
    fixture = TestBed.createComponent(GridDeviceDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
