import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SteponeComponent } from './stepone.component';

describe('SteponeComponent', () => {
  let component: SteponeComponent;
  let fixture: ComponentFixture<SteponeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SteponeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SteponeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
