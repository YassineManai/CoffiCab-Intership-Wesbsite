
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EditProfileUserComponent } from './edit-profile-user/edit-profile-user.component';
import { ProfileUser } from '../../models/profileuser';
import { ProfileUserService } from '../../services/profiluser-service';

@Component({
  selector: 'app-profil-users',
  standalone: true,
  imports: [CommonModule,EditProfileUserComponent],
  templateUrl: './profil-users.component.html',
  styleUrl: './profil-users.component.css'
})
export class ProfilUsersComponent implements OnInit {
  profileusers: ProfileUser[] = [];
  profilusertoEdit: ProfileUser | null = null;

  constructor(private profileuserService: ProfileUserService) { }


  ngOnInit(): void {
    this.fetchProcfiluser();
  }

  fetchProcfiluser(): void {
    this.profileuserService.getProfileUsers().subscribe((result: ProfileUser[]) => (this.profileusers = result));
  }

  updateProcfiluserList(profileusers: ProfileUser[]): void {
    this.profileusers = profileusers;
  }


  initNewProcfiluser(): void {
    this.profilusertoEdit = new ProfileUser();
    console.log(this.profilusertoEdit)
  }
  editProcfiluser(profileuser: ProfileUser) {
    this.profilusertoEdit = profileuser;
  }
  handleProfilesUpdated(): void {
    this.fetchProcfiluser();
    this.profilusertoEdit = null; // Hide the edit component after create/update/delete
  }


}
