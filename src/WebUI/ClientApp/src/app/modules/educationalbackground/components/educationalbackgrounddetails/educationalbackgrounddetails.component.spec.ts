import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EducationalbackgrounddetailsComponent } from './educationalbackgrounddetails.component';

describe('EducationalbackgrounddetailsComponent', () => {
  let component: EducationalbackgrounddetailsComponent;
  let fixture: ComponentFixture<EducationalbackgrounddetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EducationalbackgrounddetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EducationalbackgrounddetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
