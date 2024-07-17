import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProgProfilesComponent } from './prog-profiles.component';

describe('ProgProfilesComponent', () => {
  let component: ProgProfilesComponent;
  let fixture: ComponentFixture<ProgProfilesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProgProfilesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProgProfilesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
