import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfilUsersComponent } from './profil-users.component';

describe('ProfilUsersComponent', () => {
  let component: ProfilUsersComponent;
  let fixture: ComponentFixture<ProfilUsersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProfilUsersComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProfilUsersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
