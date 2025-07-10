import { Component, inject } from '@angular/core';
import { IproyectoList } from '../../modals/iproyecto-list';
import { ProyectoService } from '../../service/proyecto.service';
import { RouterLink, RouterOutlet } from '@angular/router';

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

  proyectoList:IproyectoList[]=[];
  private proyectoService=inject(ProyectoService);

  ngOnInit():void{
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
