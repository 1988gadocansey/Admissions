import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComplainsdetailsComponent } from './complainsdetails.component';

describe('ComplainsdetailsComponent', () => {
  let component: ComplainsdetailsComponent;
  let fixture: ComponentFixture<ComplainsdetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ComplainsdetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ComplainsdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
