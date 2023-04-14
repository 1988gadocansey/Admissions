import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResultuploadpageComponent } from './resultuploadpage.component';

describe('ResultuploadpageComponent', () => {
  let component: ResultuploadpageComponent;
  let fixture: ComponentFixture<ResultuploadpageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResultuploadpageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ResultuploadpageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
