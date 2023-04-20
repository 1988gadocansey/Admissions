import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UniversityattendedComponent } from './universityattended.component';

describe('UniversityattendedComponent', () => {
  let component: UniversityattendedComponent;
  let fixture: ComponentFixture<UniversityattendedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UniversityattendedComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UniversityattendedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
