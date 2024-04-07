import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  activeModalIndex: number | null = null;

  constructor() { }

  setActiveModal(index: number): void {
    this.activeModalIndex = index;
  }

  closeModal(): void {
    this.activeModalIndex = null;
  }

}
