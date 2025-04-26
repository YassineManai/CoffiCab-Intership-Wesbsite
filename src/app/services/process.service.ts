import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Process } from '../models/process';

@Injectable({
  providedIn: 'root'
})
export class ProcessService {
  private url = "https://localhost:7248/api/Processes";

  constructor(private http: HttpClient) {}

  public getProcesses(): Observable<Process[]> {
    return this.http.get<Process[]>(this.url);
  }

  public updateProcess(process: Process): Observable<void> {
    return this.http.put<void>(`${this.url}/${process.codeProcess}`, process);
  }

  public deleteProcess(codeprocess: string): Observable<void> {
    return this.http.delete<void>(`${this.url}/${codeprocess}`);
  }

  public createProcess(process: Process): Observable<Process> {  
    return this.http.post<Process>(this.url, process);
  }
}
