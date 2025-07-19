import { Component, inject, Inject, OnInit } from '@angular/core';
import { FormGroup,FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { IpopupRequest } from '../../models/ipopup-request';
import { ItareaCrearRequest } from '../../models/itarea-crear-request';
import { enviroment } from '../../../../../../../enviroments/constantes.develoment';
import { SecurestorageService } from '../../../../../../shared/service/securestorage.service';
import { ItareaRequestService } from '../../service/itarea-request.service';
import { Baseresponse } from '../../../../../../shared/interface/baseresponse';
import { AlertService } from '../../../../../../shared/service/alert.service';
import { CommonModule } from '@angular/common';
import { MessageErrorComponent } from '../../../../../../shared/message-error/message-error.component';
import { ItareaResponse } from '../../models/itarea-response';

@Component({
  selector: 'app-tarea-register',
  imports: [
    ReactiveFormsModule,
    CommonModule,
    MessageErrorComponent
  ],
  templateUrl: './tarea-register.component.html',
  styleUrl: './tarea-register.component.css'
})
export class TareaRegisterComponent implements OnInit {
  constructor(
    public dialogRef:MatDialogRef<TareaRegisterComponent>,
    @Inject(MAT_DIALOG_DATA) public data:IpopupRequest
  ){}

  private secuestorage=inject(SecurestorageService);
  private tareaservice=inject(ItareaRequestService);
  private alertservice=inject(AlertService);

  ngOnInit(): void {
    if(this.data.idtarea){
      this.funObtenerTarea(this.data.idtarea);
    }
  }


  frmTareaDatos=new FormGroup({
    titulo:new FormControl("",[Validators.required,Validators.minLength(3),Validators.maxLength(200)]),
    fecha:new FormControl("",[Validators.required]),
    horainicio:new FormControl("",[Validators.required]),
    horafin:new FormControl("",[Validators.required]),
    descripcion:new FormControl("",[Validators.required,Validators.minLength(1),Validators.maxLength(500)])
  })

  funObtenerTarea(idTarea:string){
    const key=enviroment.KEYSTORAGE;
    const token=this.secuestorage.getCode(key);
    this.tareaservice.GetTarea(idTarea,token).subscribe((res:ItareaResponse)=>{
      if(!res.success){
        this.alertservice.funAlert(res.message,"error");
        return;
      }
      this.frmTareaDatos.patchValue({
        titulo: res.titulo,
        fecha: res.fecha,
        horainicio: res.horainicio,
        horafin: res.horafin,
        descripcion: res.descripcion
      });
    });
  }

  funRegistrar(){
    if(!this.data.registrar){return}
    if(!this.frmTareaDatos.valid){
    this.alertservice.funAlert("Requiere validar los Campos","error");
    this.frmTareaDatos.markAllAsTouched();
    return;}

    this.data.registrar=false;
    const key=enviroment.KEYSTORAGE;
    const token=this.secuestorage.getCode(key);

    const request:ItareaCrearRequest={
      id: this.data.idproyecto,
      token: token,
      descripcion:this.frmTareaDatos.get("descripcion")?.value??"",
      fecha:this.frmTareaDatos.get("fecha")?.value??"",
      horafin:this.frmTareaDatos.get("horafin")?.value??"",
      horainicio:this.frmTareaDatos.get("horainicio")?.value??"",
      titulo:this.frmTareaDatos.get("titulo")?.value??""
    };

    this.tareaservice.SaveTarea(request).subscribe({
      next:(res)=>{
        if(!res.success){
          this.alertservice.funAlert(res.message,"error");
          this.dialogRef.close(false);
          this.data.registrar=true;//habilitar
          return;
        }
        this.alertservice.funAlert(res.message,"success");
        this.data.registrar=true;//habilitar
        this.frmTareaDatos.reset();
        this.dialogRef.close(true);
      },
      error:(error)=>{
        const mensaje = error.error?.message || 'Ocurrió un error inesperado';
        this.data.registrar=true;//habilitar
        this.alertservice.funAlert(mensaje,"error");
      }
    })

  }

  funActualizar(){
    if(!this.data.actualizar){return}
    if(!this.frmTareaDatos.valid){
    this.alertservice.funAlert("Requiere validar los Campos","error");
    this.frmTareaDatos.markAllAsTouched();
    return;}
    
    this.data.registrar=false;
    const key=enviroment.KEYSTORAGE;
    const token=this.secuestorage.getCode(key);

    const request:ItareaCrearRequest={
      id: this.data.idtarea??"",
      token: token,
      descripcion:this.frmTareaDatos.get("descripcion")?.value??"",
      fecha:this.frmTareaDatos.get("fecha")?.value??"",
      horafin:this.frmTareaDatos.get("horafin")?.value??"",
      horainicio:this.frmTareaDatos.get("horainicio")?.value??"",
      titulo:this.frmTareaDatos.get("titulo")?.value??""
    };

    this.tareaservice.UpdateTarea(request).subscribe({
      next:(res:Baseresponse)=>{
        if(!res.success){
          this.alertservice.funAlert(res.message,"error");
          this.dialogRef.close(false);
          this.data.registrar=true;//habilitar
          return;
        }
        this.alertservice.funAlert(res.message,"success");
        this.data.registrar=true;//habilitar
        this.frmTareaDatos.reset();
        this.dialogRef.close(true);
      },
      error:(error)=>{
        const mensaje = error.error?.message || 'Ocurrió un error inesperado';
        this.data.registrar=true;//habilitar
        this.alertservice.funAlert(mensaje,"error");
      }
    })
  }

  funCerrar(){
    this.dialogRef.close(false);
  }
}
