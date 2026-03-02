import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridParserEditComponent } from './grid-parser-edit.component';

describe('GridParserEditComponent', () => {
  let component: GridParserEditComponent;
  let fixture: ComponentFixture<GridParserEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridParserEditComponent]
    });
    fixture = TestBed.createComponent(GridParserEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
