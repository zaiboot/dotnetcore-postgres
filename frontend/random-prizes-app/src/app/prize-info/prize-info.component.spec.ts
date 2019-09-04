import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrizeInfoComponent } from './prize-info.component';

describe('PrizeInfoComponent', () => {
  let component: PrizeInfoComponent;
  let fixture: ComponentFixture<PrizeInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrizeInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrizeInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
