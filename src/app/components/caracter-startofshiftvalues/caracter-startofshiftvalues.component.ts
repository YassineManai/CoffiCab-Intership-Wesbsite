import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EditCaractershiftvalueComponent } from './edit-caractershiftvalue/edit-caractershiftvalue.component';
import { CaracterShitfV } from '../../models/caracter-shift-value';
import { CaracterShiftService } from '../../services/caracter-shift-value.service';


@Component({
  selector: 'app-caracter-startofshiftvalues',
  standalone: true,
  imports: [CommonModule,EditCaractershiftvalueComponent],
  templateUrl: './caracter-startofshiftvalues.component.html',
  styleUrl: './caracter-startofshiftvalues.component.css'
})
export class CaracterStartofshiftvaluesComponent {
  caracterShifts: CaracterShitfV[] = [];
  caracterShitToEdit: CaracterShitfV | null = null;

  constructor(private caractershiftService : CaracterShiftService) { }


  ngOnInit(): void {
    this.fetchCaracterShift();
  }
  fetchCaracterShift(): void {
    this.caractershiftService.getCaractershifts().subscribe((result: CaracterShitfV[]) => (this.caracterShifts = result));
  }
  updateCaracterShift(caractershifts: CaracterShitfV[]): void {
    this.caracterShifts = caractershifts;
  }


  initNewCaracterShift(): void {
    this.caracterShitToEdit = new CaracterShitfV();
    console.log(this.caracterShitToEdit)
  }
  editCaracterShift(caractershift: CaracterShitfV) {
    this.caracterShitToEdit = caractershift;
  }
  handleCaracterShiftUpdated(): void {
    this.fetchCaracterShift();
    this.caracterShitToEdit = null; // Hide the edit component after create/update/delete
  }

}
