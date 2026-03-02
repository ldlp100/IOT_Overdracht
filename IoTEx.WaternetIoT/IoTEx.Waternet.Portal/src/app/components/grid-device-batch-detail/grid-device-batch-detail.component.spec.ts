import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceBatchDetailComponent } from './grid-device-batch-detail.component';

describe('GridDeviceBatchDetailComponent', () => {
  let component: GridDeviceBatchDetailComponent;
  let fixture: ComponentFixture<GridDeviceBatchDetailComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceBatchDetailComponent]
    });
    fixture = TestBed.createComponent(GridDeviceBatchDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
