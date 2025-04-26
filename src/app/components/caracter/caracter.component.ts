import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Caracter } from '../../models/caracter';
import { CaracterService } from '../../services/caracter.service';
import { EditCaracterComponent } from './edit-caracter/edit-caracter.component';
@Component({
  selector: 'app-caracter',
  standalone: true,
  imports: [CommonModule , EditCaracterComponent],
  templateUrl: './caracter.component.html',
  styleUrl: './caracter.component.css'
})
export class CaracterComponent implements OnInit {
  caracters: Caracter[] = [];
  caracterToEdit: Caracter | null = null;

  constructor(private caracterService : CaracterService) { }
  ngOnInit(): void {
    this.fetchCaracter();
  }
  fetchCaracter(): void {
    this.caracterService.getCaracters().subscribe((result: Caracter[]) => (this.caracters = result));
  }
  updateCaracter(caracters: Caracter[]): void {
    this.caracters = caracters;
  }


  initNewCaracter(): void {
    this.caracterToEdit = new Caracter();
    console.log(this.caracterToEdit)
  }
  editCaracter(caracter: Caracter) {
    this.caracterToEdit = caracter;
  }
  handleCaracterUpdated(): void {
    this.fetchCaracter();
    this.caracterToEdit = null; // Hide the edit component after create/update/delete
  }

}
