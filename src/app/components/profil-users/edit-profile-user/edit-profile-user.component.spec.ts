import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditProfileUserComponent } from './edit-profile-user.component';

describe('EditProfileUserComponent', () => {
  let component: EditProfileUserComponent;
  let fixture: ComponentFixture<EditProfileUserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditProfileUserComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EditProfileUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
