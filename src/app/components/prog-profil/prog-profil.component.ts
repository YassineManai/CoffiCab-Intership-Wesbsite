import { Component, OnInit } from '@angular/core';
import { ProgProfil } from '../../models/prog-profil';
import { ProgprofilService } from '../../services/progprofil.service';
import { CommonModule } from '@angular/common';
import { EditProgprofilComponent } from './edit-progprofil/edit-progprofil.component';
import { Router } from '@angular/router'; // Import Router

@Component({
  selector: 'app-prog-profil',
  standalone: true,
  imports: [CommonModule, EditProgprofilComponent],
  templateUrl: './prog-profil.component.html',
  styleUrls: ['./prog-profil.component.css']
})
export class ProgProfilComponent implements OnInit {
  pr: ProgProfil[] = [];
  progProfilToEdit: ProgProfil | null = null;

  constructor(private prService: ProgprofilService, private router: Router) { }

  ngOnInit(): void {
    this.fetchProgProfils();
  }

  fetchProgProfils(): void {
    this.prService.getProgProfils().subscribe((result: ProgProfil[]) => {
      this.pr = result;
    });
  }

  updateProgProfilList(pr: ProgProfil[]): void {
    this.pr = pr;
  }

  initNewProgProfil(): void {
    this.progProfilToEdit = new ProgProfil();
    console.log(this.progProfilToEdit);
  }

  editProgProfil(pr: ProgProfil): void {
    this.progProfilToEdit = pr;
  }

  handleProgProfilUpdated(): void {
    this.fetchProgProfils();
    this.progProfilToEdit = null; // Hide the edit component after create/update/delete
  }
}
