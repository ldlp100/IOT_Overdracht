import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridTargetDBEditComponent } from './grid-target-db-edit.component';

describe('GridTargetDBEditComponent', () => {
  let component: GridTargetDBEditComponent;
  let fixture: ComponentFixture<GridTargetDBEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridTargetDBEditComponent]
    });
    fixture = TestBed.createComponent(GridTargetDBEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
