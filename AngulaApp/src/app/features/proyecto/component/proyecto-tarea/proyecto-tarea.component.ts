import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProyectoService } from '../../service/proyecto.service';
import { enviroment } from '../../../../../enviroments/constantes.develoment';
import { SecurestorageService } from '../../../../shared/service/securestorage.service';
import { IproyectoTarea,ItareaList } from '../../modals/itarea-list';
import { MatDialog } from '@angular/material/dialog';
import { TareaRegisterComponent } from '../popup/component/tarea-register/tarea-register.component';

@Component({
  selector: 'app-proyecto-tarea',
  imports: [],
  templateUrl: './proyecto-tarea.component.html',
  styleUrl: './proyecto-tarea.component.css'
})
export class ProyectoTareaComponent implements OnInit {
  constructor(
    private route:ActivatedRoute,
    private dialog:MatDialog
  ){
  }
  private proyectoService=inject(ProyectoService);
  private secureService=inject(SecurestorageService);

  proyectoTarea:IproyectoTarea={
   tituloprincipal:"",
   tareas:[]
  }

   funModal(){
       this.dialog.open(TareaRegisterComponent, {
          width: '500px',
          data: true,
          disableClose: true
        });
    }


  ngOnInit(): void {
    this.route.paramMap.subscribe(paramMap => {
      const id = paramMap.get('id');
      if (id) {
        this.findById(id);
      }
    });
  }

  findById(id:string){
    const key=enviroment.KEYSTORAGE;
    const token=this.secureService.getCode(key);
    if(token==""){
      return;
    }
    this.proyectoService.getById(id,token).subscribe((res)=>{
      this.proyectoTarea=res;
    })
  }

  CrearTarea(){
    this.funModal();
  }
}
