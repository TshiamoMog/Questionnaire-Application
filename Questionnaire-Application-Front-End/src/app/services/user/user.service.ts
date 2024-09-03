import { Injectable } from '@angular/core';
import { User } from "../../models/user/user.model"
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private url = "User";

  constructor(private http: HttpClient) { }

  public getUsers() : Observable<User[]> {
    return this.http.get<User[]>(`${environment.apiUrl}/${this.url}`) ;
  }

  public getUserById() : Observable<User[]> {
    return this.http.get<User[]>(`${environment.apiUrl}/${this.url}/id`);
  }

  public updateUser(user: User) : Observable<User[]> {
    return this.http.put<User[]>(`${environment.apiUrl}/${this.url}`, user);
  }

  public registerUser(user: User) : Observable<User> {
    return this.http.post<User>(`${environment.apiUrl}/${this.url}`, user);
  }

  public loginUser(user: User) : Observable<User> {
    return this.http.post<User>(`${environment.apiUrl}/${this.url}`, user);
  }

  public deleteUser(user: User) : Observable<User[]> {
    return this.http.delete<User[]>(`${environment.apiUrl}/${this.url}/${user.id}`);
  }
}
