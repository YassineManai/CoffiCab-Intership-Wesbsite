import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Caracter } from '../../../models/caracter';
import { CaracterService } from '../../../services/caracter.service';
import { CaracterValues } from '../../../models/caracter-values';
import { CaracterValuesService } from '../../../services/caracter-values.service';
@Component({
  selector: 'app-edi-caractervalues',
  standalone: true,
  imports: [FormsModule , CommonModule],
  templateUrl: './edit-caractervalues.component.html',
  styleUrl: './edit-caractervalues.component.css'
})
export class EditCaractervaluesComponent implements OnInit{
  @Input() value: CaracterValues | null = null;
  @Output() caracterValueupdated = new EventEmitter<void>();
  caracters: Caracter[] = []; // Add a processes array
  values:CaracterValues[]=[];
  constructor
  (private caracterService: CaracterService,
   private caracterValuesService: CaracterValuesService
  ){}
  ngOnInit(): void { 
    this.fetchCaracters();
   }
   fetchCaracters(): void {
    this.caracterService.getCaracters().subscribe((result: Caracter[]) => (this.caracters = result));
    this.caracterValuesService.getCaractersValues().subscribe((result: CaracterValues[]) => (this.values = result));
  }
  updateCaracterValues(cv: CaracterValues): void {
    console.log(cv)
    this.caracterValuesService.updateCaracterValues(cv)
      .subscribe(() => this.caracterValueupdated.emit());
  }

  deleteCaracterValues(idCaracterValues: number): void {
    console.log(idCaracterValues)
    this.caracterValuesService.deleteCaracterValues(idCaracterValues)
      .subscribe(() => this.caracterValueupdated.emit());
  }
  createCaracterValues(cv: CaracterValues): void {
      console.log(cv)
      if (this.isDuplicateCaracterValues(cv)) {
        alert('Caracter Value already exists.');
      }
       else if (this.isValidCaracterValues(cv)) {
          this.caracterValuesService.createCaracterValues(cv)
          .subscribe(() => this.caracterValueupdated.emit());
        
        } else {
          alert('Please fill in all the required fields.');
        }
    }

    isDuplicateCaracterValues(cv: CaracterValues): boolean {
      const newCodeCaracterValues = cv.idCaracterValues?.toString().toUpperCase();
      return this.values.some(existingValue => existingValue.idCaracterValues?.toString().toUpperCase() === newCodeCaracterValues);
    }
    isValidCaracterValues(cv: CaracterValues): boolean {
      const requiredFields = [
        cv.value1Caracter,
        cv.codeCaracter,
        cv.iTemGroup,
        cv.value2Caracter,
        cv.operationArithmetique1,
        cv.operationArithmetique2,
        
      ];
  
      return requiredFields.every(field => field !== undefined && field !== null && field !== '');
    }
}
