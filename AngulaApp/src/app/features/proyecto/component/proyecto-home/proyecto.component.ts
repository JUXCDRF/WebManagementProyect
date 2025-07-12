import { Component, inject, OnInit } from '@angular/core';
import { IproyectoList } from '../../modals/iproyecto-list';
import { ProyectoService } from '../../service/proyecto.service';
import { RouterLink, RouterModule, RouterOutlet } from '@angular/router';
import { LoginRegisterComponent } from '../../../../shared/popup/login-register/login-register.component';
import { MatDialog } from '@angular/material/dialog';
import { SecurestorageService } from '../../../../shared/service/securestorage.service';
import { enviroment } from '../../../../../enviroments/constantes.develoment';
import { IonlytokenRequest } from '../../../../shared/popup/interface/ionlytoken-request';
import { EncryptService } from '../../../../shared/service/encrypt.service';
import { ProyectoCreadoEventService } from '../../service/proyecto-creado-event.service';
import { FormsModule } from '@angular/forms';
import { IfiltroRequest } from '../../modals/ifiltro-request';

@Component({
  selector: 'app-proyecto',
  imports: [
    RouterOutlet,
    RouterLink,
    FormsModule
  ],
  templateUrl: './proyecto.component.html',
  styleUrl: './proyecto.component.css'
})
export class ProyectoComponent implements OnInit {
 constructor(
  private dialog: MatDialog,
  private proyectoEvent:ProyectoCreadoEventService) {}
  
  proyectoList:IproyectoList[]=[];
  filtro:string="";
  
  private proyectoService=inject(ProyectoService);
  private secure=inject(SecurestorageService);
  private encrypt=inject(EncryptService);

  private key=enviroment.KEYSTORAGE;
  private token=this.secure.getCode(this.key);
   funModal(){
       this.dialog.open(LoginRegisterComponent, {
          width: '500px',
          data: {
            titulo: 'Token requerido',
            validar:true,
            registrar:false
          },
          disableClose: true
        }).afterClosed().subscribe((res)=>{
          if(res){
          this.getListado(this.token);
          }
        });
    }

  ngOnInit():void{
    if(this.token==""){
      this.funModal();
      return;
    }
    this.getListado(this.token);

    this.proyectoEvent.proyectoCreado$.subscribe(()=>{
      this.getListado(this.token);
    })
  }

  getListado(token:string){
    const IonlytokenRequest:IonlytokenRequest={
      token:token
    }
    this.proyectoService.getLista(IonlytokenRequest).subscribe((res)=>{
      res.forEach((e)=>{
        e.nombre=e.nombre;
      });
      this.proyectoList=res;
    });
  }

  funfilter(){
    const token=this.token;
    const filtro=this.filtro;
    if(token==""){return}
    const IfiltroRequest:IfiltroRequest={
      token:token,
      filtro:filtro
    }
    this.proyectoService.getFiltro(IfiltroRequest).subscribe((res)=>{
      this.proyectoList=res;
    });
  }
}
