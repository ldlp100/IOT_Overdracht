import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceEditComponent } from './grid-device-edit.component';

describe('GridDeviceEditComponent', () => {
  let component: GridDeviceEditComponent;
  let fixture: ComponentFixture<GridDeviceEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceEditComponent]
    });
    fixture = TestBed.createComponent(GridDeviceEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
