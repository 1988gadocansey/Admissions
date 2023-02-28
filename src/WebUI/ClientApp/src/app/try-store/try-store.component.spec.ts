import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TryStoreComponent } from './try-store.component';

describe('TryStoreComponent', () => {
  let component: TryStoreComponent;
  let fixture: ComponentFixture<TryStoreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TryStoreComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TryStoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
