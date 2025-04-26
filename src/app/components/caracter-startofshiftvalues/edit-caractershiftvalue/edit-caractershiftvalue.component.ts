import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Process } from '../../../models/process'; // Import Process model
import { ProcessService } from '../../../services/process.service';
import { Caracter } from '../../../models/caracter';
import { CaracterService } from '../../../services/caracter.service';
import { CaracterShitfV } from '../../../models/caracter-shift-value';
import { Machine } from '../../../models/machine';
import { CaracterShiftService } from '../../../services/caracter-shift-value.service';
import { MachineService } from '../../../services/machine.service';

@Component({
  selector: 'app-edit-caractershiftvalue',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './edit-caractershiftvalue.component.html',
  styleUrl: './edit-caractershiftvalue.component.css'
})
export class EditCaractershiftvalueComponent {
  @Input() caractershift: CaracterShitfV | null = null;
  @Output() caractershiftupdated = new EventEmitter<void>();
  machines: Machine[] = []; 
  caractershifts:CaracterShitfV[]=[];

  constructor
  (private caractershiftservice: CaracterShiftService,
   private machineservive: MachineService
  ){}

  ngOnInit(): void { 
    this.fetchCaraterShifts();
   }
   fetchCaraterShifts(): void {
    this.caractershiftservice.getCaractershifts().subscribe((result: CaracterShitfV[]) => (this.caractershifts = result));
    this.machineservive.getMachine().subscribe((result: Machine[]) => (this.machines = result));
  }
  updateCaraterShift(caractershift: CaracterShitfV): void {
    console.log(caractershift)
    this.caractershiftservice.updateCaractershift(caractershift)
      .subscribe(() => this.caractershiftupdated.emit());
  }

  deleteCaraterShift(caracter_code: string): void {
    console.log(caracter_code)
    this.caractershiftservice.deleteCaractershift(caracter_code)
      .subscribe(() => this.caractershiftupdated.emit());
  }

  createCaracter(caracter: CaracterShitfV): void {
    console.log(caracter)
    if (this.isDuplicateCaracter(caracter)) {
      alert('Caracter already exists.');
    }
     else if (this.isValidCaracter(caracter)) {
        this.caractershiftservice.createCaractershift(caracter)
        .subscribe(() => this.caractershiftupdated.emit());
      
      } else {
        alert('Please fill in all the required fields.');
      }
  }

  isDuplicateCaracter(caracter: CaracterShitfV): boolean {
    const newCodeCaracter = caracter.codeCaracterStartOFShift?.toUpperCase();
    return this.caractershifts.some(existingCaracter => existingCaracter.codeCaracterStartOFShift?.toUpperCase() === newCodeCaracter);
  }
  isValidCaracter(caracter: CaracterShitfV): boolean {
    const requiredFields = [
      caracter.value,
      caracter.id_Poste,
      caracter.codeCaracterStartOFShift,
      caracter.machine_Code,
      caracter.user,
    ];

    return requiredFields.every(field => field !== undefined && field !== null && field !== '');

  }



}
