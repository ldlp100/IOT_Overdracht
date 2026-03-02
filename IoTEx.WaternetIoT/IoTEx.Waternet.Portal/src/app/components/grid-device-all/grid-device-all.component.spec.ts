import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceAllComponent } from './grid-device-all.component';

describe('GridDeviceAllComponent', () => {
  let component: GridDeviceAllComponent;
  let fixture: ComponentFixture<GridDeviceAllComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceAllComponent]
    });
    fixture = TestBed.createComponent(GridDeviceAllComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
