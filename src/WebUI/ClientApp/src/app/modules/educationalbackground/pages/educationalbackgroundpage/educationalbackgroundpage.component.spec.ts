import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EducationalbackgroundpageComponent } from './educationalbackgroundpage.component';

describe('EducationalbackgroundpageComponent', () => {
  let component: EducationalbackgroundpageComponent;
  let fixture: ComponentFixture<EducationalbackgroundpageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EducationalbackgroundpageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EducationalbackgroundpageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
