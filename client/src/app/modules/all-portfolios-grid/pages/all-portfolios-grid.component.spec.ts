import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AllPortfoliosGridComponent } from './all-portfolios-grid.component';

describe('AllPortfoliosGridComponent', () => {
  let component: AllPortfoliosGridComponent;
  let fixture: ComponentFixture<AllPortfoliosGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AllPortfoliosGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AllPortfoliosGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
