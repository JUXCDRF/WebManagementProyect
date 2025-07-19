import { CommonModule } from '@angular/common';
import { Component, Input, input } from '@angular/core';
import { AbstractControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-message-error',
  imports: [
    CommonModule
  ],
  templateUrl: './message-error.component.html',
  styleUrl: './message-error.component.css'
})
export class MessageErrorComponent {
  @Input() control!:AbstractControl|null;
}
