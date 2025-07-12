import { Component, Inject } from '@angular/core';
import { FormGroup,FormControl, ReactiveFormsModule } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-tarea-register',
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './tarea-register.component.html',
  styleUrl: './tarea-register.component.css'
})
export class TareaRegisterComponent {
  constructor(
    public dialogRef:MatDialogRef<TareaRegisterComponent>,
    @Inject(MAT_DIALOG_DATA) public data:boolean
  ){}

  frmTareaDatos=new FormGroup({
    titulo:new FormControl(),
    fecha:new FormControl(),
    horainicio:new FormControl(),
    horafin:new FormControl(),
    descripcion:new FormControl()
  })

  funRegistrar(){

  }

  funCerrar(){
    this.dialogRef.close();
  }
}
