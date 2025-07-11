import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProyectoService } from '../../service/proyecto.service';
import { enviroment } from '../../../../../enviroments/constantes.develoment';
import { SecurestorageService } from '../../../../shared/service/securestorage.service';
import { IproyectoTarea,ItareaList } from '../../modals/itarea-list';

@Component({
  selector: 'app-proyecto-tarea',
  imports: [],
  templateUrl: './proyecto-tarea.component.html',
  styleUrl: './proyecto-tarea.component.css'
})
export class ProyectoTareaComponent implements OnInit {
  constructor(private route:ActivatedRoute){
  }
  private proyectoService=inject(ProyectoService);
  private secureService=inject(SecurestorageService);

  proyectoTarea:IproyectoTarea={
   tituloprincipal:"",
   tareas:[]
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

  }
}
