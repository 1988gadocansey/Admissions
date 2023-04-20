import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UniversityattendedpageComponent } from './universityattendedpage.component';

describe('UniversityattendedpageComponent', () => {
  let component: UniversityattendedpageComponent;
  let fixture: ComponentFixture<UniversityattendedpageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UniversityattendedpageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UniversityattendedpageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
