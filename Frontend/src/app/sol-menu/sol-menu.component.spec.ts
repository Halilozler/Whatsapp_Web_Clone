import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SolMenuComponent } from './sol-menu.component';

describe('SolMenuComponent', () => {
  let component: SolMenuComponent;
  let fixture: ComponentFixture<SolMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SolMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SolMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
