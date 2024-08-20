import { ProfileUser } from './../models/profileuser';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Process } from '../models/process';

@Injectable({
  providedIn: 'root'
})
export class ProfileUserService {
  private url = "https://localhost:7248/api/ProfileUser";

  constructor(private http: HttpClient) {}

 
  public getProfileUsers():Observable<ProfileUser[]>{
    return this.http.get<ProfileUser[]>(this.url);
  }

  public updateProfileUser(profileUser: ProfileUser): Observable<void> {
    return this.http.put<void>(`${this.url}/${profileUser.id_Profil}`, profileUser);
  }

  public deleteProfileUser(idProfile: string): Observable<void> {
    return this.http.delete<void>(`${this.url}/${idProfile}`);
  }

  public createProfileUser(profileUser: ProfileUser): Observable<ProfileUser> {  
    return this.http.post<ProfileUser>(this.url, profileUser);
  }
}
