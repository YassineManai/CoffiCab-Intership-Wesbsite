import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProgProfilComponent } from './prog-profil.component';

describe('ProgProfilComponent', () => {
  let component: ProgProfilComponent;
  let fixture: ComponentFixture<ProgProfilComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProgProfilComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProgProfilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
