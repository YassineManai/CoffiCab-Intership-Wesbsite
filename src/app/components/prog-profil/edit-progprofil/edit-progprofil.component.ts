import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { ProgProfil } from '../../../models/prog-profil';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ProgprofilService } from '../../../services/progprofil.service';

@Component({
  selector: 'app-edit-progprofil',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule
  ],
  templateUrl: './edit-progprofil.component.html',
  styleUrls: ['./edit-progprofil.component.css']
})
export class EditProgprofilComponent implements OnInit {
  @Input() progprofil: ProgProfil | null = null;
  @Output() progProfilUpdated = new EventEmitter<void>();
  progProfils: ProgProfil[] = [];

  constructor(private progprofilService: ProgprofilService) {}

  ngOnInit(): void {
    this.fetchProgProfils();
  }

  fetchProgProfils(): void {
    this.progprofilService.getProgProfils().subscribe((result: ProgProfil[]) => {
      this.progProfils = result;
    });
  }

  updateProgProfil(progprofil: ProgProfil): void {
    this.progprofilService.updateProgProfil(progprofil)
      .subscribe(() => this.progProfilUpdated.emit());
  }

  deleteProgProfil(idProgProfil: number): void {
    this.progprofilService.deleteProgProfil(idProgProfil)
      .subscribe(() => this.progProfilUpdated.emit());
  }

  createProgProfil(progprofil: ProgProfil): void {
    this.progprofilService.createProgProfil(progprofil)
      .subscribe(() => this.progProfilUpdated.emit());
  }
}
