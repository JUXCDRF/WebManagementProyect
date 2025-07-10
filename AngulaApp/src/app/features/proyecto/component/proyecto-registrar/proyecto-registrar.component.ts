import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Iproyectorequest } from '../../modals/iproyecto-request';
import { enviroment } from '../../../../../enviroments/constantes.develoment';
import { SecurestorageService } from '../../../../shared/service/securestorage.service';
import { EncryptService } from '../../../../shared/service/encrypt.service';

@Component({
  selector: 'app-proyecto-registrar',
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './proyecto-registrar.component.html',
  styleUrl: './proyecto-registrar.component.css'
})
export class ProyectoRegistrarComponent {

  private secure=inject(SecurestorageService);
  private encrypt=inject(EncryptService);
  frmProyectoDatos=new FormGroup({
    nombre:new FormControl(),
    fechinicio:new FormControl(),
    permisos:new FormControl()
  });

  

  funRegistrar(){
    const key=enviroment.KEYSTORAGE;
    const token=this.secure.get(key);
    const nombre=this.frmProyectoDatos.get("nombre")?.value||"";
    const fechinicio=this.frmProyectoDatos.get("fechinicio")?.value||"";
    const permisos:number=this.frmProyectoDatos.get("permisos")?.value||0;

    const registrarRequest:Iproyectorequest={
      token:this.secure.getCode(key),
      nombre:this.encrypt.textoCifrado(nombre,token),
      permiso:permisos,
      fechainicio:fechinicio
    }

    console.log(registrarRequest);
  }

}
