import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BiodatapageComponent } from './biodatapage.component';

describe('BiodatapageComponent', () => {
  let component: BiodatapageComponent;
  let fixture: ComponentFixture<BiodatapageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BiodatapageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BiodatapageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
