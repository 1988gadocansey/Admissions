import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintviewComponent } from './printview.component';

describe('PrintviewComponent', () => {
  let component: PrintviewComponent;
  let fixture: ComponentFixture<PrintviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintviewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
