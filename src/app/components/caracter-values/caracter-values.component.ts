import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CaracterValues } from '../../models/caracter-values';
import { CaracterValuesService } from '../../services/caracter-values.service';
import { EditCaractervaluesComponent } from './edit-caractervalues/edit-caractervalues.component';
@Component({
  selector: 'app-caracter-values',
  standalone: true,
  imports: [CommonModule , EditCaractervaluesComponent],
  templateUrl: './caracter-values.component.html',
  styleUrl: './caracter-values.component.css'
})
export class CaracterValuesComponent implements OnInit{
  values: CaracterValues[] = [];
  valueToEdit: CaracterValues | null = null;

  constructor(private caracterValuesService : CaracterValuesService) { }
  ngOnInit(): void {
    this.fetchCaracterValues();
  }
  fetchCaracterValues(): void {
    this.caracterValuesService.getCaractersValues().subscribe((result: CaracterValues[]) => (this.values = result));
  }
  updateCaracterValues(cv: CaracterValues[]): void {
    this.values = cv;
  }


  initNewCaracterValues(): void {
    this.valueToEdit = new CaracterValues();
    console.log(this.valueToEdit)
  }
  editCaracterValues(cv: CaracterValues) {
    this.valueToEdit = cv;
  }
  handleCaracterValueUpdated(): void {
    this.fetchCaracterValues();
    this.valueToEdit = null; // Hide the edit component after create/update/delete
  }

}
