import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TareaEventService {
private tareaNotificar=new Subject<void>();

  tareaNotificar$=this.tareaNotificar.asObservable();

  ObteneerListadoTarea(){
    this.tareaNotificar.next();
  }
}
