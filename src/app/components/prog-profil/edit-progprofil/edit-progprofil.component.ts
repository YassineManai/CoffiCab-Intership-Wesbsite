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
@Input() progprofil: ProgProfil | null= null;
@Output() progProfilEdited = new EventEmitter<ProgProfil[]>();
constructor(private progprofilService: ProgprofilService) {}

  ngOnInit(): void {
    this.fetchProgProfil();
  }

  fetchProgProfil(): void {
    this.progprofilService.getProgProfils()
      .subscribe((progprofil: ProgProfil[]) => this.progProfilEdited.emit(progprofil));
  }

  updateProgProfil(progprofil: ProgProfil): void {
    this.progprofilService.updateProgProfil(progprofil)
      .subscribe(() => this.fetchProgProfil());
  }

  deleteProgProfil(idProgProfil: number): void {
    this.progprofilService.deleteProgProfil(idProgProfil)
      .subscribe(() => this.fetchProgProfil());
  }

  createProgProfil(progprofil: ProgProfil): void {
    console.log(progprofil)
    this.progprofilService.createProgProfil(progprofil)
      .subscribe(() => this.fetchProgProfil());
  }
}
