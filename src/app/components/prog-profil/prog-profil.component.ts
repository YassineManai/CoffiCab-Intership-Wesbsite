import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProgProfil } from '../../models/prog-profil';
import { ProgprofilService } from '../../services/progprofil.service';
import { EditProgprofilComponent } from "./edit-progprofil/edit-progprofil.component";
@Component({
  selector: 'app-prog-profil',
  standalone: true,
  imports: [CommonModule, EditProgprofilComponent],
  templateUrl: './prog-profil.component.html',
  styleUrl: './prog-profil.component.css'
})
export class ProgProfilComponent implements OnInit{
  pr: ProgProfil[] = [];
  progProfilToEdit: ProgProfil | null = null;

  
  constructor(private prService: ProgprofilService) {}
  ngOnInit(): void {
    this.prService
      .getProgProfils()
      .subscribe((result: ProgProfil[]) => (this.pr = result));
  }

  updateProgProfilList(pr: ProgProfil[]): void {
    this.pr = pr;
   }
 
   
   initNewProgProfil(): void {
     this.progProfilToEdit = new ProgProfil(); 
     console.log(this.progProfilToEdit)
   }
   editProgProfil(pr:ProgProfil){
     this.progProfilToEdit = pr;
   }
}
