import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceBatchComponent } from './grid-device-batch.component';

describe('GridDeviceBatchComponent', () => {
  let component: GridDeviceBatchComponent;
  let fixture: ComponentFixture<GridDeviceBatchComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceBatchComponent]
    });
    fixture = TestBed.createComponent(GridDeviceBatchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
