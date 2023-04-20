import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UniversityattendeddetailsComponent } from './universityattendeddetails.component';

describe('UniversityattendeddetailsComponent', () => {
  let component: UniversityattendeddetailsComponent;
  let fixture: ComponentFixture<UniversityattendeddetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UniversityattendeddetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UniversityattendeddetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
