import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProyectoService } from '../../service/proyecto.service';
import { enviroment } from '../../../../../enviroments/constantes.develoment';
import { SecurestorageService } from '../../../../shared/service/securestorage.service';
import { IproyectoTarea,ItareaList } from '../../modals/itarea-list';
import { MatDialog } from '@angular/material/dialog';
import { TareaRegisterComponent } from '../popup/component/tarea-register/tarea-register.component';
import { ProyectoTareaDetallesComponent } from '../proyecto-tarea-detalles/proyecto-tarea-detalles.component';
import { ProyectotareaClass } from '../../modals/proyectotarea-class';
import { ItareaListRequest } from '../../modals/itarea-list-request';
import { TareaEventService } from '../../service/tarea-event.service';

@Component({
  selector: 'app-proyecto-tarea',
  imports: [
    ProyectoTareaDetallesComponent
  ],
  templateUrl: './proyecto-tarea.component.html',
  styleUrl: './proyecto-tarea.component.css'
})
export class ProyectoTareaComponent implements OnInit {
  constructor(
    private route:ActivatedRoute,
    private dialog:MatDialog,
    private tareaEvent:TareaEventService
  ){
  }
  private proyectoService=inject(ProyectoService);
  private secureService=inject(SecurestorageService);
  private idProyecto:string="";
  pagination:ProyectotareaClass=new ProyectotareaClass("",[],0,0,0);
  paginaActual?:number;

  funModal(idProyecto:string){
    this.dialog.open(TareaRegisterComponent, {
      width: '500px',
      data: {
        idproyecto:idProyecto,
        registrar:true,
        actualizar:false,
      },
      disableClose: true
    }).afterClosed().subscribe((res=>{
      if(res){
        this.findById(this.idProyecto);
      }
    }))
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(paramMap => {
      const id = paramMap.get('id');
      if (id) {
        this.idProyecto=id;
        this.findById(id);
      }
    });

    this.tareaEvent.tareaNotificar$.subscribe(()=>{
        this.findById(this.idProyecto);
    });
  }

  findById(id:string){
    const key=enviroment.KEYSTORAGE;
    const token=this.secureService.getCode(key);
    if(token==""){
      return;
    }
    const ItareaListRequest:ItareaListRequest={
      id:id,
      token:token,
    }
    this.proyectoService.getById(ItareaListRequest).subscribe((res)=>{
      this.pagination=new ProyectotareaClass(res.tituloprincipal,res.tareas,res.pagesize,res.pagenumber,res.totalcount);
      this.paginaActual=res.pagenumber;
    })
  }

  CrearTarea(){
    this.funModal(this.idProyecto);
  }

  funIrPagina(page:number,backAndPlus:number){
    //backAndPlus=1 resta 1
    //backAndPlus=2 suma 1
    //backAndPlus=0 noacciona
    const key=enviroment.KEYSTORAGE;
    const token=this.secureService.getCode(key);
    if(backAndPlus!=0){
      let pageAdd=page+1; // por defecto aumenta mas 1
      let pageRest=page-1;
      page=pageRest;
      if(backAndPlus==2){
        page=pageAdd;
      }
    }
    
    const ItareaListRequest:ItareaListRequest={
      id:this.idProyecto,
      token:token,
      pagesize:5,
      pagenumber:page,
    }
    this.proyectoService.getById(ItareaListRequest).subscribe((res)=>{
      this.pagination=new ProyectotareaClass(res.tituloprincipal,res.tareas,res.pagesize,res.pagenumber,res.totalcount);
      this.paginaActual=res.pagenumber;
    })
  }

  
}
