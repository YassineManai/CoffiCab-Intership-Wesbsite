import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Process } from '../../../models/process'; // Import Process model
import { ProcessService } from '../../../services/process.service';
import { Caracter } from '../../../models/caracter';
import { CaracterService } from '../../../services/caracter.service';
@Component({
  selector: 'app-edit-caracter',
  standalone: true,
  imports: [FormsModule , CommonModule],
  templateUrl: './edit-caracter.component.html',
  styleUrl: './edit-caracter.component.css'
})
export class EditCaracterComponent implements OnInit {
  @Input() caracter: Caracter | null = null;
  @Output() caracterupdated = new EventEmitter<void>();
  processes: Process[] = []; // Add a processes array
  caracters:Caracter[]=[];

  constructor
  (private caracterservice: CaracterService,
   private processService: ProcessService
  ){}
  ngOnInit(): void { 
    this.fetchProcesses();
   }
   fetchProcesses(): void {
    this.processService.getProcesses().subscribe((result: Process[]) => (this.processes = result));
    this.caracterservice.getCaracters().subscribe((result: Caracter[]) => (this.caracters = result));
  }
  updateCaracter(caracter: Caracter): void {
    console.log(caracter)
    this.caracterservice.updateCaracter(caracter)
      .subscribe(() => this.caracterupdated.emit());
  }

  deleteCaracter(machine_Code: string): void {
    console.log(machine_Code)
    this.caracterservice.deleteCaracter(machine_Code)
      .subscribe(() => this.caracterupdated.emit());
  }
  createCaracter(caracter: Caracter): void {
      console.log(caracter)
      if (this.isDuplicateCaracter(caracter)) {
        alert('Caracter already exists.');
      }
       else if (this.isValidCaracter(caracter)) {
          this.caracterservice.createCaracter(caracter)
          .subscribe(() => this.caracterupdated.emit());
        
        } else {
          alert('Please fill in all the required fields.');
        }
    }

    isDuplicateCaracter(caracter: Caracter): boolean {
      const newCodeCaracter = caracter.codeCaracter?.toUpperCase();
      return this.caracters.some(existingCaracter => existingCaracter.codeCaracter?.toUpperCase() === newCodeCaracter);
    }
    isValidCaracter(caracter: Caracter): boolean {
      const requiredFields = [
        caracter.codeCaracter,
        caracter.descCaracter,
        caracter.unit_of_measure,
        caracter.type,
        caracter.codeProcess,
        caracter.masqueSaisie,
        caracter.regroupement_Libille,
        caracter.code_OPC,
        caracter.localDescCaracter,
        caracter.image_Caracters,
        caracter.lien_Cararactere_Nb_Repetition,
        
        
      ];
  
      return requiredFields.every(field => field !== undefined && field !== null && field !== '');
    }

}
