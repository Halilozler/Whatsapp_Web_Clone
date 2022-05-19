import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SagMenuComponent } from './sag-menu.component';

describe('SagMenuComponent', () => {
  let component: SagMenuComponent;
  let fixture: ComponentFixture<SagMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SagMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SagMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
