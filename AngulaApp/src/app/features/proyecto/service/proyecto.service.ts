import { inject, Injectable } from '@angular/core';
import { enviroment } from '../../../../enviroments/constantes.develoment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IproyectoList } from '../modals/iproyecto-list';
import { Iproyectorequest } from '../modals/iproyecto-request';
import { Baseresponse } from '../../../shared/interface/baseresponse';

@Injectable({
  providedIn: 'root'
})
export class ProyectoService {
  private UriList=`${enviroment.URLBASE}api/Proyecto/Listar`
  private UriRegistrar=`${enviroment.URLBASE}api/Proyecto/Registrar`

  private httpclient=inject(HttpClient);

  getLista():Observable<IproyectoList[]>{
    return this.httpclient.get<IproyectoList[]>(this.UriList)
  }

  saveProyecto(IProyectoRequest:Iproyectorequest):Observable<Baseresponse>{
      return this.httpclient.post<Baseresponse>(this.UriRegistrar,IProyectoRequest);
    }

}
