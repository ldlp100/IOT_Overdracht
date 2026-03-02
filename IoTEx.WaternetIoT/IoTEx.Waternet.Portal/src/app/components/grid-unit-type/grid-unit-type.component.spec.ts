import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridUnitTypeComponent } from './grid-unit-type.component';

describe('GridUnitTypeComponent', () => {
  let component: GridUnitTypeComponent;
  let fixture: ComponentFixture<GridUnitTypeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridUnitTypeComponent]
    });
    fixture = TestBed.createComponent(GridUnitTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
