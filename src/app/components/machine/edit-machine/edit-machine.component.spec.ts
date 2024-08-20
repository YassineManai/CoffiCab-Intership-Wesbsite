import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditMachineComponent } from './edit-machine.component';

describe('EditMachineComponent', () => {
  let component: EditMachineComponent;
  let fixture: ComponentFixture<EditMachineComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditMachineComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EditMachineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
