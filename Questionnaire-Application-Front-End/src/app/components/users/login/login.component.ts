import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { fail } from 'assert';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  hide:boolean = true;
  passwordControl: FormControl = new FormControl('', Validators.required);

  loginFormControl: FormGroup = new FormGroup({
    username: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', Validators.required),
    submit: new FormControl('', Validators.required)
  })
  constructor() { }

  ngOnInit(): void {

  }
}
