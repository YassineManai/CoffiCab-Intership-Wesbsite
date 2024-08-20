import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCaracterComponent } from './edit-caracter.component';

describe('EditCaracterComponent', () => {
  let component: EditCaracterComponent;
  let fixture: ComponentFixture<EditCaracterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditCaracterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EditCaracterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
