import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridProjectUserComponent } from './grid-project-user.component';

describe('GridProjectUserComponent', () => {
  let component: GridProjectUserComponent;
  let fixture: ComponentFixture<GridProjectUserComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridProjectUserComponent]
    });
    fixture = TestBed.createComponent(GridProjectUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
