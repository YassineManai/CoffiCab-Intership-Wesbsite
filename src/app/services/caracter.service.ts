import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs'
import { Caracter } from '../models/caracter';
@Injectable({
  providedIn: 'root'
})
export class CaracterService {
  private url = "https://localhost:7248/api/Caracters";
  constructor(private http: HttpClient) { }
  public getCaracters(): Observable<Caracter[]> {
    return this.http.get<Caracter[]>(this.url);
  }

  public updateCaracter(caracter: Caracter): Observable<void> {
    return this.http.put<void>(`${this.url}/${caracter.codeCaracter}`, caracter);
  }

  public deleteCaracter(codeCaracter: string): Observable<void> {
    return this.http.delete<void>(`${this.url}/${codeCaracter}`);
  }

  public createCaracter(caracter: Caracter): Observable<Caracter> {  
    return this.http.post<Caracter>(this.url, caracter);
  }
  getProductsByProcessCode(codeProcess: string): Observable<Caracter[]> {
    return this.http.get<Caracter[]>(`${this.url}/products?codeProcess=${codeProcess}`);
  }
}
