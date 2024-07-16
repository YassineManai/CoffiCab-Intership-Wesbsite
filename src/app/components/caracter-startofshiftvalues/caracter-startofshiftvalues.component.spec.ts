import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CaracterStartofshiftvaluesComponent } from './caracter-startofshiftvalues.component';

describe('CaracterStartofshiftvaluesComponent', () => {
  let component: CaracterStartofshiftvaluesComponent;
  let fixture: ComponentFixture<CaracterStartofshiftvaluesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CaracterStartofshiftvaluesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CaracterStartofshiftvaluesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
