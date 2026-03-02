import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridProjectEditComponent } from './grid-project-edit.component';

describe('GridProjectEditComponent', () => {
  let component: GridProjectEditComponent;
  let fixture: ComponentFixture<GridProjectEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridProjectEditComponent]
    });
    fixture = TestBed.createComponent(GridProjectEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
