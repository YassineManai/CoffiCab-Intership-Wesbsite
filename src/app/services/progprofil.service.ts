import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProgProfil } from '../models/prog-profil';
@Injectable({
  providedIn: 'root'
})
export class ProgprofilService {
  private url = "https://localhost:7248/api/ProgProfil";
  constructor(private http: HttpClient) { }
  public getProgProfils(): Observable<ProgProfil[]> {
    return this.http.get<ProgProfil[]>(this.url);
  }
  public updateProgProfil(pr: ProgProfil): Observable<void> {
    return this.http.put<void>(`${this.url}/${pr.idProgProfil}`, pr);
  }

  public deleteProgProfil(id: number): Observable<void> {
    return this.http.delete<void>(`${this.url}/${id}`);
  }

  public createProgProfil(pr: ProgProfil): Observable<ProgProfil> {  
    return this.http.post<ProgProfil>(this.url, pr);
  }
}
