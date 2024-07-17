import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { ProgProfil } from '../../../models/prog-profil';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ProgprofilService } from '../../../services/progprofil.service';
@Component({
  selector: 'app-edit-progprofil',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './edit-progprofil.component.html',
  styleUrl: './edit-progprofil.component.css'
})
export class EditProgprofilComponent implements OnInit{
@Input() pr: ProgProfil | null= null;
@Output() progProfilEdited = new EventEmitter<ProgProfil[]>();
constructor(private progprofilService: ProgprofilService) {}

  ngOnInit(): void {
    this.fetchProgProfil();
  }

  fetchProgProfil(): void {
    this.progprofilService.getProgProfils()
      .subscribe((pr: ProgProfil[]) => this.progProfilEdited.emit(pr));
  }

  updateProgProfil(pr: ProgProfil): void {
    this.progprofilService.updateProgProfil(pr)
      .subscribe(() => this.fetchProgProfil());
  }

  deleteProgProfil(idProgProfil: number): void {
    this.progprofilService.deleteProgProfil(idProgProfil)
      .subscribe(() => this.fetchProgProfil());
  }

  createProgProfil(pr: ProgProfil): void {
    console.log(pr)
    this.progprofilService.createProgProfil(pr)
      .subscribe(() => this.fetchProgProfil());
  }
}
