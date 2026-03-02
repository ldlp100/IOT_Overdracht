import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceBatchEditComponent } from './grid-device-batch-edit.component';

describe('GridDeviceBatchEditComponent', () => {
  let component: GridDeviceBatchEditComponent;
  let fixture: ComponentFixture<GridDeviceBatchEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceBatchEditComponent]
    });
    fixture = TestBed.createComponent(GridDeviceBatchEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
