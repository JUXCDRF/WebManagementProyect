import { inject, Injectable } from '@angular/core';
import { enviroment } from '../../../../enviroments/constantes.develoment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IproyectoList } from '../modals/iproyecto-list';

@Injectable({
  providedIn: 'root'
})
export class ProyectoService {
  UriList=`${enviroment.URLBASE}api/Proyecto/Listar`

  private httpclient=inject(HttpClient);

  getLista():Observable<IproyectoList[]>{
    return this.httpclient.get<IproyectoList[]>(this.UriList)
  }
}
