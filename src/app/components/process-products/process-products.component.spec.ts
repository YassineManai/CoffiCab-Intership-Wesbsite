import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProcessProductsComponent } from './process-products.component';

describe('ProcessProductsComponent', () => {
  let component: ProcessProductsComponent;
  let fixture: ComponentFixture<ProcessProductsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProcessProductsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProcessProductsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
