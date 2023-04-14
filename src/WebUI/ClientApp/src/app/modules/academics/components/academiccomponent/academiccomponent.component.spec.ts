import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AcademiccomponentComponent } from './academiccomponent.component';

describe('AcademiccomponentComponent', () => {
  let component: AcademiccomponentComponent;
  let fixture: ComponentFixture<AcademiccomponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AcademiccomponentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AcademiccomponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
