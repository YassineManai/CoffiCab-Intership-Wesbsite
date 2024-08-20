import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs'
import { Caracter } from '../models/caracter';
import { CaracterShitfV } from '../models/caracter-shift-value';
@Injectable({
  providedIn: 'root'
})
export class CaracterShiftService {
  private url = "https://localhost:7248/api/CaractersStartOfShiftValues";
  constructor(private http: HttpClient) { }
  public getCaractershifts(): Observable<CaracterShitfV[]> {
    return this.http.get<CaracterShitfV[]>(this.url);
  }

  public updateCaractershift(caractershift: CaracterShitfV): Observable<void> {
    return this.http.put<void>(`${this.url}/${caractershift.codeCaracterStartOFShift}`, caractershift);
  }

  public deleteCaractershift(codeCaracter: string): Observable<void> {
    return this.http.delete<void>(`${this.url}/${codeCaracter}`);
  }

  public createCaractershift(caractershift: CaracterShitfV): Observable<CaracterShitfV> {  
    return this.http.post<CaracterShitfV>(this.url, caractershift);
  }
 
}
