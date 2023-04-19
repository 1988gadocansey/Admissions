import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EducationalbackgroundComponent } from './educationalbackground.component';

describe('EducationalbackgroundComponent', () => {
  let component: EducationalbackgroundComponent;
  let fixture: ComponentFixture<EducationalbackgroundComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EducationalbackgroundComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EducationalbackgroundComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
