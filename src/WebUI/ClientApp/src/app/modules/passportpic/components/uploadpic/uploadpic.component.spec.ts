import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UploadpicComponent } from './uploadpic.component';

describe('UploadpicComponent', () => {
  let component: UploadpicComponent;
  let fixture: ComponentFixture<UploadpicComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UploadpicComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UploadpicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
