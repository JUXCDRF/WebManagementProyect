import { Component, inject, Input, input, OnInit } from '@angular/core';
import { ItareaList } from '../../modals/itarea-list';
import { MatDialog } from '@angular/material/dialog';
import { TareaRegisterComponent } from '../popup/component/tarea-register/tarea-register.component';
import { TareaEventService } from '../../service/tarea-event.service';
import { AlertService } from '../../../../shared/service/alert.service';
import { SecurestorageService } from '../../../../shared/service/securestorage.service';
import { ItareaRequestService } from '../popup/service/itarea-request.service';
import { Baseresponse } from '../../../../shared/interface/baseresponse';
import { enviroment } from '../../../../../enviroments/constantes.develoment';
import Swal from 'sweetalert2'
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-proyecto-tarea-detalles',
  imports: [
    CommonModule
  ],
  templateUrl: './proyecto-tarea-detalles.component.html',
  styleUrl: './proyecto-tarea-detalles.component.css'
})
export class ProyectoTareaDetallesComponent {
  constructor(
    private dialog:MatDialog,
    private tareaEvent:TareaEventService
  ){}
  @Input() tarea!:ItareaList;

  private secuestorage=inject(SecurestorageService);
  private tareaservice=inject(ItareaRequestService);
  private alertservice=inject(AlertService);

  funModal(idtarea:string){
    this.dialog.open(TareaRegisterComponent, {
      width: '500px',
      data: {
        idproyecto:"",
        registrar:false,
        actualizar:true,
        idtarea:idtarea
      },
      disableClose: true
    }).afterClosed().subscribe((res:boolean)=>{
      if(res){
        this.tareaEvent.ObteneerListadoTarea();
      }
    })
  }
  
  funEditar(idtarea:string){
    this.funModal(idtarea);
  }

  async funFinalizar(idtarea:string){
    const estado="Finalizar";
    const respuesta = await this.alertservice.funAlertConsulta(estado);
    if(!respuesta){
      return;
    } 
    const key=enviroment.KEYSTORAGE;
    const token=this.secuestorage.getCode(key);
    await this.tareaservice.UpdateEstado(idtarea,token,2).subscribe((res:Baseresponse)=>{
      if(!res.success){
        Swal.fire(res.message, "", "error");
        return;
      }
      this.tareaEvent.ObteneerListadoTarea();
      Swal.fire(res.message, "", "success");
    });
  }

  async funEliminar(idtarea:string){
    const estado="Eliminar";
    const respuesta = await this.alertservice.funAlertConsulta(estado);
    if(!respuesta){
      return;
    } 
    const key=enviroment.KEYSTORAGE;
    const token=this.secuestorage.getCode(key);
    await this.tareaservice.UpdateEstado(idtarea,token,3).subscribe((res:Baseresponse)=>{
      if(!res.success){
        Swal.fire(res.message, "", "error");
        return;
      }
      this.tareaEvent.ObteneerListadoTarea();
      Swal.fire(res.message, "", "success");
    });
  }
}
