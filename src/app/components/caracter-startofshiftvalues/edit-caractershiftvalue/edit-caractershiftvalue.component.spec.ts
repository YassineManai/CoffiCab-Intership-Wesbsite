import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCaractershiftvalueComponent } from './edit-caractershiftvalue.component';

describe('EditCaractershiftvalueComponent', () => {
  let component: EditCaractershiftvalueComponent;
  let fixture: ComponentFixture<EditCaractershiftvalueComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditCaractershiftvalueComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EditCaractershiftvalueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
