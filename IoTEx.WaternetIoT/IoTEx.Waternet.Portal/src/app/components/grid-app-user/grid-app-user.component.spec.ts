import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridAppUserComponent } from './grid-app-user.component';

describe('GridAppUserComponent', () => {
  let component: GridAppUserComponent;
  let fixture: ComponentFixture<GridAppUserComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridAppUserComponent]
    });
    fixture = TestBed.createComponent(GridAppUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
