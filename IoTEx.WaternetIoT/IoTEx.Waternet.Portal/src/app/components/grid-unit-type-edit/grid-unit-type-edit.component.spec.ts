import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridUnitTypeEditComponent } from './grid-unit-type-edit.component';

describe('GridUnitTypeEditComponent', () => {
  let component: GridUnitTypeEditComponent;
  let fixture: ComponentFixture<GridUnitTypeEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridUnitTypeEditComponent]
    });
    fixture = TestBed.createComponent(GridUnitTypeEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
