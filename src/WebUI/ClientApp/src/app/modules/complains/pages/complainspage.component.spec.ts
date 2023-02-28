import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComplainspageComponent } from './complainspage.component';

describe('ComplainspageComponent', () => {
  let component: ComplainspageComponent;
  let fixture: ComponentFixture<ComplainspageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ComplainspageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ComplainspageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
