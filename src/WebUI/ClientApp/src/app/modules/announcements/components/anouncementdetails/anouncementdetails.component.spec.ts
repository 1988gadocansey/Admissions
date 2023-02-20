import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnouncementdetailsComponent } from './anouncementdetails.component';

describe('AnouncementdetailsComponent', () => {
  let component: AnouncementdetailsComponent;
  let fixture: ComponentFixture<AnouncementdetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AnouncementdetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AnouncementdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
