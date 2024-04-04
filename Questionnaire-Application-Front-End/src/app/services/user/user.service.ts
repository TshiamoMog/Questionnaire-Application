import { Injectable } from '@angular/core';
import { User } from "../../models/user/user.model"

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor() { }

  public getUsers() : User[] {
    let user = new User();
    user.id = 1;
    user.name = "Robert";
    user.email = "bob.r@gmail.com";
    user.role = 1;

    return [user];
  }
}
