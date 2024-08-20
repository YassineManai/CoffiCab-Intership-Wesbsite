import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCaractervaluesComponent } from './edit-caractervalues.component';

describe('EdiCaractervaluesComponent', () => {
  let component: EditCaractervaluesComponent;
  let fixture: ComponentFixture<EditCaractervaluesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditCaractervaluesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EditCaractervaluesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
