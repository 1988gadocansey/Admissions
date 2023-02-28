import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChangeformdetailsComponent } from './changeformdetails.component';

describe('ChangeformdetailsComponent', () => {
  let component: ChangeformdetailsComponent;
  let fixture: ComponentFixture<ChangeformdetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChangeformdetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChangeformdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
