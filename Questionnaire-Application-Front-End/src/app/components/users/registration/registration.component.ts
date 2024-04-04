import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent {
  
  hide:boolean = true;
  passwordControl: FormControl = new FormControl('', Validators.required);

  registerFormControl: FormGroup = new FormGroup({
    phoneNumber: new FormControl('', [Validators.required, Validators.email]),
    name: new FormControl('', Validators.required),
    username: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
    confirmPassword: new FormControl('', Validators.required)
  })
  constructor() { }

  ngOnInit(): void {

  }
}
