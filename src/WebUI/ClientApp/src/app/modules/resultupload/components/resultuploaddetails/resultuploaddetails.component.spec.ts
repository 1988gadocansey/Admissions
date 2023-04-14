import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResultuploaddetailsComponent } from './resultuploaddetails.component';

describe('ResultuploaddetailsComponent', () => {
  let component: ResultuploaddetailsComponent;
  let fixture: ComponentFixture<ResultuploaddetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResultuploaddetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ResultuploaddetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
