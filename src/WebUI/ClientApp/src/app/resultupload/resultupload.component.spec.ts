import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResultuploadComponent } from './resultupload.component';

describe('ResultuploadComponent', () => {
  let component: ResultuploadComponent;
  let fixture: ComponentFixture<ResultuploadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResultuploadComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ResultuploadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
