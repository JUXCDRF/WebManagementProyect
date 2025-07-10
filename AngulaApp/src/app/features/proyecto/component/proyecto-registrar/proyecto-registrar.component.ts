import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Iproyectorequest } from '../../modals/iproyecto-request';
import { enviroment } from '../../../../../enviroments/constantes.develoment';
import { SecurestorageService } from '../../../../shared/service/securestorage.service';
import { EncryptService } from '../../../../shared/service/encrypt.service';
import { ProyectoService } from '../../service/proyecto.service';
import { MatDialog } from '@angular/material/dialog';
import { LoginRegisterComponent } from '../../../../shared/popup/login-register/login-register.component';

@Component({
  selector: 'app-proyecto-registrar',
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './proyecto-registrar.component.html',
  styleUrl: './proyecto-registrar.component.css'
})
export class ProyectoRegistrarComponent {
  constructor(private dialog: MatDialog) {}

  registrando=false;

  private secure=inject(SecurestorageService);
  private encrypt=inject(EncryptService);
  private poyectoService=inject(ProyectoService)

  frmProyectoDatos=new FormGroup({
    nombre:new FormControl(),
    fechinicio:new FormControl(),
    permisos:new FormControl()
  });

  funModal(){
     this.dialog.open(LoginRegisterComponent, {
        width: '500px',
        data: {
          titulo: 'Token requerido',
          validar:true,
          registrar:false
        }
      });
  }

  funRegistrar(){
    if(this.registrando){return}
    this.registrando=true;
    const key=enviroment.KEYSTORAGE;
    const token=this.secure.get(key);
    const nombre=this.frmProyectoDatos.get("nombre")?.value||"";
    const fechinicio=this.frmProyectoDatos.get("fechinicio")?.value||"";
    const permisos:number=this.frmProyectoDatos.get("permisos")?.value||0;

    if(token==""){
      this.funModal();
      this.registrando = false;
      return;
    }

    const registrarRequest:Iproyectorequest={
      token:this.secure.getCode(key),
      nombre:this.encrypt.textoCifrado(nombre,token),
      permiso:permisos,
      fechainicio:fechinicio
    }

    this.poyectoService.saveProyecto(registrarRequest).subscribe({
      next:(res)=>{
        if(!res.success){
          alert(res.message);
          return;
        }
        alert(res.message);
      },
      error:(error)=>{
        const mensaje = error.error?.message || 'Ocurrió un error inesperado';
        alert(mensaje);
        this.registrando = false;
      },
      complete: () => {
        this.registrando = false;
      }
    });

  }
}
