import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridAppUserEditComponent } from './grid-app-user-edit.component';

describe('GridAppUserEditComponent', () => {
  let component: GridAppUserEditComponent;
  let fixture: ComponentFixture<GridAppUserEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridAppUserEditComponent]
    });
    fixture = TestBed.createComponent(GridAppUserEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
