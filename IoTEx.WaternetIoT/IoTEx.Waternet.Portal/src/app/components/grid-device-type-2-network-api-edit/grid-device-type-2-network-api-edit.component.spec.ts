import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceType2NetworkAPIEditComponent } from './grid-device-type-2-network-api-edit.component';

describe('GridDeviceType2NetworkAPIEditComponent', () => {
  let component: GridDeviceType2NetworkAPIEditComponent;
  let fixture: ComponentFixture<GridDeviceType2NetworkAPIEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceType2NetworkAPIEditComponent]
    });
    fixture = TestBed.createComponent(GridDeviceType2NetworkAPIEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
