import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-send-token',
  templateUrl: './send-token.component.html',
  styleUrl: './send-token.component.css'
})
export class SendTokenComponent {
  hide:boolean = true;

  sendTokenFormControl: FormGroup = new FormGroup({
    token: new FormControl('', Validators.required),
    submit: new FormControl('', Validators.required)
  })

  constructor() { }

  ngOnInit(): void {

  }

}
