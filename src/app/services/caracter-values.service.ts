import { Injectable } from '@angular/core';
import { CaracterValues } from '../models/caracter-values';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs'
@Injectable({
  providedIn: 'root'
})
export class CaracterValuesService {
  private url = "https://localhost:7248/api/CaractersValues";
  constructor(private http: HttpClient) { }
  public getCaractersValues(): Observable<CaracterValues[]> {
    return this.http.get<CaracterValues[]>(this.url);
}
public updateCaracterValues(value: CaracterValues): Observable<void> {
  return this.http.put<void>(`${this.url}/${value.idCaracterValues}`, value);
}

public deleteCaracterValues(idCaracterValues: number): Observable<void> {
  return this.http.delete<void>(`${this.url}/${idCaracterValues.toString()}`);
}

public createCaracterValues(caracter: Caracter): Observable<Caracter> {  
  return this.http.post<Caracter>(this.url, caracter);
}
getValuesByCaracterCode(codeProcess: string): Observable<Caracter[]> {
  return this.http.get<Caracter[]>(`${this.url}/products?codeProcess=${codeProcess}`);
}


}

