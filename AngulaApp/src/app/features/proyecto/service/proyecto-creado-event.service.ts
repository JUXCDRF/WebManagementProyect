import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProyectoCreadoEventService {
  private proyectoCreado=new Subject<void>();

  proyectoCreado$=this.proyectoCreado.asObservable();

  NotificarProyectoCreado(){
    console.log('Notificando creación de proyecto');
    this.proyectoCreado.next();
  }
}
