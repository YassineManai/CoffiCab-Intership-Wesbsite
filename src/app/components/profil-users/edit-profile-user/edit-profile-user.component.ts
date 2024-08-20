import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Process } from '../../../models/process';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ProcessService } from '../../../services/process.service';
import { ProfileUser } from '../../../models/profileuser';
import { ProfileUserService } from '../../../services/profiluser-service';
@Component({
  selector: 'app-edit-profile-user',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule
  ],
  templateUrl: './edit-profile-user.component.html',
  styleUrl: './edit-profile-user.component.css'
})
export class EditProfileUserComponent implements OnInit  {
  @Input() profileUser: ProfileUser | null = null;
  @Output() profileUpdate = new EventEmitter<void>();

  profilusers:ProfileUser[]=[] ;
  constructor(private profileuserservice: ProfileUserService) {}
  ngOnInit(): void {
    this.fetchProfileUser();
  }
  fetchProfileUser(): void {
    this.profileuserservice.getProfileUsers().subscribe((result: ProfileUser[]) => {
      this.profilusers = result;
    });
  }
  updateProfileUser(profileuser: ProfileUser): void {
    this.profileuserservice.updateProfileUser(profileuser)
      .subscribe(() => this.profileUpdate.emit());
  }

  deleteProfile(idprofile: string): void {
    this.profileuserservice.deleteProfileUser(idprofile)
      .subscribe(() => this.profileUpdate.emit());
  }

  createProfile(profile: ProfileUser): void {
    if (this.isDuplicateProfile(profile)) {
      alert('A process with the same CodeProcess already exists.');
    } else if (this.isValidProcess(profile)) {
      this.profileuserservice.createProfileUser(profile).subscribe(() => this.profileUpdate.emit());
    } else {
      alert('Please fill in all the required fields.');
    }
  }

  isDuplicateProfile(profile: ProfileUser): boolean {
    const newidprofile = profile.id_Profil?.toUpperCase();
    return this.profilusers.some(existingProfile => existingProfile.id_Profil?.toUpperCase() === newidprofile);
  }
  

  isValidProcess(profilUser: ProfileUser): boolean {
    const requiredFields = [
   profilUser.id_Profil,
   profilUser.nomProfil
    ];

    return requiredFields.every(field => field !== undefined && field !== null && field !== '');
  }



}
