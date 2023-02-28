import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChangeformComponent } from './changeform.component';

describe('ChangeformComponent', () => {
  let component: ChangeformComponent;
  let fixture: ComponentFixture<ChangeformComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChangeformComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChangeformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
