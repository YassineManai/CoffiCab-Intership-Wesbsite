import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditProgprofilComponent } from './edit-progprofil.component';

describe('EditProgprofilComponent', () => {
  let component: EditProgprofilComponent;
  let fixture: ComponentFixture<EditProgprofilComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditProgprofilComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EditProgprofilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
