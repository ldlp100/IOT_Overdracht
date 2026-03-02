import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridProjectUserEditComponent } from './grid-project-user-edit.component';

describe('GridProjectUserEditComponent', () => {
  let component: GridProjectUserEditComponent;
  let fixture: ComponentFixture<GridProjectUserEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridProjectUserEditComponent]
    });
    fixture = TestBed.createComponent(GridProjectUserEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
