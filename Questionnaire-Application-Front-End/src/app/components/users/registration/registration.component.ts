import { Component } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent {
  
  hide:boolean = true;
  passwordControl: FormControl = new FormControl('', Validators.required);

  registerFormControl: FormGroup = new FormGroup({
    phoneNumber: new FormControl('', [Validators.required, Validators.email, phoneNumberValidator()]),
    name: new FormControl('', Validators.required),
    username: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
    confirmPassword: new FormControl('', Validators.required)
  })

  isFormControlValueString(): boolean {
    const usernameControl = this.registerFormControl.get('username');
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
