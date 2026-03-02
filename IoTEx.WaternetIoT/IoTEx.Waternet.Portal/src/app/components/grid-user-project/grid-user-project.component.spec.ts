import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridUserProjectComponent } from './grid-user-project.component';

describe('GridUserProjectComponent', () => {
  let component: GridUserProjectComponent;
  let fixture: ComponentFixture<GridUserProjectComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridUserProjectComponent]
    });
    fixture = TestBed.createComponent(GridUserProjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
