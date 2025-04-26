import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Machine } from '../models/machine';
@Injectable({
  providedIn: 'root'
})
export class MachineService {
  private url = "https://localhost:7248/api/Machine";
  constructor(private http: HttpClient) { }
  public getMachine(): Observable<Machine[]> {
    return this.http.get<Machine[]>(this.url);
  }
  public updateMachine(pr: Machine): Observable<void> {
    return this.http.put<void>(`${this.url}/${pr.machine_Code}`, pr);
  }

  public deleteMachine(code: string): Observable<void> {
    return this.http.delete<void>(`${this.url}/${code}`);
  }

  public createMachine(machine: Machine): Observable<Machine> {  
    return this.http.post<Machine>(this.url, machine);
  }
}
