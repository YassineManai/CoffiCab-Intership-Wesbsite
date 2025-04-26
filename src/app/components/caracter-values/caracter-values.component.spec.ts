import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CaracterValuesComponent } from './caracter-values.component';

describe('CaracterValuesComponent', () => {
  let component: CaracterValuesComponent;
  let fixture: ComponentFixture<CaracterValuesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CaracterValuesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CaracterValuesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
