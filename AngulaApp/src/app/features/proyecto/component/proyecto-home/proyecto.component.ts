import { Component, inject } from '@angular/core';
import { IproyectoList } from '../../modals/iproyecto-list';
import { ProyectoService } from '../../service/proyecto.service';
import { RouterLink, RouterOutlet } from '@angular/router';
import { LoginRegisterComponent } from '../../../../shared/popup/login-register/login-register.component';
import { MatDialog } from '@angular/material/dialog';
import { SecurestorageService } from '../../../../shared/service/securestorage.service';
import { enviroment } from '../../../../../enviroments/constantes.develoment';
@Component({
  selector: 'app-proyecto',
  imports: [
    RouterOutlet,
    RouterLink
  ],
  templateUrl: './proyecto.component.html',
  styleUrl: './proyecto.component.css'
})
export class ProyectoComponent {
 constructor(private dialog: MatDialog) {}
  
  proyectoList:IproyectoList[]=[];
  private proyectoService=inject(ProyectoService);
  private secure=inject(SecurestorageService);
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

  ngOnInit():void{
    const key=enviroment.KEYSTORAGE;
    const token=this.secure.get(key);
    if(token==""){
      this.funModal();
      return;
    }
    this.getListado();
  }

  getListado(){
    this.proyectoService.getLista().subscribe((res)=>{
      this.proyectoList=res;
    })
  }

  funfilter(){
  }
}
