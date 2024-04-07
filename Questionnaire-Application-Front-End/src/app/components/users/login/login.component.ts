import { Component } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { fail } from 'assert';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  hide:boolean = true;

  loginFormControl: FormGroup = new FormGroup({
    username: new FormControl('', [Validators.required, Validators.email, phoneNumberValidator()]),
    password: new FormControl('', Validators.required),
    submit: new FormControl('', Validators.required)
  })

  isFormControlValueString(): boolean {
    const usernameControl = this.loginFormControl.get('username');
    if (usernameControl && typeof usernameControl.value === 'string') {
      // Check if the value contains only digits
      return /^\d+$/.test(usernameControl.value);
    }
    return false;
  }

  constructor() { }

  ngOnInit(): void {

  }

}

// Custom validator function for phone number format
function phoneNumberValidator(): ValidatorFn {
  return (control: AbstractControl): { [key: string]: any } | null => {
    // Regular expression for validating phone number (you can adjust this as per your requirements)
    const phoneNumberPattern = /^[0-9]{10}$/;

    // Check if the input value matches the pattern
    const isValidFormat = phoneNumberPattern.test(control.value);
    
    // Check if the phone number starts with 0
    const startsWithZero = control.value.charAt(0) === '0';

    // Return validation result
    return isValidFormat && startsWithZero ? null : { phoneNumber: true };
  };
}
