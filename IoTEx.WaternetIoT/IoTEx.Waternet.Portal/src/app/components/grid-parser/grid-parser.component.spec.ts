import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridParserComponent } from './grid-parser.component';

describe('GridParserComponent', () => {
  let component: GridParserComponent;
  let fixture: ComponentFixture<GridParserComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridParserComponent]
    });
    fixture = TestBed.createComponent(GridParserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
