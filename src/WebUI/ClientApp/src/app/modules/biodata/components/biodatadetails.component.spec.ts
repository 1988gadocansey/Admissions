import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BiodatadetailsComponent } from './biodatadetails.component';

describe('BiodatadetailsComponent', () => {
  let component: BiodatadetailsComponent;
  let fixture: ComponentFixture<BiodatadetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BiodatadetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BiodatadetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
