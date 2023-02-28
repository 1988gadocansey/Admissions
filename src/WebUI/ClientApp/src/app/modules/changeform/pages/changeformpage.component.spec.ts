import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChangeformpageComponent } from './changeformpage.component';

describe('ChangeformpageComponent', () => {
  let component: ChangeformpageComponent;
  let fixture: ComponentFixture<ChangeformpageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChangeformpageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChangeformpageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
