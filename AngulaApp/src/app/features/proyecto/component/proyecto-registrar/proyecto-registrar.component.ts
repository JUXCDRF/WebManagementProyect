import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Iproyectorequest } from '../../modals/iproyecto-request';
import { enviroment } from '../../../../../enviroments/constantes.develoment';
import { SecurestorageService } from '../../../../shared/service/securestorage.service';
import { EncryptService } from '../../../../shared/service/encrypt.service';
import { ProyectoService } from '../../service/proyecto.service';
import { MatDialog } from '@angular/material/dialog';
import { LoginRegisterComponent } from '../../../../shared/popup/login-register/login-register.component';
import { ProyectoCreadoEventService } from '../../service/proyecto-creado-event.service';
import { AlertService } from '../../../../shared/service/alert.service';
import { CommonModule } from '@angular/common';
import { MessageErrorComponent } from "../../../../shared/message-error/message-error.component";

@Component({
  selector: 'app-proyecto-registrar',
  imports: [
    ReactiveFormsModule,
    CommonModule,
    MessageErrorComponent
],
  templateUrl: './proyecto-registrar.component.html',
  styleUrl: './proyecto-registrar.component.css'
})
export class ProyectoRegistrarComponent {
  constructor(
    private dialog: MatDialog,
    private proyectoEvent:ProyectoCreadoEventService) {}

  registrando=false;

  private secure=inject(SecurestorageService);
  private encrypt=inject(EncryptService);
  private poyectoService=inject(ProyectoService);
  private alert=inject(AlertService);

  frmProyectoDatos=new FormGroup({
    nombre:new FormControl("",[Validators.required,Validators.minLength(3),Validators.maxLength(100)]),
    fechinicio:new FormControl("",[Validators.required]),
    permisos:new FormControl(1,Validators.required)
  });

  funModal(){
     this.dialog.open(LoginRegisterComponent, {
        width: '500px',
        data: {
          titulo: 'Token requerido',
          validar:true,
          registrar:false
        },
        disableClose: true
      });
  }

  funRegistrar(){
    if(this.registrando){return}
    if(!this.frmProyectoDatos.valid){
      this.alert.funAlert("Requiere validar los Campos","error");
      this.frmProyectoDatos.markAllAsTouched();
      return;}
    this.registrando=true;
    const key=enviroment.KEYSTORAGE;
    const token=this.secure.get(key);
    const nombre:string=this.frmProyectoDatos.get("nombre")?.value||"";
    const fechinicio:string=this.frmProyectoDatos.get("fechinicio")?.value||"";
    const permisos:number=this.frmProyectoDatos.get("permisos")?.value||0;

    if(token==""){
      this.funModal();
      this.registrando = false;
      this.alert.funAlert("Requiere Token","error");
      return;
    }

    const registrarRequest:Iproyectorequest={
      token:this.secure.getCode(key),
      nombre:nombre,
      permiso:permisos,
      fechainicio:fechinicio
    }

    this.poyectoService.saveProyecto(registrarRequest).subscribe({
      next:(res)=>{
        if(!res.success){
          this.alert.funAlert(res.message,"error");
          return;
        }
        this.alert.funAlert(res.message,"success");
        this.proyectoEvent.NotificarProyectoCreado();
        this.frmProyectoDatos.reset();
      },
      error:(error)=>{
        const mensaje = error.error?.message || 'Ocurrió un error inesperado';
        this.alert.funAlert(mensaje,"error");
        this.registrando = false;
      },
      complete: () => {
        this.registrando = false;
      }
    });

  }
}
