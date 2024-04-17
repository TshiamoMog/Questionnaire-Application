import { Injectable } from '@angular/core';
import { User } from "../../models/user/user.model"

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor() { }
  url = ""

  public getUsers() : User[] {
    let user = new User();
    user.id = 1;
    user.email = "bob.r@gmail.com";
    user.phoneNumber = "0123456789"
    user.name = "Robert";
    user.username = "rob_the.black5000"

    return [user];
  }
}
