import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceProjectEditComponent } from './grid-device-project-edit.component';

describe('GridDeviceProjectEditComponent', () => {
  let component: GridDeviceProjectEditComponent;
  let fixture: ComponentFixture<GridDeviceProjectEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GridDeviceProjectEditComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GridDeviceProjectEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
