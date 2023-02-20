import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PassportpicComponent } from './passportpic.component';

describe('PassportpicComponent', () => {
  let component: PassportpicComponent;
  let fixture: ComponentFixture<PassportpicComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PassportpicComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PassportpicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
